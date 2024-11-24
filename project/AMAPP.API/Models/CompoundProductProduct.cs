namespace AMAPP.API.Models
{
    public class CompoundProductProduct
    {
        public int CompoundProductId { get; set; }
        public Product CompoundProduct { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
