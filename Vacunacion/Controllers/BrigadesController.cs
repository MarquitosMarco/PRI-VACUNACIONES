using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vacunacion.Data;
using Vacunacion.Models;

namespace Vacunacion.Controllers
{
    public class BrigadesController : Controller
    {
        private readonly DB_Context _context;

        public BrigadesController(DB_Context context)
        {
            _context = context;
        }

        // GET: Brigades
        public async Task<IActionResult> Index()
        {
              return _context.Brigade != null ? 
                          View(await _context.Brigade.ToListAsync()) :
                          Problem("Entity set 'DB_Context.Brigade'  is null.");
        }

        // GET: Brigades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brigade == null)
            {
                return NotFound();
            }

            var brigade = await _context.Brigade
                .FirstOrDefaultAsync(m => m.BrigadeId == id);
            if (brigade == null)
            {
                return NotFound();
            }

            return View(brigade);
        }

        // GET: Brigades/Create
        public IActionResult Create()
        {
            ViewBag.CampaignId = new SelectList(_context.Campaign, "CampaignId", "Name");
            return View();
        }

        // POST: Brigades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrigadeId,Name,Description,Latitude,Longitude,CampaignId")] Brigade brigade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brigade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brigade);
        }

        // GET: Brigades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.CampaignId = new SelectList(_context.Campaign, "CampaignId", "Name");
            if (id == null || _context.Brigade == null)
            {
                return NotFound();
            }

            var brigade = await _context.Brigade.FindAsync(id);
            if (brigade == null)
            {
                return NotFound();
            }
            return View(brigade);
        }

        // POST: Brigades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrigadeId,Name,Description,Latitude,Longitude,CampaignId")] Brigade brigade)
        {
            if (id != brigade.BrigadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brigade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrigadeExists(brigade.BrigadeId))
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
            return View(brigade);
        }

        // GET: Brigades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brigade == null)
            {
                return NotFound();
            }

            var brigade = await _context.Brigade
                .FirstOrDefaultAsync(m => m.BrigadeId == id);
            if (brigade == null)
            {
                return NotFound();
            }

            return View(brigade);
        }

        // POST: Brigades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brigade == null)
            {
                return Problem("Entity set 'DB_Context.Brigade'  is null.");
            }
            var brigade = await _context.Brigade.FindAsync(id);
            if (brigade != null)
            {
                _context.Brigade.Remove(brigade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrigadeExists(int id)
        {
          return (_context.Brigade?.Any(e => e.BrigadeId == id)).GetValueOrDefault();
        }
    }
}
