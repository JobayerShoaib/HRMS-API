using Application.Common.Models;
using Application.Features.Setups.Sections.Commands.Create;
using Application.Features.Setups.Sections.Commands.Update;
using Application.Features.Setups.Sections.Queries.QRM;
using Application.Repositories.Setup;
using Application.Services.Setup;

namespace Infrastructure.ImpServices.Setup
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }
        public async Task<Result> Create(SectionCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            Section entity = new()
            {
                SectionName = model.SectionName,
                SectionNameUC = model.SectionNameUC,
                SectionCode = model.SectionCode,
                SectionCodeUC = model.SectionCodeUC,
                IsActive = model.IsActive
            };
            await _sectionRepository.InsertAsync(entity, saveChanges, cancellationToken);
            return result.Success();
        }

        public async Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _sectionRepository.GetByIdAsync(id, cancellationToken);
            entity.IsDeleted = true;
            await _sectionRepository.UpdateAsync(entity, saveChanges, cancellationToken);

            return result.Update("Deleted Successfully");
        }

        public async Task<IList<SectionGetDataListRM>> GetDataList(CancellationToken cancellationToken = default)
        {
            return await _sectionRepository.GetDataList(cancellationToken);
        }

        public async Task<Result> Update(SectionUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _sectionRepository.GetByIdAsync(model.SectionID, cancellationToken);
            entity.SectionName = model.SectionName;
            entity.SectionNameUC = model.SectionNameUC;
            entity.SectionCode = model.SectionCode;
            entity.SectionCodeUC = model.SectionCodeUC;

            await _sectionRepository.UpdateAsync(entity, saveChanges, cancellationToken);
            return result.Update();
        }
    }
}
