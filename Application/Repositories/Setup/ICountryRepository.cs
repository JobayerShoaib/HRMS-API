using Application.Features.Setups.Countries.Queries.QRM;

namespace Application.Repositories.Setup
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<IList<CountryGetDataListRM>> GetDataList(CancellationToken cancellationToken);
    }
}
