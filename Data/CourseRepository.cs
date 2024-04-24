using ASPCore_MVP.Models;

namespace ASPCore_MVP.Data
{
    public class CourseRepository : ICourse
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CourseRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        public IEnumerable<Course> GetAll()
        {
            return applicationDbContext.Courses.OrderBy(x => x.Name);
        }

        public Course GetById(int id)
        {
            return applicationDbContext.Courses.FirstOrDefault(s => s.CourseId == id);
        }

        public void Add(Course course)
        {
            applicationDbContext.Add(course);
        }

        public void Update(Course course)
        {
            applicationDbContext.Update(course);
        }

        public void Delete(Course course)
        {
            applicationDbContext.Courses.Remove(course);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

    }
}
