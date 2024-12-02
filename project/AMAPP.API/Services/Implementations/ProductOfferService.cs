using AMAPP.API.DTOs.ProductOffer;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProductOfferRepository;
using AMAPP.API.Repository.ProdutoRepository;
using AMAPP.API.Repository.SubscriptionPeriodRepository;
using AMAPP.API.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMAPP.API.Services.Implementations
{
    public class ProductOfferService : IProductOfferService
    {
        private readonly IProductOfferRepository _productOfferRepository;
        private readonly ISubscriptionPeriodRepository _subscriptionPeriodRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductOfferService(
            IProductOfferRepository productOfferRepository,
            ISubscriptionPeriodRepository subscriptionPeriodRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productOfferRepository = productOfferRepository;
            _subscriptionPeriodRepository = subscriptionPeriodRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductOfferDto> CreateProductOfferAsync(ProductOfferDto productOfferDto)
        {
            // Validar se o PeriodSubscriptionId existe
            var subscriptionPeriod = await _subscriptionPeriodRepository.GetByIdAsync(productOfferDto.PeriodSubscriptionId);
            if (subscriptionPeriod == null)
            {
                throw new Exception("Período de subscrição inválido.");
            }

            // Validar se o ProductId existe
            var product = await _productRepository.GetByIdAsync(productOfferDto.ProductId);
            if (product == null)
            {
                throw new Exception("Produto inválido.");
            }

            // Criar a oferta de produto
            var productOffer = _mapper.Map<ProductOffer>(productOfferDto);

            // Mapear as datas selecionadas
            productOffer.SelectedDeliveryDates = productOfferDto.SelectedDeliveryDates
                .Select(date => new SelectedDeliveryDate { Date = date, ProductOffer = productOffer })
                .ToList();

            // Salvar no repositório
           // var createdProductOffer = await _productOfferRepository.AddAsync(productOffer);

            return _mapper.Map<ProductOfferDto>(createdProductOffer);
        }

        public async Task<ProductOfferDto> GetProductOfferByIdAsync(int id)
        {
            var productOffer = await _productOfferRepository.GetByIdAsync(id);
            return _mapper.Map<ProductOfferDto>(productOffer);
        }

        public async Task<List<ProductOfferDto>> GetProductOffersBySubscriptionPeriodAsync(int subscriptionPeriodId)
        {
            var productOffers = await _productOfferRepository.GetBySubscriptionPeriodIdAsync(subscriptionPeriodId);
            return _mapper.Map<List<ProductOfferDto>>(productOffers);
        }

        public async Task<bool> AddProductOffersAsync(int subscriptionPeriodId, List<ProductOfferDto> offersDto)
        {
            var productOffers = _mapper.Map<List<ProductOffer>>(offersDto);
            foreach (var offer in productOffers)
            {
                offer.PeriodSubscriptionId = subscriptionPeriodId;
                await _productOfferRepository.AddAsync(offer);
            }
            return true;
        }

        public async Task<bool> RemoveProductOfferAsync(int id)
        {
            var productOffer = await _productOfferRepository.GetByIdAsync(id);
            if (productOffer == null)
                return false;

            await _productOfferRepository.RemoveAsync(productOffer);
            return true;
        }
    }
}
