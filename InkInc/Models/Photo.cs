using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InkInc.Models
{
    public class Photo
    {
        public int Id { get; set; }
        
        [Display(Name = "Upload a photo of your work:")]
        public string FilePath { get; set; }

        public string UserId { get; set; }
    }
}
