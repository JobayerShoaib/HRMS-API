using Application.Common.Models;
using Application.Features.Setups.Districts.Commands.Create;
using Application.Features.Setups.Districts.Commands.Update;
using Application.Features.Setups.Districts.Queries.QRM;

namespace Application.Services.Setup
{
    public interface IDistrictService
    {
        Task<Result> Create(DistrictCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Update(DistrictUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<IList<DistrictGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
    }
}
