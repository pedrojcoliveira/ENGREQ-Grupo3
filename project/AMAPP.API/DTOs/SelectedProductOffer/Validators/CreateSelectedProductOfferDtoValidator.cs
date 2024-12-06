using FluentValidation;
using System;

namespace AMAPP.API.DTOs.SelectedProductOffer.Validators
{
    public class CreateSelectedProductOfferDtoValidator : AbstractValidator<CreateSelectedProductOfferDto>
    {
        public CreateSelectedProductOfferDtoValidator()
        {
            RuleFor(x => x.DeliveryDate)
                .NotEmpty().WithMessage("A data de entrega é obrigatória.")
                .Must(date => date != default(DateTime)).WithMessage("A data de entrega não deve ser um valor padrão.")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("A data de entrega deve ser hoje ou no futuro.");

            RuleFor(x => x.ProductOfferId)
                .GreaterThan(0).WithMessage("O ID da oferta de produto deve ser maior que 0.");

            RuleFor(x => x.SubscriptionId)
                .GreaterThan(0).WithMessage("O ID da assinatura deve ser maior que 0.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que 0.");
        }
    }
}