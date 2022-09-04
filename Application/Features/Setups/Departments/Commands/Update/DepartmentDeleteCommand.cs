using Application.Services.Setup;

namespace Application.Features.Setups.Departments.Commands.Update
{
    public class DepartmentDeleteCommand : IRequest<Result>
    {
        public int DepartmentID { get; set; }
    }
    public class DepartmentDeleteCommandHandler : IRequestHandler<DepartmentDeleteCommand, Result>
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentDeleteCommandHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<Result> Handle(DepartmentDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _departmentService.Delete(request.DepartmentID,true,cancellationToken);
        }
    }
}
