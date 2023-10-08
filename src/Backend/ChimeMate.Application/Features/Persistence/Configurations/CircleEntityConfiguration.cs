using ChimeMate.Application.Features.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChimeMate.Application.Features.Persistence.Configurations;

public sealed class CircleEntityConfiguration : IEntityTypeConfiguration<CircleEntity>
{
    public void Configure(EntityTypeBuilder<CircleEntity> builder)
    {
        builder
            .HasKey(entity => entity.Id)
            .IsClustered();

        builder
            .HasMany(entity => entity.Contacts)
            .WithOne(contactEntity => contactEntity.Circle)
            .HasForeignKey(entity => entity.CircleId)
            .IsRequired(false);

        builder
            .HasOne(entity => entity.User)
            .WithMany(userEntity => userEntity.Circles)
            .HasForeignKey(entity => entity.UserId);
    }
}
