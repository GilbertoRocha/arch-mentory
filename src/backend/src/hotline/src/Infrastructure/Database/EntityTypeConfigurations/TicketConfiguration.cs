using Hotline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotline.Infrastructure.Database.EntityTypeConfigurations;

public class TicketConfiguration :  BaseEntityConfiguration<Ticket>
{
    public override void Configure(EntityTypeBuilder<Ticket> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Ticket");
        
        builder.Property(x => x.Title)
            .HasMaxLength(100);
        
        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.ExternalId)
            .IsRequired();
        
        builder.HasIndex(x => x.ExternalId)
            .IsUnique();
        
        builder.Property(x => x.UpdatedAt);
        
        builder.Property(x => x.ResolvedAt);
        
        builder.Property(x => x.Status)
            .IsRequired();

    }
}