namespace ChimeMate.Application.Features.Persistence.Entities;

public sealed class ContactEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? CircleId { get; set; }
    public CircleEntity? Circle { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
}
