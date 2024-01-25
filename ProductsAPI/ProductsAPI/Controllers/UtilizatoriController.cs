using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Dtos;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UtilizatoriController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UtilizatoriController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Utilizator>> GetUtilizatori()
        {
            var utilizatori = _context.Utilizatori.ToList();
            return Ok(utilizatori);
        }

        [HttpPost]
        public ActionResult<Utilizator> AdaugaUtilizator(UtilizatorDto utilizatordto)
        {
            var utilizator = new Utilizator
            {
                Name = utilizatordto.Name,
                Age = utilizatordto.Age
            };

            _context.Utilizatori.Add(utilizator);
            _context.SaveChanges();
            return Ok(utilizator);
        }
    }
}
