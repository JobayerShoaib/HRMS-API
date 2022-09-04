using Application.Common.Models;
using Application.Features.Setups.Countries.Commands.Create;
using Application.Features.Setups.Countries.Commands.Update;
using Application.Features.Setups.Countries.Queries.QRM;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Services.Setup
{
    public interface ICountryService
    {
        Task<Result> Create(CountryCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Update(CountryUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<IList<CountryGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
        Task<CountryGetDataListRM> CountryGetDataByID(int countryID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetDDL(CancellationToken cancellationToken);
    }
}
