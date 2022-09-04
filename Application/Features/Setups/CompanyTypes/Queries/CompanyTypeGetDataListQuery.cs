using Application.Features.Setups.CompanyTypes.Queries.QRM;
using Application.Services.Setup;
using MediatR;

namespace Application.Features.Setups.CompanyTypes.Queries
{
    public class CompanyTypeGetDataListQuery : IRequest<IList<CompanyTypeGetDataListRM>>
    {
    }
    public class CompanyTypeGetDataListQueryHandler : IRequestHandler<CompanyTypeGetDataListQuery, IList<CompanyTypeGetDataListRM>>
    {
        private readonly ICompanyTypeService _companyTypeService;

        public CompanyTypeGetDataListQueryHandler(ICompanyTypeService companyTypeService)
        {
            _companyTypeService = companyTypeService;
        }
        public async Task<IList<CompanyTypeGetDataListRM>> Handle(CompanyTypeGetDataListQuery request, CancellationToken cancellationToken)
        {
            return await _companyTypeService.GetDataList(cancellationToken);
        }
    }
}
