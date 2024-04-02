using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MvcAuthApp.Controllers

{
    public class ReservedController : Controller
    {
        
        [Authorize (Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }
        [Authorize (Roles = "User")]
        public IActionResult User()
        {
            return View();
        }

    }
}
