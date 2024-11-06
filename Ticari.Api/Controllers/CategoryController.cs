using Microsoft.AspNetCore.Mvc;
using Ticari.Entities.Entities.Concrete;
using Ticari.BusinessLayer.Managers.Abstract;



namespace Ticari.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class CategoryController(IManager<Category> manager) : ControllerBase
    {

        [HttpGet]
        public async Task<IResult> Index()
        {
            var result = manager.GetAll();
            if (result != null)
            {
                return Results.Ok(result);
            }
            return Results.NoContent();
        }
        [HttpGet]
        public async Task<IResult> GetCategory(int id)
        {
            var result = manager.Get(p => p.Id == id);
            if (result != null)
            {
                return Results.Ok(result);
            }
            return Results.NoContent();
        }
        [HttpPost]
        public async Task<IResult> Insert(Category category)
        {
            int result = manager.Create(category);
            if (result > 0)
            {
                return Results.Created();
            }
            return Results.Problem();
        }
    }
}
