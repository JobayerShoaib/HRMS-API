using Application.Features.Setups.OfficeDivisions.Commands.Create;
using Application.Features.Setups.OfficeDivisions.Commands.Update;
using Application.Features.Setups.OfficeDivisions.Queries.QRM;

namespace Application.Services.Setup
{
    public interface IOfficeDivisionService
    {
        Task<Result> Create(OfficeDivisionCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Update(OfficeDivisionUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<IList<OfficeDivisionGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
    }
}
