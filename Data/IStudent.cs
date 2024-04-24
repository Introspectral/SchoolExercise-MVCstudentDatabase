using ASPCore_MVP.Models;

namespace ASPCore_MVP.Data
{
    public interface IStudent
    {
        Student GetById(int Id);
        IEnumerable<Student> GetAll();
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
        void SaveChanges();
    }
}
