using Domain.Entities.Setup;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public interface IHRMDbContext
    {
        public DbSet<CompanyType> CompanyType { get; set; }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<District> District { get; set; }
        Task<int> SaveChangesAsync(string? UserId = null, CancellationToken cancellationToken = default);
    }
}
