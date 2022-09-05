using Application.Common.Models;
using Application.Features.Setups.Divisions.Commands.Create;
using Application.Features.Setups.Divisions.Commands.Update;
using Application.Features.Setups.Divisions.Queries.QRM;
using Application.Repositories.Setup;
using Application.Services.Setup;
using Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImpServices.Setup
{
    public class DivisionService : IDivisionService
    {
        private readonly IDivisionRepository _divisionRepository;

        public DivisionService(IDivisionRepository divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }
        public async Task<Result> Create(DivisionCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            Division entity = new()
            {
                DivisionName = model.DivisionName,
                DivisionNameUC = model.DivisionNameUC,
                CountryID = model.CountryID,
                IsActive = model.IsActive
            };
            await _divisionRepository.InsertAsync(entity, saveChanges, cancellationToken);
            return result.Success();
        }

        public async Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _divisionRepository.GetByIdAsync(id, cancellationToken);
            entity.IsDeleted = true;
            await _divisionRepository.UpdateAsync(entity, saveChanges, cancellationToken);

            return result.Update("Deleted Successfully");
        }

        public async Task<IList<DivisionGetDataListRM>> GetDataList(int countryID =0,CancellationToken cancellationToken = default)
        {
            return await _divisionRepository.GetDataList(countryID, cancellationToken);
        }

        public async Task<Result> Update(DivisionUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            Result result = new();
            var entity = await _divisionRepository.GetByIdAsync(model.CountryID, cancellationToken);
            entity.DivisionName = model.DivisionName;
            entity.DivisionNameUC = model.DivisionNameUC;
            entity.CountryID = model.CountryID;

            await _divisionRepository.UpdateAsync(entity, saveChanges, cancellationToken);
            return result.Update();
        }
    }
}
