using Hotline.Application.Schema.DTO;

namespace Hotline.Application.Factories;

public static class TicketFactory
{
	public static NewTicketDTO CreateNewTicketDTO(string title, string description)
	{
		return new NewTicketDTO(title, description);
	}

}
