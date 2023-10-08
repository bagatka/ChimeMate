using ChimeMate.Application.Enums;

namespace ChimeMate.Api.Endpoints.Contacts.CreateCircle;

public sealed record CreateCircleRequest
{
    public string Name { get; set; }
    public TimeUnit RepeatTimeUnit { get; set; }
    public int RepeatTimeValue { get; set; }
    public ICollection<Guid> ContactIds { get; set; }
    public Guid UserId { get; set; }
}
