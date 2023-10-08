using ChimeMate.Extensions;
using Mediator;

namespace ChimeMate.Application.Features.Contacts.CreateContact;

public sealed record CreateContactCommand(string Name, Guid? CircleId, Guid UserId) : ICommand<Result<Guid, ICollection<ValidationError>>>;
