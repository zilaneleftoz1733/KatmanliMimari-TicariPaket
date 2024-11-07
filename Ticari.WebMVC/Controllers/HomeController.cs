using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Ticari.Entities.DBContexts;
using Ticari.WebMVC.Models;

namespace Ticari.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService notyfService;
        private readonly TurkiyeContext turkiyeContext;

        public HomeController(ILogger<HomeController> logger, INotyfService notyfService, TurkiyeContext turkiyeContext)
        {
            _logger = logger;
            this.notyfService = notyfService;
            this.turkiyeContext = turkiyeContext;
        }

        public IActionResult Index()
        {

            //notyfService.Success("ISlem Basarili");
            //notyfService.Error("Hatali i?lem");
            //notyfService.Information("ISlem Tamam");
            //notyfService.Warning("Dikkat..");
            List<SelectListItem> illerlist = new List<SelectListItem>();
            var iller = turkiyeContext.TblIls.ToList();

            foreach (var item in iller)
            {
                SelectListItem listItem = new SelectListItem
                {
                    Disabled = false,
                    Selected = false,
                    Text = item.IlAd,
                    Value = item.IlId.ToString(),
                };
                illerlist.Add(listItem);
            }

            ViewBag.List = illerlist;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}