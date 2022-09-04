using Application.Common.Models;
using Application.Features.Setups.CompanyTypes.Commands.Create;
using Application.Features.Setups.CompanyTypes.Commands.Update;
using Application.Features.Setups.CompanyTypes.Queries.QRM;
using Application.Repositories.Setup;
using Application.Services.Setup;
using Domain.Entities.Setup;

namespace Infrastructure.ImpServices.Setup
{
    public class CompanyTypeService : ICompanyTypeService
    {
        private readonly ICompanyTypeRepository _companyTypeRepository;

        public CompanyTypeService(ICompanyTypeRepository companyTypeRepository)
        {
            _companyTypeRepository = companyTypeRepository;
        }
        public async Task<Result> Create(CompanyTypeCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            CompanyType entity = new()
            {
                CompanyTypeName = model.CompanyTypeName,
                IsActive = model.IsActive
            };
            await _companyTypeRepository.InsertAsync(entity, saveChanges, cancellationToken);
            return result.Success();
        }

        public async Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _companyTypeRepository.GetByIdAsync(id, cancellationToken);
            entity.IsDeleted = true;
            await _companyTypeRepository.UpdateAsync(entity, saveChanges, cancellationToken);

            return result.Update("Deleted Successfully");
        }

        public async Task<IList<CompanyTypeGetDataListRM>> GetDataList(CancellationToken cancellationToken = default)
        {
            return await _companyTypeRepository.GetDataList(cancellationToken);
        }

        public async Task<Result> Update(CompanyTypeUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _companyTypeRepository.GetByIdAsync(model.CompanyTypeID);
            entity.CompanyTypeName = model.CompanyTypeName;
            await _companyTypeRepository.UpdateAsync(entity, saveChanges, cancellationToken);
            return result.Update();
        }
    }
}
