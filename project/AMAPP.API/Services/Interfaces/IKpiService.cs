using AMAPP.API.DTOs.Kpi;

namespace AMAPP.API.Services.Interfaces
{
    public interface IKpiService
    {
        Task<IEnumerable<ProducerDeliveryKpi>> GetProducerDeliveryKpiAsync();
        Task<IEnumerable<CoproducerSubscriptionKpi>> GetCoproducerSubscriptionKpiAsync();
    }

}
