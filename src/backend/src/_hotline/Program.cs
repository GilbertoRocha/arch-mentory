using Hotline.Application.Factories;
using Hotline.Application.Schema.DTO;
using Hotline.Application.Services;
using Hotline.Domain.Interfaces;
using Hotline.Infrastructure.Database;
using Hotline.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using DotNetEnv;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION")));

builder.Services.AddOpenApi();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<TicketService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Hotline API",
            Version = "v1",
            Description = "API para a Hotline"
        });
    });


var app = builder.Build();

using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotline API v1");
        c.RoutePrefix = string.Empty; // http://localhost:5000
    });

    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.MapGet("/tickets", async (TicketService ticketService) =>
{
    var tickets = await ticketService.GetAllTicketsAsync();
    return Results.Ok(tickets);
})
.WithName("GetAllTickets");


app.MapPost("/tickets", async (NewTicketDTO newTicketDTO, TicketService ticketService) =>
{
    var externalId = await ticketService.AddTicketAsync(newTicketDTO);
    return Results.Ok(externalId);
})
.WithName("NewTicket");



app.Run();
