using AMAPP.API.DTOs.ProductOffer.Validators;
using AMAPP.API.DTOs.ProductOffer;
using AMAPP.API.DTOs.Subscription;
using AMAPP.API.Services.Interfaces;
using AMAPP.API.Repository.SubscriptionRepository;
using AMAPP.API.Repository.SubscriptionPeriodRepository;
using AMAPP.API.Repository.ProductOfferRepository;
using AMAPP.API.Models;
using AutoMapper;
using AMAPP.API.Migrations;

namespace AMAPP.API.Services.Implementations
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ISubscriptionPeriodRepository _subscriptionPeriodRepository;
        private readonly IProductOfferRepository _productOfferRepository;
        private readonly IMapper _mapper;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, ISubscriptionPeriodRepository subscriptionPeriodRepository, IProductOfferRepository productOfferRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _subscriptionPeriodRepository = subscriptionPeriodRepository;
            _productOfferRepository = productOfferRepository;
            _mapper = mapper;
        }

        public async Task<SubscriptionDto> AddSubscriptionAsync(CreateSubscriptionDto subscriptionDto)
        {
            // Validação do DTO
            //var validationResult = await _createSubscriptionDtoValidator.ValidateAsync(subscriptionDto);
            //if (!validationResult.IsValid)
            //{
            //    throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            //}

            // Validar se o SubscriptionPeriodId existe
            var subscriptionPeriod = await _subscriptionPeriodRepository.GetByIdAsync(subscriptionDto.SubscriptionPeriodId);
            if (subscriptionPeriod == null)
            {
                throw new Exception("Período de subscrição inválido.");
            }

            // Validar se os ProductOfferIds existem
            var productOffers = await _productOfferRepository.GetProductOffersByIds(subscriptionDto.SubscriptionProductOffers.Select(spo => spo.ProductOfferId));
            if (productOffers.Count() != subscriptionDto.SubscriptionProductOffers.Count())
            {
                throw new Exception("Uma ou mais ofertas de produto são inválidas.");
            }


            //TODO obter user pelo toke e atribuir ao subscription
            var coproducerInfoId = 1;

            var subscription = new Subscription
            {
                SubscriptionPeriodId = subscriptionDto.SubscriptionPeriodId,
                CoproducerInfoId = coproducerInfoId
            };

            subscription.SelectedProductOffers = CreateSubscritionProductOffers(productOffers, subscriptionDto);

            _subscriptionRepository.Add(subscription);


            return _mapper.Map<SubscriptionDto>(subscription);
        }

        private List<SelectedProductOffer> CreateSubscritionProductOffers(List<ProductOffer> productOffers, CreateSubscriptionDto subscriptionDto)
        {
            List<SelectedProductOffer> selectedProductOffers = new();

            foreach (var subscriptionProductOffer in subscriptionDto.SubscriptionProductOffers)
            {

                var selectedProductOffer = new SelectedProductOffer
                {
                    ProductOfferId = subscriptionProductOffer.ProductOfferId
                };

                var productPrice = productOffers.FirstOrDefault(po => po.Id == subscriptionProductOffer.ProductOfferId).Product.ReferencePrice;

                selectedProductOffer.SelectedProductOfferDeliveries =  CreateProductOfferDelivery(subscriptionProductOffer.SubscriptionProductOfferDates, selectedProductOffer.Id, productPrice);
                selectedProductOffer.Payments = CreatePayments(selectedProductOffer, subscriptionProductOffer);

                selectedProductOffers.Add(selectedProductOffer);
            }

            return selectedProductOffers;
        }

        private ICollection<Payment> CreatePayments(SelectedProductOffer selectedProductOffer, SubscriptionProductOffers subscriptionProductOffer)
        {
            List<Payment> payments = new();

            if (subscriptionProductOffer.PaymentMode == Constants.PaymentMode.Fracionado)
            {
                foreach (var selectedProductOfferDelivery in selectedProductOffer.SelectedProductOfferDeliveries)
                {
                    var payment = new Payment
                    {
                        SelectedProductOfferId = selectedProductOffer.Id,
                        PaymentMode = Constants.PaymentMode.Fracionado,
                        PaymentMethod = subscriptionProductOffer.PaymentMethod,
                        Amount = selectedProductOfferDelivery.Price * selectedProductOfferDelivery.Amount,
                        Status = Constants.PaymentStatus.Pendente,
                        PaymentDate = selectedProductOfferDelivery.DeliveryDate,
                        // TODO
                        //SelectedProductOfferDeliveryId = selectedProductOfferDelivery.Id
                    };

                    payments.Add(payment);
                }
            } else
            {
                var query = selectedProductOffer.SelectedProductOfferDeliveries.OrderBy(s => s.DeliveryDate);
                var deliveryDate = query.FirstOrDefault().DeliveryDate; 
                var totalAmount = query.Sum(s => s.Amount);

                var payment = new Payment
                {
                    SelectedProductOfferId = selectedProductOffer.Id,
                    PaymentMode = Constants.PaymentMode.Fracionado,
                    PaymentMethod = subscriptionProductOffer.PaymentMethod,
                    Amount = totalAmount,
                    Status = Constants.PaymentStatus.Pendente,
                    PaymentDate = deliveryDate
                };

                payments.Add(payment);

            }

            return payments;    
        }

        private List<SelectedProductOfferDelivery> CreateProductOfferDelivery(List<SubscriptionProductOfferDates> SubscriptionProductOfferDates, int id, double productPrice)
        {
            List<SelectedProductOfferDelivery> selectedProductOfferDeliveries = new();

            foreach (var subscriptionProductOfferDate in SubscriptionProductOfferDates)
            {
                var selectedProductOffer = new SelectedProductOfferDelivery
                {
                    SelectedProductOfferId = id,
                    Amount = subscriptionProductOfferDate.Amount,
                    DeliveredAmount = subscriptionProductOfferDate.Amount,
                    DeliveryDate = subscriptionProductOfferDate.DeliveryDate,
                    Price = productPrice,
                    Status = Constants.DeliveryStatus.NaoEntregue
                };

                selectedProductOfferDeliveries.Add(selectedProductOffer);
            }

            return selectedProductOfferDeliveries;
        }
    }
}
