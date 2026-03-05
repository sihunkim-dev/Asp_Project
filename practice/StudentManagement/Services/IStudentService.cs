using Models;

namespace StudentManagement.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentAsync(long studentId);

        //Create a new Student 
        Task AddStudentAsync(Student student);

        //Update
        Task UpdateStudentAsync(Student student);


        //Delete
        Task DeleteStudentAsync(long studentId);
    }
}