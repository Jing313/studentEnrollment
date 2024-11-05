using StudentEnrollementSystem_Backend.Models;

namespace StudentEnrollementSystem_Backend.DB
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student);
        Task DeleteStudentAsync(int studentId);
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<List<Student>> GetStudents();
        Task UpdateStudentAsync(Student student);
    }
}