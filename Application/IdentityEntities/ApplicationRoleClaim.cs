using Microsoft.AspNetCore.Identity;

namespace Application.IdentityEntities
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public ApplicationRoleClaim() : base()
        {
        }

        public ApplicationRoleClaim(string roleClaimDescription = null, string roleClaimGroup = null) : base()
        {
            Description = roleClaimDescription;
            Group = roleClaimGroup;
        }
        public string Description { get; set; }
        public string? Group { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
