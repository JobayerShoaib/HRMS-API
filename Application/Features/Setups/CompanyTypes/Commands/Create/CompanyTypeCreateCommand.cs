using Application.Common.Models;
using Application.Services.Setup;
using MediatR;

namespace Application.Features.Setups.CompanyTypes.Commands.Create
{
    public class CompanyTypeCreateCommand : IRequest<Result>
    {
        public int CompanyTypeID { get; set; }
        public string CompanyTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public class CompanyTypeCreateCommandHandler : IRequestHandler<CompanyTypeCreateCommand, Result>
    {
        private readonly ICompanyTypeService _companyTypeService;

        public CompanyTypeCreateCommandHandler(ICompanyTypeService companyTypeService)
        {
            _companyTypeService = companyTypeService;
        }
        public async Task<Result> Handle(CompanyTypeCreateCommand request, CancellationToken cancellationToken)
        {
            return await _companyTypeService.Create(request, true, cancellationToken);
        }
    }
}
