using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Dtos;
using ProductsAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduseController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProduseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Produs>> GetProduse()
        {
            var produse = _context.Produse.ToList();
            return Ok(produse);
        }

        [HttpPost]
        public ActionResult<Produs> AdaugaProdus(ProdusDto produsdto)
        {
            var produs = new Produs
            {
                Name = produsdto.Name,
                Price = produsdto.Price,
                Units = produsdto.Units
            };

            _context.Produse.Add(produs);
            _context.SaveChanges();
            return Ok(produs);
        }
    }
}
