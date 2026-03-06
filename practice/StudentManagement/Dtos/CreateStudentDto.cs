using System.ComponentModel.DataAnnotations;
using StudentManagement.Models;

namespace StudentManagement.Dtos.StudentDto
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50)]
        public required string FirstName { get; set; }

        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50)]
        public required string LastName { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public virtual Department? Department { get; set; }

    }
}



///////DTOS//////////
