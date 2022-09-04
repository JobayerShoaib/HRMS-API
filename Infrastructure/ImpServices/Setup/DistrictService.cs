using Application.Common.Models;
using Application.Features.Setups.Districts.Commands.Create;
using Application.Features.Setups.Districts.Commands.Update;
using Application.Features.Setups.Districts.Queries.QRM;
using Application.Repositories.Setup;
using Application.Services.Setup;

namespace Infrastructure.ImpServices.Setup
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }
        public async Task<Result> Create(DistrictCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            District entity = new()
            {
                DistrictName = model.DistrictName,
                DistrictNameUC = model.DistrictNameUC,
                DivisionID = model.DivisionID,
                IsActive = model.IsActive
            };
            await _districtRepository.InsertAsync(entity, saveChanges, cancellationToken);
            return result.Success();
        }

        public async Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _districtRepository.GetByIdAsync(id, cancellationToken);
            entity.IsDeleted = true;
            await _districtRepository.UpdateAsync(entity, saveChanges, cancellationToken);

            return result.Update("Deleted Successfully");
        }

        public async Task<IList<DistrictGetDataListRM>> GetDataList(CancellationToken cancellationToken = default)
        {
            return await _districtRepository.GetDataList(cancellationToken);
        }

        public async Task<Result> Update(DistrictUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _districtRepository.GetByIdAsync(model.DistrictID, cancellationToken);
            entity.DistrictName = model.DistrictName;
            entity.DistrictNameUC = model.DistrictNameUC;
            entity.DivisionID = model.DivisionID;

            await _districtRepository.UpdateAsync(entity, saveChanges, cancellationToken);
            return result.Update();
        }
    }
}
