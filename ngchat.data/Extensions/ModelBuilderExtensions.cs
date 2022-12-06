using Microsoft.EntityFrameworkCore;
using ngchat.data.Entities;

namespace ngchat.data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var userId = new Guid("1b60fd43-a1b5-4214-9ccc-d239f0f4c97b");
            var roleId = new Guid("1b60fd43-a1b5-4214-9ccc-d239f0f4c97c");

            modelBuilder.Entity<SysAppRole>().HasData(
                new SysAppRole()
                {
                    Id = roleId,
                    Name = "ADMIN",
                    Description = "Administration role",
                    CreatedDate = DateTime.Now,
                    CreatedTime = DateTime.Now,
                    CreatedBy = null,
                    ModifiedBy = null,
                    ModifiedDate = DateTime.Now,
                    ModifiedTime = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    DeletedBy = null
                });

            modelBuilder.Entity<SysAppUser>().HasData(
                new SysAppUser()
                {
                    Id = userId,
                    Username = "root",
                    Email = "root@gmail.com",
                    FirstName = "root",
                    LastName = "",
                    FullName = "root",
                    Gender = 0,
                    RoleId = roleId,
                    Password = "$2a$12$WWgvNkyp.9Yr2dWS1mv.f.k/jqoAoxzrwzup9BZviJYryA7SnKgDy", // Password is Abc123!@#
                    IsActive = true,
                    IsDeleted = false,
                    JoinedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    CreatedTime = DateTime.Now,
                }
                );


        }
    }
}
