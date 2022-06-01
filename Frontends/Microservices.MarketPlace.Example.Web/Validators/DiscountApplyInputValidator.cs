using FluentValidation;
using Microservices.MarketPlace.Example.Web.Models.Discounts;

namespace Microservices.MarketPlace.Example.Web.Validators
{
    public class DiscountApplyInputValidator : AbstractValidator<DiscountApplyInput>
    {
        public DiscountApplyInputValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("indirim kupon alanı boş olamaz");
        }
    }
}
