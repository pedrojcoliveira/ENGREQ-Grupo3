using AMAPP.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMAPP.API.Repository.CompoundProductProductRepository
{
    public interface ICompoundProductProductRepository
    {
        Task<List<CompoundProductProduct>> GetAllAsync();
        Task<CompoundProductProduct> GetByIdAsync(int id);
        Task AddAsync(CompoundProductProduct compoundProductProduct);
        Task UpdateAsync(CompoundProductProduct compoundProductProduct);
        Task RemoveAsync(CompoundProductProduct compoundProductProduct);
        
        Task<List<CompoundProductProduct>> GetByProductIdAsync(int productId);
        

    }
}