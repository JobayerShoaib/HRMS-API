namespace Domain.Entities.Setup
{
    public class OfficeLevel : AuditableEntity
    {
        public int OfficeLevelID { get; set; }
        public string OfficeLevelName { get; set; }
        public int LevelOrderNo { get; set; }
        public int CompanyID { get; set; }
        public bool IsEditable { get; set; }
        public bool IsActive { get; set; }
    }
}
