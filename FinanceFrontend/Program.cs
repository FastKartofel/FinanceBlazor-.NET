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

// Register AuthenticationService
builder.Services.AddScoped<AuthenticationService>();

await builder.Build().RunAsync();