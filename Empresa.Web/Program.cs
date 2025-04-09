using Empresa.Web;
using Empresa.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<MovimientoApiService>();

var URL = "http://localhost:5062";

builder.Services.AddHttpClient<ClienteApiService>(client => client.BaseAddress = new Uri(URL));

builder.Services.AddHttpClient<EstadoApiService>(client => client.BaseAddress = new Uri(URL));

builder.Services.AddHttpClient<EquipoApiService>(client => client.BaseAddress = new Uri(URL));

builder.Services.AddHttpClient<OperarioApiService>(client => client.BaseAddress = new Uri(URL));

builder.Services.AddHttpClient<MovimientoApiService>(client => client.BaseAddress = new Uri(URL));

await builder.Build().RunAsync();
