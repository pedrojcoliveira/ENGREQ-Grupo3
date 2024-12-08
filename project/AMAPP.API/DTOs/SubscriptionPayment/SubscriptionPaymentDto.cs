using System.ComponentModel.DataAnnotations;

namespace AMAPP.API.DTOs.SubscriptionPayment;

public class SubscriptionPaymentDto
{
    [Required]
    public int Id { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public Constants.PaymentStatus PaymentStatus { get; set; }
}