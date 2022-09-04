using Application.Features.Setups.Departments.Queries.QRM;
using Application.Services.Setup;

namespace Application.Features.Setups.Departments.Queries
{
    public class DepartmentGetDataListQuery : IRequest<IList<DepartmentGetDataListRM>>
    {
    }
    public class DepartmentGetDataListQueryHandler : IRequestHandler<DepartmentGetDataListQuery, IList<DepartmentGetDataListRM>>
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentGetDataListQueryHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IList<DepartmentGetDataListRM>> Handle(DepartmentGetDataListQuery request, CancellationToken cancellationToken)
        {
            return await _departmentService.GetDataList(cancellationToken);
        }
    }
}
