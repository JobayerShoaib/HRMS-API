using Application.Features.Setups.CompanyInfos.Queries.QRM;
using Application.Repositories.Setup;
using Domain.Entities.Setup;


namespace Infrastructure.ImpRepositories.Setup
{
    public class CompanyInfoRepository : GenericRepository<CompanyInfo>, ICompanyInfoRepository
    {
        private readonly HRMDbContext _dbCon;

        public CompanyInfoRepository(HRMDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<IList<CompanyInfoGetDataListRM>> GetDataList(CancellationToken cancellationToken = default)
        {
            var data = await (from ci in _dbCon.CompanyInfo
                              join ct in _dbCon.CompanyType on ci.CompanyTypeID equals ct.CompanyTypeID
                              where ci.IsActive == true && ci.IsDeleted == false
                              select new CompanyInfoGetDataListRM
                              {
                                  CompanyID = ci.CompanyID,
                                  CompanyName = ci.CompanyName,
                                  CompanyNameUC = ci.CompanyNameUC,
                                  CompanyShortName = ci.CompanyShortName,
                                  CompanyShortNameUC = ci.CompanyShortNameUC,
                                  EstablishedDate = ci.EstablishedDate,
                                  CompanyTypeID = ci.CompanyTypeID,
                                  CompanyTypeName = ct.CompanyTypeName,
                                  CompanyAddress = ci.CompanyAddress
                              }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
