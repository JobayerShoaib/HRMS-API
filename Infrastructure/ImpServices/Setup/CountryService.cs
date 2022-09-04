using Application.Common.Models;
using Application.Features.Setups.Countries.Commands.Create;
using Application.Features.Setups.Countries.Commands.Update;
using Application.Features.Setups.Countries.Queries.QRM;
using Application.Repositories.Setup;
using Application.Services.Setup;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrastructure.ImpServices.Setup
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<CountryGetDataListRM> CountryGetDataByID(int countryID, CancellationToken cancellationToken)
        {
            var entity = await _countryRepository.GetByIdAsync(countryID, cancellationToken);
            CountryGetDataListRM model = new()
            {
                CountryID = entity.CountryID,
                CountryName = entity.CountryName,
                CountryNameUC = entity.CountryNameUC,
                CountryShortCode = entity.CountryShortCode,
                IsDefault = entity.IsDefault
            };
            return model;
        }

        public async Task<Result> Create(CountryCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            Country entity = new()
            {
                CountryName = model.CountryName,
                CountryShortCode = model.CountryShortCode,
                CountryNameUC = model.CountryNameUC,
                IsDefault = model.IsDefault,
                IsActive = model.IsActive
            };
            await _countryRepository.InsertAsync(entity, saveChanges, cancellationToken);
            return result.Success();
        }

        public async Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _countryRepository.GetByIdAsync(id, cancellationToken);
            entity.IsDeleted = true;
            await _countryRepository.UpdateAsync(entity, saveChanges, cancellationToken);

            return result.Update("Deleted Successfully");
        }

        public async Task<IList<CountryGetDataListRM>> GetDataList(CancellationToken cancellationToken = default)
        {
            return await _countryRepository.GetDataList(cancellationToken);
        }

        public async Task<List<SelectListItem>> GetDDL(CancellationToken cancellationToken)
        {
            var data =await _countryRepository.GetAllAsync(cancellationToken);
            var ddlData = data.Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.CountryID.ToString()
            }).ToList();
            return ddlData;

        }

        public async Task<Result> Update(CountryUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _countryRepository.GetByIdAsync(model.CountryID, cancellationToken);
            entity.CountryName = model.CountryName;
            entity.CountryShortCode = model.CountryShortCode;
            entity.CountryNameUC = model.CountryNameUC;
            entity.IsDefault = model.IsDefault;

            await _countryRepository.UpdateAsync(entity, saveChanges, cancellationToken);
            return result.Update();
        }
    }
}
