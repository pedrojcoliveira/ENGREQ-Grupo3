using AMAPP.API.Data;
using AMAPP.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMAPP.API.Repository.CompoundProductProductRepository
{
    public class CompoundProductProductRepository : RepositoryBase<CompoundProductProduct>, ICompoundProductProductRepository
    {
        public CompoundProductProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new async Task<List<CompoundProductProduct>> GetAllAsync()
        {
            return await _context.CompoundProductProducts
                .Include(cpp => cpp.Product)
                .ToListAsync();
        }

    public new async Task<CompoundProductProduct> GetByIdAsync(int id)
    {
        var compoundProduct = await _context.CompoundProductProducts
            .Include(cpp => cpp.Product)
            .FirstOrDefaultAsync(cpp => cpp.CompoundProductId == id);

        if (compoundProduct == null)
        {
            // Handle the null case as needed, e.g., throw an exception or return a default value
            throw new KeyNotFoundException($"CompoundProductProduct with id {id} not found.");
        }

        return compoundProduct;
    }

        public new async Task AddAsync(CompoundProductProduct compoundProductProduct)
        {
            await _context.CompoundProductProducts.AddAsync(compoundProductProduct);
            await _context.SaveChangesAsync();
        }

    //doesn't work    
public new async Task UpdateAsync(CompoundProductProduct compoundProductProduct)
{
    try
    {
        var existingEntity = await _context.CompoundProductProducts
            .Include(cpp => cpp.Product)
            .FirstOrDefaultAsync(cpp => cpp.CompoundProductId == compoundProductProduct.CompoundProductId && cpp.ProductId == compoundProductProduct.ProductId);

        if (existingEntity == null)
        {
            throw new KeyNotFoundException($"CompoundProductProduct with id {compoundProductProduct.CompoundProductId} and ProductId {compoundProductProduct.ProductId} not found.");
        }

        // Update the properties of the existing entity, excluding the key properties
        _context.Entry(existingEntity).CurrentValues.SetValues(compoundProductProduct);

        // Ensure key properties are not modified
        _context.Entry(existingEntity).Property(e => e.CompoundProductId).IsModified = false;
        _context.Entry(existingEntity).Property(e => e.ProductId).IsModified = false;

        // Update the related Product entity if needed
        if (compoundProductProduct.Product != null)
        {
            _context.Entry(existingEntity.Product).CurrentValues.SetValues(compoundProductProduct.Product);
        }

        await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
        // Log the exception or throw it with more details
        throw new Exception("An error occurred while updating the entity.", ex);
    }
}


        public new async Task RemoveAsync(CompoundProductProduct compoundProductProduct)
        {
            _context.CompoundProductProducts.Remove(compoundProductProduct);
            await _context.SaveChangesAsync();
        }
        
        public async Task<List<CompoundProductProduct>> GetByProductIdAsync(int productId)
        {
            var compoundProducts = await _context.CompoundProductProducts
                .Include(cpp => cpp.Product)
                .Where(cpp => cpp.ProductId == productId)
                .ToListAsync();

            if (compoundProducts == null || !compoundProducts.Any())
            {
                // Handle the null or empty case as needed, e.g., throw an exception or return a default value
                throw new KeyNotFoundException($"No CompoundProductProducts with ProductId {productId} found.");
            }

            return compoundProducts;
        }
        
    }
}