using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>

{

    config.AddJsonFile("ocelot.json");

});
builder.Services.AddOcelot();

var app = builder.Build();

app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
