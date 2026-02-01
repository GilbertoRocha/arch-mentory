using Hotline.Application.Schema.DTO;
using Hotline.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotline.WebApi.Extension.WebApi;

public static class TicketEndpoinExtension
{
    public static IEndpointRouteBuilder MapTicketEndpoint(this IEndpointRouteBuilder ticketEndpoint)
    {
        ticketEndpoint.MapGet("/tickets", async ([FromServices] TicketService ticketService) =>
            {
                var tickets = await ticketService.GetAllTicketsAsync();
                return Results.Ok(tickets);
            })
            .WithName("GetAllTickets");

        ticketEndpoint.MapPost("/tickets", async ([FromBody] NewTicketDTO newTicketDto, [FromServices] TicketService ticketService) =>
            {
                var externalId = await ticketService.AddTicketAsync(newTicketDto);
                return Results.Ok(externalId);
            })
            .WithName("NewTicket");

        return ticketEndpoint;
    }
    
}