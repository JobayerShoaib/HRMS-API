using Application.Features.Setups.OfficeLevels.Queries.QRM;

namespace Application.Repositories.Setup
{
    public interface IOfficeLevelRepository:IGenericRepository<OfficeLevel>
    {
        Task<IList<OfficeLevelGetDataListRM>> GetDataList(CancellationToken cancellationToken);
    }
}
