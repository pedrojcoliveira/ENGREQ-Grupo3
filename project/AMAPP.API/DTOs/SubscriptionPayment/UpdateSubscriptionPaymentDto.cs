namespace AMAPP.API.DTOs.SubscriptionPayment;

public class UpdateSubscriptionPaymentDto
{
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public Constants.PaymentStatus PaymentStatus { get; set; }
}