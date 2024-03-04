using FinanceFrontend;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage; // Add this using directive
using FinanceFrontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Register a named HttpClient for interacting with your backend API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7155/") });

// Dependency container 
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<CompanyService>();


await builder.Build().RunAsync();