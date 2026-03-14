using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Create(CreateProductDto dto)
        {
            var createdProduct = _service.Create(dto);

            return CreatedAtAction(nameof(GetById),
                                   new { id = createdProduct.ProductId },
                                   createdProduct);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateProductDto dto)
        {
            var updated = _service.Update(id, dto);

            if (!updated)
                return NotFound("Product not found");

            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);

            if (!deleted)
                return NotFound("Product not found");

            return NoContent();
        }
    }
}
