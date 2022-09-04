using Application.Services.Setup;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setups.Countries.Queries
{
    public class CountryGetDDLQuery:IRequest<List<SelectListItem>>
    {
    }
    public class CountryGetDDLQueryHandler : IRequestHandler<CountryGetDDLQuery, List<SelectListItem>>
    {
        private readonly ICountryService _countryService;

        public CountryGetDDLQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public async Task<List<SelectListItem>> Handle(CountryGetDDLQuery request, CancellationToken cancellationToken)
        {
            return await _countryService.GetDDL(cancellationToken);

        }
    }
}
