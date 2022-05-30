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
    public class SocialServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SocialServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SocialService
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocialService.ToListAsync());
        }

        // GET: SocialService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialService = await _context.SocialService
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialService == null)
            {
                return NotFound();
            }

            return View(socialService);
        }

        // GET: SocialService/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ServiceDescription")] SocialService socialService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialService);
        }

        // GET: SocialService/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialService = await _context.SocialService.FindAsync(id);
            if (socialService == null)
            {
                return NotFound();
            }
            return View(socialService);
        }

        // POST: SocialService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ServiceDescription")] SocialService socialService)
        {
            if (id != socialService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialServiceExists(socialService.Id))
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
            return View(socialService);
        }

        // GET: SocialService/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialService = await _context.SocialService
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialService == null)
            {
                return NotFound();
            }

            return View(socialService);
        }

        // POST: SocialService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialService = await _context.SocialService.FindAsync(id);
            _context.SocialService.Remove(socialService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialServiceExists(int id)
        {
            return _context.SocialService.Any(e => e.Id == id);
        }
    }
}
