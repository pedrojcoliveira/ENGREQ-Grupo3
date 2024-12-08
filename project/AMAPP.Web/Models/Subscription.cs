namespace AMAPP.Web.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string CoproducerName { get; set; }
        public string PeriodDescription { get; set; }

        // Lista de produtos selecionados
        public List<string> Products { get; set; } = new();

        public decimal TotalPayments { get; set; }
    }
}
