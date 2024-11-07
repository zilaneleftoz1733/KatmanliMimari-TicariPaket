using Microsoft.AspNetCore.Mvc;

namespace Ticari.WebMVC.Models
{
    public class MyController : Controller
    {
        public readonly HttpClient httpClient;

        public MyController(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient.CreateClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:7003");
        }
    }
}