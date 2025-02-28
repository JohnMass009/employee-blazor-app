using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EmployeeBlazorApp;
using MudBlazor.Services;
using EmployeeBlazorApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient("EmployeeApi", client =>
{
    var apiBaseUrl = builder.Configuration["EmployeeApiBaseUrl"] 
        ?? throw new Exception("Не удалось загрузить конфигурацию из appsettings.json"); ;
    client.BaseAddress = new Uri(apiBaseUrl);
});

builder.Services.AddMudServices();
builder.Services.AddScoped<EmployeeService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
