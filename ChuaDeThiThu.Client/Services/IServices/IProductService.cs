using ChuaDeThiThu.Shared;

namespace ChuaDeThiThu.Client.Services.IServices
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<IEnumerable<Product>> GetProducts();
        Task DeleteProduct(Guid id);
    }
}
