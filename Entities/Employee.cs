namespace angularCRUDAPI.Entities
{
    public class Employee
    {
        public int employeeId { get; set; }
        public required string employeeName { get; set; }
        public string employeeContactNumber { get; set; } = string.Empty;
        public required string employeeAddress { get; set; }
        public string employeeGender { get; set; } = string.Empty;
        public string employeeDepartment { get; set; } = string.Empty;
        public string employeeSkills { get; set; } = string.Empty;
        
    }
}
