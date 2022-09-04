using Microsoft.AspNetCore.Identity;

namespace Application.IdentityEntities
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser() : base()
        {
            Claims = new List<ApplicationUserClaim>();
            Logins = new List<ApplicationUserLogin>();
            Tokens = new List<ApplicationUserToken>();
            UserRoles=new List<ApplicationUserRole>();
        }
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string UserType { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }


    }
}
