using Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task AddStudentAsync(Student student)
        {
            // Implementation for adding a student
            // Check validation for the exact student information (e.g., name, age, etc.)
            // If not-> Add, else -> throw an exception or return an error message
            if (string.IsNullOrWhiteSpace(student.FirstName) || string.IsNullOrWhiteSpace(student.LastName)){
                throw new ArgumentException("First and Last name is required.");
            }
            //Email generation LogiC (FirstName[0] + LastName + indexNumber @school.com)
            
            var StudentCounter = 0;
            var StudentEmailFormat = $"{char.ToLower(student.FirstName[0])}{student.LastName.ToLower()}{StudentCounter}@school.com";
           
            while(await _studentRepository.EmailExistsAsync(StudentEmailFormat))
            {
                StudentCounter++;
                StudentEmailFormat = $"{char.ToLower(student.FirstName[0])}{student.LastName.ToLower()}{StudentCounter}@school.com";
            }

            student.Email = StudentEmailFormat;
            await _studentRepository.AddStudentAsync(student);
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }
        public async Task<Student?> GetStudentAsync(long studentId)
        {
            if(studentId <= 0)
            {
                throw new ArgumentException("Invalid student ID.");
            }
            return await _studentRepository.GetStudentAsync(studentId);
        }

        public async Task DeleteStudentAsync(long studentId)
        {
            //Id validation
            if(studentId <= 0)
            {
                throw new ArgumentException("Invalid student ID.");
            }

            var existingStudent = await _studentRepository.GetStudentAsync(studentId);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException("Student not found.");
            }

            await _studentRepository.DeleteStudentAsync(studentId);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            if(student.StudentID <= 0)
            {
                throw new ArgumentException("Invalid student ID.");
            }

            if(string.IsNullOrWhiteSpace(student.FirstName) || string.IsNullOrWhiteSpace(student.LastName)){
                throw new ArgumentException("First and Last name is required.");
            }

            await _studentRepository.UpdateStudentAsync(student);
        }

    }
}