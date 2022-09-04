using Application.Features.Setups.CompanyInfos.Queries.QRM;

namespace Application.Repositories.Setup
{
    public interface ICompanyInfoRepository : IGenericRepository<CompanyInfo>
    {
        Task<IList<CompanyInfoGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
    }
}
