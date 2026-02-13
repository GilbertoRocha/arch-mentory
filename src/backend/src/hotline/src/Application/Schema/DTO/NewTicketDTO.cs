namespace Hotline.Application.Schema.DTO;

public class NewTicketDTO(string title, string description)
{
	public string Title { get; set; } = title;
	public string Description { get; set; } = description;
}
