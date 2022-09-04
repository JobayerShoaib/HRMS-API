using Application.Services.Setup;

namespace Application.Features.Setups.CompanyInfos.Commands.Update
{
    public class CompanyInfoDeleteCommand : IRequest<Result>
    {
        public int CompanyID { get; set; }
    }
    public class CompanyInfoDeleteCommandHandler : IRequestHandler<CompanyInfoDeleteCommand, Result>
    {
        private readonly ICompanyInfoService _companyInfoService;

        public CompanyInfoDeleteCommandHandler(ICompanyInfoService companyInfoService)
        {
            _companyInfoService = companyInfoService;
        }
        public async Task<Result> Handle(CompanyInfoDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _companyInfoService.Delete(request.CompanyID, true, cancellationToken);
        }
    }
}

