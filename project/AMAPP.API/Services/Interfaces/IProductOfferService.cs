﻿using AMAPP.API.DTOs.DeliveryDate;
using AMAPP.API.DTOs.ProductOffer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMAPP.API.Services.Interfaces
{
    public interface IProductOfferService
    {
        Task<ProductOfferDto> CreateProductOfferAsync(CreateProductOfferDto productOfferDto);
        Task<ProductOfferDto> GetProductOfferByIdAsync(int id);
        Task<List<ProductOfferDto>> GetProductOffersBySubscriptionPeriodAsync(int subscriptionPeriodId);
        Task<List<ProductOfferDto>> GetAllProductOffersAsync();
        Task<bool> AddProductOffersAsync(int subscriptionPeriodId, List<ProductOfferDto> offersDto);
        Task<bool> UpdateProductOfferAsync(int id, ProductOfferDto productOfferDto);
        Task<bool> RemoveProductOfferAsync(int id);
        Task<List<ProductOfferResultDto>> GetAllProductOffersWithDetailsAsync();
        Task<ProductOfferDetailsDto> GetProductsOfferDetailsById(int id);
    }
}
