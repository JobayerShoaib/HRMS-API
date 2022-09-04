using Application.Features.Setups.Departments.Queries.QRM;

namespace Application.Repositories.Setup
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<IList<DepartmentGetDataListRM>> GetDataList(CancellationToken cancellationToken);
    }
}
