using AMAPP.API.DTOs.Kpi;

namespace AMAPP.API.Repository.KpiRepository
{
    public interface IKpiRepository
    {
        Task<IEnumerable<ProducerDeliveryKpi>> GetProducerDeliveryKpiAsync();
        Task<IEnumerable<CoproducerSubscriptionKpi>> GetCoproducerSubscriptionKpiAsync();
    }
}
