using FluentValidation;
using System;
using System.Linq;

namespace AMAPP.API.DTOs.Subscription.Validators
{
    public class CreateSubscriptionDtoValidator : AbstractValidator<CreateSubscriptionDto>
    {
        public CreateSubscriptionDtoValidator()
        {
            /*
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters."); */

            RuleFor(x => x.Duration)
                .IsInEnum().WithMessage("Invalid subscription duration.");

            RuleFor(x => x.StartDate)
                .GreaterThan(DateTime.Now).WithMessage("Start date must be in the future.");

            RuleFor(x => x.DeliveryDates)
                .NotEmpty().WithMessage("Delivery dates are required.")
                .Must((dto, dates) => dates.All(date => date > DateTime.Now && date > dto.StartDate))
                .WithMessage("All delivery dates must be in the future and after the start date.");
            
            RuleFor(x => (long)x.ProducerId)
                .GreaterThan(0).WithMessage("Producer ID must be greater than 0.");
            
        }
    }
}