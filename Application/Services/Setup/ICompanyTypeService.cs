using Application.Common.Models;
using Application.Features.Setups.CompanyTypes.Commands.Create;
using Application.Features.Setups.CompanyTypes.Commands.Update;
using Application.Features.Setups.CompanyTypes.Queries.QRM;

namespace Application.Services.Setup
{
    public interface ICompanyTypeService
    {
        Task<Result> Create(CompanyTypeCreateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Update(CompanyTypeUpdateCommand model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<IList<CompanyTypeGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
    }
}
