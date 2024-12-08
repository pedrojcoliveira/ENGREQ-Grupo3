using AMAPP.API.DTOs.Auth;
using AMAPP.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KpiController : ControllerBase
    {
        private readonly IKpiService _kpiService;

        public KpiController(IKpiService kpiService)
        {
            _kpiService = kpiService;
        }

        [HttpGet("GetCoproducerSubscriptionKpi")]
        public async Task<IActionResult> GetCoproducerSubscriptionKpi()
        {
            var coproducerSubscriptionKpi = await _kpiService.GetCoproducerSubscriptionKpiAsync();

            return Ok(coproducerSubscriptionKpi);
        }

        [HttpGet("GetProducerDeliveryKpi")]
        public async Task<IActionResult> GetProducerDeliveryKpi()
        {
            var producerDeliveryKpi = await _kpiService.GetProducerDeliveryKpiAsync();
            return Ok(producerDeliveryKpi);
        }

    }
}
