namespace Domain.Entities.Setup
{
    public class Country : AuditableEntity
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryNameUC { get; set; }
        public string CountryShortCode { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
    }
}
