using Application.Features.Setups.CompanyTypes.Queries.QRM;

namespace Application.Repositories.Setup
{
    public interface ICompanyTypeRepository : IGenericRepository<CompanyType>
    {
        Task<IList<CompanyTypeGetDataListRM>> GetDataList(CancellationToken cancellationToken = default);
    }
}
