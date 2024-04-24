using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPCore_MVP.Data;
using ASPCore_MVP.Models;
using ASPCore_MVP.ViewModel;

namespace ASPCore_MVP.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudent studentRep;
        private readonly ICourse courseRep;
        private readonly IStudentCourse studentCourseRep;

        public StudentCoursesController(ApplicationDbContext context, IStudent studentRep, ICourse courseRep, IStudentCourse studentCourseRep)
        {
            
            _context = context;
            this.studentRep=studentRep;
            this.courseRep=courseRep;
            this.studentCourseRep=studentCourseRep;
        }

        // GET: StudentCourses
        public IActionResult Index()
        {
            return View(studentCourseRep.GetAll());
        }

        // GET: StudentCourses/Details/5
        public IActionResult Details(int id)
        {
            if (id == null || studentCourseRep.GetById(id) == null)
            {
                return NotFound();
            }
            StudentCourseViewModel studentCourseVM = new StudentCourseViewModel();
            studentCourseVM.StudentCourse = studentCourseRep.GetById(id);
            studentCourseVM.Student = studentRep.GetById(studentCourseVM.StudentCourse.StudentId);
            studentCourseVM.Course = courseRep.GetById(studentCourseVM.StudentCourse.CourseId);
            return View(studentCourseVM);
        }

        // GET: StudentCourses/Create
        public IActionResult Create()
        {
            ViewBag.Students=new SelectList(studentRep.GetAll(), "Id", "FirstName");
            ViewBag.Courses=new SelectList(courseRep.GetAll(), "CourseId", "Name");
            List<SelectListItem> grade = new ()
            {
                new SelectListItem { Value = "1", Text = "IG"},
                new SelectListItem { Value = "2", Text = "G"},
                new SelectListItem { Value = "3", Text = "VG"}
            };
            ViewBag.Grade = grade;
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,CourseId,Grade,Completed")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentCourse);
        }

        // GET: StudentCourses/Edit/5
        public IActionResult Edit()
        {
            ViewBag.Students=new SelectList(studentRep.GetAll(), "Id", "FirstName");
            ViewBag.Courses=new SelectList(courseRep.GetAll(), "CourseId", "Name");
            List<SelectListItem> grade = new()
            {
                new SelectListItem { Value = "1", Text = "IG"},
                new SelectListItem { Value = "2", Text = "G"},
                new SelectListItem { Value = "3", Text = "VG"}
            };
            ViewBag.Grade = grade;
            return View();
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId,Grade,Completed")] StudentCourse studentCourse)
        {
            if (id != studentCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCourseExists(studentCourse.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentCourses == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentCourses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentCourses'  is null.");
            }
            var studentCourse = await _context.StudentCourses.FindAsync(id);
            if (studentCourse != null)
            {
                _context.StudentCourses.Remove(studentCourse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseExists(int id)
        {
          return (_context.StudentCourses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
