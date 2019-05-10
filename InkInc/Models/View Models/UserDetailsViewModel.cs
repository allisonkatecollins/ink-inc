using Microsoft.AspNetCore.Http;

namespace InkInc.Models.View_Models
{
    public class UserDetailsViewModel
    {
        public User User { get; set; }

        public IFormFile ImageToSave { get; set; }

        public Photo Photo { get; set; }
    }
}
