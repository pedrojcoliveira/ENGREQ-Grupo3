using AMAPP.API.Data;
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
        selectedProductOffer.Quantity = quantity;

        // Salva as mudanças no contexto
        await _context.SaveChangesAsync();

        return true; // Indica que a operação foi bem-sucedida
    }


}
    /*public new async Task<IEnumerable<SelectedProductOffer>> GetAllAsync()
        {
            return await _context.SubscriptionPeriods
                .Include(sp => sp.DeliveryDatesList) 
                .ToListAsync();
        }
    */
