using Application.Common.Models;
using Application.Features.Setups.OfficeLevels.Commands.Create;
using Application.Features.Setups.OfficeLevels.Commands.Update;
using Application.Features.Setups.OfficeLevels.Queries.QRM;
using Application.Repositories.Setup;
using Application.Services.Setup;

namespace Infrastructure.ImpServices.Setup
{
    public class OfficeLevelService : IOfficeLevelService
    {
        private readonly IOfficeLevelRepository _officeLevelRepository;

        public OfficeLevelService(IOfficeLevelRepository officeLevelRepository)
        {
            _officeLevelRepository = officeLevelRepository;
        }
        public async Task<Result> Create(OfficeLevelCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            OfficeLevel entity = new()
            {
                OfficeLevelName = model.OfficeLevelName,
                LevelOrderNo = model.LevelOrderNo,
                CompanyID = model.CompanyID,
                IsEditable= model.IsEditable,
                IsActive = model.IsActive
            };
            await _officeLevelRepository.InsertAsync(entity, saveChanges, cancellationToken);
            return result.Success();
        }

        public async Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _officeLevelRepository.GetByIdAsync(id, cancellationToken);
            entity.IsDeleted = true;
            await _officeLevelRepository.UpdateAsync(entity, saveChanges, cancellationToken);

            return result.Update("Deleted Successfully");
        }

        public async Task<IList<OfficeLevelGetDataListRM>> GetDataList(CancellationToken cancellationToken = default)
        {
            return await _officeLevelRepository.GetDataList(cancellationToken);
        }

        public async Task<Result> Update(OfficeLevelUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _officeLevelRepository.GetByIdAsync(model.OfficeLevelID, cancellationToken);
            entity.OfficeLevelName = model.OfficeLevelName;
            entity.LevelOrderNo = model.LevelOrderNo;
            entity.CompanyID = model.CompanyID;
            entity.IsEditable= model.IsEditable;

            await _officeLevelRepository.UpdateAsync(entity, saveChanges, cancellationToken);
            return result.Update();
        }
    }
}
