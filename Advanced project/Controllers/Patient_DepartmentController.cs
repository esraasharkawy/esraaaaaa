using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Advancedproject.Data;
using Advancedproject.Models;

namespace Advanced_project.Controllers
{
    public class Patient_DepartmentController : Controller
    {
        private readonly MyContext _context;

        public Patient_DepartmentController(MyContext context)
        {
            _context = context;
        }

        // GET: Patient_Department
        public IActionResult Index()
        {
            var myContext = _context.Patient_Departments.Include(p => p.department).Include(p => p.patient);
            return View( myContext.ToList());
        }

        // GET: Patient_Department/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Department =  _context.Patient_Departments
                .Include(p => p.department)
                .Include(p => p.patient)
                .FirstOrDefault(m => m.pid == id);
            if (patient_Department == null)
            {
                return NotFound();
            }

            return View(patient_Department);
        }

        // GET: Patient_Department/Create
        public IActionResult Create()
        {
            ViewData["deptno"] = new SelectList(_context.Departments, "Deptno", "Deptno");
            ViewData["pid"] = new SelectList(_context.Patients, "pid", "pid");
            return View();
        }

        // POST: Patient_Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Patient_Department patient_Department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient_Department);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["deptno"] = new SelectList(_context.Departments, "Deptno", "Deptno", patient_Department.deptno);
            ViewData["pid"] = new SelectList(_context.Patients, "pid", "pid", patient_Department.pid);
            return View(patient_Department);
        }

        // GET: Patient_Department/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Department =  _context.Patient_Departments.Find(id);
            if (patient_Department == null)
            {
                return NotFound();
            }
            ViewData["deptno"] = new SelectList(_context.Departments, "Deptno", "Deptno", patient_Department.deptno);
            ViewData["pid"] = new SelectList(_context.Patients, "pid", "pid", patient_Department.pid);
            return View(patient_Department);
        }

        // POST: Patient_Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("pid,deptno")] Patient_Department patient_Department)
        {
            if (id != patient_Department.pid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient_Department);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Patient_DepartmentExists(patient_Department.pid))
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
            ViewData["deptno"] = new SelectList(_context.Departments, "Deptno", "Deptno", patient_Department.deptno);
            ViewData["pid"] = new SelectList(_context.Patients, "pid", "pid", patient_Department.pid);
            return View(patient_Department);
        }

        // GET: Patient_Department/Delete/5
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Department = _context.Patient_Departments.Find(id);
                
            if (patient_Department == null)
            {
                return NotFound();
            }

            return View(patient_Department);
        }

        // POST: Patient_Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var patient_Department =  _context.Patient_Departments.Find(id);
            _context.Patient_Departments.Remove(patient_Department);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool Patient_DepartmentExists(int id)
        {
            return _context.Patient_Departments.Any(e => e.pid == id);
        }
    }
}
