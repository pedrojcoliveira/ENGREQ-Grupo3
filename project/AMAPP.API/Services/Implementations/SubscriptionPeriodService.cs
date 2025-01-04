﻿using AMAPP.API.DTOs.Product;
using AMAPP.API.Services.Interfaces;
using AMAPP.API.DTOs.SubscriptionPeriod;
using AMAPP.API.Events;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProductOfferRepository;
using AMAPP.API.Repository.SelectedProductOfferRepository;
using AMAPP.API.Repository.SubscriptionPeriodRepository;
using AMAPP.API.Utils;
using AutoMapper;
using MediatR;

namespace AMAPP.API.Services.Implementations
{
    public class SubscriptionPeriodService : ISubscriptionPeriodService
    {
        private readonly ISubscriptionPeriodRepository _subscriptionPeriodRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SubscriptionPeriodService(ISubscriptionPeriodRepository subscriptionPeriodRepository, IMapper mapper, IMediator mediator)
        {
            _subscriptionPeriodRepository = subscriptionPeriodRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseSubscriptionPeriodDto> AddSubscriptionPeriodAsync(
            CreateSubscriptionPeriodDto subscriptionPeriodDto)
        {
            var subscriptionPeriod =
                _mapper.Map<SubscriptionPeriod>(
                    subscriptionPeriodDto);
            
            //Bad Practice but let's go: Business Rule that the Created Resource and its Delivery Dates are Active
            subscriptionPeriod.ResourceStatus = ResourceStatus.Ativo;
            subscriptionPeriod.DeliveryDates.ForEach(dd => dd.ResourceStatus = ResourceStatus.Ativo);

            await _subscriptionPeriodRepository.AddAsync(subscriptionPeriod);
            await Task.Run(() =>
            {
                _mediator.Publish(new SubscriptionPeriodCreatedEvent
                {
                    NewlyCreatedSubscriptionPeriod = subscriptionPeriod
                });
            });

            return _mapper.Map<ResponseSubscriptionPeriodDto>(subscriptionPeriod);
        }

        public async Task<List<ResponseSubscriptionPeriodDto>> GetAllSubscriptionPeriodsAsync()
        {
            var subscriptionPeriods = await _subscriptionPeriodRepository.GetAllAsync();
            return _mapper.Map<List<ResponseSubscriptionPeriodDto>>(subscriptionPeriods);
        }

        public async Task<ResponseSubscriptionPeriodDto> GetSubscriptionPeriodByIdAsync(int id)
        {
            var subscriptionPeriod = await _subscriptionPeriodRepository.GetByIdAsync(id);
            if (subscriptionPeriod == null)
                throw new NotFoundException("O Período de Subscrição  não existe");

            return _mapper.Map<ResponseSubscriptionPeriodDto>(subscriptionPeriod);
        }

        public async Task<ResponseSubscriptionPeriodDto> UpdateSubscriptionPeriodAsync(int id,
            SubscriptionPeriodDto subscriptionPeriodDto)
        {
            // Retrieve the existing SubscriptionPeriod by ID
            var subscriptionPeriod = await _subscriptionPeriodRepository.GetByIdAsync(id);
            if (subscriptionPeriod == null)
                throw new NotFoundException("O período de subscrição  não existe");
            
            //Business Rule: The Subscription Period cannot be updated if it is soft-deleted
            if (subscriptionPeriod.ResourceStatus == ResourceStatus.Inativo)
                throw new ArgumentException("O período de subscrição não pode ser alterado pois não existe");

            // Update the Name if provided
            if (!string.IsNullOrEmpty(subscriptionPeriodDto.Name))
                subscriptionPeriod.Name = subscriptionPeriodDto.Name;

            // Update StartDate if a valid, non-default date is provided
            if (subscriptionPeriodDto.StartDate != default && subscriptionPeriodDto.StartDate != DateTime.MinValue)
                subscriptionPeriod.StartDate = subscriptionPeriodDto.StartDate;

            // Update EndDate if a valid, non-default date is provided
            if (subscriptionPeriodDto.EndDate != default && subscriptionPeriodDto.EndDate != DateTime.MinValue)
                subscriptionPeriod.EndDate = subscriptionPeriodDto.EndDate;

            // Ensure EndDate is not earlier than StartDate
            if (subscriptionPeriod.StartDate > subscriptionPeriod.EndDate)
                throw new ArgumentException("Hora de término não pode ser mais recente que data de início");
            
            // Update the Duration if provided
            if (subscriptionPeriodDto.Duration.HasValue)
                subscriptionPeriod.Duration = subscriptionPeriodDto.Duration.Value;
            

            if (subscriptionPeriodDto.Dates != null && subscriptionPeriodDto.Dates.Any(date => date != default))
            {
                var validDates = subscriptionPeriodDto.Dates
                    .Where(date => date != default && date.Date >= subscriptionPeriod.StartDate && date.Date <= subscriptionPeriod.EndDate)
                    .Select(date => new DeliveryDate { Date = date.Date, ResourceStatus = date.ResourceStatus })
                    .ToList();

                if (validDates.Count != subscriptionPeriodDto.Dates.Count)
                {
                    throw new ArgumentException("One or more delivery dates are outside the subscription period time interval.");
                }

                subscriptionPeriod.DeliveryDates = validDates;
            }    
            
            // Persist the updated entity to the repository
            await _subscriptionPeriodRepository.UpdateAsync(subscriptionPeriod);

            await Task.Run(() =>
            {
                _mediator.Publish(new SubscriptionPeriodUpdatedEvent
                {
                    NewlyUpdatedSubscriptionPeriod = subscriptionPeriod
                });
            });

            // Map the updated entity to the response DTO
            return _mapper.Map<ResponseSubscriptionPeriodDto>(subscriptionPeriod);
        }

        public async Task<bool> DeleteSubscriptionPeriodAsync(int id)
        {
            var subscriptionPeriod = await _subscriptionPeriodRepository.GetByIdAsync(id);
            if (subscriptionPeriod == null)
                throw new NotFoundException("O Período de Subscrição  não existe");
            
            //inactivate the subscription period and its delivery dates instead of deleting them -> soft delete
            subscriptionPeriod.ResourceStatus = ResourceStatus.Inativo;
            subscriptionPeriod.DeliveryDates.ForEach(dd => dd.ResourceStatus = ResourceStatus.Inativo);

            //await _subscriptionPeriodRepository.RemoveAsync(subscriptionPeriod);
            await _subscriptionPeriodRepository.UpdateAsync(subscriptionPeriod);
            return true;
        }

    }
}