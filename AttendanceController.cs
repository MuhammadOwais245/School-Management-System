using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Step 1 → Select Class
        public IActionResult SelectClass()
        {
            ViewBag.Classes = _context.Classes.ToList();
            return View();
        }

        // Step 2 → Show Students of selected class
        public IActionResult Mark(int classId)
        {
            var students = _context.Students
                .Where(s => s.ClassId == classId)
                .ToList();

            ViewBag.ClassId = classId;

            return View(students);
        }

        // Step 3 → Save Attendance
        [HttpPost]
        public IActionResult Save(int classId, List<int> presentStudents)
        {
            var students = _context.Students
                .Where(x => x.ClassId == classId)
                .ToList();

            DateTime today = DateTime.Today;

            foreach (var student in students)
            {
                var attendance = new Attendance
                {
                    ClassId = classId,
                    StudentId = student.Id,
                    Date = today,
                    IsPresent = presentStudents != null && presentStudents.Contains(student.Id)
                };

                _context.Attendances.Add(attendance);
            }

            _context.SaveChanges();

            return RedirectToAction("Report", new { classId });
        }

        // Attendance Report
        public IActionResult Report(int classId)
        {
            var attendance = _context.Attendances
                .Include(a => a.Student)
                .Where(a => a.ClassId == classId)
                .OrderByDescending(a => a.Date)
                .ToList();

            return View(attendance);
        }
    }
}
