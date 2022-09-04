using Application.Common.Models;
using Application.Services.Setup;
using MediatR;

namespace Application.Features.Setups.CompanyTypes.Commands.Update
{
    public class CompanyTypeDeleteCommand : IRequest<Result>
    {
        public int CompanyTypeID { get; set; }
    }
    public class CompanyTypeDeleteCommandHandler : IRequestHandler<CompanyTypeDeleteCommand, Result>
    {
        private readonly ICompanyTypeService _companyTypeService;

        public CompanyTypeDeleteCommandHandler(ICompanyTypeService companyTypeService)
        {
            _companyTypeService = companyTypeService;
        }
        public async Task<Result> Handle(CompanyTypeDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _companyTypeService.Delete(request.CompanyTypeID, true, cancellationToken);
        }
    }
}
