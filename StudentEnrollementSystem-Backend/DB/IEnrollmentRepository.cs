using StudentEnrollementSystem_Backend.Models;

namespace StudentEnrollementSystem_Backend.DB
{
    public interface IEnrollmentRepository
    {
        Task AddEnrollmentAsync(Enrollment enrollment);
        Task DeleteEnrollmentAsync(int enrollmentId);
        Task<List<Enrollment>> GetEnrollments();
        Task UpdateEnrollmentAsync(Enrollment enrollment);
    }
}