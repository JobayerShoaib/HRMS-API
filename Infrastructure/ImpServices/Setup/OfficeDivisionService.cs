using Application.Common.Models;
using Application.Features.Setups.OfficeDivisions.Commands.Create;
using Application.Features.Setups.OfficeDivisions.Commands.Update;
using Application.Features.Setups.OfficeDivisions.Queries.QRM;
using Application.Repositories.Setup;
using Application.Services.Setup;

namespace Infrastructure.ImpServices.Setup
{
    public class OfficeDivisionService : IOfficeDivisionService
    {
        private readonly IOfficeDivisionRepository _officeDivisionRepository;

        public OfficeDivisionService(IOfficeDivisionRepository officeDivisionRepository)
        {
            _officeDivisionRepository = officeDivisionRepository;
        }
        public async Task<Result> Create(OfficeDivisionCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            OfficeDivision entity = new()
            {
                OfficeDivisionName = model.OfficeDivisionName,
                OfficeDivisionNameUC = model.OfficeDivisionNameUC,
                OfficeDivisionCode = model.OfficeDivisionCode,
                OfficeDivisionCodeUC = model.OfficeDivisionCodeUC,
                OfficeDivisionColor = model.OfficeDivisionColor,
                EstablishedDate = model.EstablishedDate,
                IsActive = model.IsActive
            };
            await _officeDivisionRepository.InsertAsync(entity, saveChanges, cancellationToken);
            return result.Success();
        }

        public async Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _officeDivisionRepository.GetByIdAsync(id, cancellationToken);
            entity.IsDeleted = true;
            await _officeDivisionRepository.UpdateAsync(entity, saveChanges, cancellationToken);

            return result.Update("Deleted Successfully");
        }

        public async Task<IList<OfficeDivisionGetDataListRM>> GetDataList(CancellationToken cancellationToken = default)
        {
            return await _officeDivisionRepository.GetDataList(cancellationToken);
        }

        public async Task<Result> Update(OfficeDivisionUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _officeDivisionRepository.GetByIdAsync(model.OfficeDivisionID, cancellationToken);
            entity.OfficeDivisionName = model.OfficeDivisionName;
            entity.OfficeDivisionNameUC = model.OfficeDivisionNameUC;
            entity.OfficeDivisionCode = model.OfficeDivisionCode;
            entity.OfficeDivisionCodeUC = model.OfficeDivisionCodeUC;
            entity.EstablishedDate = model.EstablishedDate;

            await _officeDivisionRepository.UpdateAsync(entity, saveChanges, cancellationToken);
            return result.Update();
        }
    }
}
