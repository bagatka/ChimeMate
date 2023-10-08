using ChimeMate.Application.Features.Contacts.GetContacts;
using ChimeMate.Application.Models;
using FastEndpoints;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChimeMate.Api.Endpoints.Contacts.GetContacts;

public sealed class GetContactsEndpoint(ISender sender) : EndpointWithoutRequest<Ok<ICollection<ContactModel>>>
{
    public override void Configure()
    {
        Get("/contact");
        AllowAnonymous();
    }

    public override async Task<Ok<ICollection<ContactModel>>> ExecuteAsync(CancellationToken ct)
    {
        var userId = Guid.Empty; // TODO: Get UserId from JWT.
        var command = new GetContactsCommand(userId);

        var result = await sender.Send(command, ct);

        return TypedResults.Ok(result);
    }
}
