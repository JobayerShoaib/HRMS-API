using Application.Features.Setups.Countries.Queries.QRM;
using Application.Repositories.Setup;
using Domain.Entities.Setup;

namespace Infrastructure.ImpRepositories.Setup
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly HRMDbContext _dbCon;

        public CountryRepository(HRMDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<IList<CountryGetDataListRM>> GetDataList(CancellationToken cancellationToken)
        {
            var data = await _dbCon.Country
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .Select(x => new CountryGetDataListRM
                {
                    CountryID = x.CountryID,
                    CountryName = x.CountryName,
                    CountryNameUC = x.CountryNameUC,
                    CountryShortCode = x.CountryShortCode,
                    IsDefault = x.IsDefault
                }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
