using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_api.Filter;
using test_api.Model.Domaine;
using test_api.Model.Domaine.Entities;

namespace test_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IDAO _dao;
        public ProductController(IDAO dao)
        {
            _dao = dao;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetProductbyid([FromRoute] int id)
        {
            var product = _dao.GetProductById(id);
            if (product == null)
            {
                return NotFound($"product id : {id} not found");
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product prod)
        {
            var  prduct = _dao.AjouterProduct(prod);
            //return CreatedAtAction(nameof(GetProduct) , new {id = prod.ProductId} , prod);
            return Ok(prduct);
        }
        [TokenAuthenticationFilter]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            _dao.deleteProduct(id);

            return Ok("product deleted");

        }

        [HttpPut ("{id}")]
        public IActionResult Updateproduct([FromRoute] int id ,Product prod)
        {
            _dao.updateProduct(id, prod);
            return Ok(prod);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_dao.GetProducts());
        }

    }
}
