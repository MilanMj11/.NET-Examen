namespace ProductsAPI.Models
{
    public class Comanda
    {
        public int ComandaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int UtilizatorId { get; set; }

        public Utilizator Utilizator { get; set; }
        public ICollection<ComandaProdus> ComandaProduse { get; set; }
    }
}
