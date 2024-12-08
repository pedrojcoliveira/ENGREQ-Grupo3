using AMAPP.API.DTOs.SubscriptionPayment;
using AMAPP.API.Models;
using AMAPP.API.Repository.SubscriptionPaymentRepository;
using AMAPP.API.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMAPP.API.Services.Implementations
{
    public class SubscriptionPaymentService : ISubscriptionPaymentService
    {
        private readonly ISubscriptionPaymentRepository _subscriptionPaymentRepository;
        private readonly IMapper _mapper;

        public SubscriptionPaymentService(ISubscriptionPaymentRepository subscriptionPaymentRepository, IMapper mapper)
        {
            _subscriptionPaymentRepository = subscriptionPaymentRepository;
            _mapper = mapper;
        }

        public async Task<ResponseSubscriptionPaymentDto> AddSubscriptionPaymentAsync(CreateSubscriptionPaymentDto createSubscriptionPaymentDto)
        {
            var subscriptionPayment = _mapper.Map<SubscriptionPayment>(createSubscriptionPaymentDto);
            subscriptionPayment.PaymentStatus = Constants.PaymentStatus.Pendente; // vai por defeito como pendente
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

        public async Task<ResponseSubscriptionPaymentDto> UpdateSubscriptionPaymentAsync(int id, SubscriptionPaymentDto updateSubscriptionPaymentDto)
        {
            var existingSubscriptionPayment = await _subscriptionPaymentRepository.GetByIdAsync(id);
            if (existingSubscriptionPayment == null)
            {
                throw new KeyNotFoundException("Subscription payment not found.");
            }

            _mapper.Map(updateSubscriptionPaymentDto, existingSubscriptionPayment);
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