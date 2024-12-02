using FluentValidation;
using System.Linq;

namespace AMAPP.API.DTOs.SubscriptionPeriod.Validators
{
    public class CreateSubscriptionPeriodPlanDtoValidator : AbstractValidator<CreateSubscriptionPeriodPlanDto>
    {
        public CreateSubscriptionPeriodPlanDtoValidator()
        {
            RuleFor(x => x.SubscriptionPeriod)
                .NotNull().WithMessage("Subscription period is required.")
                .SetValidator(new CreateSubscriptionPeriodDtoValidator());

            RuleFor(x => x.SelectedProductOfferIds)
                .NotEmpty().WithMessage("Selected product offer IDs are required.")
                .Must(ids => ids.All(id => id > 0)).WithMessage("All selected product offer IDs must be greater than 0.");

            RuleFor(x => x.ProductOfferIds)
                .NotEmpty().WithMessage("Product offer IDs are required.")
                .Must(ids => ids.All(id => id > 0)).WithMessage("All product offer IDs must be greater than 0.");
        }
    }
}