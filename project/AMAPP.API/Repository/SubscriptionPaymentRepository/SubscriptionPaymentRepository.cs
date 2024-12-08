using AMAPP.API.Data;
using AMAPP.API.DTOs.SubscriptionPayment;
using AMAPP.API.Models;
using Microsoft.EntityFrameworkCore;
using static AMAPP.API.Constants;

namespace AMAPP.API.Repository.SubscriptionPaymentRepository
{
    public class SubscriptionPaymentRepository : RepositoryBase<SubscriptionPayment>, ISubscriptionPaymentRepository
    {
        public SubscriptionPaymentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<CoProducerDebts>> GetAllCoproducersDebts()
        {

            var coproducersDebts = await (from sp in _context.SubscriptionPayments
                join s in _context.Subscriptions on sp.SubscriptionId equals s.Id
                join c in _context.CoproducersInfo on s.CoproducerInfoId equals c.Id
                join uc in _context.Users on c.UserId equals uc.Id
                join spo in _context.SelectedProductOffers on sp.SelectedProductOfferId equals spo.Id
                join po in _context.ProductOffers on spo.ProductOfferId equals po.Id
                join p in _context.Products on po.ProductId equals p.Id
                join pi in _context.ProducersInfo on p.ProducerInfoId equals pi.Id
                join up in _context.Users on pi.UserId equals up.Id
                where sp.PaymentStatus == PaymentStatus.Pendente
                group sp by new
                {
                    CoProducerName = uc.UserName, ProducerName = up.UserName,
                    SubscriptionName = s.SubscriptionPeriod.Name
                }
                into g
                select new CoProducerDebts
                {
                    CoProducerName = g.Key.CoProducerName,
                    ProducerName = g.Key.ProducerName,
                    SubscriptionName = g.Key.SubscriptionName,
                    Debt = g.Sum(x => x.Amount)
                }).ToListAsync();

            return coproducersDebts;
        }

        public async Task<List<ProducerPendingPayments>> GetAllProducerPendingPayments()
        {
            var producerPendingPayments = await (from sp in _context.SubscriptionPayments
                join s in _context.Subscriptions on sp.SubscriptionId equals s.Id
                join c in _context.CoproducersInfo on s.CoproducerInfoId equals c.Id
                join uc in _context.Users on c.UserId equals uc.Id
                join spo in _context.SelectedProductOffers on sp.SelectedProductOfferId equals spo.Id
                join po in _context.ProductOffers on spo.ProductOfferId equals po.Id
                join p in _context.Products on po.ProductId equals p.Id
                join pi in _context.ProducersInfo on p.ProducerInfoId equals pi.Id
                join up in _context.Users on pi.UserId equals up.Id
                where sp.PaymentStatus == PaymentStatus.Pendente
                group sp by new
                {
                    CoProducerName = uc.UserName, ProducerName = up.UserName,
                    SubscriptionName = s.SubscriptionPeriod.Name
                }
                into g
                select new ProducerPendingPayments
                {
                    CoProducerName = g.Key.CoProducerName,
                    ProducerName = g.Key.ProducerName,
                    SubscriptionName = g.Key.SubscriptionName,
                    PendingPayment = g.Sum(x => x.Amount)
                }).ToListAsync();

            return producerPendingPayments;
        }

        public new async Task<IEnumerable<SubscriptionPayment>> GetAllAsync()
        {
            return await _context.SubscriptionPayments.ToListAsync();
        }

        public new async Task<SubscriptionPayment?> GetByIdAsync(int id)
        {
            return await _context.SubscriptionPayments.FirstOrDefaultAsync(sp => sp.Id == id);
        }
    }
}