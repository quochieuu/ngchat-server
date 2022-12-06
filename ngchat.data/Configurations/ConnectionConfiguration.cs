using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ngchat.data.Entities;

namespace ngchat.data.Configurations
{
    public class ConnectionConfiguration : IEntityTypeConfiguration<Connections>
    {
        public void Configure(EntityTypeBuilder<Connections> builder)
        {
            builder.ToTable("Connections");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SignalrId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
