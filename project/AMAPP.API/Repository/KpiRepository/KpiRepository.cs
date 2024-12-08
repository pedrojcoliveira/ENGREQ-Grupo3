using AMAPP.API.Data;
using AMAPP.API.DTOs.Kpi;
using AMAPP.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAPP.API.Repository.KpiRepository
{
    public class KpiRepository : IKpiRepository
    {

        protected readonly ApplicationDbContext _context;

        public KpiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CoproducerSubscriptionKpi>> GetCoproducerSubscriptionKpiAsync()
        {
            var coproducerSubscriptionKpi = await (from coproducer in _context.CoproducersInfo
                                            join user in _context.Users on coproducer.UserId equals user.Id
                                            join subscription in _context.Subscriptions on coproducer.Id equals subscription.CoproducerInfoId
                                            join selectedProductOffer in _context.SelectedProductOffers on subscription.Id equals selectedProductOffer.SubscriptionId
                                            join subscriptionPayment in _context.SubscriptionPayments on selectedProductOffer.Id equals subscriptionPayment.SelectedProductOfferId
                                            join productOffer in _context.ProductOffers on selectedProductOffer.ProductOfferId equals productOffer.Id
                                            join product in _context.Products on productOffer.ProductId equals product.Id
                                            join subscriptionPeriod in _context.SubscriptionPeriods on subscription.SubscriptionPeriodId equals subscriptionPeriod.Id
                                            group new { subscriptionPayment, user.UserName, subscriptionPeriod.Name, product.ReferencePrice } by new { user.UserName, subscriptionPeriod.Name } into g
                                            select new CoproducerSubscriptionKpi
                                            {
                                                CoproducerName = g.Key.UserName,
                                                SubscriptionPeriodName = g.Key.Name,
                                                AverageVelueByDelivery = g.Average(x => x.ReferencePrice),
                                                AverageValueByPeriod = g.Sum(x => x.ReferencePrice)
                                            }).ToListAsync();

            return coproducerSubscriptionKpi;
        }

        public async Task<IEnumerable<ProducerDeliveryKpi>> GetProducerDeliveryKpiAsync()
        {
            var producerDeliveryKpi  = await (from producer in _context.ProducersInfo
                                                   join user in _context.Users on producer.UserId equals user.Id
                                                   join subscription in _context.Subscriptions on producer.Id equals subscription.CoproducerInfoId
                                                   join selectedProductOffer in _context.SelectedProductOffers on subscription.Id equals selectedProductOffer.SubscriptionId
                                                   join subscriptionPayment in _context.SubscriptionPayments on selectedProductOffer.Id equals subscriptionPayment.SelectedProductOfferId
                                                   join productOffer in _context.ProductOffers on selectedProductOffer.ProductOfferId equals productOffer.Id
                                                   join product in _context.Products on productOffer.ProductId equals product.Id
                                                   join subscriptionPeriod in _context.SubscriptionPeriods on subscription.SubscriptionPeriodId equals subscriptionPeriod.Id
                                                   group new { subscriptionPayment, user.UserName, subscriptionPeriod.Name, product.ReferencePrice } by new { user.UserName, subscriptionPeriod.Name } into g
                                                   select new ProducerDeliveryKpi
                                                   {
                                                       ProducerName = g.Key.UserName,
                                                       SubscriptionPeriodName = g.Key.Name,
                                                       DeliveryAverageValue = g.Average(x => x.ReferencePrice),
                                                       PeriodTotalValue = g.Sum(x => x.ReferencePrice)
                                                   }).ToListAsync();

            return producerDeliveryKpi;
        }
    }
}
