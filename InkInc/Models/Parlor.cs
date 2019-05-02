using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InkInc.Models
{
    public class Parlor
    {
        [Required]
        public int ParlorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "City")]
        public string CityAndState
        {
            get
            {
                return $"{City}, {State}";
            }
        }

        [Display(Name = "Address")]
        public string FullAddress
        {
            get
            {
                return $"{StreetAddress}, {City}, {State}";
            }
        }

        [Required]
        public string OpenTime { get; set; }

        [Required]
        public string CloseTime { get; set; }

        [Required]
        public string DaysOpen { get; set; }

        [Display(Name = "Hours of Operation")]
        public string Hours
        {
            get
            {
                return $"{OpenTime} - {CloseTime}, {DaysOpen}";
            }
        }

        [Required]
        public string OwnerId { get; set; }

        [Display(Name = "Contact Us")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
