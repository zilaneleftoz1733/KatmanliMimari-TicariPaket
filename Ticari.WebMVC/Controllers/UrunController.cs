
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Ticari.Entities.Entities.Concrete;
using Ticari.Entities.EntityConfig.Concrete;
using Ticari.WebMVC.Models;

namespace Ticari.WebMVC.Controllers
{
    public class UrunController(IHttpClientFactory httpClient) : MyController(httpClient)
    {
        public async Task<IActionResult> Index()
        {


            #region Deserilize edilme durumu 
            //var resulttemp = await httpClient.GetAsync("/api/products");
            //JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            //jsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; ;

            //var productListStr = await resulttemp.Content.ReadAsStringAsync();
            //var productList = JsonSerializer.Deserialize<List<Product>>(productListStr, jsonSerializerOptions);
            #endregion

            var result = await httpClient.GetFromJsonAsync<List<Product>>("/api/products");


            return View();
        }

        public async Task<IActionResult> Insert()
        {
            return View();
        }
    }
}
