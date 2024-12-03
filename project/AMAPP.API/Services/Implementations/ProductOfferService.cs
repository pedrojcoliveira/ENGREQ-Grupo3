using AMAPP.API.DTOs.ProductOffer;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProductOfferRepository;
using AMAPP.API.Repository.ProdutoRepository;
using AMAPP.API.Repository.SubscriptionPeriodRepository;
using AMAPP.API.Services.Interfaces;
using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<ProductOfferDto> _productOfferDtoValidator;

        public ProductOfferService(
            IProductOfferRepository productOfferRepository,
            ISubscriptionPeriodRepository subscriptionPeriodRepository,
            IProductRepository productRepository,
            IMapper mapper,
            IValidator<ProductOfferDto> productOfferDtoValidator)
        {
            _productOfferRepository = productOfferRepository;
            _subscriptionPeriodRepository = subscriptionPeriodRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _productOfferDtoValidator = productOfferDtoValidator;
        }

        public async Task<ProductOfferDto> CreateProductOfferAsync(ProductOfferDto productOfferDto)
        {
            var validationResult = await _productOfferDtoValidator.ValidateAsync(productOfferDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

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
            await _productOfferRepository.AddAsync(productOffer);

            // Retornar o DTO da oferta de produto criada
            return _mapper.Map<ProductOfferDto>(productOffer);
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

        public async Task<List<ProductOfferDto>> GetAllProductOffersAsync()
        {
            var productOffers = await _productOfferRepository.GetAllAsync();
            return _mapper.Map<List<ProductOfferDto>>(productOffers);
        }

        public async Task<bool> AddProductOffersAsync(int subscriptionPeriodId, List<ProductOfferDto> offersDto)
        {
            foreach (var offerDto in offersDto)
            {
                var validationResult = await _productOfferDtoValidator.ValidateAsync(offerDto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.ToString());
                }
            }

            var productOffers = _mapper.Map<List<ProductOffer>>(offersDto);
            foreach (var offer in productOffers)
            {
                offer.PeriodSubscriptionId = subscriptionPeriodId;
                await _productOfferRepository.AddAsync(offer);
            }
            return true;
        }

        public async Task<bool> UpdateProductOfferAsync(int id, ProductOfferDto productOfferDto)
        {
            var validationResult = await _productOfferDtoValidator.ValidateAsync(productOfferDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var existingProductOffer = await _productOfferRepository.GetByIdAsync(id);
            if (existingProductOffer == null)
            {
                return false;
            }

            // Atualizar os campos da oferta de produto
            existingProductOffer.ProductId = productOfferDto.ProductId;
            existingProductOffer.PeriodSubscriptionId = productOfferDto.PeriodSubscriptionId;
            existingProductOffer.SelectedDeliveryDates = productOfferDto.SelectedDeliveryDates
                .Select(date => new SelectedDeliveryDate { Date = date, ProductOffer = existingProductOffer })
                .ToList();

            await _productOfferRepository.UpdateAsync(existingProductOffer);
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
