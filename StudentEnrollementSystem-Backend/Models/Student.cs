using System;
using System.ComponentModel.DataAnnotations;

namespace StudentEnrollementSystem_Backend.Models
{
    public class Student : BaseId
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(150)]
        public string LastName { get; set; }

        public DateTime DoB { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        [StringLength (250)]
        public string Address { get; set; }

        public int CourseId { get; set; }

        public bool Active { get; set; }
    }
}
