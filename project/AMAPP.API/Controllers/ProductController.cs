using AMAPP.API.DTOs.Product;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProducerInfoRepository;
using AMAPP.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AMAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly UserManager<User> _userManager;
        private readonly IProducerInfoRepository _producerInfoRepository;

        public ProductController(IProductService productService, UserManager<User> userManager, IProducerInfoRepository producerInfoRepository)
        {
            _productService = productService;
            _userManager = userManager;
            _producerInfoRepository = producerInfoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductDto>> AddProduct([FromForm] CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var createdProduct = await _productService.AddProductAsync(productDto);
                return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedProduct = await _productService.UpdateProductAsync(id, productDto);
            if (updatedProduct == null)
                return NotFound();

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var isDeleted = await _productService.DeleteProductAsync(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }

    }
}
