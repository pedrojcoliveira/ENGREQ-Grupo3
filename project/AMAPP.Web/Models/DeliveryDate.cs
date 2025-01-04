namespace AMAPP.Web.Models;

public class DeliveryDate
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int SubscriptionPeriodId { get; set; }
    public Constants.ResourceStatus ResourceStatus { get; set; }
}