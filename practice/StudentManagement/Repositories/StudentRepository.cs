using Microsoft.EntityFrameworkCore;
using Models;
using StudentManagement.Data;

namespace StudentManagement.Repositories
{
    public class StudentRepository : IStudentRepository
    {   
        //Context
        private readonly StudentContext _context;

        //Dependency Injection (DI)
        public StudentRepository(StudentContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentAsync(long studentId)
        {
            return await _context.Students.FindAsync(studentId);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Students.AnyAsync(s => s.Email == email);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(long id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}