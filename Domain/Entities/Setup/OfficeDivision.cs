namespace Domain.Entities.Setup
{
    public class OfficeDivision : AuditableEntity
    {
        public int OfficeDivisionID { get; set; }
        public string OfficeDivisionName { get; set; }
        public string OfficeDivisionNameUC { get; set; }
        public string OfficeDivisionCode { get; set; }
        public string OfficeDivisionCodeUC { get; set; }
        public string OfficeDivisionColor { get; set; }
        public DateTime EstablishedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
