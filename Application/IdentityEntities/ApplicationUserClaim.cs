using Microsoft.AspNetCore.Identity;

namespace Application.IdentityEntities
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public ApplicationUserClaim() : base()
        {

        }
        public ApplicationUserClaim(string userClaimDescriptoin = null, string userClaimGroup = null) : base()
        {
            Description = userClaimDescriptoin;
            Group = userClaimGroup;
        }
        public string? Description { get; set; }
        public string? Group { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
