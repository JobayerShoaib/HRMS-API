using Application.Features.Setups.OfficeLevels.Queries.QRM;
using Application.Repositories.Setup;

namespace Infrastructure.ImpRepositories.Setup
{
    public class OfficeLevelRepository : GenericRepository<OfficeLevel>, IOfficeLevelRepository
    {
        private readonly HRMDbContext _dbCon;
        public OfficeLevelRepository(HRMDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<IList<OfficeLevelGetDataListRM>> GetDataList(CancellationToken cancellationToken)
        {
            var data = await (from ol in _dbCon.OfficeLevel                              
                              join c in _dbCon.CompanyInfo on ol.CompanyID equals c.CompanyID
                              where ol.IsActive == true && ol.IsDeleted == false
                              select new OfficeLevelGetDataListRM
                              {
                                  CompanyID = ol.CompanyID,
                                  LevelOrderNo = ol.LevelOrderNo,
                                  OfficeLevelID = ol.OfficeLevelID,
                                  OfficeLevelName= ol.OfficeLevelName,
                                  CompanyName=c.CompanyName
                              }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
