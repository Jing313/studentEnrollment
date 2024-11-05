using Microsoft.AspNetCore.Mvc;
using StudentEnrollementSystem_Backend.DB;
using StudentEnrollementSystem_Backend.Models;

namespace StudentEnrollementSystem_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments()

        {
            return await _enrollmentRepository.GetEnrollments();
        }


        [HttpPost]
        public async Task<ActionResult<Enrollment>> AddStudent(Enrollment enrollment)
        {
            await _enrollmentRepository.AddEnrollmentAsync(enrollment);
            return CreatedAtAction(nameof(GetEnrollments), new { id = enrollment.Id }, enrollment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return BadRequest();

            }

            await _enrollmentRepository.AddEnrollmentAsync(enrollment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _enrollmentRepository.DeleteEnrollmentAsync(id);
            return NoContent();
        }
    }
}
