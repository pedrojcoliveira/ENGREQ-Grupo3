using FluentValidation;
using System;

namespace AMAPP.API.DTOs.SelectedProductOffer.Validators
{
    public class CreateSelectedProductOfferDtoValidator : AbstractValidator<CreateSelectedProductOfferDto>
    {
        public CreateSelectedProductOfferDtoValidator()
        {
            RuleFor(x => x.DeliveryDate)
                .NotEmpty().WithMessage("DeliveryDate is required.")
                .Must(date => date != default(DateTime))
                .WithMessage("DeliveryDate must not be a default value.");

            RuleFor(x => x.ProductOfferId)
                .GreaterThan(0).WithMessage("ProductOfferId must be greater than 0.");

            RuleFor(x => x.SubscriptionId)
                .GreaterThan(0).WithMessage("SubscriptionId must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            
        }
    }
}