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
    public class EmployeesController : Controller
    {
        private readonly MyContext _context;

        public EmployeesController(MyContext context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index()
        {
            var myContext = _context.Employees.Include(e => e.doctor);
            return View( myContext.ToList());
        }

        // GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =  _context.Employees
                .Include(e => e.doctor)
                .FirstOrDefault(m => m.Eid == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["D_id"] = new SelectList(_context.Doctors, "Did", "Did");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Eid,E_salary,E_phone,E_gender,D_id")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["D_id"] = new SelectList(_context.Doctors, "Did", "Did", employee.D_id);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =  _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["D_id"] = new SelectList(_context.Doctors, "Did", "Did", employee.D_id);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Eid,E_salary,E_phone,E_gender,D_id")] Employee employee)
        {
            if (id != employee.Eid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Eid))
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
            ViewData["D_id"] = new SelectList(_context.Doctors, "Did", "Did", employee.D_id);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee =  _context.Employees
                .Include(e => e.doctor)
                .FirstOrDefault(m => m.Eid == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee =  _context.Employees.Find(id);
            _context.Employees.Remove(employee);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Eid == id);
        }
    }
}
