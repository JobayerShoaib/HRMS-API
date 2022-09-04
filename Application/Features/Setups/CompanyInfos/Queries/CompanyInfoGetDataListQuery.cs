using Application.Features.Setups.CompanyInfos.Queries.QRM;
using Application.Services.Setup;
using MediatR;

namespace Application.Features.Setups.CompanyInfos.Queries
{
    public class CompanyInfoGetDataListQuery : IRequest<IList<CompanyInfoGetDataListRM>>
    {
    }
    public class CompanyInfoGetDataListQueryHandler : IRequestHandler<CompanyInfoGetDataListQuery, IList<CompanyInfoGetDataListRM>>
    {
        private readonly ICompanyInfoService _companyInfoService;

        public CompanyInfoGetDataListQueryHandler(ICompanyInfoService companyInfoService)
        {
            _companyInfoService = companyInfoService;
        }
        public async Task<IList<CompanyInfoGetDataListRM>> Handle(CompanyInfoGetDataListQuery request, CancellationToken cancellationToken)
        {
            return await _companyInfoService.GetDataList(cancellationToken);
        }
    }
}
