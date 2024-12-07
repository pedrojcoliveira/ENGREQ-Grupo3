using AMAPP.API.DTOs.Product;
using AMAPP.API.Models;
using AMAPP.API.Repository.ProducerInfoRepository;
using AMAPP.API.Repository.ProdutoRepository;
using AMAPP.API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AMAPP.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProducerInfoRepository _producerInfoRepository;
        private readonly UserManager<User> _userManager;

        public ProductService(IProductRepository productRepository, IMapper mapper, IProducerInfoRepository producerInfoRepository, UserManager<User> userManager)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _producerInfoRepository = producerInfoRepository;
            _userManager = userManager;
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

        public async Task<ProductDto> AddProductAsync(CreateProductDto productDto)
        {
            var producer = await _userManager.FindByNameAsync("quimbarreiros");
            if (producer == null)
                throw new KeyNotFoundException("Producer not found.");

            if (productDto.Photo != null)
            {
                if (productDto.Photo.Length > 5 * 1024 * 1024) // 5 MB limit
                {
                    throw new ArgumentException("Photo size exceeds the 5MB limit.");
                }

                var validFormats = new[] { ".jpg", ".jpeg", ".png" };
                var fileExtension = Path.GetExtension(productDto.Photo.FileName).ToLower();
                if (!validFormats.Contains(fileExtension))
                {
                    throw new ArgumentException("Invalid photo format. Only JPG and PNG are allowed.");
                }
            }


            var producerInfo = await _producerInfoRepository.GetProducerInfoByUserIdAsync(producer.Id);
            if (producerInfo == null)
            {
                producerInfo = new ProducerInfo
                {
                    UserId = producer.Id
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

        public async Task<ProductDto> UpdateProductAsync(int id, UpdateProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);

            if (existingProduct == null)
                throw new KeyNotFoundException("Producer not found.");


            if (productDto.Photo != null)
            {
                if (productDto.Photo.Length > 5 * 1024 * 1024) // 5 MB limit
                {
                    throw new ArgumentException("Photo size exceeds the 5MB limit.");
                }

                var validFormats = new[] { ".jpg", ".jpeg", ".png" };
                var fileExtension = Path.GetExtension(productDto.Photo.FileName).ToLower();
                if (!validFormats.Contains(fileExtension))
                {
                    throw new ArgumentException("Invalid photo format. Only JPG and PNG are allowed.");
                }
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

            _mapper.Map(productDto, existingProduct);

            existingProduct.Photo = photoBytes;

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
