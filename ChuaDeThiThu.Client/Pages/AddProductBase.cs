using ChuaDeThiThu.Client.Services.IServices;
using ChuaDeThiThu.Shared;
using Microsoft.AspNetCore.Components;

namespace ChuaDeThiThu.Client.Pages
{
    public class AddProductBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }
        public Product product { get; set; } = new Product();

        public async Task HandleSubmitForm()
        {
            var result = await ProductService.AddProduct(product);
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
