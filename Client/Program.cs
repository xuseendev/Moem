using Blazored.LocalStorage;
using Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoeSystem.Client;
using MoeSystem.Client.Providers;
using MoeSystem.Client.Services;
using MoeSystem.Client.Services.Authentication;
using MoeSystem.Client.Services.Base;
using MoeSystem.Client.Services.Contracts;
using MudBlazor.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:28725") });
builder.Services.AddScoped<IClient, MoeSystem.Client.Services.Base.Client>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient(typeof(IHttpRepository<>), typeof(HttpRepository<>));
builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<HttpInerceptorService>();
builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetRequiredService<ApiAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();
builder.Services.AddMudBlazorKeyInterceptor();
builder.Services.AddMudServices();


await builder.Build().RunAsync();