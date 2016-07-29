using System.ComponentModel.DataAnnotations;

namespace BEEPOApp.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        
        [Required]
        [StringLength(50,MinimumLength = 2)]
        public string Name { get; set; }
    }
}