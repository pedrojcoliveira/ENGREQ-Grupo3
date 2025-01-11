using AMAPP.API.DTOs.Subscription;
using AMAPP.API.Models;
using AMAPP.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AMAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly UserManager<User> _userManager;
        public SubscriptionController(ISubscriptionService subscriptionService, UserManager<User> userManager)
        {
            _subscriptionService = subscriptionService;
            _userManager = userManager;
        }


        //[HttpGet]
        //public async Task<ActionResult<List<SubscriptionDto>>> GetAllSubscriptions()
        //{
        //    var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync();
        //    return Ok(subscriptions);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<SubscriptionDto>> GetSubscriptionById(int id)
        //{
        //    var subscription = await _subscriptionService.GetSubscriptionByIdAsync(id);
        //    if (subscription == null)
        //        return NotFound();
        //    return Ok(subscription);
        //}


        [HttpPost]
        public async Task<ActionResult<CreateSubscriptionDto>> AddSubscription(CreateSubscriptionDto subscriptionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var createdSubscription = await _subscriptionService.AddSubscriptionAsync(subscriptionDto);
                return Created();
                //return CreatedAtAction(nameof(GetSubscriptionById), new { id = createdSubscription.Id }, createdSubscription);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        //[HttpPut("{id}")]
        //public async Task<ActionResult<SubscriptionDto>> UpdateSubscription(int id, [FromForm] UpdateSubscriptionDto subscriptionDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    try
        //    {
        //        var updatedSubscription = await _subscriptionService.UpdateSubscriptionAsync(id, subscriptionDto);
        //        return Ok(updatedSubscription);
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}


    }
}
