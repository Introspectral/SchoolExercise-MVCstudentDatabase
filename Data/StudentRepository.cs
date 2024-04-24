using ASPCore_MVP.Models;

namespace ASPCore_MVP.Data
{
    public class StudentRepository : IStudent
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        public IEnumerable<Student> GetAll()
        {
            return applicationDbContext.Students.OrderBy(x => x.LastName);
        }

        public Student GetById(int id)
        {
            return applicationDbContext.Students.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Student student)
        {
            applicationDbContext.Add(student);
        }

        public void Update(Student student)
        {
            applicationDbContext.Update(student);
        }

        public void Delete(Student student)
        {
            applicationDbContext.Students.Remove(student);
        }

        public void SaveChanges()
        {
            applicationDbContext.SaveChanges();
        }

    }
}
