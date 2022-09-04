using Application.Repositories.Identity;
using Domain.Common;

namespace Infrastructure.ImpRepositories.Identity
{
    public class AuditSecretsRepository : GenericRepository<AuditSecrets>, IAuditSecretsRepository
    {
        private readonly HRMDbContext _dbCon;

        public AuditSecretsRepository(HRMDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

    }
}
