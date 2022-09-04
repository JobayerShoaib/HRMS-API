using Application.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Setups.Countries.Commands.Create
{
    public class CountryCreateCommandValidator : AbstractValidator<CountryCreateCommand>
    {
        private readonly IHRMDbContext _dbCon;
        public CountryCreateCommandValidator(IHRMDbContext dbCon)
        {
            _dbCon = dbCon;
            RuleFor(x => x.CountryName)
                .NotEmpty().WithMessage("shouldn't be empty")
                .MustAsync(BeUniqueCountryName).WithMessage("Name must be unique");
        }
        private async Task<bool> BeUniqueCountryName(string CountryName, CancellationToken cancellationToken)
        {
            bool result = await _dbCon.Country.Where(b => b.IsActive == true && b.IsDeleted == false)
                    .AllAsync(b => b.CountryName != CountryName);
            return result;
        }
    }
}
