using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Models;

namespace StudentManagement.Models
{
    [Index(nameof(DepartmentName), IsUnique = true)]
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage ="Department name is required.")]
        [MaxLength(50)]
        public required string DepartmentName { get; set; }
    
        [MaxLength(200)]
        public string? Description { get; set; }

        //1:N relationship with Student
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();   

        //Keyword : Virtual
    }
}