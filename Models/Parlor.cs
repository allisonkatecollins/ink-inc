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
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name = "Address")]
        public string FullAddress
        {
            get
            {
                return $"{StreetAddress}, {City}, {State}";
            }
        }

        [Required]
        public int OpenTime { get; set; }

        [Required]
        public int CloseTime { get; set; }

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

        public User User { get; set; }
    }
}
