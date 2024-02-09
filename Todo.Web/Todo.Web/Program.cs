using Todo.Middleware;
using Todo.Web.Components;
using Todo.Web.Services;
using Todo.Web.Services.Interfaces;
using Todo.Web.State;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();
builder.Services.AddScoped<AppState>();
builder.Services.AddScoped<QuoteService>();

builder.Services.AddScoped<ITodoMangerService, TodoManagerService>();

builder.Services.AddRazorPages()
 .AddRazorPagesOptions(options => {
     options.RootDirectory = "/home";
 });

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddInteractiveServerRenderMode();


app.Run();
