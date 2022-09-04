using Application.Features.Setups.Sections.Queries.QRM;
using Application.Repositories.Setup;

namespace Infrastructure.ImpRepositories.Setup
{
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        private readonly HRMDbContext _dbCon;
        public SectionRepository(HRMDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<IList<SectionGetDataListRM>> GetDataList(CancellationToken cancellationToken)
        {
            var data = await _dbCon.Section.Where(x => x.IsActive == true && x.IsDeleted == false)
                .Select(x => new SectionGetDataListRM
                {
                    SectionID = x.SectionID,
                    SectionName = x.SectionName,
                    SectionNameUC = x.SectionNameUC,
                    SectionCode = x.SectionCode,
                    SectionCodeUC = x.SectionCodeUC
                }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
