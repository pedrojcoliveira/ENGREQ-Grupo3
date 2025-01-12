using Microsoft.AspNetCore.Mvc;
using AMAPP.API.Services.Interfaces;
using AMAPP.API.DTOs.ProductOffer;
using AMAPP.API.Repository.ProdutoRepository;
using AMAPP.API.Repository.SubscriptionPeriodRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using AMAPP.API.DTOs.Product;
using AMAPP.API.Services.Implementations;

namespace AMAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOfferController : ControllerBase
    {
        private readonly IProductOfferService _productOfferService;
        private readonly IProductRepository _productRepository;
        private readonly ISubscriptionPeriodRepository _subscriptionPeriodRepository;

        public ProductOfferController(
            IProductOfferService productOfferService,
            IProductRepository productRepository,
            ISubscriptionPeriodRepository subscriptionPeriodRepository)
        {
            _productOfferService = productOfferService;
            _productRepository = productRepository;
            _subscriptionPeriodRepository = subscriptionPeriodRepository;
        }

        /// <summary>
        /// Cria uma oferta de produto para o período de subscrição especificado.
        /// </summary>
        /// <param name="createProductOfferDto">Dados da oferta de produto a serem criados.</param>
        /// <returns>Retorna a oferta criada ou erros de validação.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProductOfferDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateProductOffer([FromBody] CreateProductOfferDto createProductOfferDto)
        {
            try
            {
                var createdProductOffer = await _productOfferService.CreateProductOfferAsync(createProductOfferDto);
                return CreatedAtAction(nameof(GetProductOfferById), new { id = createdProductOffer.ProductId }, createdProductOffer);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }

        }

        /// <summary>
        /// Adiciona várias ofertas de produtos para um período de subscrição especificado.
        /// </summary>
        /// <param name="subscriptionPeriodId">ID do período de subscrição.</param>
        /// <param name="offersDto">Lista de ofertas de produtos a serem adicionadas.</param>
        /// <returns>Retorna NoContent se bem-sucedido ou erros de validação.</returns>
        [HttpPost("subscription/{subscriptionPeriodId}/offers")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddProductOffers(int subscriptionPeriodId, [FromBody] List<ProductOfferDto> offersDto)
        {
            if (offersDto == null || !offersDto.Any())
            {
                return BadRequest("Dados inválidos: é necessário fornecer ao menos uma oferta de produto.");
            }

            var success = await _productOfferService.AddProductOffersAsync(subscriptionPeriodId, offersDto);
            if (!success)
            {
                return BadRequest("Falha ao adicionar ofertas de produtos.");
            }

            return NoContent();
        }

        /// <summary>
        /// Retorna a oferta de produto com o ID especificado.
        /// </summary>
        /// <param name="id">ID da oferta de produto.</param>
        /// <returns>A oferta de produto ou erro caso não encontrada.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductOfferDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetProductOfferById(int id)
        {
            var productOffer = await _productOfferService.GetProductOfferByIdAsync(id);
            if (productOffer == null)
            {
                return NotFound("Oferta de produto não encontrada.");
            }
            return Ok(productOffer);
        }

        /// <summary>
        /// Lista todas as ofertas de produtos.
        /// </summary>
        /// <returns>Lista de ofertas de produtos.</returns>
        // GET: api/ProductOffer
        [HttpGet]
        [ProducesResponseType(typeof(List<ProductOfferResultDto>), 200)]
        public async Task<IActionResult> GetAllProductOffers()
        {
            try
            {
                var productOffers = await _productOfferService.GetAllProductOffersWithDetailsAsync();
                return Ok(productOffers);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        /// <summary>
        /// Atualiza uma oferta de produto existente.
        /// </summary>
        /// <param name="id">ID da oferta de produto a ser atualizada.</param>
        /// <param name="productOfferDto">Dados atualizados da oferta de produto.</param>
        /// <returns>Retorna NoContent se bem-sucedido ou erros de validação.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateProductOffer(int id, [FromBody] ProductOfferDto productOfferDto)
        {
            // Validações iniciais
            if (productOfferDto == null || productOfferDto.SelectedDeliveryDates == null || !productOfferDto.SelectedDeliveryDates.Any())
            {
                return BadRequest("Dados inválidos: é necessário selecionar ao menos uma data de entrega.");
            }

            // Validar o Período de Subscrição
            var subscriptionPeriod = await _subscriptionPeriodRepository.GetByIdAsync(productOfferDto.SubscriptionPeriodId);
            if (subscriptionPeriod == null)
            {
                return NotFound("Período de subscrição não encontrado.");
            }

            // Validar o Produto
            var product = await _productRepository.GetByIdAsync(productOfferDto.ProductId);
            if (product == null)
            {
                return NotFound("Produto não encontrado.");
            }

            // Verificar se as datas de entrega estão dentro do período de subscrição
            //var invalidDates = productOfferDto.SelectedDeliveryDates
            //    .Where(date => date < subscriptionPeriod.StartDate || date > subscriptionPeriod.EndDate)
            //    .ToList();

            //if (invalidDates.Any())
            //{
            //    return BadRequest("Algumas datas de entrega estão fora do período de subscrição permitido.");
            //}

            // Atualizar a oferta de produto
            var success = await _productOfferService.UpdateProductOfferAsync(id, productOfferDto);
            if (!success)
            {
                return NotFound("Oferta de produto não encontrada.");
            }

            return NoContent();
        }

        /// <summary>
        /// Remove uma oferta de produto existente.
        /// </summary>
        /// <param name="id">ID da oferta de produto a ser removida.</param>
        /// <returns>Retorna NoContent se bem-sucedido ou erro caso não encontrada.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteProductOffer(int id)
        {
            var success = await _productOfferService.RemoveProductOfferAsync(id);
            if (!success)
            {
                return NotFound("Oferta de produto não encontrada.");
            }

            return NoContent();
        }

        [HttpGet("{id}/productofferdetails")]
        public async Task<ActionResult> GetProductsOfferDates(int id)
        {
            try
            {
                var ProductOfferDetailsDto = await _productOfferService.GetProductsOfferDetailsById(id);

                return Ok(ProductOfferDetailsDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}



