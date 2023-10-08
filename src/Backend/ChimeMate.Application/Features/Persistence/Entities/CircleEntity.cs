using ChimeMate.Application.Enums;

namespace ChimeMate.Application.Features.Persistence.Entities;

public sealed class CircleEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public TimeUnit RepeatTimeUnit { get; set; }
    public int RepeatTimeValue { get; set; }

    public ICollection<ContactEntity> Contacts { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
}
