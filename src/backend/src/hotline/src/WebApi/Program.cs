using Hotline.Application.DependencyInjection;
using Hotline.Infrastructure.DependencyInjection;
using Hotline.WebApi.Extension.Dev;
using Hotline.WebApi.Extension.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddEndPointSingleton();

var app = builder.Build();

app.MapScalar(app.Environment);

//app.UseHttpsRedirection();
app.MapTicketEndpoint();


app.Run();
