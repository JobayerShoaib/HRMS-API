using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setup
{
    public class ThanaConfig : IEntityTypeConfiguration<Thana>
    {
        public void Configure(EntityTypeBuilder<Thana> builder)
        {
            builder.HasKey(b => b.ThanaID);
            builder.ToTable("Thana", "setup");
        }
    }
}
