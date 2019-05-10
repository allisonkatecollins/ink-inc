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
using InkInc.Models.View_Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace InkInc.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostEnviro;
        //access the currently authenticated user
        private readonly UserManager<User> _userManager;

        //inject UserManager service
        //IHostingEnvironment needed to upload; built into ASP.NET
        public UsersController(IHostingEnvironment hostingEnvironment, ApplicationDbContext context, UserManager<User> userManager)
        {
            _hostEnviro = hostingEnvironment;
            _userManager = userManager;
            _context = context;
        }

        //getting current user (whoever is logged in) into the system
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //method to prevent user from uploading 2 images with same name
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

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
        //get current logged in user
        //var user = await _userManager.GetUserAsync(HttpContext.User);
            if (id == null)
            {
                return NotFound();
            }

            UserDetailsViewModel viewModel = new UserDetailsViewModel();

            var User = await _context.User
                .Include(u => u.Parlor)
                .Include(u => u.Photos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }

            //User defined in viewModel = User defined above
            viewModel.User = User;

            return View(viewModel);
        }

        // GET: User/Create
        public async Task<IActionResult> Create()
        {
            //get current logged in user
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewData["ParlorId"] = new SelectList(_context.Parlor, "ParlorId", "Name");
            //return specified user
            return View(user);
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,FirstName,LastName,BaselinePricing,PricePerHour,InstagramHandle,Biography,ParlorId")] User User)
        {
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
            //access user that's logged in
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            //edit only available for logged in user's profile
            if (id == null || id != currentUser.Id)
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
            //access user that's logged in
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (id != User.Id || id != currentUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //update current user with every property that I've determined to be updateable 
                try
                {
                    currentUser.FirstName = User.FirstName;
                    currentUser.LastName = User.LastName;
                    currentUser.BaselinePricing = User.BaselinePricing;
                    currentUser.PricePerHour = User.PricePerHour;
                    currentUser.InstagramHandle = User.InstagramHandle;
                    currentUser.Biography = User.Biography;
                    currentUser.ParlorId = User.ParlorId;

                    //changed this from User to currentUser
                    _context.Update(currentUser);
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
