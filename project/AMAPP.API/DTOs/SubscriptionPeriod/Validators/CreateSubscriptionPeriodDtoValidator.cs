using FluentValidation;
using System;
using System.Linq;

namespace AMAPP.API.DTOs.SubscriptionPeriod.Validators
{
    public class CreateSubscriptionPeriodDtoValidator : AbstractValidator<CreateSubscriptionPeriodDto>
    {
        public CreateSubscriptionPeriodDtoValidator()
        {
            
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
            

            RuleFor(x => x.StartDate)
                .GreaterThan(DateTime.Now).WithMessage("Start date must be in the future.");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate).WithMessage("End date must be after the start date.");
            /*
            RuleFor(x => x.SelectedProductOfferIds)
                .NotEmpty().WithMessage("Selected product offer IDs are required.")
                .Must(ids => ids.All(id => id > 0)).WithMessage("All selected product offer IDs must be greater than 0.");

            RuleFor(x => x.ProductOfferIds)
                .NotEmpty().WithMessage("Product offer IDs are required.")
                .Must(ids => ids.All(id => id > 0)).WithMessage("All product offer IDs must be greater than 0.");
            */
        }
    }
}