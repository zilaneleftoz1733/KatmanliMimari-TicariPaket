using Microsoft.AspNetCore.Mvc;
using Ticari.Entities.Entities.Concrete;
using Ticari.BusinessLayer.Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using FluentValidation;



namespace Ticari.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class CategoryController(IManager<Category> manager, IValidator<Category> validator) : ControllerBase
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

            var validateResult = validator.Validate(category);
            if (!validateResult.IsValid)
            {

                return Results.Ok(validateResult.Errors.FirstOrDefault().ErrorMessage);
            }

            int result = manager.Create(category);
            if (result > 0)
            {
                return Results.Created();
            }
            return Results.Problem("Beklenmedik bir hata olustu");
        }
    }
}
