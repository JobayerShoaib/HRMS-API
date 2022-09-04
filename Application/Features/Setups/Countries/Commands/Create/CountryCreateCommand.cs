using Application.Common.Models;
using Application.Services.Setup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setups.Countries.Commands.Create
{
    public class CountryCreateCommand:IRequest<Result>
    {
        public string CountryName { get; set; }
        public string CountryNameUC { get; set; }
        public string CountryShortCode { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }=true;
    }
    public class CountryCreateCommandHandler : IRequestHandler<CountryCreateCommand, Result>
    {
        private readonly ICountryService _countryService;

        public CountryCreateCommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public async Task<Result> Handle(CountryCreateCommand request, CancellationToken cancellationToken)
        {
            return await _countryService.Create(request, true, cancellationToken);
        }
    }
}
