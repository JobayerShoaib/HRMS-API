using Microsoft.AspNetCore.Identity;

namespace Application.IdentityEntities
{
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
