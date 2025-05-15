using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using webAssemblyDemo.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<ContainerStorage>();

await builder.Build().RunAsync();
