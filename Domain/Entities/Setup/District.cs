namespace Domain.Entities.Setup
{
    public class District : AuditableEntity
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string DistrictNameUC { get; set; }
        public int DivisionID { get; set; }
        public bool IsActive { get; set; }
    }
}
