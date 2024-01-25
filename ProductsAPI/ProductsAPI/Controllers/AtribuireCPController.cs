using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtribuireCPController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AtribuireCPController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("comanda/{comandaId}/produs/{produsId}")]
        public ActionResult AtribuireProdusLaComanda(int comandaId, int produsId)
        {
            var comanda = _context.Comenzi.Find(comandaId);
            var produs = _context.Produse.Find(produsId);

            if (comanda == null || produs == null) { return NotFound(); }

            var atribuire = new ComandaProdus { ComandaId = comandaId, ProdusId = produsId };
            _context.ComandaProduse.Add(atribuire);

            return Ok(atribuire);
        }
    }
}
