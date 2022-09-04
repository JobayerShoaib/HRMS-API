namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn{ get; set; }

    }
}
