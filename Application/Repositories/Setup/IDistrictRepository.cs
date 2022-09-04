using Application.Features.Setups.Districts.Queries.QRM;


namespace Application.Repositories.Setup
{
    public interface IDistrictRepository : IGenericRepository<District>
    {
        Task<IList<DistrictGetDataListRM>> GetDataList(CancellationToken cancellationToken);
    }
}
