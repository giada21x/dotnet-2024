using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MvcAuthApp.Controllers

{
    public class ReservedController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
