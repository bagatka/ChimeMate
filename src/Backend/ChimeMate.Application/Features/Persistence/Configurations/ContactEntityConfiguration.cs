using ChimeMate.Application.Features.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChimeMate.Application.Features.Persistence.Configurations;

public sealed class ContactEntityConfiguration : IEntityTypeConfiguration<ContactEntity>
{
    public void Configure(EntityTypeBuilder<ContactEntity> builder)
    {
        builder
            .HasKey(entity => entity.Id)
            .IsClustered();

        builder
            .HasOne(entity => entity.Circle)
            .WithMany(circleEntity => circleEntity.Contacts)
            .HasForeignKey(entity => entity.CircleId)
            .IsRequired(false);

        builder
            .HasOne(entity => entity.User)
            .WithMany(userEntity => userEntity.Contacts)
            .HasForeignKey(entity => entity.UserId);
    }
}
