using DocumentFormat.OpenXml.Drawing.Diagrams;
using FluentValidation;
using Ticari.Entities.Entities.Concrete;


namespace Ticari.Api.Validations
{
    public class CategoryValidation : AbstractValidator<Entities.Entities.Concrete.Category>
    {
        public CategoryValidation()
        {
            RuleFor(p => p.CategoryName)
                .NotEmpty()
                .WithMessage("Category Name alani boş olamaz")
                .MinimumLength(2)
                .WithMessage("En az 2 karakter olmalidir")
                .MaximumLength(50)
                .WithMessage("50 karakterden fazla olamaz");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Acıklama alani boş olamaz")
                .MinimumLength(2)
                .WithMessage("En az 2 karakter olmalidir")
                .MaximumLength(50)
                .WithMessage("50 karakterden fazla olamaz");

        }

    }
}
