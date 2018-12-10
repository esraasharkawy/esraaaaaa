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
    public class Patient_DoctorController : Controller
    {
        private readonly MyContext _context;

        public Patient_DoctorController(MyContext context)
        {
            _context = context;
        }

        // GET: Patient_Doctor
        public IActionResult Index()
        {
            var myContext = _context.Patient_Doctors.Include(p => p.doctor).Include(p => p.patient);
            return View( myContext.ToList());
        }

        // GET: Patient_Doctor/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Doctor =  _context.Patient_Doctors
                .Include(p => p.doctor)
                .Include(p => p.patient)
                .FirstOrDefault(m => m.pid == id);
            if (patient_Doctor == null)
            {
                return NotFound();
            }

            return View(patient_Doctor);
        }

        // GET: Patient_Doctor/Create
        public IActionResult Create()
        {
            ViewData["Did"] = new SelectList(_context.Doctors, "Did", "Did");
            ViewData["pid"] = new SelectList(_context.Patients, "pid", "pid");
            return View();
        }

        // POST: Patient_Doctor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient_Doctor patient_Doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient_Doctor);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Did"] = new SelectList(_context.Doctors, "Did", "Did", patient_Doctor.Did);
            ViewData["pid"] = new SelectList(_context.Patients, "pid", "pid", patient_Doctor.pid);
            return View(patient_Doctor);
        }

        // GET: Patient_Doctor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Doctor =  _context.Patient_Doctors.Find(id);
            if (patient_Doctor == null)
            {
                return NotFound();
            }
            ViewData["Did"] = new SelectList(_context.Doctors, "Did", "Did", patient_Doctor.Did);
            ViewData["pid"] = new SelectList(_context.Patients, "pid", "pid", patient_Doctor.pid);
            return View(patient_Doctor);
        }

        // POST: Patient_Doctor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("pid,Did")] Patient_Doctor patient_Doctor)
        {
            if (id != patient_Doctor.pid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient_Doctor);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Patient_DoctorExists(patient_Doctor.pid))
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
            ViewData["Did"] = new SelectList(_context.Doctors, "Did", "Did", patient_Doctor.Did);
            ViewData["pid"] = new SelectList(_context.Patients, "pid", "pid", patient_Doctor.pid);
            return View(patient_Doctor);
        }

        // GET: Patient_Doctor/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient_Doctor = _context.Patient_Doctors.Find(id);
               
            if (patient_Doctor == null)
            {
                return NotFound();
            }

            return View(patient_Doctor);
        }

        // POST: Patient_Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var patient_Doctor = _context.Patient_Doctors.Find(id);
            _context.Patient_Doctors.Remove(patient_Doctor);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool Patient_DoctorExists(int id)
        {
            return _context.Patient_Doctors.Any(e => e.pid == id);
        }
    }
}
