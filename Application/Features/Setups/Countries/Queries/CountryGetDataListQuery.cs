using Application.Features.Setups.Countries.Queries.QRM;
using Application.Services.Setup;
using MediatR;

namespace Application.Features.Setups.Countries.Queries
{
    public class CountryGetDataListQuery : IRequest<IList<CountryGetDataListRM>>
    {
    }
    public class CountryGetDataListQueryHandler : IRequestHandler<CountryGetDataListQuery, IList<CountryGetDataListRM>>
    {
        private readonly ICountryService _countryService;

        public CountryGetDataListQueryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public async Task<IList<CountryGetDataListRM>> Handle(CountryGetDataListQuery request, CancellationToken cancellationToken)
        {
            return await _countryService.GetDataList(cancellationToken);
        }
    }
}
