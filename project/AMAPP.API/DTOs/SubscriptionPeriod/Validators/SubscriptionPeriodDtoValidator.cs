using FluentValidation;
using System;

namespace AMAPP.API.DTOs.SubscriptionPeriod.Validators
{
    public class SubscriptionPeriodDtoValidator : AbstractValidator<SubscriptionPeriodDto>
    {
        public SubscriptionPeriodDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
            RuleFor(x => x.StartDate)
                .GreaterThan(DateTime.Now).WithMessage("Start date must be in the future.");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate).WithMessage("End date must be after the start date.");
        }
    }
}