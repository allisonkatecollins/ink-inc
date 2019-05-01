﻿using Microsoft.AspNetCore.Identity;
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
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int BaselinePricing { get; set; }
        
        public int PricePerHour { get; set; }

        public string InstagramHandle { get; set; }

        public string Biography { get; set; }

        public int ParlorId { get; set; }

        public Parlor Parlor { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
