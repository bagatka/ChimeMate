using ChimeMate.Application.Enums;
using ChimeMate.Extensions;
using Mediator;

namespace ChimeMate.Application.Features.Circles.CreateCircle;

public sealed record CreateCircleCommand(string Name, TimeUnit RepeatTimeUnit, int RepeatTimeValue, ICollection<Guid> ContactIds, Guid UserId)
    : ICommand<Result<Guid, ICollection<ValidationError>>>;
