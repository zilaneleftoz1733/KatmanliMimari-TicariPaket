using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Ticari.Entities.Entities.Concrete;
using Ticari.WebMVC.Models;

namespace Ticari.WebMVC.Controllers
{
    public class CategoryController(IHttpClientFactory httpClientFactory) : MyController(httpClientFactory)
    {
        public async Task<IActionResult> Index()
        {
            var categoryies = await HttpClient.GetFromJsonAsync<List<Category>>("/api/category/index");
            return View(categoryies);
        }
        public async Task<IActionResult> Create()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {

            var result = await httpClient.PostAsJsonAsync<Category>("/api/category/insert", category);
            // if(result)
            return View(category);
        }
    }
}
