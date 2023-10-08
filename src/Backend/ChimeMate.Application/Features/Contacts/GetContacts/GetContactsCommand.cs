using ChimeMate.Application.Models;
using Mediator;

namespace ChimeMate.Application.Features.Contacts.GetContacts;

public sealed record GetContactsCommand(Guid UserId) : ICommand<ICollection<ContactModel>>;