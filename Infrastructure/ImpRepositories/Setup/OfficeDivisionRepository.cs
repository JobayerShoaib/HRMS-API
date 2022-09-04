using Application.Features.Setups.OfficeDivisions.Queries.QRM;
using Application.Repositories.Setup;

namespace Infrastructure.ImpRepositories.Setup
{
    public class OfficeDivisionRepository : GenericRepository<OfficeDivision>, IOfficeDivisionRepository
    {
        private readonly HRMDbContext _dbCon;

        public OfficeDivisionRepository(HRMDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<IList<OfficeDivisionGetDataListRM>> GetDataList(CancellationToken cancellationToken = default)
        {
            var data = await _dbCon.OfficeDivision.Where(x=>x.IsActive==true && x.IsDeleted==false)
                .Select(r=>new OfficeDivisionGetDataListRM { 
                    OfficeDivisionID = r.OfficeDivisionID,
                    OfficeDivisionName = r.OfficeDivisionName,
                    OfficeDivisionNameUC = r.OfficeDivisionNameUC,
                    OfficeDivisionCode = r.OfficeDivisionCode,
                    OfficeDivisionCodeUC = r.OfficeDivisionCodeUC,
                    OfficeDivisionColor = r.OfficeDivisionColor,
                    EstablishedDate = r.EstablishedDate
                }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
