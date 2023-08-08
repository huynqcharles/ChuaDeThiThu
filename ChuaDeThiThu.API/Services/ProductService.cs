using ChuaDeThiThu.API.Data;
using ChuaDeThiThu.API.Services.IServices;
using ChuaDeThiThu.Shared;
using Microsoft.EntityFrameworkCore;

namespace ChuaDeThiThu.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> AddProduct(Product product)
        {
            await this.dbContext.Products.AddAsync(product);
            await this.dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(Guid id)
        {
            var product = await this.dbContext.FindAsync<Product>(id);

            this.dbContext.Remove(product);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await this.dbContext.Products.ToListAsync();
        }
    }
}
