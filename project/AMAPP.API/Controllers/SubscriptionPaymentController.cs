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
        
                [HttpPost]
        public async Task<ActionResult<ResponseSubscriptionPaymentDto>> AddSubscriptionPayment([FromBody] CreateSubscriptionPaymentDto createSubscriptionPaymentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _subscriptionPaymentService.AddSubscriptionPaymentAsync(createSubscriptionPaymentDto);
            return CreatedAtAction(nameof(AddSubscriptionPayment), new { id = response.Id }, response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseSubscriptionPaymentDto>>> GetAllSubscriptionPayments()
        {
            var subscriptionPayments = await _subscriptionPaymentService.GetAllSubscriptionPaymentsAsync();
            return Ok(subscriptionPayments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseSubscriptionPaymentDto>> GetSubscriptionPaymentById(int id)
        {
            var subscriptionPayment = await _subscriptionPaymentService.GetSubscriptionPaymentByIdAsync(id);
            if (subscriptionPayment == null)
                return NotFound();

            return Ok(subscriptionPayment);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ResponseSubscriptionPaymentDto>> UpdateSubscriptionPayment(int id, [FromBody] UpdateSubscriptionPaymentDto updateSubscriptionPaymentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedSubscriptionPayment = await _subscriptionPaymentService.UpdateSubscriptionPaymentAsync(id, updateSubscriptionPaymentDto);
            if (updatedSubscriptionPayment == null)
                return NotFound();

            return Ok(updatedSubscriptionPayment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubscriptionPayment(int id)
        {
            var isDeleted = await _subscriptionPaymentService.DeleteSubscriptionPaymentAsync(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
