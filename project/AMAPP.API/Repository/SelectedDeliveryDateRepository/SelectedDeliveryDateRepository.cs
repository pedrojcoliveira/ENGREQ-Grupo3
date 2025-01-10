using AMAPP.API.Data;
using AMAPP.API.Models;

namespace AMAPP.API.Repository.SelectedDeliveryDateRepository
{
    public class SelectedDeliveryDateRepository: RepositoryBase<SelectedDeliveryDate>, ISelectedDeliveryDateRepository
    {
        public SelectedDeliveryDateRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
