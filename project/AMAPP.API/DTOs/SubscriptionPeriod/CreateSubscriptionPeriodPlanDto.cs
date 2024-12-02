using System.ComponentModel.DataAnnotations;
using AMAPP.API.Models;

namespace AMAPP.API.DTOs.SubscriptionPeriod;

public class CreateSubscriptionPeriodPlanDto
{ 
    [Required]
    public CreateSubscriptionPeriodDto SubscriptionPeriod { get; set; }
    [Required]
    public List<int> SelectedProductOfferIds { get; set; } = new ();
    [Required]
    public List<int> ProductOfferIds { get; set; } = new ();
}