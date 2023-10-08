namespace ChimeMate.Application.Features.Persistence.Entities;

public sealed class UserEntity
{
    public Guid Id { get; set; }
    public string TelegramId { get; set; }

    public ICollection<ContactEntity> Contacts { get; set; }
    public ICollection<CircleEntity> Circles { get; set; }
}
