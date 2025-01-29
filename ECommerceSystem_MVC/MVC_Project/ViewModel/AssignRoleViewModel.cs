using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Project.ViewModel
{
    public class AssignRoleViewModel
    {
        public string UserId { get; set; } // ID of the user
        public string UserName { get; set; } // Username for display
        public List<SelectListItem> Roles { get; set; } // List of roles for selection
        public List<string> SelectedRoles { get; set; } // Roles selected by the admin
    }
}
