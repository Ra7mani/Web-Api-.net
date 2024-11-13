using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_api.Infrastructure.Data;
using test_api.Model.Domaine.Entities;

namespace test_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDbController : ControllerBase
    {
        private readonly BdApp _bd;

        public ProductDbController(BdApp bd)
        {
            _bd = bd;
        }

        [HttpGet]
        public async Task<IActionResult> Getproducts()
        {

            var prod = await _bd.Products.ToListAsync();
            return Ok(prod);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _bd.Products.FindAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _bd.Products.AddAsync(product);
            await _bd.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = await _bd.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            _bd.Entry(existingProduct).CurrentValues.SetValues(product);

            try
            {
                await _bd.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
                return Conflict("The product was updated or deleted by another process.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _bd.Products.FindAsync(id);
            _bd.Products.Remove(product);
            await _bd.SaveChangesAsync();

            return NoContent();
        }
    }
}
