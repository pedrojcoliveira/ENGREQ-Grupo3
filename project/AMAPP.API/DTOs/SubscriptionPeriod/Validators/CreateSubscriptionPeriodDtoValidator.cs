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
                .GreaterThanOrEqualTo(x => x.StartDate).WithMessage("A data de término do periodo de subscrição deve ser igual ou superior à data de início.");
             
            RuleForEach(x => x.Dates)
                //.SetValidator(new CreateDeliveryDateDtoValidator())
                .Must((dto, date) => date.Date >= dto.StartDate && date.Date <= dto.EndDate)
                .WithMessage("Cada data de entrega deve estar dentro do período de subscrição.");
            
        }
    }
}