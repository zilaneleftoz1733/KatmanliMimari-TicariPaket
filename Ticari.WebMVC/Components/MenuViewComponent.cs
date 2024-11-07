using Microsoft.AspNetCore.Mvc;
using Ticari.BusinessLayer.Managers.Abstract;
using Ticari.Entities.Entities.Concrete;

namespace Ticari.WebMVC.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IManager<Menu> menuManager;

        public MenuViewComponent(IManager<Menu> menuManager)
        {
            this.menuManager = menuManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuler = menuManager.GetAll();
            return View(menuler);
        }
    }
}