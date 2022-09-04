using Application.Features.Setups.Divisions.Queries.QRM;
using Application.Repositories.Setup;

namespace Infrastructure.ImpRepositories.Setup
{
    public class DivisionRepository : GenericRepository<Division>, IDivisionRepository
    {
        private readonly HRMDbContext _dbCon;

        public DivisionRepository(HRMDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<IList<DivisionGetDataListRM>> GetDataList(CancellationToken cancellationToken)
        {
            var data = await (from d in _dbCon.Division
                              join c in _dbCon.Country on d.CountryID equals c.CountryID
                              where d.IsActive == true && d.IsDeleted == false
                              select new DivisionGetDataListRM
                              {
                                  CountryID = c.CountryID,
                                  CountryName = c.CountryName,
                                  DivisionID = d.DivisionID,
                                  DivisionName = d.DivisionName,
                                  DivisionNameUC = d.DivisionNameUC
                              }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
