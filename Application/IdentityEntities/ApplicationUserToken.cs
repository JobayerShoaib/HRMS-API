using Microsoft.AspNetCore.Identity;

namespace Application.IdentityEntities
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
