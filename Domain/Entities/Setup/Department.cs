namespace Domain.Entities.Setup
{
    public class Department : AuditableEntity
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameUC { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentCodeUC { get; set; }
        public bool IsActive { get; set; }
    }
}
