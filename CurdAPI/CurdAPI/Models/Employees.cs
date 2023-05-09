using System.ComponentModel.DataAnnotations;

namespace CurdAPI.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
    }
}
