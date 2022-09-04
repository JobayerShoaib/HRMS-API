using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setup
{
    public class OfficeDivisionConfig : IEntityTypeConfiguration<OfficeDivision>
    {
        public void Configure(EntityTypeBuilder<OfficeDivision> builder)
        {
            builder.HasKey(b => b.OfficeDivisionID);
            builder.ToTable("OfficeDivision", "setup");
        }
    }
}
