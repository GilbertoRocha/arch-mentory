using Hotline.Application.DependencyInjection;
using Hotline.Infrastructure.DependencyInjection;
using Hotline.WebApi.Endpoints;
using Hotline.WebApi.Extension.Dev;
using Hotline.WebApi.Extension.WebApi;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.LoadEnvValues(builder.Environment);
builder.Services.AddDevCors(builder.Environment);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddEndPointSingleton();
builder.Services.AddDefaultApiVersioning();

var app = builder.Build();

app.UseForwardedHeaders();

app.UseDevCors(app.Environment);
app.MapScalar(app.Environment);

//app.UseHttpsRedirection();
app.MapTicketEndpoint();


app.Run();
