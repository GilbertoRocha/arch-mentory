using Hotline.Domain.Entities;

namespace Hotline.Domain.Factories;

public static class TicketFactory
{
    public static Ticket New (string title, string description)
    {
        return new Ticket(title, description);
    }
}