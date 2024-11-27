using AMAPP.API.DTOs.Product;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProducerInfoRepository;
using AMAPP.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Linq;
using System.Security.Principal;

namespace AMAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly UserManager<User> _userManager;
        private readonly IProducerInfoRepository _producerInfoRepository;

        public ProductController(IProductService productService, UserManager<User> userManager)
        {
            _productService = productService;
            _userManager = userManager;
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
        public async Task<ActionResult<ProductDto>> AddProduct([FromForm] CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var producer = await _userManager.FindByNameAsync("quimbarreiros");
            if (producer == null)
                return NotFound("Producer not found.");

            if (productDto.Photo != null)
            {
                if (productDto.Photo.Length > 5 * 1024 * 1024) // 5 MB limit
                {
                    return BadRequest("Photo size exceeds the 5MB limit.");
                }

                var validFormats = new[] { ".jpg", ".jpeg", ".png" };
                var fileExtension = Path.GetExtension(productDto.Photo.FileName).ToLower();
                if (!validFormats.Contains(fileExtension))
                {
                    return BadRequest("Invalid photo format. Only JPG and PNG are allowed.");
                }
            }

            var createdProduct = await _productService.AddProductAsync(productDto, producer.Id);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
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
