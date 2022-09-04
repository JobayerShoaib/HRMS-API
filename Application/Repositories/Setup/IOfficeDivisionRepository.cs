using Application.Features.Setups.OfficeDivisions.Queries.QRM;

namespace Application.Repositories.Setup
{
    public interface IOfficeDivisionRepository : IGenericRepository<OfficeDivision>
    {
        Task<IList<OfficeDivisionGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
    }
}
