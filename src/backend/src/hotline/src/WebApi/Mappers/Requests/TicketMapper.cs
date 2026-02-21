using Hotline.Application.Schemas.Input;
using Hotline.Application.Schemas.Output;
using Hotline.WebApi.Mappers.Responses;
using Hotline.WebApi.Schemas.Requests;

namespace Hotline.WebApi.Mappers.Requests;

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

}