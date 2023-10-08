using ChimeMate.Application.Enums;
using ChimeMate.Application.Features.Persistence;
using ChimeMate.Application.Features.Persistence.Entities;
using ChimeMate.Extensions;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace ChimeMate.Application.Features.Circles.CreateCircle;

internal sealed class CreateCircleCommandHandler(IDbContext dbContext)
    : ICommandHandler<CreateCircleCommand, Result<Guid, ICollection<ValidationError>>>
{
    public async ValueTask<Result<Guid, ICollection<ValidationError>>> Handle(
        CreateCircleCommand command,
        CancellationToken cancellationToken
    )
    {
        var validationErrors = Validate(command);

        if (validationErrors.Count > 0)
        {
            return new Result<Guid, ICollection<ValidationError>>(validationErrors);
        }

        var contacts = await dbContext.Contacts.Where(c => command.ContactIds.Contains(c.Id)).ToListAsync(cancellationToken);

        var circleEntity = new CircleEntity
        {
            Name = command.Name,
            RepeatTimeUnit = command.RepeatTimeUnit,
            RepeatTimeValue = command.RepeatTimeValue,
            UserId = command.UserId,
            Contacts = contacts
        };

        dbContext.Circles.Add(circleEntity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new Result<Guid, ICollection<ValidationError>>(circleEntity.Id);
    }

    private ICollection<ValidationError> Validate(CreateCircleCommand command)
    {
        var validationErrors = new List<ValidationError>();

        if (string.IsNullOrWhiteSpace(command.Name))
        {
            validationErrors.Add(new ValidationError(nameof(command.Name), "Field is required"));
        }

        if (command.RepeatTimeUnit == TimeUnit.None)
        {
            validationErrors.Add(new ValidationError(nameof(command.RepeatTimeUnit), "Field is required"));
        }

        if (command.RepeatTimeValue == 0)
        {
            validationErrors.Add(new ValidationError(nameof(command.RepeatTimeValue), "Field is required"));
        }

        return validationErrors;
    }
}
