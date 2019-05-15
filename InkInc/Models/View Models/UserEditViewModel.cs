//this view model needed for parlor drop down in User Edit to include a null option

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InkInc.Models.View_Models
{
    public class UserEditViewModel
    {
        public User User { get; set; }

        public Parlor Parlor { get; set; }

        public IEnumerable<SelectListItem> ParlorOptions { get; set; }
    }
}
