using Hotline.Application.Schemas.Input;
using Hotline.Application.Schemas.Output;
using Hotline.WebApi.Schemas.Requests;
using Hotline.WebApi.Schemas.Responses;

namespace Hotline.WebApi.Mappers.Tickets;

public static class TicketMapper
{
    public static NewTicketInput ToNewTicketInput(this NewTicketRequest newTicketRequest) => 
        new NewTicketInput(
            Title: newTicketRequest.Title,
            Description: newTicketRequest.Description);

    public static TicketResponse ToTicketResponse(this TicketOutput ticketOutput) =>
        new TicketResponse(
            ExternalId: ticketOutput.ExternalId,
            Title: ticketOutput.Title,
            Description: ticketOutput.Description,
            Status: ticketOutput.Status,
            CreatedAt: ticketOutput.CreatedAt,
            UpdatedAt: ticketOutput.UpdatedAt,
            ResolvedAt: ticketOutput.ResolvedAt);

    public static IEnumerable<TicketResponse> ToTicketResponses(this IEnumerable<TicketOutput> ticketOutputs)
    {
        return ticketOutputs.Select(TicketMapper.ToTicketResponse);
    }
        
}