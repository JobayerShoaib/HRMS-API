using Application.Services.Setup;

namespace Application.Features.Setups.Departments.Commands.Create
{
    public class DepartmentCreateCommand:IRequest<Result>
    {
        public string DepartmentName { get; set; }
        public string DepartmentNameUC { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentCodeUC { get; set; }
        public bool IsActive { get; set; }
    }
    public class DepartmentCreateCommandHandler : IRequestHandler<DepartmentCreateCommand, Result>
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentCreateCommandHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<Result> Handle(DepartmentCreateCommand request, CancellationToken cancellationToken)
        {
            return await _departmentService.Create(request,true,cancellationToken);
        }
    }
}
