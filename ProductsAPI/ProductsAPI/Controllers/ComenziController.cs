using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProductsAPI.Dtos;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComenziController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComenziController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comanda>> GetComenzi()
        {
            var comenzi = _context.Comenzi.Include(c => c.ComandaProduse).ToList();
            return Ok(comenzi);
        }

        [HttpPost]
        public ActionResult<Comanda> AdaugaComanda(ComandaDto comandaDto)
        {
            var comanda = new Comanda()
            {
                Name = comandaDto.Name,
                Description = comandaDto.Description,
                UtilizatorId = comandaDto.UtilizatorId, 
            };
            
            _context.Comenzi.Add(comanda);
            _context.SaveChanges();
            
            return Ok(comanda);
        }

    }
}
