﻿namespace ngchat.data.ViewModels.Chat
{
    public class PersonInfo
    {
        public string userName { get; set; }
        public string password { get; set; }
    }


    //4Tutorial
    public class User
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string connId { get; set; } //signalrId

        public User(Guid someId, string someName, string someConnId)
        {
            id = someId;
            name = someName;
            connId = someConnId;
        }
    }
}
