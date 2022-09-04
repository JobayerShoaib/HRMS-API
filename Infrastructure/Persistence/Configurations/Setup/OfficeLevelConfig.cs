using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setup
{
    public class OfficeLevelConfig : IEntityTypeConfiguration<OfficeLevel>
    {
        public void Configure(EntityTypeBuilder<OfficeLevel> builder)
        {
            builder.HasKey(b => b.OfficeLevelID);
            builder.ToTable("OfficeLevel", "setup");
        }
    }
}
