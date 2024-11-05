using Microsoft.EntityFrameworkCore;
using StudentEnrollementSystem_Backend.Models;

namespace StudentEnrollementSystem_Backend.DB
{
    public class CourseRepository : BaseService, ICourseRepository
    {
        public CourseRepository(StudentContext context) : base(context)
        {

        }

        public async Task<List<Course>> GetCourses()
        {
            return await Context.Courses.ToListAsync();
        }

        public async Task AddCourseAsync(Course course)
        {
            Context.Courses.Add(course);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            Context.Entry(course).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var course = await Context.Courses.FindAsync(courseId);
            if (course != null)
            {
                Context.Courses.Remove(course);
                await Context.SaveChangesAsync();

            }
        }
    }
}
