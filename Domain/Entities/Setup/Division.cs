namespace Domain.Entities.Setup
{
    public class Division : AuditableEntity
    {
        public int DivisionID { get; set; }
        public string DivisionName { get; set; }
        public string DivisionNameUC { get; set; }
        public int CountryID { get; set; }
        public bool IsActive { get; set; }

    }
}
