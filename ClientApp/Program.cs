using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ClientApp;
using Blazored.LocalStorage;
using ClientApp.Service;

    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    builder.Services.AddSingleton(new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
        
    });

    builder.Services.AddBlazoredLocalStorage();

    builder.Services.AddSingleton<ITodoService, ToDoServiceHttp>();
    await builder.Build().RunAsync();

