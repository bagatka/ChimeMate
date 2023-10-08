using ChimeMate.Application.Features.Persistence;
using ChimeMate.Application.Features.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChimeMate.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext, IDbContext
{
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<ContactEntity> Contacts => Set<ContactEntity>();

    public DbSet<CircleEntity> Circles => Set<CircleEntity>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
