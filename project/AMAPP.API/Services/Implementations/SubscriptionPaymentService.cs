using AMAPP.API.DTOs.SubscriptionPayment;
using AMAPP.API.Models;
using AMAPP.API.Repository.SubscriptionPaymentRepository;
using AMAPP.API.Services.Interfaces;
using AutoMapper;

namespace AMAPP.API.Services.Implementations
{
    public class SubscriptionPaymentService: ISubscriptionPaymentService
    {
        private readonly ISubscriptionPaymentRepository _subscriptionPaymentRepository;
        private readonly IMapper _mapper;

        public SubscriptionPaymentService(ISubscriptionPaymentRepository subscriptionPaymentRepository, IMapper mapper)
        {
            _subscriptionPaymentRepository = subscriptionPaymentRepository;
            _mapper = mapper;
        }

        public async Task<List<CoProducerDebts>> GetAllCoproducersDepts()
        {
            var coproducersDebts = await _subscriptionPaymentRepository.GetAllCoproducersDebts();

            return coproducersDebts;
        }

        public async Task<List<ProducerPendingPayments>> GetAllProducerPendingPayments()
        {
            var producerPendingPayments = await _subscriptionPaymentRepository.GetAllProducerPendingPayments();

            return producerPendingPayments;
        }
        
        public async Task<ResponseSubscriptionPaymentDto> AddSubscriptionPaymentAsync(CreateSubscriptionPaymentDto createSubscriptionPaymentDto)
        {
            var subscriptionPayment = _mapper.Map<Payment>(createSubscriptionPaymentDto);
            subscriptionPayment.Status = Constants.PaymentStatus.Pendente; // vai por defeito como pendente
            await _subscriptionPaymentRepository.AddAsync(subscriptionPayment);
            return _mapper.Map<ResponseSubscriptionPaymentDto>(subscriptionPayment);
        }

        public async Task<List<ResponseSubscriptionPaymentDto>> GetAllSubscriptionPaymentsAsync()
        {
            var subscriptionPayments = await _subscriptionPaymentRepository.GetAllAsync();
            return _mapper.Map<List<ResponseSubscriptionPaymentDto>>(subscriptionPayments);
        }

        public async Task<ResponseSubscriptionPaymentDto> GetSubscriptionPaymentByIdAsync(int id)
        {
            var subscriptionPayment = await _subscriptionPaymentRepository.GetByIdAsync(id);
            if (subscriptionPayment == null)
            {
                throw new KeyNotFoundException("Subscription payment not found.");
            }
            return _mapper.Map<ResponseSubscriptionPaymentDto>(subscriptionPayment);
        }

        public async Task<ResponseSubscriptionPaymentDto> UpdateSubscriptionPaymentAsync(int id, UpdateSubscriptionPaymentDto updateSubscriptionPaymentDto)
        {
            var existingSubscriptionPayment = await _subscriptionPaymentRepository.GetByIdAsync(id);
            if (existingSubscriptionPayment == null)
            {
                throw new KeyNotFoundException("Subscription payment not found.");
            }

            // Update PaymentDate if provided
            if (updateSubscriptionPaymentDto.PaymentDate != default && updateSubscriptionPaymentDto.PaymentDate != DateTime.MinValue)
                existingSubscriptionPayment.PaymentDate = updateSubscriptionPaymentDto.PaymentDate;

            // Update Amount if provided and greater than 0
            if (updateSubscriptionPaymentDto.Amount > 0)
                existingSubscriptionPayment.Amount = updateSubscriptionPaymentDto.Amount;

            // Update PaymentStatus if provided
            if (Enum.IsDefined(typeof(Constants.PaymentStatus), updateSubscriptionPaymentDto.PaymentStatus))
                existingSubscriptionPayment.Status = updateSubscriptionPaymentDto.PaymentStatus;

            await _subscriptionPaymentRepository.UpdateAsync(existingSubscriptionPayment);

            return _mapper.Map<ResponseSubscriptionPaymentDto>(existingSubscriptionPayment);
        }

        public async Task<bool> DeleteSubscriptionPaymentAsync(int id)
        {
            var subscriptionPayment = await _subscriptionPaymentRepository.GetByIdAsync(id);
            if (subscriptionPayment == null)
            {
                return false;
            }

            await _subscriptionPaymentRepository.RemoveAsync(subscriptionPayment);
            return true;
        }
    }
}