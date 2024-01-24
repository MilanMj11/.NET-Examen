using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            if (products == null || products.Count == 0)
            {
                return NotFound();
            }

            return products;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product prod)
        {
            _context.Products.Add(prod);
            await _context.SaveChangesAsync();

            // Return 201 Created with the location of the newly created resource
            return CreatedAtAction(nameof(GetProducts), new { id = prod.Id }, prod);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product prod)
        {
            if (id != prod.Id)
            {
                return BadRequest("Invalid ID in the request body.");
            }

            _context.Entry(prod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(p => p.Id == id))
                {
                    return NotFound(); // Return 404 if the product with the given ID is not found.
                }
                else
                {
                    throw; // Rethrow the exception if it's not a concurrency issue.
                }
            }

            return NoContent(); // Return 204 No Content if the update is successful.
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(); // Return 404 if the product with the given ID is not found.
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content if the deletion is successful.
        }
    }

}
