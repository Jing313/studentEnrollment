using Microsoft.EntityFrameworkCore;
using StudentEnrollementSystem_Backend.Models;

namespace StudentEnrollementSystem_Backend.DB
{
    public class EnrollmentRepository : BaseService, IEnrollmentRepository
    {
        public EnrollmentRepository(StudentContext context) : base(context)
        {
        }

        public async Task<List<Enrollment>> GetEnrollments()
        {
            return await Context.Enrollements.ToListAsync();
        }

        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            Context.Enrollements.Add(enrollment);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateEnrollmentAsync(Enrollment enrollment)
        {
            Context.Entry(enrollment).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteEnrollmentAsync(int enrollmentId)
        {
            var enrollment = await Context.Enrollements.FindAsync(enrollmentId);
            if (enrollment != null)
            {
                Context.Enrollements.Remove(enrollment);
                await Context.SaveChangesAsync();

            }
        }
    }
}
