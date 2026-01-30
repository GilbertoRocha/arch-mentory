using Hotline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotline.Infrastructure.Database.EntityTypeConfigurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Ticket");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .HasMaxLength(100);
        
        builder.Property(x => x.Description)
            .HasMaxLength(100);

        builder.Property(x => x.ExternalId)
            .IsRequired();
        
        builder.HasIndex(x => x.ExternalId)
            .IsUnique();

        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.Property(x => x.UpdatedAt);
        
        builder.Property(x => x.ResolvedAt);
        
        builder.Property(x => x.Status)
            .IsRequired();

    }
}