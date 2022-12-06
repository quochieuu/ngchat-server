using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ngchat.data.Entities;

namespace ngchat.data.Configurations
{
    public class SysAppUserConfiguration : IEntityTypeConfiguration<SysAppUser>
    {
        public void Configure(EntityTypeBuilder<SysAppUser> builder)
        {
            builder.ToTable("SysAppUsers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired();
        }
    }
}
