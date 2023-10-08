using ChimeMate.Application.Features.Persistence;
using ChimeMate.Application.Features.Persistence.Entities;
using ChimeMate.Extensions;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace ChimeMate.Application.Features.Contacts.CreateContact;

internal sealed class CreateContactCommandHandler(IDbContext dbContext)
    : ICommandHandler<CreateContactCommand, Result<Guid, ICollection<ValidationError>>>
{
    public async ValueTask<Result<Guid, ICollection<ValidationError>>> Handle(
        CreateContactCommand command,
        CancellationToken cancellationToken
    )
    {
        var validationErrors = await Validate(command, cancellationToken);

        if (validationErrors.Count > 0)
        {
            return new Result<Guid, ICollection<ValidationError>>(validationErrors);
        }

        var contactEntity = new ContactEntity
        {
            Name = command.Name,
            UserId = command.UserId
        };

        if (command.CircleId is not null)
        {
            contactEntity.CircleId = command.CircleId.Value;
        }

        dbContext.Contacts.Add(contactEntity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new Result<Guid, ICollection<ValidationError>>(contactEntity.Id);
    }

    private async Task<ICollection<ValidationError>> Validate(CreateContactCommand command, CancellationToken cancellationToken)
    {
        var validationErrors = new List<ValidationError>();

        if (string.IsNullOrWhiteSpace(command.Name))
        {
            validationErrors.Add(new ValidationError(nameof(command.Name), "Field is required"));
        }

        if (command.CircleId is not null)
        {
            var circle = await dbContext.Circles.FirstOrDefaultAsync(c => c.Id == command.CircleId, cancellationToken);

            if (circle is null)
            {
                validationErrors.Add(new ValidationError(nameof(command.CircleId), "Incorrect value"));
            }
        }

        return validationErrors;
    }
}
