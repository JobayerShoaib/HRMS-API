using Application.Common.Models;
using Application.Features.Setups.Divisions.Commands.Create;
using Application.Features.Setups.Divisions.Commands.Update;
using Application.Features.Setups.Divisions.Queries.QRM;

namespace Application.Services.Setup
{
    public interface IDivisionService
    {
        Task<Result> Create(DivisionCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Update(DivisionUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<IList<DivisionGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
    }
}
