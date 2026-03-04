using Models;

namespace StudentManagement.Repositories
{
    public interface IStudentRepository
    {
        //Get all students Task<IEnumerable<Student>> => 비동기 작업 후 특정 타입의<T> -> Student 결과물을 반환
        Task<IEnumerable<Student>> GetAllStudentsAsync();

        //Get a student by ID(? => nullable)
        Task<Student?> GetStudentAsync(long studentId);

        //Create a new Student 
        Task AddStudentAsync(Student student);

        Task UpdateStudentAsync(Student student);

        Task DeleteStudentAsync(long studentId);
    }
}

///////////////////////////// Description /////////////////////////
/*
Tips for Repository Interface Design:
1. CRUD Operations 
2. Asynchronous Methods : Task<T> -> 비동기 작업 후 특정 타입의<T> -> Student 결과물을 반환
3. Nullable Return Types : GetStudentAsync(long studentId) -> Task<Student?> -> 학생
*/