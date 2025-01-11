using AMAPP.API.DTOs.SelectedProductOffer;
using AMAPP.API.DTOs.SubscriptionPayment;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProductOfferRepository;
using AMAPP.API.Repository.SelectedProductOfferRepository;
using AMAPP.API.Repository.SubscriptionPaymentRepository;
using AMAPP.API.Repository.SubscriptionPeriodRepository;
using AMAPP.API.Repository.SubscriptionRepository;
using AMAPP.API.Services.Interfaces;
using AMAPP.API.Utils;
using AutoMapper;

namespace AMAPP.API.Services.Implementations;

public class SelectedProductOfferService : ISelectedProductOfferService
{
    private readonly ISelectedProductOfferRepository selectedProductOfferRepository;
    private readonly IProductOfferRepository productOfferRepository;
    private readonly ISubscriptionRepository subscriptionRepository;
    private readonly IMapper mapper;
    private readonly ISubscriptionPaymentRepository subscriptionPaymentRepository;
    private readonly ISubscriptionPeriodRepository subscriptionPeriodRepository;

    public SelectedProductOfferService(ISelectedProductOfferRepository selectedProductOfferRepository,
        IProductOfferRepository productOfferRepository, ISubscriptionRepository subscriptionRepository, IMapper mapper, ISubscriptionPaymentRepository subscriptionPaymentRepository,
        ISubscriptionPeriodRepository subscriptionPeriodRepository)
    {
        this.selectedProductOfferRepository = selectedProductOfferRepository;
        this.productOfferRepository = productOfferRepository;
        this.subscriptionRepository = subscriptionRepository;
        this.mapper = mapper;
        this.subscriptionPaymentRepository = subscriptionPaymentRepository;
        this.subscriptionPeriodRepository = subscriptionPeriodRepository;
    }

    public async Task<ResponseSelectedProductOfferDto> AddSelectedProductOfferAsync(
        CreateSelectedProductOfferDto createSelectedProductOfferDto)
    {
        // Validate if ProductOfferId exists
        var productOffer = await productOfferRepository.GetByIdAsync(createSelectedProductOfferDto.ProductOfferId);
        if (productOffer is null)
        {
            throw new NotFoundException("A Oferta de Produto não existe");
        }

        // Validate if SubscriptionId exists
        var subscription = await subscriptionRepository.GetByIdAsync(createSelectedProductOfferDto.SubscriptionId);
        if (subscription is null)
        {
            throw new Exception("A Subscrição não existe");
        }
        
        //Validate if subscription period exists
        var subscriptionPeriod = await subscriptionPeriodRepository.GetByIdAsync(subscription.SubscriptionPeriodId);
        if (subscriptionPeriod is null)
        {
            throw new Exception("O Período de Subscrição não existe");
        }
        
        // Validate if DeliveryDate is within the SubscriptionPeriod using ValidateSubscriptionPeriodAndDeliveryDateAsync
        bool isValidDeliveryDate = await ValidateSubscriptionPeriodAndDeliveryDateAsync(subscription.SubscriptionPeriodId, createSelectedProductOfferDto.DeliveryDate);

        if (!isValidDeliveryDate)
        {
            throw new Exception("A data de entrega deve estar dentro do período de subscrição");
        }
        
        var selectedProductOffer = mapper.Map<SelectedProductOffer>(createSelectedProductOfferDto);
        //add subscription period id from the subscription

        // Add default payment status to each subscription payment
        foreach (var payment in selectedProductOffer.Payments)
        {
            payment.Status = Constants.PaymentStatus.Pendente;
        }

        await selectedProductOfferRepository.AddAsync(selectedProductOffer);

        return MapToResponseSelectedProductOfferDto(selectedProductOffer);
        //return mapper.Map<ResponseSelectedProductOfferDto>(selectedProductOffer);
    }

    public async Task<List<ResponseSelectedProductOfferDto>> GetAllSelectedProductOffersAsync()
    {
        var selectedProductOffers = (await selectedProductOfferRepository.GetAllAsync()).ToList();

        return selectedProductOffers.Select(MapToResponseSelectedProductOfferDto).ToList();
    }


    //javardice time
    public async Task<ResponseSelectedProductOfferDto> GetSelectedProductOfferByIdAsync(int id)
    {
        var selectedProductOffers = (await selectedProductOfferRepository.GetAllAsync()).ToList();
        var selectedProductOffer = selectedProductOffers.FirstOrDefault(spo => spo.Id == id);

        if (selectedProductOffer == null)
        {
            throw new NotFoundException("A Oferta de Produto Subscripta não existe");
        }

        return MapToResponseSelectedProductOfferDto(selectedProductOffer);
    }

    public async Task<ResponseSelectedProductOfferDto> UpdateSelectedProductOfferAsync(int id,
        SelectedProductOfferDto updateSelectedProductOfferDto)
    {
        // Retrieve the existing SelectedProductOffer by ID com javardice
        var selectedProductOffers = (await selectedProductOfferRepository.GetAllAsync()).ToList();
        var selectedProductOffer = selectedProductOffers.FirstOrDefault(spo => spo.Id == id);
        //var selectedProductOffer = await selectedProductOfferRepository.GetByIdAsync(id);
        if (selectedProductOffer == null)
        {
            throw new NotFoundException("A Oferta de Produto Subscrita não existe");
        }

        // Update DeliveryDate if a valid, non-default date is provided
        //if (updateSelectedProductOfferDto.DeliveryDate != default &&
        //    updateSelectedProductOfferDto.DeliveryDate != DateTime.MinValue)
        //    selectedProductOffer.DeliveryDate = updateSelectedProductOfferDto.DeliveryDate;

        // Update ProductOfferId if provided and greater than 0
        if (updateSelectedProductOfferDto.ProductOfferId > 0)
        {
            var productOfferExists =
                await productOfferRepository.GetByIdAsync(updateSelectedProductOfferDto.ProductOfferId);
            if (productOfferExists == null)
            {
                throw new NotFoundException("A Oferta de Produto selecionada não existe");
            }

            selectedProductOffer.ProductOfferId = updateSelectedProductOfferDto.ProductOfferId;
        }

        // Update SubscriptionId if provided and greater than 0
        if (updateSelectedProductOfferDto.SubscriptionId > 0)
        {
            var subscriptionExists =
                await subscriptionRepository.GetByIdAsync(updateSelectedProductOfferDto.SubscriptionId);
            if (subscriptionExists == null)
            {
                throw new NotFoundException("A Subscrição selecionada não existe");
            }

            selectedProductOffer.SubscriptionId = updateSelectedProductOfferDto.SubscriptionId;

        }
        
        // Validate if DeliveryDate is within the SubscriptionPeriod using ValidateSubscriptionPeriodAndDeliveryDateAsync
        //bool isValidDeliveryDate = await ValidateSubscriptionPeriodAndDeliveryDateAsync(selectedProductOffer.SubscriptionPeriodId, updateSelectedProductOfferDto.DeliveryDate);
        //if (!isValidDeliveryDate)
        //{
        //    throw new Exception("A data de entrega deve estar dentro do período de subscrição");
        //}
        

        // Update Quantity if provided and greater than 0
        //if (updateSelectedProductOfferDto.Quantity >= 0)
        //    selectedProductOffer.Quantity = updateSelectedProductOfferDto.Quantity.Value;

        // Update SubscriptionPayments
        foreach (var paymentDto in updateSelectedProductOfferDto.SubscriptionPaymentDto)
        {
            var existingPayment = selectedProductOffer.Payments.FirstOrDefault(p => p.Id == paymentDto.Id);
            if (existingPayment != null)
            {
                // Update PaymentDate if provided
                if (paymentDto.PaymentDate != default && paymentDto.PaymentDate != DateTime.MinValue)
                    existingPayment.PaymentDate = paymentDto.PaymentDate;

                // Update Amount if provided and greater than 0
                if (paymentDto.Amount > 0)
                    existingPayment.Amount = paymentDto.Amount;

                // Update PaymentStatus if provided
                if (Enum.IsDefined(typeof(Constants.PaymentStatus), paymentDto.PaymentStatus))
                    existingPayment.Status = paymentDto.PaymentStatus;
                
                //update id subscription if changed in the parent dto
                //existingPayment.SubscriptionId = selectedProductOffer.SubscriptionId;
            }
            
        }


        // Persist the updated entity to the repository
        await selectedProductOfferRepository.UpdateAsync(selectedProductOffer);

        // Map the updated entity to the response DTO
        //return mapper.Map<ResponseSelectedProductOfferDto>(selectedProductOffer);
        return MapToResponseSelectedProductOfferDto(selectedProductOffer);
    }

    public async Task<bool> DeleteSelectedProductOfferAsync(int id)
    {
        var selectedProductOffer = await selectedProductOfferRepository.GetByIdAsync(id);
        if (selectedProductOffer == null)
        {
            throw new NotFoundException("A Oferta de Produto Subscrita não existe");
        }

        await selectedProductOfferRepository.RemoveAsync(selectedProductOffer);
        return true;
    }

    public async Task<bool> UpdateSelectedProductOfferQuantityAsync(int id, int quantity)
    {
        return await selectedProductOfferRepository.UpdateQuantityAsync(id, quantity);
    }

    private ResponseSelectedProductOfferDto MapToResponseSelectedProductOfferDto(
        SelectedProductOffer selectedProductOffer)
    {
        var responseDto = new ResponseSelectedProductOfferDto
        {
            Id = selectedProductOffer.Id,
            //DeliveryDate = selectedProductOffer.DeliveryDate,
            ProductOfferId = selectedProductOffer.ProductOfferId,
            SubscriptionId = selectedProductOffer.SubscriptionId,
            //Quantity = selectedProductOffer.Quantity,
            //SubscriptionPeriodId = selectedProductOffer.SubscriptionPeriodId,
            //ResponseSubscriptionPaymentDto = selectedProductOffer.SubscriptionPayments.Select(payment =>
            //    new ResponseSubscriptionPaymentDto
            //    {
            //        Id = payment.Id,
            //        SubscriptionId = payment.SubscriptionId,
            //        SelectedProductOfferId = payment.SelectedProductOfferId,
            //        PaymentDate = payment.PaymentDate ?? DateTime.MinValue,
            //        Amount = payment.Amount,
            //        PaymentStatus = payment.PaymentStatus
            //    }).ToList()
        };

        return responseDto;
    }
    
    private bool IsValidDeliveryDate(DateTime deliveryDate, DateTime startDate, DateTime endDate)
    {
        return deliveryDate >= startDate && deliveryDate <= endDate;
    }
    
    private async Task<bool> ValidateSubscriptionPeriodAndDeliveryDateAsync(int subscriptionPeriodId, DateTime deliveryDate)
    {

        // Validate if subscription period exists
        var subscriptionPeriod = await subscriptionPeriodRepository.GetByIdAsync(subscriptionPeriodId);
        if (subscriptionPeriod is null)
        {
            throw new Exception("O Período de Subscrição não existe");
        }

        // Validate if DeliveryDate is within the SubscriptionPeriod
        if (!IsValidDeliveryDate(deliveryDate, subscriptionPeriod.StartDate, subscriptionPeriod.EndDate))
        {
            return false;
        }

        return true;
    }
}