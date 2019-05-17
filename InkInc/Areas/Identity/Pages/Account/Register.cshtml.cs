using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using InkInc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using InkInc.Data;

namespace InkInc.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        //======= parlor dropdown list ===========
        //called in register.cshtml
        public List<SelectListItem> PopulateParlorsDropDownList()
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
       
        public RegisterModel(
            ApplicationDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Baseline price")]
            public int BaselinePricing { get; set; }

            [Display(Name = "Price per hour")]
            public int PricePerHour { get; set; }

            [Display(Name = "Instagram handle")]
            public string InstagramHandle { get; set; }

            [MaxLength(500)]
            public string Biography { get; set; }

            [Display(Name = "Parlor")]
            public int? ParlorId { get; set; }

            public List<SelectListItem> parlorOptions { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new User {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    BaselinePricing = Input.BaselinePricing,
                    PricePerHour = Input.PricePerHour,
                    InstagramHandle = Input.InstagramHandle,
                    Biography = Input.Biography,
                    ParlorId = Input.ParlorId };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
