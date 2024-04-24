using ASPCore_MVP.Models;

namespace ASPCore_MVP.Data
{
    public interface IStudentCourse
    {
        StudentCourse GetById(int StudentId);
        IEnumerable<StudentCourse> GetAll();
        void Add(StudentCourse studentCourse);
        void Update(StudentCourse studentCourse);
        void Delete(StudentCourse studentCourse);
        void SaveChanges();
    }
}
