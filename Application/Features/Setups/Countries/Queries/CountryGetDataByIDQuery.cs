using Application.Features.Setups.Countries.Queries.QRM;
using Application.Services.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setups.Countries.Queries
{
    public class CountryGetDataByIDQuery:IRequest<CountryGetDataListRM>
    {
        public int CountryID { get; set; }
    }
    public class CountryGetDataByIDQueryHandler : IRequestHandler<CountryGetDataByIDQuery, CountryGetDataListRM>
    {
        private readonly ICountryService _countryServic;

        public CountryGetDataByIDQueryHandler(ICountryService countryServic)
        {
            _countryServic = countryServic;
        }
        public async Task<CountryGetDataListRM> Handle(CountryGetDataByIDQuery request, CancellationToken cancellationToken)
        {
            return await _countryServic.CountryGetDataByID(request.CountryID, cancellationToken);
        }
    }
}
