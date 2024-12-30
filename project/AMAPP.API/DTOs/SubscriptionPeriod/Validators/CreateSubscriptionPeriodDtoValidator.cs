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
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(2, 50).WithMessage("O nome deve ter entre 2 e 50 caracteres.");

            /*RuleFor(x => x.StartDate)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("A data de início deve ser hoje ou no futuro.");
            */

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate).WithMessage("A data de término deve ser após a data de início.");
        }
    }
}