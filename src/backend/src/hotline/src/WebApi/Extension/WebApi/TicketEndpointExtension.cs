using Asp.Versioning;
using Hotline.Application.Schemas.Input;
using Hotline.Application.Schemas.Output;
using Hotline.Application.Services;
using Hotline.WebApi.Mappers.Requests;
using Hotline.WebApi.Schemas.Requests;
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
        
        group.MapGet("/", async ([FromServices] TicketService ticketService, CancellationToken ct) =>
            {
                IEnumerable<TicketOutput> tickets = await ticketService.GetAllTicketsAsync();
                return Results.Ok(tickets);
            })
            .MapToApiVersion(1, 0)
            .WithName("GetAllTickets");

        group.MapPost("/", async ([FromBody] NewTicketRequest newTicketRequest, [FromServices] TicketService ticketService, CancellationToken ct) =>
            {
                TicketOutput newTicket= await ticketService.AddTicketAsync(newTicketRequest.ToNewTicketInput(), ct);
                return Results.Ok(newTicket.ToTicketResponse());
            })
            .MapToApiVersion(1, 0)
            .WithName("NewTicket");

        return ticketEndpoint;
    }
    
}