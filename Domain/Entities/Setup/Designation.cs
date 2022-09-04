namespace Domain.Entities.Setup
{
    public class Designation : AuditableEntity
    {
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string DesignationCode { get; set; }
        public string DesignationCodeUC { get; set; }
        public decimal? Currency { get; set; }
        public decimal? MinimumSalary { get; set; }
        public decimal? MaximumSalary { get; set; }
        public int? NoOfSteps { get; set; }
        public decimal? IncrementAmount { get; set; }
        public bool IsActive { get; set; }
    }
}
