namespace ChimeMate.Application.Models;

public sealed record ContactModel
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public Guid? CircleId { get; init; }
    public string? CircleName { get; init; }
}
