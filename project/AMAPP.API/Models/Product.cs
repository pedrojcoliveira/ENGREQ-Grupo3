namespace AMAPP.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public double ReferencePrice { get; set; }
        public string DeliveryUnit { get; set; }

        // Relacionamento com TipoProduto
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        // Relacionamento muitos-para-muitos
        public List<CompoundProductProduct> CompoundProductProduct { get; set; } = new List<CompoundProductProduct>();
    }
}
