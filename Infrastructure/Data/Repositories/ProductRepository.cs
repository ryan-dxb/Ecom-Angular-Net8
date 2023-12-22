using Core;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly EcomDbContext context;

    public ProductRepository(EcomDbContext context)
    {
        this.context = context;
    }

    public Task<IList<Product>> GetProductsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IList<ProductBrand>> GetProductBrandsAsync()
    {
        return await context.ProductBrands.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await context.Products.Include(x => x.ProductBrand).Include(x => x.ProductType).
            FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Product not found");
    }


    public Task<IList<ProductType>> GetProductTypesAsync()
    {
        throw new NotImplementedException();
    }
}
