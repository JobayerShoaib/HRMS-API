namespace Domain.Entities.Setup
{
    public class Office : AuditableEntity
    {
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public string OfficeNameUC { get; set; }
        public int OfficeLevelID { get; set; }
        public int? ParentOfficeID { get; set; }
        public int? CompanyID { get; set; }
        public int? DivisionID { get; set; }
        public int? DistrictID { get; set; }
        public int? ThanaID { get; set; }
        public string OfficeAddress { get; set; }
        public int? OfficeGeoLocationID { get; set; }
    }
}
