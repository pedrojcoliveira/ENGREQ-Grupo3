using AMAPP.API.Data;
using AMAPP.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAPP.API.Repository.DeliveryDateRepository;

public class DeliveryDateRepository : RepositoryBase<DeliveryDate>, IDeliveryDateRepository
{
    public DeliveryDateRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<DeliveryDate>> GetDeliveryDatesByIds(List<int> selectedDeliveryDates)
    {
        var deliveryDates = await _context.DeliveryDates
            .Where(d => selectedDeliveryDates.Contains(d.Id))
            .ToListAsync();

        return deliveryDates;
    }
}