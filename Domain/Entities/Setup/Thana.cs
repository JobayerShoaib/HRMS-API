namespace Domain.Entities.Setup
{
    public class Thana : AuditableEntity
    {
        public int ThanaID { get; set; }
        public string ThanaName { get; set; }
        public string ThanaNameUC { get; set; }
        public string ThanaCode { get; set; }
        public int DistrictID { get; set; }
        public bool IsActive { get; set; }
       
    }
}
