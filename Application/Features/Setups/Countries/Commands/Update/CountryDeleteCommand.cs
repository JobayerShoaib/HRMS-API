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
    public class CountryDeleteCommand : IRequest<Result>
    {
        public int CountryID { get; set; }
    }
    public class CountryDeleteCommandHandler : IRequestHandler<CountryDeleteCommand, Result>
    {
        private readonly ICountryService _countryService;

        public CountryDeleteCommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public async Task<Result> Handle(CountryDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _countryService.Delete(request.CountryID, true, cancellationToken);
        }
    }
}
