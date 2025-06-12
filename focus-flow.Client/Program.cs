using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using focus_flow.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//services register
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<TagService>();

// Configure HttpClient with API base address
builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri("http://localhost:5122") 
});


await builder.Build().RunAsync();
