using Microsoft.AspNetCore.Mvc;
using Ticari.Entities.Entities.Concrete;
using Ticari.BusinessLayer.Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using FluentValidation;
using Ticari.Api.Model;
using System.Text.Json;
using FluentValidation.Results;



namespace Ticari.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
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
            ApiResult apiResult = new();
            ValidationResult validateResult = await validator.ValidateAsync(category);
            if (!validateResult.IsValid)
            {
                apiResult.hasError = true;

                foreach (var failure in validateResult.Errors)
                {
                    apiResult.errors.Add(failure.PropertyName, failure.ErrorCode);
                }
                var apiResultStr = JsonSerializer.Serialize<ApiResult>(apiResult);
                return Results.Problem(apiResultStr);
            }

            int result = manager.Create(category);
            if (result > 0)
            {

                apiResult.hasError = false;

                return Results.Ok(apiResult);
            }
            return Results.Problem("Beklenmedik bir hata olustu");
        }
    }
}