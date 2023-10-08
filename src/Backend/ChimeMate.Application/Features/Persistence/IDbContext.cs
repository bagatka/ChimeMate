using ChimeMate.Application.Features.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChimeMate.Application.Features.Persistence;

public interface IDbContext
{
    DbSet<UserEntity> Users { get; }
    DbSet<ContactEntity> Contacts { get; }

    DbSet<CircleEntity> Circles { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
