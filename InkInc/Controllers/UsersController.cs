using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InkInc.Data;
using InkInc.Models;
using Microsoft.AspNetCore.Identity;

namespace InkInc.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        //access the currently authenticated user
        private readonly UserManager<User> _userManager;

        //inject UserManager service
        public UsersController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        //getting current user (whoever is logged in) into the system
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: User
        public async Task<IActionResult> Index(string searchUserCity)
        {
            //index if nothing has been searched
            if (string.IsNullOrEmpty(searchUserCity))
            {
                var applicationDbContext = _context.User
                    .Include(u => u.Parlor);
                return View(await applicationDbContext.ToListAsync());
            }

            //index if something has been searched
            if (!string.IsNullOrEmpty(searchUserCity)) 
            {
                var applicationDbContext = _context.User
                    .Include(u => u.Parlor)
                    .Where(u => u.Parlor.City.Contains(searchUserCity));
                return View(await applicationDbContext.ToListAsync());
            }

            return View();
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var User = await _context.User
                .Include(u => u.Parlor)
                .Include(u => u.Photos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            return View(User);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            //generated in case I need to make a dropdown - not currently needed
            ViewData["ParlorId"] = new SelectList(_context.Parlor, "ParlorId", "Name");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,FirstName,LastName,BaselinePricing,PricePerHour,InstagramHandle,Biography,ParlorId")] User User)
        {
            //let the info post to DB
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                //fetch user asynchronously
                var user = await _userManager.GetUserAsync(HttpContext.User);
                _context.Add(User);
                await _context.SaveChangesAsync();
                //return to artist index
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParlorId"] = new SelectList(_context.Parlor, "ParlorId", "Name", User.ParlorId);
            return View(User);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var User = await _context.User.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            ViewData["ParlorId"] = new SelectList(_context.Parlor, "ParlorId", "Name", User.ParlorId);
            return View(User);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email,FirstName,LastName,BaselinePricing,PricePerHour,InstagramHandle,Biography,ParlorId")] User User)
        {
            if (id != User.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(User);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(User.Id))
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
            ViewData["ParlorId"] = new SelectList(_context.Parlor, "ParlorId", "Name", User.ParlorId);
            return View(User);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var User = await _context.User
                .Include(u => u.Parlor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            return View(User);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var User = await _context.User.FindAsync(id);
            _context.User.Remove(User);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
