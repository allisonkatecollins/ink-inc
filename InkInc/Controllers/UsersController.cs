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

        //======= parlor dropdown list ===========
        public List<SelectListItem> ParlorsEditList()
        {
            //access db
            var parlors = _context.Parlor;
            List<SelectListItem> parlorOptions = new List<SelectListItem>();

            //gives option of selecting a ParlorId value of null
            parlorOptions.Insert(0, new SelectListItem
            {
                Text = "--Select your parlor--",
                Value = null,
                Selected = true
            });

            foreach (var p in parlors)
            {
                //each parlor displayed by name
                SelectListItem li = new SelectListItem
                {
                    Value = p.ParlorId.ToString(),
                    Text = p.Name
                };
                parlorOptions.Add(li);
            }
            return parlorOptions;
        }

        // GET: User
        public async Task<IActionResult> Index(string searchUserLocation)
        {
            //index if nothing has been searched
            if (string.IsNullOrEmpty(searchUserLocation))
            {
                var applicationDbContext = _context.User
                    .Include(u => u.Parlor);
                return View(await applicationDbContext.ToListAsync());
            }

            //index if something has been searched
            if (!string.IsNullOrEmpty(searchUserLocation))
            {
                var applicationDbContext = _context.User
                    .Include(u => u.Parlor)
                    .Where(u => u.Parlor.City.Contains(searchUserLocation) || u.Parlor.State.Contains(searchUserLocation));
                return View(await applicationDbContext.ToListAsync());
            }

            return View();
        }

        // ====== USER PROFILE =========
        // GET PROFILE: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
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

        //============== UPLOAD PHOTOS ====================
        //GET UploadPhoto view - exists in Photos view folder
        public async Task<IActionResult> GetUploadPhoto()
        {
            UserDetailsViewModel viewModel = new UserDetailsViewModel();
            return View("../Photos/UploadPhoto", viewModel);
        }

        //POST PHOTO: User/Details/GetUploadPhoto
        //this method is very similar to User/Create method scaffolded by ASP.NET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadPhoto(UserDetailsViewModel viewModel)
        {
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                //fetch user asynchronously
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (viewModel.ImageToSave != null)
                {
                    //FileName is a built-in property of type IFormFile, which was declared in the view model
                    var uniqueFileName = GetUniqueFileName(viewModel.ImageToSave.FileName);
                    //save uploaded images to "images" folder in wwwroot folder
                    var uploads = Path.Combine(_hostEnviro.WebRootPath, "images");
                    var filePath = Path.Combine(uploads, uniqueFileName);

                    //filestream = representation of bytes of a file
                    //using block closes the FileStream so the OS knows it's finished using the file
                    //if not closed, could throw an error when I try to delete a photo
                    using (var portfolioImg = new FileStream(filePath, FileMode.Create))
                    {
                        viewModel.ImageToSave.CopyTo(portfolioImg);
                    }

                    //instantiate new photo to be sent to db
                    Photo photo = new Photo()
                    {
                        //tilde makes it a relative path, meaning the browser reads back through wwwroot folder
                        FilePath = "~/images/" + uniqueFileName,
                        UserId = user.Id
                    };

                    //access Photo table, which exists in the db - unlike the view model
                    _context.Add(photo);
                    //adds photo to db
                    await _context.SaveChangesAsync();
                }

                //return to Details page with images; access URL of specific user
                return RedirectToAction(nameof(Details), new { id = user.Id });
            }

            //if none of the above works, just show Details
            return View("Details");
        }
        //============== END PHOTO UPLOAD =====================

        //======== EDIT PROFILE ================
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

            //null option for parlor edit
            var parlors = _context.Parlor.ToList();

            List<SelectListItem> ParlorOptions = new List<SelectListItem>();

            ParlorOptions.Insert(0, new SelectListItem
            {
                Text = "No parlor",
                Value = null,
                Selected = true
            });

            foreach (var p in parlors)
            {
                SelectListItem li = new SelectListItem
                {
                    Value = p.ParlorId.ToString(),
                    Text = p.Name
                };
                ParlorOptions.Add(li);
            }

            var User = await _context.User.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            //variables from view model equals local variables
            UserEditViewModel viewModel = new UserEditViewModel
            {
                User = User,
                ParlorOptions = ParlorOptions
            };
            return View(viewModel);

        //} else
        //{
        //    return View();
        //}
        //    ViewData["ParlorId"] = new SelectList (_context.Parlor, "ParlorId", "Name", User.ParlorId);
        //    return View(User);
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
