using Application.Features.Setups.Departments.Commands.Create;
using Application.Features.Setups.Departments.Commands.Update;
using Application.Features.Setups.Departments.Queries.QRM;

namespace Application.Services.Setup
{
    public interface IDepartmentService
    {
        Task<Result> Create(DepartmentCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Update(DepartmentUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<IList<DepartmentGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
    }
}
