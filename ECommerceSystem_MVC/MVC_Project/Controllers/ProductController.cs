using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Seller")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles="User")]
        public IActionResult Buy()
        {
            return View();
        }
    }
}
