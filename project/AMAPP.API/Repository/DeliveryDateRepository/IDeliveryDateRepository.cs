
using AMAPP.API.Models;

namespace AMAPP.API.Repository.DeliveryDateRepository;

public interface IDeliveryDateRepository: IRepositoryBase<DeliveryDate>
{
    Task<List<DeliveryDate>> GetDeliveryDatesByIds(List<int> selectedDeliveryDates);
}