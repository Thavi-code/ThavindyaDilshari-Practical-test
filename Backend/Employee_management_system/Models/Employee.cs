using Employee_management_system.Data;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Employee_management_system.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string Department { get; set; }

        public string Address { get; set; }

        [Required]
        [MaxLength(10)] 
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "MobileNumber must be numeric.")]
        [UniqueMobileNumber(ErrorMessage = "MobileNumber must be unique.")]
        public string MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        [UniqueEmail(ErrorMessage = "Email must be unique.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
        [JsonIgnore]
        public List<Department> Departments { get; set; }
    }

   

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueMobileNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (AppDbContext)validationContext.GetService(typeof(AppDbContext));

            var existingEmployee = dbContext.Employees.SingleOrDefault(e => e.MobileNumber == (string)value);
            if (existingEmployee != null)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (AppDbContext)validationContext.GetService(typeof(AppDbContext));

            var existingEmployee = dbContext.Employees.SingleOrDefault(e => e.Email == (string)value);
            if (existingEmployee != null)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
