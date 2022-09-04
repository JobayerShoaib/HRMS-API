using Application.Features.Setups.CompanyInfos.Commands.DTM;
using Application.Features.Setups.CompanyInfos.Queries.QRM;

namespace Application.Services.Setup
{
    public interface ICompanyInfoService
    {
        Task<Result> Create(CompanyInfoCreateDTM model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Update(CompanyInfoUpdateDTM model, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<Result> Delete(int id, bool saveChanges = true, CancellationToken cancellationToken = default);
        Task<IList<CompanyInfoGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
    }
}
