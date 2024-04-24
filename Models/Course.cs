using Microsoft.Extensions.FileSystemGlobbing;

namespace ASPCore_MVP.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Teatcher { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
