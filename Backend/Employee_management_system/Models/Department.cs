using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Employee_management_system.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        [JsonIgnore]
        public List<Employee> Employees { get; set; }
    }
}
