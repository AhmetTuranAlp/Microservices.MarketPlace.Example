using FluentValidation;
using Microservices.MarketPlace.Example.Web.Models.Products;

namespace Microservices.MarketPlace.Example.Web.Validators
{
    public class ProductUpdateInputValidator : AbstractValidator<ProductUpdateInput>
    {
        public ProductUpdateInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("isim alanı boş olamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("açıklama alanı boş olamaz");
            RuleFor(x => x.SalePrice).NotEmpty().WithMessage("fiyat alanı boş olamaz").ScalePrecision(2, 6).WithMessage("hatalı para formatı");
        }
    }
}
