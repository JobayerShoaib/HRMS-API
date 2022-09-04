using Application.Common.Models;
using Application.Features.Setups.CompanyInfos.Commands.DTM;
using Application.Services.Setup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setups.CompanyInfos.Commands.Update
{
    public class CompanyInfoUpdateCommand:IRequest<Result>
    {
        public CompanyInfoUpdateDTM CompanyInfo { get; set; }
    }
    public class CompanyInfoUpdateCommandHandler : IRequestHandler<CompanyInfoUpdateCommand, Result>
    {
        private readonly ICompanyInfoService _companyInfoService;

        public CompanyInfoUpdateCommandHandler(ICompanyInfoService companyInfoService)
        {
            _companyInfoService = companyInfoService;
        }
        public async Task<Result> Handle(CompanyInfoUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _companyInfoService.Update(request.CompanyInfo, true, cancellationToken);
        }
    }
}
