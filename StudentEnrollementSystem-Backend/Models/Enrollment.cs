using System.ComponentModel.DataAnnotations;

namespace StudentEnrollementSystem_Backend.Models
{
    public class Enrollment : BaseId
    {
        [StringLength(50)]
        public string EnrollementName { get; set; }

        public Student Student { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public Course SelectedCourse { get; set; }

        public bool Active { get; set; }

        [StringLength(250)]
        public string Comments { get; set; }
    }
}
