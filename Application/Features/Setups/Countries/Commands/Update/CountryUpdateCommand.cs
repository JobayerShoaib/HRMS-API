using Application.Common.Models;
using Application.Services.Setup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Setups.Countries.Commands.Update
{
    public class CountryUpdateCommand : IRequest<Result>
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryNameUC { get; set; }
        public string CountryShortCode { get; set; }
        public bool IsDefault { get; set; }
    }
    public class CountryUpdateCommandHandler : IRequestHandler<CountryUpdateCommand, Result>
    {
        private readonly ICountryService _countryService;

        public CountryUpdateCommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public async Task<Result> Handle(CountryUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _countryService.Update(request,true,cancellationToken);
        }
    }
}
