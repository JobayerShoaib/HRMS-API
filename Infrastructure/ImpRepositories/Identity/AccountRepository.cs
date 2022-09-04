using Application.IdentityEntities;
using Application.Repositories.Identity;

namespace Infrastructure.ImpRepositories.Identity
{
    public class AccountRepository : GenericRepository<ApplicationUser>, IAccountRepository
    {
        private readonly HRMDbContext _dbCon;
        public AccountRepository(HRMDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
    }
}
