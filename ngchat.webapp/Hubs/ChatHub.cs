using Microsoft.AspNetCore.SignalR;
using ngchat.data.EF;
using ngchat.data.Entities;
using ngchat.data.ViewModels.Chat;
using System;
using System.Security.Claims;

namespace ngchat.webapp.Hubs
{
    public class ChatHub : Hub
    {
        private readonly DataDbContext _context;
        public ChatHub(DataDbContext context)
        {
            _context = context;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Guid currUserId = _context.Connections.Where(c => c.SignalrId == Context.ConnectionId).Select(c => c.UserId).SingleOrDefault();
            _context.Connections.RemoveRange(_context.Connections.Where(p => p.UserId == currUserId).ToList());
            _context.SaveChanges();
            Clients.Others.SendAsync("userOff", currUserId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task authMe(PersonInfo personInfo)
        {
            string currSignalrID = Context.ConnectionId;
            SysAppUser tempPerson = _context.SysAppUsers.Where(p => p.Username == personInfo.userName && p.Password == personInfo.password)
                .SingleOrDefault();

            if (tempPerson != null) //if credentials are correct
            {
                Console.WriteLine("\n" + tempPerson.FullName + " logged in" + "\nSignalrID: " + currSignalrID);

                Connections currUser = new Connections
                {
                    UserId = tempPerson.Id,
                    SignalrId = currSignalrID,
                    TimeStamp = DateTime.Now
                };
                await _context.Connections.AddAsync(currUser);
                await _context.SaveChangesAsync();

                User newUser = new User(tempPerson.Id, tempPerson.FullName, currSignalrID);
                await Clients.Caller.SendAsync("authMeResponseSuccess", newUser);
                await Clients.Others.SendAsync("userOn", newUser);
            }

            else //if credentials are incorrect
            {
                await Clients.Caller.SendAsync("authMeResponseFail");
            }
        }


        public async Task reauthMe(Guid personId)
        {
            string currSignalrID = Context.ConnectionId;
            SysAppUser tempPerson = _context.SysAppUsers.Where(p => p.Id == personId)
                .SingleOrDefault();

            if (tempPerson != null) //if credentials are correct
            {
                Console.WriteLine("\n" + tempPerson.FullName + " logged in" + "\nSignalrID: " + currSignalrID);

                Connections currUser = new Connections
                {
                    UserId = tempPerson.Id,
                    SignalrId = currSignalrID,
                    TimeStamp = DateTime.Now
                };
                await _context.Connections.AddAsync(currUser);
                await _context.SaveChangesAsync();

                User newUser = new User(tempPerson.Id, tempPerson.FullName, currSignalrID);
                await Clients.Caller.SendAsync("reauthMeResponse", newUser);
                await Clients.Others.SendAsync("userOn", newUser);
            }
        }

        public void logOut(Guid personId)
        {
            _context.Connections.RemoveRange(_context.Connections.Where(p => p.UserId == personId).ToList());
            _context.SaveChanges();
            Clients.Caller.SendAsync("logoutResponse");
            Clients.Others.SendAsync("userOff", personId);
        }

        public async Task getOnlineUsers()
        {
            Guid currUserId = _context.Connections.Where(c => c.SignalrId == Context.ConnectionId).Select(c => c.UserId).SingleOrDefault();
            List<User> onlineUsers = _context.Connections
                .Where(c => c.UserId != currUserId)
                .Select(c =>
                    new User(c.UserId, _context.SysAppUsers.Where(p => p.Id == c.UserId).Select(p => p.FullName).SingleOrDefault(), c.SignalrId)
                ).ToList();
            await Clients.Caller.SendAsync("getOnlineUsersResponse", onlineUsers);
        }


        public async Task sendMsg(string connId, string msg)
        {
            await Clients.Client(connId).SendAsync("sendMsgResponse", Context.ConnectionId, msg);
        }

    }
}
