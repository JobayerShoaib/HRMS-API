using Application.Features.Setups.CompanyTypes.Queries.QRM;
using Application.Repositories.Setup;
using Domain.Entities.Setup;

namespace Infrastructure.ImpRepositories.Setup
{
    public class CompanyTypeRepository : GenericRepository<CompanyType>, ICompanyTypeRepository
    {
        private readonly HRMDbContext _dbCon;

        public CompanyTypeRepository(HRMDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<IList<CompanyTypeGetDataListRM>> GetDataList(CancellationToken cancellationToken = default)
        {
            var dataList = await _dbCon.CompanyType
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .Select(x => new CompanyTypeGetDataListRM
                {
                    CompanyTypeID = x.CompanyTypeID,
                    CompanyTypeName = x.CompanyTypeName
                }).ToListAsync(cancellationToken);
            return dataList;
        }
    }
}
