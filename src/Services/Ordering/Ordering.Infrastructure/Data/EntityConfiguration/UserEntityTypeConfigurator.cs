using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Data.EntityConfiguration;

public class UserEntityTypeConfigurator : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> userConfiguration)
    {
        userConfiguration.ToTable(nameof(User));

        userConfiguration.HasKey(order => order.Id);

        userConfiguration.Property(order => order.FullName)
            .IsRequired();
    }
}
