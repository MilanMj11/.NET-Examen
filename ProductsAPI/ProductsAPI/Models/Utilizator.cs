namespace ProductsAPI.Models
{
    public class Utilizator
    {
        public int UtilizatorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public ICollection<Comanda> Comenzi { get; set; }
    }
}
