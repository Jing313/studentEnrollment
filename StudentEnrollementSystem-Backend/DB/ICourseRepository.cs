using StudentEnrollementSystem_Backend.Models;

namespace StudentEnrollementSystem_Backend.DB
{
    public interface ICourseRepository
    {
        Task AddCourseAsync(Course course);
        Task DeleteCourseAsync(int courseId);
        Task<List<Course>> GetCourses();
        Task UpdateCourseAsync(Course course);
    }
}