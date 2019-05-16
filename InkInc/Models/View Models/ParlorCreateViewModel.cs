using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InkInc.Models.View_Models
{
    public class ParlorCreateViewModel
    {
        public Parlor Parlor { get; set; }

        public User User { get; set; }

        [Required]
        public int ParlorId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address")]
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
        [Display(Name = "Opening Time")]
        public string OpenTime { get; set; }

        [Required]
        [Display(Name = "Closing Time")]
        public string CloseTime { get; set; }

        [Required]
        [Display(Name = "Days Open")]
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
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
