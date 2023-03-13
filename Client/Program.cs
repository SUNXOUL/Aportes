using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Aportes.Client;
using Aportes.Client.Sevices.PersonaService;
using Aportes.Client.Services.AporteService;
using Aportes.Client.Services.TiposAporteService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IAporteService, AporteService>();
builder.Services.AddScoped<ITiposAportesService, TiposAportesService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
