using ASPCore_MVP.Models;

namespace ASPCore_MVP.Data
{
    public class StudentCourseRepository : IStudentCourse
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentCourseRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        public IEnumerable<StudentCourse> GetAll()
        {
            return applicationDbContext.StudentCourses.OrderBy(x => x.StudentId);
        }

        public StudentCourse GetById(int id)
        {
            return applicationDbContext.StudentCourses.FirstOrDefault(s => s.StudentId == id);
        }

        public void Add(StudentCourse studentCourse)
        {
            applicationDbContext.Add(studentCourse);
        }

        public void Update(StudentCourse studentCourse)
        {
            applicationDbContext.Update(studentCourse);
        }

        public void Delete(StudentCourse studentCourse)
        {
            applicationDbContext.StudentCourses.Remove(studentCourse);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

    }
}
