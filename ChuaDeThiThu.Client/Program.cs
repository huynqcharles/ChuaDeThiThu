using ChuaDeThiThu.Client;
using ChuaDeThiThu.Client.Services;
using ChuaDeThiThu.Client.Services.IServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7053/")
});

builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
