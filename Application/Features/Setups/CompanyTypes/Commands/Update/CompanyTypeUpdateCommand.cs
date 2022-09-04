using Application.Common.Models;
using Application.Services.Setup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setups.CompanyTypes.Commands.Update
{
    public class CompanyTypeUpdateCommand:IRequest<Result>
    {
        public int CompanyTypeID { get; set; }
        public string CompanyTypeName { get; set; }
    }
    public class CompanyTypeUpdateCommandHandler : IRequestHandler<CompanyTypeUpdateCommand, Result>
    {
        private readonly ICompanyTypeService _companyTypeService;

        public CompanyTypeUpdateCommandHandler(ICompanyTypeService companyTypeService)
        {
            _companyTypeService = companyTypeService;
        }
        public async Task<Result> Handle(CompanyTypeUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _companyTypeService.Update(request,true,cancellationToken);
        }
    }
}
