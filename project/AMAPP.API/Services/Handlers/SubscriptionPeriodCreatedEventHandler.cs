using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AMAPP.API.DTOs;
using AMAPP.API.Events;
using AMAPP.API.Repository.ProducerInfoRepository;
using AMAPP.API.Services.Interfaces;

namespace AMAPP.API.Services.Handlers
{
    public class SubscriptionPeriodCreatedEventHandler : INotificationHandler<SubscriptionPeriodCreatedEvent>
    {
        private readonly IProducerInfoRepository producerInfoRepository;
        private readonly IEmailService emailService;

        public SubscriptionPeriodCreatedEventHandler(IProducerInfoRepository producerInfoRepository, IEmailService emailService)
        {
            this.producerInfoRepository = producerInfoRepository;
            this.emailService = emailService;
        }
        public async Task Handle(SubscriptionPeriodCreatedEvent notification, CancellationToken cancellationToken)
        {
            var producers = producerInfoRepository.GetAll();
            foreach (var producerInfo in producers)
            {
                if (producerInfo == null || producerInfo.User == null)
                    continue;
                
                var message = new MessageDto(producerInfo.User.Email, "Período de Subscrição Criado", "Um período de subscrição denominado " + notification.NewlyCreatedSubscriptionPeriod.Name + " foi criado.\nPor favor verifique.");
                await emailService.SendEmailAsync(message);
            }
        }
    }
}