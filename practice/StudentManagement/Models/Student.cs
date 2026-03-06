using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Student
    {
        [Key]
        public long StudentID {get; set;}
        
        [MaxLength(50)]
        public required string FirstName {get; set;}
        
        [MaxLength(50)]
        public string? MiddleName {get; set;}

        [MaxLength(50)]
        public required string LastName {get; set;}

        [MaxLength(100)]
        public required string Email {get; set;}
        
        public required DateOnly DateOfBirth {get; set;}
        
        public int DepartmentID {get; set;}

        public virtual Department? Department {get; set;}
        //Virtual : 자식 클래스에서 재정의 가능, Lazy Loading 
    }
}

/*
| Columns      | Type           | Constraints         |
| ------------ | -------------- | ------------------- |
| StudentId    | `BIGINT`       | `PK`                |
| FirstName    | `VARCHAR(50)`  | `NOT NULL`          |
| MiddleName   | `VARCHAR(50)`  | Nullable            |
| LastName     | `VARCHAR(50)`  | `NOT NULL`          |
| Email        | `VARCHAR(100)` | `UNIQUE` `NOT NULL` |
| DateOfBirth  | `DATE`         | `NOT NULL`          |
| DepartmentId | `INT`          | `FK`                |*/

///////////////////////// Description /////////////////////////
/*
 - Naming Conventions : PascalCase[ StudentId ]
 - There must be public access modifier for all properties in Entities.
 - NOT NULL : required keyword is used to make the property mandatory.


*/