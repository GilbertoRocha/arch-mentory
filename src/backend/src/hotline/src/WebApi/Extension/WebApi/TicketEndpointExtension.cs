using Asp.Versioning;
using Hotline.Application.Schema.DTO;
using Hotline.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotline.WebApi.Extension.WebApi;

public static class TicketEndpointExtension
{
    public static IEndpointRouteBuilder MapTicketEndpoint(this IEndpointRouteBuilder ticketEndpoint)
    {
        
        var versionSet = ticketEndpoint.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1, 0))
            .Build();
        
        var group = ticketEndpoint.MapGroup("/api/v{version:apiVersion}/tickets")
            .WithApiVersionSet(versionSet)
            .WithTags("Tickets");
        
        group.MapGet("/", async ([FromServices] TicketService ticketService) =>
            {
                var tickets = await ticketService.GetAllTicketsAsync();
                return Results.Ok(tickets);
            })
            .MapToApiVersion(1, 0)
            .WithName("GetAllTickets");

        group.MapPost("/", async ([FromBody] NewTicketDTO newTicketDto, [FromServices] TicketService ticketService) =>
            {
                var externalId = await ticketService.AddTicketAsync(newTicketDto);
                return Results.Ok(externalId);
            })
            .MapToApiVersion(1, 0)
            .WithName("NewTicket");

        return ticketEndpoint;
    }
    
}