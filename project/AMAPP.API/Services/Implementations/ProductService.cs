using AMAPP.API.DTOs.Product;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProducerInfoRepository;
using AMAPP.API.Repository.ProdutoRepository;
using AMAPP.API.Services.Interfaces;
using AutoMapper;

namespace AMAPP.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProducerInfoRepository _producerInfoRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper, IProducerInfoRepository producerInfoRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _producerInfoRepository = producerInfoRepository;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return null;

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> AddProductAsync(CreateProductDto productDto, string producerId)
        {
            var producerInfo = await _producerInfoRepository.GetProducerInfoByUserIdAsync(producerId);
            if (producerInfo == null)
            {
                producerInfo = new ProducerInfo
                {
                    UserId = producerId
                };

                await _producerInfoRepository.AddAsync(producerInfo);
            }


            // Convert the uploaded image to a byte array
            byte[]? photoBytes = null;
            if (productDto.Photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await productDto.Photo.CopyToAsync(memoryStream);
                    photoBytes = memoryStream.ToArray();
                }
            }

            var product = _mapper.Map<Product>(productDto);

            product.Photo = photoBytes;
            product.ProducerInfoId = producerInfo.Id;

            await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(int id, ProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);

            if (existingProduct == null)
                return null;

            _mapper.Map(productDto, existingProduct);
            await _productRepository.UpdateAsync(existingProduct);

            return _mapper.Map<ProductDto>(existingProduct);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return false;

            await _productRepository.RemoveAsync(product);

            return true;
        }
    }
}
