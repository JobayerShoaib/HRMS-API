using Application.Features.Setups.Sections.Queries.QRM;

namespace Application.Repositories.Setup
{
    public interface ISectionRepository : IGenericRepository<Section>
    {
        Task<IList<SectionGetDataListRM>> GetDataList(CancellationToken cancellationToken);
    }
}
