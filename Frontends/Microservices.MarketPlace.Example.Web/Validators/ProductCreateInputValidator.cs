using FluentValidation;
using Microservices.MarketPlace.Example.Web.Models.Products;

namespace Microservices.MarketPlace.Example.Web.Validators
{
    public class ProductCreateInputValidator : AbstractValidator<ProductCreateInput>
    {
        public ProductCreateInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş olamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş olamaz");
            RuleFor(x => x.SalePrice).NotEmpty().WithMessage("Fiyat alanı boş olamaz").ScalePrecision(2, 12).WithMessage("Hatalı para formatı");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori alanı seçiniz");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Marka alanı seçiniz");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stok alanı boş olamaz");
        }
    }
}
