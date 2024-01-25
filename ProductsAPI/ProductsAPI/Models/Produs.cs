using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models
{
    public class Produs
    {
        public int ProdusId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Units { get; set; }

        public ICollection<ComandaProdus> ComandaProduse { get; set; }
    }
}
