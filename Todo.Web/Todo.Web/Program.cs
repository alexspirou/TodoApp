using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Todo.Web;
using Todo.Web.Services.Interfaces;
using Todo.Web.Services;
using Todo.Web.Common;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddScoped<AppState>();
builder.Services.AddScoped<QuoteService>();
builder.Services.AddScoped<ITodoMangerService, TodoManagerService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

