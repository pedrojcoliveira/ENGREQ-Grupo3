using AMAPP.API.DTOs.DeliveryDate;
using AMAPP.API.DTOs.Product;
using AMAPP.API.Models;
using AutoMapper;

namespace AMAPP.API.Profiles
{
    public class DeliveryDateProfile: Profile
    {
        public DeliveryDateProfile()
        {
            // Map Produto to ProductDto
            CreateMap<DeliveryDate, DeliveryDateDto>();

            // Map CreateProductDto to Produto
            CreateMap<DeliveryDateDto, DeliveryDate>();


        }
    }
}
