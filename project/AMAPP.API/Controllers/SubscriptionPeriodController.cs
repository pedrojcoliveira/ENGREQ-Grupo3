using AMAPP.API.DTOs.Product;
using AMAPP.API.DTOs.SubscriptionPeriod;
using AMAPP.API.Models;
using AMAPP.API.Services.Implementations;
using AMAPP.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Linq;
using System.Security.Principal;

namespace AMAPP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionPeriodController : ControllerBase
{
    private readonly ISubscriptionPeriodService _subscriptionPeriodService;

    public SubscriptionPeriodController(ISubscriptionPeriodService subscriptionPeriodService)
    {
        _subscriptionPeriodService = subscriptionPeriodService;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseSubscriptionPeriodDto>> AddSubscriptionPeriod([FromBody] CreateSubscriptionPeriodDto subscriptionPeriodDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var createdSubscriptionPeriod = await _subscriptionPeriodService.AddSubscriptionPeriodAsync(subscriptionPeriodDto);
        return StatusCode(201, createdSubscriptionPeriod);
    }

    [HttpGet]
    public async Task<ActionResult<List<ResponseSubscriptionPeriodDto>>> GetAllSubscriptionPeriods([FromQuery(Name = "show-all")] bool showAll = false)
    {
        var subscriptionPeriods = await _subscriptionPeriodService.GetAllSubscriptionPeriodsAsync();

        //only show active subscription periods with active delivery dates
        if (!showAll)
        {
            //subscriptionPeriods = subscriptionPeriods.Where(sp => sp.ResourceStatus == ResourceStatus.Ativo).ToList();
            subscriptionPeriods = subscriptionPeriods.Where(sp => sp.ResourceStatus == ResourceStatus.Ativo).Select(sp =>
                {
                    sp.Dates = sp.Dates.Where(d => d.ResourceStatus == ResourceStatus.Ativo).ToList();
                    return sp;
                }).ToList();
        }

        return Ok(subscriptionPeriods);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseSubscriptionPeriodDto>> GetSubscriptionPeriodById(int id)
    {
        var subscriptionPeriod = await _subscriptionPeriodService.GetSubscriptionPeriodByIdAsync(id);
        if (subscriptionPeriod == null)
            return NotFound();

        return Ok(subscriptionPeriod);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<ResponseSubscriptionPeriodDto>> UpdateSubscriptionPeriod(int id, [FromBody] SubscriptionPeriodDto subscriptionPeriodDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedSubscriptionPeriod = await _subscriptionPeriodService.UpdateSubscriptionPeriodAsync(id, subscriptionPeriodDto);
        if (updatedSubscriptionPeriod == null)
            return NotFound();

        return Ok(updatedSubscriptionPeriod);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSubscriptionPeriod(int id)
    {
        var isDeleted = await _subscriptionPeriodService.DeleteSubscriptionPeriodAsync(id);
        if (!isDeleted)
            return NotFound();

        return NoContent();
    }

    [HttpGet("{id}/deliverydates")]
    public async Task<ActionResult> GetSubscriptionPeriodDates(int id)
    {
        try
        {
            var deliveryDatesDto = await _subscriptionPeriodService.GetSubscriptionPeriodDatesById(id);

            return Ok(deliveryDatesDto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    [HttpGet("{id}/productoffers")]
    public async Task<ActionResult> GetSubscriptionPeriodProductOffer(int id)
    {
        try
        {
            var productOfferDto = await _subscriptionPeriodService.GetSubscriptionPeriodProductOfferById(id);

            return Ok(productOfferDto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

}