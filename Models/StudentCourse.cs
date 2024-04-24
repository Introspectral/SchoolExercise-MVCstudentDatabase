using System.ComponentModel;

namespace ASPCore_MVP.Models
{
    public class StudentCourse
    {
        
        public int Id { get; set; }
        [DisplayName("Student")]
        public int StudentId { get; set; }
        [DisplayName("Course")]
        public int CourseId { get; set; }

        public string? Grade { get; set; }
        
        public bool Completed { get; set; }
    }
}
