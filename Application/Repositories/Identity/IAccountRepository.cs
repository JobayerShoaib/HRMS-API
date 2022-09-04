using Application.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Identity
{
    public interface IAccountRepository:IGenericRepository<ApplicationUser>
    {
        
    }
}
