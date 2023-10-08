using ChimeMate.Application.Features.Persistence;
using ChimeMate.Application.Models;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace ChimeMate.Application.Features.Contacts.GetContacts;

internal sealed class GetContactsCommandHandler(IDbContext dbContext) : ICommandHandler<GetContactsCommand, ICollection<ContactModel>>
{
    public async ValueTask<ICollection<ContactModel>> Handle(GetContactsCommand command, CancellationToken cancellationToken)
    {
        return await dbContext.Contacts
            .Where(c => c.UserId == command.UserId)
            .Select(c => new ContactModel
            {
                Id = c.Id,
                Name = c.Name,
                CircleId = c.CircleId,
                CircleName = c.Circle == null ? null : c.Circle.Name
            })
            .ToListAsync(cancellationToken);
    }
}
