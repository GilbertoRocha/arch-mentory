using Asp.Versioning;
using Hotline.Application.Schemas.Output;
using Hotline.Application.Services;
using Hotline.Domain.Entities;
using Hotline.Domain.Interfaces;
using Hotline.Domain.Shared;
using Hotline.Domain.Specifications.Tickets;
using Hotline.WebApi.Mappers.Tickets;
using Hotline.WebApi.Schemas.Requests;
using Hotline.WebApi.Schemas.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Hotline.WebApi.Endpoints;

public static class TicketEndpoint
{
    public static IEndpointRouteBuilder MapTicketEndpoint(this IEndpointRouteBuilder ticketEndpoint)
    {
        
        var versionSet = ticketEndpoint.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1, 0))
            .Build();
        
        var group = ticketEndpoint.MapGroup("/api/v{version:apiVersion}/tickets")
            .WithApiVersionSet(versionSet)
            .WithTags("Tickets");
        
        group.MapGet("/", async ([FromServices] IRepository<Ticket> repository, CancellationToken ct) =>
            {
                
                var spec = new ActiveTicketsSpec();
                var ticketResponse = await repository.ListBySpecAndProjAsync(spec, TicketMapper.ToResponse, ct);

                if (ticketResponse.Count == 0)
                    return Results.NoContent();
                
                return Results.Ok(ticketResponse);
            })
            .MapToApiVersion(1, 0)
            .WithName("GetActiveTickets");

        group.MapPost("/", async ([FromBody] NewTicketRequest newTicketRequest, [FromServices] TicketService ticketService, CancellationToken ct) =>
            {
                Result<TicketOutput> newTicket = await ticketService.AddTicketAsync(newTicketRequest.ToNewTicketInput(), ct);
                
                Result<TicketResponse> response = newTicket.Map(ticket => ticket.ToTicketResponse()); 
                
                if (!response.IsSuccess)
                    return Results.BadRequest(response);
                
                return Results.Ok(response);
            })
            .MapToApiVersion(1, 0)
            .WithName("NewTicket");

        return ticketEndpoint;
    }
    
}