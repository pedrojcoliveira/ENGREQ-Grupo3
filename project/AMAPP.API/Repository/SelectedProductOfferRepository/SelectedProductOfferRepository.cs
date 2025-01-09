using AMAPP.API.Data;
using AMAPP.API.DTOs.AccountBalance;
using AMAPP.API.Models;
using AMAPP.API.Repository;
using AMAPP.API.Repository.SelectedProductOfferRepository;
using Microsoft.EntityFrameworkCore;

public class SelectedProductOfferRepository : RepositoryBase<SelectedProductOffer>, ISelectedProductOfferRepository
{
    public SelectedProductOfferRepository(ApplicationDbContext context) : base(context)
    {
    }

public async Task<bool> UpdateQuantityAsync(int id, int quantity)
    {
        // Obtém a oferta selecionada pelo ID
        var selectedProductOffer = await _context.Set<SelectedProductOffer>().FindAsync(id);
        if (selectedProductOffer == null)
        {
            return false; // Retorna falso se não for encontrado
        }

        // Atualiza a quantidade
        //selectedProductOffer.Quantity = quantity;

        // Salva as mudanças no contexto
        await _context.SaveChangesAsync();

        return true; // Indica que a operação foi bem-sucedida
    }

        public new async Task<IEnumerable<SelectedProductOffer>> GetAllAsync()
        {
            return await _context.Set<SelectedProductOffer>()
                .Include(spo => spo.Payments)
                .ToListAsync();
    }

    public async Task<List<CoproducerAccountBalanceDTO>> TotalCoproducersProductValues()
    {
        //var t = await _context.Products.Include(p => p.ProductOffers)
        //        .ThenInclude(po => po.PeriodSubscription)
        //        .ThenInclude(ps => ps.SelectedProductOffers).ToListAsync();

        var coproducerAccountBalanceDTO = await (from spo in _context.SelectedProductOffers
                           join s in _context.Subscriptions on spo.SubscriptionId equals s.Id
                           join c in _context.CoproducersInfo on s.CoproducerInfoId equals c.Id
                           join uc in _context.Users on c.UserId equals uc.Id
                           join po in _context.ProductOffers on spo.ProductOfferId equals po.Id
                           join sp in _context.SubscriptionPayments on spo.Id equals sp.SelectedProductOfferId
                           join p in _context.Products on po.ProductId equals p.Id
                           group new { sp, p.ReferencePrice, uc.UserName } by new { c.Id, uc.UserName } into g
                           select new CoproducerAccountBalanceDTO
                           {
                               CoproducerId = g.Key.Id,
                               CoproducerName = g.Key.UserName,
                               Balance = (double)g.Sum(x => x.sp.Amount) - g.Sum(x => x.ReferencePrice)
                           }).ToListAsync();

        return coproducerAccountBalanceDTO;
    }
}
