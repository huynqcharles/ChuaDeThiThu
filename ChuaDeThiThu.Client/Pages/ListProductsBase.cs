using ChuaDeThiThu.Client.Services.IServices;
using ChuaDeThiThu.Shared;
using Microsoft.AspNetCore.Components;

namespace ChuaDeThiThu.Client.Pages
{
    public class ListProductsBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        public IEnumerable<Product> products { get; set; }
        public int Count = 1;

        protected override async Task OnInitializedAsync()
        {
            products = (await ProductService.GetProducts()).ToList();
        }

        public async Task DeleteProduct(Guid id)
        {
            await ProductService.DeleteProduct(id);
            NavigationManager.NavigateTo("/list", forceLoad: true);
        }
    }
}
