using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EmployeeBlazorApp;
using MudBlazor.Services;
using EmployeeBlazorApp.Services;
using System.Net.Http.Json;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var apiBaseUrl = builder.Configuration.GetValue<string>("EmployeeApiBaseUrl")
    ?? throw new Exception("Не удалось загрузить конфигурацию из appsettings.json");

builder.Services.AddScoped(sp =>
{
    return new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
});

builder.Services.AddMudServices();
builder.Services.AddScoped<EmployeeService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
