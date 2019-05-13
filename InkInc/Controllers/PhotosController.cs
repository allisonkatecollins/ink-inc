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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace InkInc.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _context;

        //needed to access full path to delete photo
        private readonly IHostingEnvironment _hostEnviro;

        //access the currently authenticated user
        private readonly UserManager<User> _userManager;

        //inject UserManager service
        public PhotosController(ApplicationDbContext context, UserManager<User> userManager, IHostingEnvironment hostingEnvironment)
        {
            _hostEnviro = hostingEnvironment;
            _userManager = userManager;
            _context = context;
        }

        //allows any method that needs to see who the user is to invoke the method
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Photos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Photo.ToListAsync());
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilePath,IsDisplayPhoto,UserId")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(photo);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(photo);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //get current logged in user
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var photo = await _context.Photo.FindAsync(id);

            //====== delete from file structure ========

            //get photo's file path, use Substring method to return the rest of the string starting at index 2
            //index at 2 removes the tilde and the first slash
            //so this method returns wwwroot/images/filename instead of ~/images/filename (full file path instead of relative)
            //store in variable pathSansTilde, which is /images/
            //Substring creates a new string minus the first 2 characters - doesn't modify string, but creates new one
            var pathSansTilde = photo.FilePath.Substring(2);
            //use same process as we used to save photo in UsersController with Path.Combine
            var fullPath = Path.Combine(_hostEnviro.WebRootPath, pathSansTilde);

            if (System.IO.File.Exists(fullPath))
                {
                   System.IO.File.Delete(fullPath);
                }   
            
            //delete from database
            _context.Photo.Remove(photo);
            await _context.SaveChangesAsync();

            //after deleting, redirect to current logged in user's details page
            return RedirectToAction("Details", "Users", new { id = user.Id });
        }


    private bool PhotoExists(int id)
        {
            return _context.Photo.Any(e => e.Id == id);
        }
     }
}
