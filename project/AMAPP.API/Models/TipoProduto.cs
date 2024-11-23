namespace AMAPP.API.Models
{
    public class TipoProduto
    {
        public int Id { get; set; } // Ex.: 1 (Simples), 2 (Composto)
        public string Nome { get; set; } // Ex.: "Simples", "Composto"
        public string Descricao { get; set; } // Opcional: "Produto individual sem composição"
    }
}
