namespace Domain.Entities.Setup
{
    public class Section : AuditableEntity
    {
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public string SectionNameUC { get; set; }
        public string SectionCode { get; set; }
        public string SectionCodeUC { get; set; }
        public bool IsActive { get; set; }=true;
    }
}
