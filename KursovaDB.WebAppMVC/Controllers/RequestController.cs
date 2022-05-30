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
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Request
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Request.Include(r => r.Citizen).Include(r => r.Specialist).Include(r => r.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Request/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .Include(r => r.Citizen)
                .Include(r => r.Specialist)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Request/Create
        public IActionResult Create()
        {
            ViewData["CitizenId"] = new SelectList(_context.Citizen, "Id", "Id");
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "Id", "Id");
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "Id", "Id");
            return View();
        }

        // POST: Request/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,RequestDescription,CreatedAt,QueuedNumber,CitizenId,SpecialistId,StatusId")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CitizenId"] = new SelectList(_context.Citizen, "Id", "Id", request.CitizenId);
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "Id", "Id", request.SpecialistId);
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "Id", "Id", request.StatusId);
            return View(request);
        }

        // GET: Request/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["CitizenId"] = new SelectList(_context.Citizen, "Id", "Id", request.CitizenId);
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "Id", "Id", request.SpecialistId);
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "Id", "Id", request.StatusId);
            return View(request);
        }

        // POST: Request/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,RequestDescription,CreatedAt,QueuedNumber,CitizenId,SpecialistId,StatusId")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Id))
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
            ViewData["CitizenId"] = new SelectList(_context.Citizen, "Id", "Id", request.CitizenId);
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "Id", "Id", request.SpecialistId);
            ViewData["StatusId"] = new SelectList(_context.RequestStatus, "Id", "Id", request.StatusId);
            return View(request);
        }

        // GET: Request/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .Include(r => r.Citizen)
                .Include(r => r.Specialist)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Request.FindAsync(id);
            _context.Request.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.Id == id);
        }
    }
}
