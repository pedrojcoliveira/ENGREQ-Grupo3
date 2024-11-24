using AMAPP.API.DTOs.Produto;
using AMAPP.API.Models;
using AutoMapper;

namespace AMAPP.API.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            // Map Produto to ProductDto
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductTypeId, opt => opt.MapFrom(src => src.ProductType.Id));

            // Map ProductDto to Produto
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.ProductType, opt => opt.Ignore()); // TipoProduto is set separately
        }
    }
}
