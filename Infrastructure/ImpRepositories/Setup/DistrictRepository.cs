using Application.Features.Setups.Districts.Queries.QRM;
using Application.Repositories.Setup;


namespace Infrastructure.ImpRepositories.Setup
{
    public class DistrictRepository : GenericRepository<District>, IDistrictRepository
    {
        private readonly HRMDbContext _dbCon;
        public DistrictRepository(HRMDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<IList<DistrictGetDataListRM>> GetDataList(CancellationToken cancellationToken)
        {
            var data = await (from dd in _dbCon.District
                              join d in _dbCon.Division on dd.DivisionID equals d.DivisionID
                              join c in _dbCon.Country on d.CountryID equals c.CountryID
                              where dd.IsActive == true && dd.IsDeleted == false
                              select new DistrictGetDataListRM
                              {
                                  CountryID = c.CountryID,
                                  CountryName = c.CountryName,
                                  DivisionID = d.DivisionID,
                                  DivisionName = d.DivisionName,
                                  DistrictID = d.DivisionID,
                                  DistrictName = d.DivisionName,
                                  DistrictNameUC = d.DivisionNameUC
                              }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
