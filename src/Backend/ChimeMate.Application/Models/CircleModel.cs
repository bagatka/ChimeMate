using ChimeMate.Application.Enums;

namespace ChimeMate.Application.Models;

public sealed record CircleModel
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public TimeUnit RepeatTimeUnit { get; init; }
    public int RepeatTimeValue { get; init; }
}
