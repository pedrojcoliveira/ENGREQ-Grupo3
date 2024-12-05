using AMAPP.API.DTOs.SelectedProductOffer;
using AMAPP.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AMAPP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SelectedProductOfferController : ControllerBase
    {
        private readonly ISelectedProductOfferService _selectedProductOfferService;

        public SelectedProductOfferController(ISelectedProductOfferService selectedProductOfferService)
        {
            _selectedProductOfferService = selectedProductOfferService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseSelectedProductOfferDto>> AddSelectedProductOffer([FromBody] CreateSelectedProductOfferDto createSelectedProductOfferDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _selectedProductOfferService.AddSelectedProductOfferAsync(createSelectedProductOfferDto);
            return CreatedAtAction(nameof(AddSelectedProductOffer), new { id = response.Id }, response);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ResponseSelectedProductOfferDto>>> GetAllSelectedProductOffers()
        {
            var selectedProductOffers = await _selectedProductOfferService.GetAllSelectedProductOffersAsync();
            return Ok(selectedProductOffers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseSelectedProductOfferDto>> GetSelectedProductOfferById(int id)
        {
            var selectedProductOffer = await _selectedProductOfferService.GetSelectedProductOfferByIdAsync(id);
            if (selectedProductOffer == null)
                return NotFound();

            return Ok(selectedProductOffer);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ResponseSelectedProductOfferDto>> UpdateSelectedProductOffer(int id, [FromBody] SelectedProductOfferDto updateSelectedProductOfferDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedSelectedProductOffer = await _selectedProductOfferService.UpdateSelectedProductOfferAsync(id, updateSelectedProductOfferDto);
            if (updatedSelectedProductOffer == null)
                return NotFound();

            return Ok(updatedSelectedProductOffer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSelectedProductOffer(int id)
        {
            var isDeleted = await _selectedProductOfferService.DeleteSelectedProductOfferAsync(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }    
    }
}