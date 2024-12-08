using AMAPP.API.DTOs.SubscriptionPayment;
using AMAPP.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMAPP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionPaymentController : ControllerBase
    {
        private readonly ISubscriptionPaymentService _subscriptionPaymentService;

        public SubscriptionPaymentController(ISubscriptionPaymentService subscriptionPaymentService)
        {
            _subscriptionPaymentService = subscriptionPaymentService;
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
        public async Task<ActionResult<ResponseSubscriptionPaymentDto>> UpdateSubscriptionPayment(int id, [FromBody] SubscriptionPaymentDto updateSubscriptionPaymentDto)
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