namespace Domain.Entities.Setup
{
    public class CompanyType : AuditableEntity
    {
        public int CompanyTypeID { get; set; }
        public string CompanyTypeName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<CompanyInfo> Companies { get; set; }
    }
}
