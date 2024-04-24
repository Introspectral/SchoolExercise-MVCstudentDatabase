using ASPCore_MVP.Data;
using ASPCore_MVP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCore_MVP.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent studentRep;
        private readonly ApplicationDbContext applicationDbContext;

        public StudentController(IStudent studentRep)
        {
            this.studentRep = studentRep;

        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View(studentRep.GetAll());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(studentRep.GetById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind("Id,FirstName, LastName")]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentRep.Add(student);
                    studentRep.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null || studentRep == null)
            {
                return NotFound();
            }

            var student = studentRep.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    studentRep.Update(student);
                    studentRep.SaveChanges();
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || studentRep == null)
            {
                return NotFound();
            }

            var student = studentRep.GetById(id); //
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = studentRep.GetById(id); //
            if (ModelState.IsValid)
            {
                try
                {
                    studentRep.Delete(student); //
                    studentRep.SaveChanges(); //
                }
                catch (Exception)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
}
