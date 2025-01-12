using AMAPP.API.DTOs.CompoundProductProduct;
using AMAPP.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AMAPP.API.Models;

namespace AMAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompoundProductProductController : ControllerBase
    {
        private readonly ICompoundProductProductService _compoundProductProductService;
        private readonly UserManager<User> _userManager;

        
        public CompoundProductProductController(ICompoundProductProductService compoundProductProductService, UserManager<User> userManager)
        {
            _compoundProductProductService = compoundProductProductService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompoundProductProductDto>>> GetAllCompoundProductProducts()
        {
            var compoundProducts = await _compoundProductProductService.GetAllCompoundProductProducts();
            return Ok(compoundProducts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompoundProductProductDto>> GetCompoundProductProductById(int id)
        {
            var compoundProduct = await _compoundProductProductService.GetCompoundProductProductById(id);
            if (compoundProduct == null)
                return NotFound();

            return Ok(compoundProduct);
        }

        [HttpPost]
        public async Task<ActionResult<CreateCompoundProductProductDto>> CreateCompoundProductProduct([FromForm] CreateCompoundProductProductDto compoundProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var createdCompoundProduct = await _compoundProductProductService.CreateCompoundProductProduct(compoundProductDto);
                return CreatedAtAction(nameof(GetCompoundProductProductById), new { id = createdCompoundProduct.CompoundProductId }, createdCompoundProduct);
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
        public async Task<ActionResult<CompoundProductProductDto>> UpdateCompoundProductProduct(int id, [FromForm] UpdateCompoundProductProductDto compoundProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedCompoundProduct = await _compoundProductProductService.UpdateCompoundProductProduct(id, compoundProductDto);
                if (updatedCompoundProduct == null)
                    return NotFound();

                return Ok(updatedCompoundProduct);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompoundProductProduct(int id)
        {
            var isDeleted = await _compoundProductProductService.DeleteCompoundProductProduct(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}