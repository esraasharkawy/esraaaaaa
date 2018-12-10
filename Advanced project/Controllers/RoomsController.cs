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
    public class RoomsController : Controller
    {
        private readonly MyContext _context;

        public RoomsController(MyContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public IActionResult Index()
        {
            var myContext = _context.Rooms.Include(r => r.department);
            return View( myContext.ToList());
        }

        // GET: Rooms/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room =  _context.Rooms
                .Include(r => r.department)
                .FirstOrDefault(m => m.Rno == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["dept_no"] = new SelectList(_context.Departments, "Deptno", "Deptno");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Rno,R_floor,dept_no")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["dept_no"] = new SelectList(_context.Departments, "Deptno", "Deptno", room.dept_no);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room =  _context.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["dept_no"] = new SelectList(_context.Departments, "Deptno", "Deptno", room.dept_no);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Rno,R_floor,dept_no")] Room room)
        {
            if (id != room.Rno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Rno))
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
            ViewData["dept_no"] = new SelectList(_context.Departments, "Deptno", "Deptno", room.dept_no);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room =  _context.Rooms
                .Include(r => r.department)
                .FirstOrDefault(m => m.Rno == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var room =  _context.Rooms.Find(id);
            _context.Rooms.Remove(room);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Rno == id);
        }
    }
}
