using ChuaDeThiThu.Client.Services.IServices;
using ChuaDeThiThu.Shared;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ChuaDeThiThu.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var response = await this.httpClient.PostAsJsonAsync("api/product/add", product);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Product>(content);
        }

        public async Task DeleteProduct(Guid id)
        {
            var response = await this.httpClient.DeleteAsync($"api/product/delete/{id}");
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await this.httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/product/list");
        }
    }
}
