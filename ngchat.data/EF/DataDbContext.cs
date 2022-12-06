using Microsoft.EntityFrameworkCore;
using ngchat.data.Configurations;
using ngchat.data.Entities;
using ngchat.data.Extensions;

namespace ngchat.data.EF
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        public DataDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new ConnectionConfiguration());

            modelBuilder.ApplyConfiguration(new SysAppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new SysAppUserConfiguration());


            //Data seeding
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Connections> Connections { get; set; }
        public DbSet<SysAppUser> SysAppUsers { get; set; }
        public DbSet<SysAppRole> SysAppRoles { get; set; }
    }
}
