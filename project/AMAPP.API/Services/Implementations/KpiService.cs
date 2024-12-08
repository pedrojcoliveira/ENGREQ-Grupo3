using AMAPP.API.DTOs.Kpi;
using AMAPP.API.Repository.KpiRepository;
using AMAPP.API.Services.Interfaces;

namespace AMAPP.API.Services.Implementations
{
    public class KpiService : IKpiService
    {

        private readonly IKpiRepository _kpiRepository;

        public KpiService(IKpiRepository kpiRepository)
        {
            _kpiRepository = kpiRepository;
        }

        public async Task<IEnumerable<CoproducerSubscriptionKpi>> GetCoproducerSubscriptionKpiAsync()
        {
            var coproducerSubscriptionKpi = await _kpiRepository.GetCoproducerSubscriptionKpiAsync();

            return coproducerSubscriptionKpi;
        }

        public async Task<IEnumerable<ProducerDeliveryKpi>> GetProducerDeliveryKpiAsync()
        {
            var producerDeliveryKpi = await _kpiRepository.GetProducerDeliveryKpiAsync();

            return producerDeliveryKpi;
        }
    }
}
