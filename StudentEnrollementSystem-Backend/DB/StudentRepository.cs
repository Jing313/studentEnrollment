using Microsoft.EntityFrameworkCore;
using StudentEnrollementSystem_Backend.Models;
using static StudentEnrollementSystem_Backend.DB.StudentRepository;

namespace StudentEnrollementSystem_Backend.DB
{
    public class StudentRepository : BaseService, IStudentRepository
    {
        public StudentRepository(StudentContext context) : base(context)
        {

        }

        //public async Task<List<Student>> GetAllStudentsAsync()
        //{
        //    return await _context.Students.ToListAsync();
        //}
        public async Task<List<Student>> GetStudents()
        {
            return await Context.Students.
                Where(x => x.Active).ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await Context.Students.FindAsync(studentId);
        }

        public async Task AddStudentAsync(Student student)
        {
            Context.Students.Add(student);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            Context.Entry(student).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            var student = await Context.Students.FindAsync(studentId);
            if (student != null)
            {
                Context.Students.Remove(student);
                await Context.SaveChangesAsync();

            }
        }
    }
}
