using KaryawanBlazorApp.WebUI.Components;
using KaryawanBlazorApp.WebUI.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// Register named HttpClient for API calls using ApiBaseUrl from configuration
var apiBase = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5094/";
builder.Services.AddHttpClient("Api", client => client.BaseAddress = new Uri(apiBase));

// Register KaryawanApiClient
builder.Services.AddScoped<KaryawanApiClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
