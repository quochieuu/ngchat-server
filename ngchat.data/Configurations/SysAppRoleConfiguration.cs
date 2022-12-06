using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ngchat.data.Entities;

namespace ngchat.data.Configurations
{
    public class SysAppRoleConfiguration : IEntityTypeConfiguration<SysAppRole>
    {
        public void Configure(EntityTypeBuilder<SysAppRole> builder)
        {
            builder.ToTable("SysAppRoles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
