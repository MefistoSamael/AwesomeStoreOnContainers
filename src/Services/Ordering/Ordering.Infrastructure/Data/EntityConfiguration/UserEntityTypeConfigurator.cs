using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Data.EntityConfiguration;

public class UserEntityTypeConfigurator : IEntityTypeConfiguration<Buyer>
{
    public void Configure(EntityTypeBuilder<Buyer> userConfiguration)
    {
        userConfiguration.ToTable(nameof(Buyer));

        userConfiguration.HasKey(order => order.Id);

        userConfiguration.Property(order => order.Email)
            .IsRequired();
    }
}
