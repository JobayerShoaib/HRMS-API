using Application.Common.Models;
using Application.Features.Setups.Departments.Commands.Create;
using Application.Features.Setups.Departments.Commands.Update;
using Application.Features.Setups.Departments.Queries.QRM;
using Application.Repositories.Setup;
using Application.Services.Setup;

namespace Infrastructure.ImpServices.Setup
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<Result> Create(DepartmentCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            Department entity = new()
            {
                DepartmentName = model.DepartmentName,
                DepartmentNameUC = model.DepartmentNameUC,
                DepartmentCode = model.DepartmentCode,
                DepartmentCodeUC = model.DepartmentCodeUC,               
                IsActive = model.IsActive
            };
            await _departmentRepository.InsertAsync(entity, saveChanges, cancellationToken);
            return result.Success();
        }

        public async Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _departmentRepository.GetByIdAsync(id, cancellationToken);
            entity.IsDeleted = true;
            await _departmentRepository.UpdateAsync(entity, saveChanges, cancellationToken);

            return result.Update("Deleted Successfully");
        }

        public async Task<IList<DepartmentGetDataListRM>> GetDataList(CancellationToken cancellationToken = default)
        {
            return await _departmentRepository.GetDataList(cancellationToken);
        }

        public async Task<Result> Update(DepartmentUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _departmentRepository.GetByIdAsync(model.DepartmentID, cancellationToken);
            entity.DepartmentName = model.DepartmentName;
            entity.DepartmentNameUC = model.DepartmentNameUC;
            entity.DepartmentCode = model.DepartmentCode;
            entity.DepartmentCodeUC = model.DepartmentCodeUC;

            await _departmentRepository.UpdateAsync(entity, saveChanges, cancellationToken);
            return result.Update();
        }
    }
}
