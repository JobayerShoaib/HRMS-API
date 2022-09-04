using Application.Features.Setups.Divisions.Queries.QRM;

namespace Application.Repositories.Setup
{
    public interface IDivisionRepository : IGenericRepository<Division>
    {
        Task<IList<DivisionGetDataListRM>> GetDataList(CancellationToken cancellationToken);
    }
}
