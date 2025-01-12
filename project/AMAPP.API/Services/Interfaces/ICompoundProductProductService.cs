using AMAPP.API.DTOs.CompoundProductProduct;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMAPP.API.Services.Interfaces
{
    public interface ICompoundProductProductService
    {
        Task<List<CompoundProductProductDto>> GetAllCompoundProductProducts();
        Task<CompoundProductProductDto> GetCompoundProductProductById(int id);
        Task<CompoundProductProductDto> CreateCompoundProductProduct(CreateCompoundProductProductDto newCompoundProductProduct);
        Task<CompoundProductProductDto> UpdateCompoundProductProduct(int id, UpdateCompoundProductProductDto updateCompoundProductProduct);
        Task<bool> DeleteCompoundProductProduct(int id);
    }
}