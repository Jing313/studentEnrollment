namespace StudentEnrollementSystem_Backend.Models
{
    public class Subject : BaseId
    {
        public string Name {  get; set; }

        public string Description { get; set; }

        public Course Course { get; set; }
    }
}