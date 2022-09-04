using Application.Features.Setups.Departments.Queries.QRM;
using Application.Repositories.Setup;

namespace Infrastructure.ImpRepositories.Setup
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly HRMDbContext _dbCon;
        public DepartmentRepository(HRMDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<IList<DepartmentGetDataListRM>> GetDataList(CancellationToken cancellationToken)
        {
            var data= await _dbCon.Department.Where(x=>x.IsActive==true && x.IsDeleted==false)
                .Select(x=>new DepartmentGetDataListRM {
                    DepartmentID = x.DepartmentID,
                    DepartmentName = x.DepartmentName,
                    DepartmentNameUC = x.DepartmentNameUC,  
                    DepartmentCode = x.DepartmentCode,
                    DepartmentCodeUC = x.DepartmentCodeUC                                     
                }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
