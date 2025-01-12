using AMAPP.API.DTOs.CompoundProductProduct;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProducerInfoRepository;
using AMAPP.API.Repository.CompoundProductProductRepository;
using AMAPP.API.Repository.ProdutoRepository;
using AMAPP.API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AMAPP.API.Services.Implementations
{
    public class CompoundProductProductService : ICompoundProductProductService
    {
        private readonly ICompoundProductProductRepository _compoundProductProductRepository;
        private readonly IMapper _mapper;
        private readonly IProducerInfoRepository _producerInfoRepository;
        private readonly UserManager<User> _userManager;
        private readonly IProductRepository _ProductRepository;

        public CompoundProductProductService(ICompoundProductProductRepository compoundProductProductRepository, IMapper mapper, IProducerInfoRepository producerInfoRepository, UserManager<User> userManager, IProductRepository ProductRepository)
        {
            _compoundProductProductRepository = compoundProductProductRepository;
            _mapper = mapper;
            _producerInfoRepository = producerInfoRepository;
            _userManager = userManager;
            _ProductRepository = ProductRepository;
        }

        public async Task<List<CompoundProductProductDto>> GetAllCompoundProductProducts()
        {
            var compoundProducts = await _compoundProductProductRepository.GetAllAsync();
            
            foreach (var compoundProduct in compoundProducts)
            {
                compoundProduct.Product = await _ProductRepository.GetByIdAsync(compoundProduct.ProductId);
            }
            
            return _mapper.Map<List<CompoundProductProductDto>>(compoundProducts);
        }

        public async Task<CompoundProductProductDto> GetCompoundProductProductById(int id)
        {
            var compoundProduct = await _compoundProductProductRepository.GetByIdAsync(id);

            if (compoundProduct == null)
                return null;
            
            compoundProduct.Product = await _ProductRepository.GetByIdAsync(compoundProduct.ProductId);

            return _mapper.Map<CompoundProductProductDto>(compoundProduct);
        }

        public async Task<CompoundProductProductDto> CreateCompoundProductProduct(CreateCompoundProductProductDto newCompoundProductProduct)
        {
            var producer = await _userManager.FindByNameAsync("quimbarreiros");
            if (producer == null)
                throw new KeyNotFoundException("Producer not found.");

            var producerInfo = await _producerInfoRepository.GetProducerInfoByUserIdAsync(producer.Id);
            if (producerInfo == null)
            {
                producerInfo = new ProducerInfo
                {
                    UserId = producer.Id
                };

                await _producerInfoRepository.AddAsync(producerInfo);
            }

            var compoundProduct = _mapper.Map<CompoundProductProduct>(newCompoundProductProduct);
            compoundProduct.CompoundProduct.ProducerInfoId = producerInfo.Id;

            await _compoundProductProductRepository.AddAsync(compoundProduct);
            
            compoundProduct.Product = await _ProductRepository.GetByIdAsync(compoundProduct.ProductId);
            return _mapper.Map<CompoundProductProductDto>(compoundProduct);
        }

        public async Task<CompoundProductProductDto> UpdateCompoundProductProduct(int id, UpdateCompoundProductProductDto updateCompoundProductProduct)
        {
            var existingCompoundProduct = await _compoundProductProductRepository.GetByIdAsync(id);

            if (existingCompoundProduct == null)
                throw new KeyNotFoundException("Compound product not found.");

            _mapper.Map(updateCompoundProductProduct, existingCompoundProduct);
            
            existingCompoundProduct.CompoundProductId = id;

            var validateProduct= await _ProductRepository.GetByIdAsync(existingCompoundProduct.ProductId);
            if (validateProduct == null)
                throw new KeyNotFoundException("Product not found.");
            
            //only update the associated product
            //await _ProductRepository.UpdateAsync(existingCompoundProduct.CompoundProduct);
            
            //doesn't work due to keys violation
            await _compoundProductProductRepository.UpdateAsync(existingCompoundProduct);
            
            return _mapper.Map<CompoundProductProductDto>(existingCompoundProduct);
        }

        public async Task<bool> DeleteCompoundProductProduct(int id)
        {
            var compoundProduct = await _compoundProductProductRepository.GetByIdAsync(id);

            if (compoundProduct == null)
                return false;

            await _compoundProductProductRepository.RemoveAsync(compoundProduct);

            return true;
        }
        
    }
}