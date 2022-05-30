using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KursovaDB.DAL.Data;
using KursovaDB.DAL.Entities;

namespace KursovaDB.WebAppMVC.Controllers
{
    public class SpecialistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Specialist
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Specialist.Include(s => s.Service);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Specialist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialist
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialist == null)
            {
                return NotFound();
            }

            return View(specialist);
        }

        // GET: Specialist/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.SocialService, "Id", "Id");
            return View();
        }

        // POST: Specialist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Specialization,ServiceId")] Specialist specialist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.SocialService, "Id", "Id", specialist.ServiceId);
            return View(specialist);
        }

        // GET: Specialist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialist.FindAsync(id);
            if (specialist == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.SocialService, "Id", "Id", specialist.ServiceId);
            return View(specialist);
        }

        // POST: Specialist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Specialization,ServiceId")] Specialist specialist)
        {
            if (id != specialist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialistExists(specialist.Id))
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
            ViewData["ServiceId"] = new SelectList(_context.SocialService, "Id", "Id", specialist.ServiceId);
            return View(specialist);
        }

        // GET: Specialist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialist
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialist == null)
            {
                return NotFound();
            }

            return View(specialist);
        }

        // POST: Specialist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialist = await _context.Specialist.FindAsync(id);
            _context.Specialist.Remove(specialist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialistExists(int id)
        {
            return _context.Specialist.Any(e => e.Id == id);
        }
    }
}
