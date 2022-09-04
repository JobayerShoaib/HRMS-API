using Domain.Entities.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Setup
{
    public class CompanyTypeConfig : IEntityTypeConfiguration<CompanyType>
    {
        public void Configure(EntityTypeBuilder<CompanyType> builder)
        {
            builder.HasKey(b => b.CompanyTypeID);
            builder.ToTable("CompanyType", "setup");
        }
    }
}

