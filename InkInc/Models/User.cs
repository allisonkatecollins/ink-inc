using InkInc.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InkInc.Models
{
    //IdentityUser is the model created when a user registers
    //the colon enables the user to inherit all the properties of IdentityUser, which were automatically generated
    public class User : IdentityUser
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
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

        public Parlor Parlor { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
