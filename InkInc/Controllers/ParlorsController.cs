using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InkInc.Data;
using InkInc.Models;

namespace InkInc.Controllers
{
    public class ParlorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParlorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parlors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parlor.ToListAsync());
        }

        // GET: Parlors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parlor = await _context.Parlor
                .Include(p => p.Users)
                .FirstOrDefaultAsync(p => p.ParlorId == id);

            if (parlor == null)
            {
                return NotFound();
            }

            return View(parlor);
        }

        // GET: Parlors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parlors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParlorId,Name,StreetAddress,City,State,OpenTime,CloseTime,DaysOpen,OwnerId")] Parlor parlor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parlor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parlor);
        }

        // GET: Parlors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parlor = await _context.Parlor.FindAsync(id);
            if (parlor == null)
            {
                return NotFound();
            }
            return View(parlor);
        }

        // POST: Parlors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParlorId,Name,StreetAddress,City,State,OpenTime,CloseTime,DaysOpen,OwnerId")] Parlor parlor)
        {
            if (id != parlor.ParlorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parlor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParlorExists(parlor.ParlorId))
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
            return View(parlor);
        }

        // GET: Parlors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parlor = await _context.Parlor
                .FirstOrDefaultAsync(m => m.ParlorId == id);
            if (parlor == null)
            {
                return NotFound();
            }

            return View(parlor);
        }

        // POST: Parlors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parlor = await _context.Parlor.FindAsync(id);
            _context.Parlor.Remove(parlor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParlorExists(int id)
        {
            return _context.Parlor.Any(e => e.ParlorId == id);
        }
    }
}
