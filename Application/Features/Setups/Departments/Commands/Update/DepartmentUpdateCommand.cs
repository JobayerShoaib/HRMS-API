using Application.Services.Setup;

namespace Application.Features.Setups.Departments.Commands.Update
{
    public class DepartmentUpdateCommand:IRequest<Result>
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameUC { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentCodeUC { get; set; }
    }
    public class DepartmentUpdateCommandHandler : IRequestHandler<DepartmentUpdateCommand, Result>
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentUpdateCommandHandler(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<Result> Handle(DepartmentUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _departmentService.Update(request, true, cancellationToken);
        }
    }
}
