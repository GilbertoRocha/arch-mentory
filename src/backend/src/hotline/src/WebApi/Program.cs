using Hotline.Application.DependencyInjection;
using Hotline.Application.Schema.DTO;
using Hotline.Application.Services;
using Hotline.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Hotline WebAPi")
               .WithTheme(ScalarTheme.DeepSpace)
               .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

//app.UseHttpsRedirection();

app.MapGet("/tickets", async ([FromServices] TicketService ticketService) =>
{
    var tickets = await ticketService.GetAllTicketsAsync();
    return Results.Ok(tickets);
})
.WithName("GetAllTickets");


app.MapPost("/tickets", async ([FromBody] NewTicketDTO newTicketDto, [FromServices] TicketService ticketService) =>
{
    var externalId = await ticketService.AddTicketAsync(newTicketDto);
    return Results.Ok(externalId);
})
.WithName("NewTicket");

app.Run();
