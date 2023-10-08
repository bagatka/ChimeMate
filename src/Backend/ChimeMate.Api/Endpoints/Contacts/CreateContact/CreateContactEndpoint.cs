using ChimeMate.Application.Features.Contacts.CreateContact;
using FastEndpoints;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChimeMate.Api.Endpoints.Contacts.CreateContact;

public sealed class CreateContactEndpoint(ISender sender)
    : Endpoint<CreateContactRequest, Results<Ok<CreateContactResponse.Ok>, BadRequest<CreateContactResponse.BadRequest>>>
{
    public override void Configure()
    {
        Post("/contact");
        AllowAnonymous();
    }

    public override async Task<Results<Ok<CreateContactResponse.Ok>, BadRequest<CreateContactResponse.BadRequest>>> ExecuteAsync(
        CreateContactRequest request,
        CancellationToken ct
    )
    {
        var userId = Guid.Empty; // TODO: Get UserId from JWT.
        var command = new CreateContactCommand(request.Name, request.CircleId, userId);

        var result = await sender.Send(command, ct);

        if (result.IsSuccess)
        {
            return TypedResults.Ok(new CreateContactResponse.Ok { ContactId = result.AsSuccess });
        }

        return TypedResults.BadRequest(new CreateContactResponse.BadRequest { ValidationErrors = result.AsFaulted! });
    }
}
