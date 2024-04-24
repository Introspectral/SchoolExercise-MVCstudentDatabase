using ASPCore_MVP.Models;

namespace ASPCore_MVP.Data
{
    public interface ICourse
    {
        Course GetById(int ID);
        IEnumerable<Course> GetAll();
        void Add(Course course);
        void Update(Course course);
        void Delete(Course course);
        void SaveChanges();

    } 
}
