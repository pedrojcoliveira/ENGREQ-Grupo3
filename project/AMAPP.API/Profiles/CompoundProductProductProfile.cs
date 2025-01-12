using AMAPP.API.DTOs.CompoundProductProduct;
using AMAPP.API.Models;
using AutoMapper;

namespace AMAPP.API.Profiles
{
    public class CompoundProductProductProfile : Profile
    {
        public CompoundProductProductProfile()
        {
            // Map CreateCompoundProductProductDto to CompoundProductProduct
            CreateMap<CreateCompoundProductProductDto, CompoundProductProduct>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForPath(dest => dest.CompoundProduct.Photo, opt => opt.MapFrom(src => 
                    src.CompoundProduct.Photo != null ? ConvertIFormFileToByteArray(src.CompoundProduct.Photo) : null))
                .ForMember(dest => dest.CompoundProduct, opt => opt.MapFrom(src => src.CompoundProduct));

            
            // Map CompoundProductProduct to CompoundProductProductDto
            CreateMap<CompoundProductProduct, CompoundProductProductDto>()
                .ForMember(dest => dest.CompoundProductId, opt => opt.MapFrom(src => src.CompoundProductId))
                .ForMember(dest => dest.CompoundProduct, opt => opt.MapFrom(src => src.CompoundProduct))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));

            // Map CompoundProductProductDto to CompoundProductProduct
            CreateMap<CompoundProductProductDto, CompoundProductProduct>()
                .ForMember(dest => dest.CompoundProductId, opt => opt.MapFrom(src => src.CompoundProductId))
                .ForMember(dest => dest.CompoundProduct, opt => opt.MapFrom(src => src.CompoundProduct))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));

        CreateMap<UpdateCompoundProductProductDto, CompoundProductProduct>()
            .ForPath(dest => dest.CompoundProduct.Photo, opt => opt.MapFrom(src => 
                src.CompoundProduct.Photo != null ? ConvertIFormFileToByteArray(src.CompoundProduct.Photo) : null))
            .ForMember(dest => dest.CompoundProduct, opt => opt.MapFrom(src => src.CompoundProduct))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));

        }
        
    private byte[] ConvertIFormFileToByteArray(IFormFile formFile)
    {
        if (formFile == null || formFile.Length == 0)
            return null;

        if (formFile.Length > 5 * 1024 * 1024) // 5 MB limit
        {
            throw new ArgumentException("Photo size exceeds the 5MB limit.");
        }

        var validFormats = new[] { ".jpg", ".jpeg", ".png" };
        var fileExtension = Path.GetExtension(formFile.FileName).ToLower();
        if (!validFormats.Contains(fileExtension))
        {
            throw new ArgumentException("Invalid photo format. Only JPG and PNG are allowed.");
        }

        using (var memoryStream = new MemoryStream())
        {
            formFile.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }


    }
}
