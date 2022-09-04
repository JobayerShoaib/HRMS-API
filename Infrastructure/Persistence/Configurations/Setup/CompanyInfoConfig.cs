using Domain.Entities.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setup
{
    public class CompanyInfoConfig : IEntityTypeConfiguration<CompanyInfo>
    {
        public void Configure(EntityTypeBuilder<CompanyInfo> builder)
        {
            builder.HasKey(b => b.CompanyID);
            builder.ToTable("CompanyInfo", "setup");
        }
    }
}