using Microsoft.AspNetCore.Mvc;
using StudentEnrollementSystem_Backend.DB;
using StudentEnrollementSystem_Backend.Models;

namespace StudentEnrollementSystem_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()

        {
            return await _courseRepository.GetCourses();
        }


        [HttpPost]
        public async Task<ActionResult<Course>> AddStudent(Course course)
        {
            await _courseRepository.AddCourseAsync(course);
            return CreatedAtAction(nameof(GetCourses), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();

            }

            await _courseRepository.UpdateCourseAsync(course);
            return Ok(course); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _courseRepository.DeleteCourseAsync(id);
            return Ok(id);
        }
    }
}
