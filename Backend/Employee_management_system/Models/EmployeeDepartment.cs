using System.ComponentModel.DataAnnotations;

namespace Employee_management_system.Models
{
    public class EmployeeDepartment
    {
        
        public int EmployeeNo { get; set; }
     
        public int DepartmentNo { get; set; }

        public Employee Employee { get; set; }
        public Department Department { get; set; }
    }
}
