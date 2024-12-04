using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AMAPP.API.DTOs;
using AMAPP.API.Events;
using AMAPP.API.Repository.ProducerInfoRepository;
using AMAPP.API.Services.Interfaces;

namespace AMAPP.API.Services.Handlers
{
    public class SubscriptionPeriodUpdatedEventHandler : INotificationHandler<SubscriptionPeriodUpdatedEvent>
    {
        private readonly IProducerInfoRepository producerInfoRepository;
        private readonly IEmailService emailService;

        public SubscriptionPeriodUpdatedEventHandler(IProducerInfoRepository producerInfoRepository, IEmailService emailService)
        {
            this.producerInfoRepository = producerInfoRepository;
            this.emailService = emailService;
        }
        public async Task Handle(SubscriptionPeriodUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var producers = producerInfoRepository.GetAll();
            foreach (var producerInfo in producers)
            {
                if (producerInfo == null || producerInfo.User == null)
                    continue;
                
                var message = new MessageDto(producerInfo.User.Email, "Período de Subscrição Actualizado", "Um período de subscrição denominado " + notification.NewlyUpdatedSubscriptionPeriod.Name  + " foi actualizado.\nPor favor verifique.");
                await emailService.SendEmailAsync(message);
            }
        }
    }
}