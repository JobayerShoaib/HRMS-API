using Application.Features.Setups.OfficeLevels.Commands.Create;
using Application.Features.Setups.OfficeLevels.Commands.Update;
using Application.Features.Setups.OfficeLevels.Queries.QRM;

namespace Application.Services.Setup
{
    public interface IOfficeLevelService
    {
        Task<Result> Create(OfficeLevelCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Update(OfficeLevelUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<IList<OfficeLevelGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
    }
}
