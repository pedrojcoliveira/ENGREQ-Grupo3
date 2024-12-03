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
            var producers = await producerInfoRepository.GetAllAsync();
            foreach (var producerInfo in producers)
            {
                if (producerInfo == null || producerInfo.User == null)
                    continue;
                
                var message = new MessageDto(producerInfo.User.Email, "Subscription period created", "A new subscription period " + notification.NewlyCreatedSubscriptionPeriod.Name + " has been created");
                await emailService.SendEmailAsync(message);
            }
            // Handle the event here
            Console.WriteLine("Subscription period created");
        }
    }
}