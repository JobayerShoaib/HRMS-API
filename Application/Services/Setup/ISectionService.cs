using Application.Features.Setups.Sections.Commands.Create;
using Application.Features.Setups.Sections.Commands.Update;
using Application.Features.Setups.Sections.Queries.QRM;

namespace Application.Services.Setup
{
    public interface ISectionService
    {
        Task<Result> Create(SectionCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Update(SectionUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<IList<SectionGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
    }
}
