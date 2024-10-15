using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using System.Collections.Generic;

namespace SchoolManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> Students = new List<Student>();


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var student = Students.FirstOrDefault(s => s.Username == username && s.Password == password);

            if (student != null)
            {
                // Store the student data in session
                HttpContext.Session.SetInt32("StudentId", student.StudentId);
                return RedirectToAction("Details", new { id = student.StudentId });
            }

            ViewBag.Error = "Invalid Username or Password";
            return View();
        }

        // GET: Student/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Student/Register
        [HttpPost]
        public IActionResult Register(Student student)
        {
            // Auto-generate StudentId
            student.StudentId = Students.Count + 1;

            // Save student to the list (in real application, save to database)
            Students.Add(student);

            return RedirectToAction("Details", new { id = student.StudentId });
        }

        // GET: Student/Details/{id}
        public IActionResult Details(int id)
        {
            var student = Students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
                return NotFound();

            return View(student); // Pass the student object to the view.
        }



        public IActionResult AddQualifications(int id)
        {
            var student = Students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
                return NotFound();

            return View(student); // Pass the student object to the view.
        }

        [HttpPost]
        [Route("Student/AddQualification/{id}")]
        public IActionResult AddQualification(int id, List<Qualification> qualifications)
        {
            var student = Students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
                return NotFound();

            if (qualifications != null && qualifications.Any())
            {
                student.Qualifications.AddRange(qualifications);
            }

            return RedirectToAction("Details", new { id = student.StudentId });
        }
    }
}
