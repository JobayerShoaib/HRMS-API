using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setup
{
    public class DesignationConfig : IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> builder)
        {
            builder.HasKey(b => b.DesignationID);
            builder.ToTable("Designation", "setup");
        }
    }
}
