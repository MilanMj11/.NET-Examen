namespace ProductsAPI.Models
{
    public class ComandaProdus
    {
        public int ComandaId { get; set; }
        public int ProdusId { get; set; }
        public Comanda Comanda { get; set; }
        public Produs Produs { get; set; }
    }
}
