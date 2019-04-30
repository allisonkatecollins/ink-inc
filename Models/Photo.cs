using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkInc.Models
{
    public class Photo
    {
        public int Id { get; set; }
         
        public string Description { get; set; }

        public bool IsDisplayPhoto { get; set; }
    }
}
