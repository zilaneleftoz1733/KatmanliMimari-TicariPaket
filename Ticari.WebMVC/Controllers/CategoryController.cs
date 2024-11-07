using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Ticari.Entities.Entities.Concrete;
using Ticari.WebMVC.Models;

namespace Ticari.WebMVC.Controllers
{
    public class CategoryController(IHttpClientFactory httpClientFactory) : MyController(httpClientFactory)
    {
        public async Task<IActionResult> Index()
        {
            var categoryies = await httpClient.GetFromJsonAsync<List<Category>>("/api/category/index");
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

            var responsstr = await result.Content.ReadAsStringAsync();
            //{"type":"https://tools.ietf.org/html/rfc9110#section-15.5.1","title":"One or more validation errors occurred."
            //,"status":400,
            //"errors":{"Description":["Acıklama alani boş olamaz"],
            //"CategoryName":["En az 2 karakter olmalidir"]},
            //"traceId":"00-a6bb1f6dd09919153ecc62adb97b9e61-a68057aea923cd69-00"}
            // if(result)
            var apiResult = JsonSerializer.Deserialize<ApiResult>(responsstr);


            return View(category);
        }
        //public class Errors
        //{
        //    public List<string> Description { get; set; }
        //    public List<string> CategoryName { get; set; }
        //}

        public class ApiResult
        {
            public string type { get; set; }
            public int status { get; set; }

            public Dictionary<string, string> errors { get; set; }
            public string traceId { get; set; }
            public bool hasError { get; set; }
        }
    }
}