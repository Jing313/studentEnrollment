using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment_Frontend.ViewModel
{
    public class Course : BaseId
    {
        //public ICollection<Student> Students { get ; set ; }

        //public ICollection<Subject> Subjects { get; set; }

        //public ICollection<Teacher> Teachers { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double Fees { get; set; }

        public string Subject { get; set; }

        public string Location { get; set; }

        [StringLength(250)]
        public string BranchAddress { get; set; }

        public string ContactPerson { get; set; }

    }
}
