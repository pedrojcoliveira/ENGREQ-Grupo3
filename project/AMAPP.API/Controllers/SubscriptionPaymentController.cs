using AMAPP.API.DTOs.SubscriptionPayment;
using AMAPP.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPaymentController : ControllerBase
    {
        private readonly ISubscriptionPaymentService _subscriptionPaymentService;

        public SubscriptionPaymentController(ISubscriptionPaymentService subscriptionPaymentService)
        {
            _subscriptionPaymentService = subscriptionPaymentService;
        }

        [HttpGet("CoproducersDebts")]
        public async Task<ActionResult<List<CoProducerDebts>>> GetAllCoproducersDepts()
        {
            var coproducersDebts = await _subscriptionPaymentService.GetAllCoproducersDepts();
            return Ok(coproducersDebts);
        }

        [HttpGet("ProducerPendingPayments")]
        public async Task<ActionResult<List<ProducerPendingPayments>>> GetAllProducerPendingPayments()
        {
            var producerPendingPayments = await _subscriptionPaymentService.GetAllProducerPendingPayments();
            return Ok(producerPendingPayments);
        }
    }
}
