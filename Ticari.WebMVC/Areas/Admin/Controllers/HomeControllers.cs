using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ticari.WebMVC.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Area("Admin")]
        [Authorize]
            public IActionResult Index()
            {
                var cookies = HttpContext.Request.Cookies;
                return View();
            }
        }
}
