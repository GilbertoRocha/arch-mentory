
namespace Hotline.WebApi.Schemas.Requests;

public readonly record struct NewTicketRequest(
    string Title, 
    string Description);