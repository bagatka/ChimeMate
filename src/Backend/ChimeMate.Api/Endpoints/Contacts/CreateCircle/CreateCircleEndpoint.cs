using ChimeMate.Application.Features.Circles.CreateCircle;
using FastEndpoints;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ChimeMate.Api.Endpoints.Contacts.CreateCircle;

public class CreateCircleEndpoint(ISender sender)
    : Endpoint<CreateCircleRequest, Results<Ok<CreateCircleResponse.Ok>, BadRequest<CreateCircleResponse.BadRequest>>>
{
    public override void Configure()
    {
        Post("/circle");
        AllowAnonymous();
    }

    public override async Task<Results<Ok<CreateCircleResponse.Ok>, BadRequest<CreateCircleResponse.BadRequest>>> ExecuteAsync(
        CreateCircleRequest request,
        CancellationToken ct
    )
    {
        var userId = Guid.Empty; // TODO: Get UserId from JWT.
        var command = new CreateCircleCommand(request.Name, request.RepeatTimeUnit, request.RepeatTimeValue, request.ContactIds, userId);

        var result = await sender.Send(command, ct);

        if (result.IsSuccess)
        {
            return TypedResults.Ok(new CreateCircleResponse.Ok { CircleId = result.AsSuccess });
        }

        return TypedResults.BadRequest(new CreateCircleResponse.BadRequest { ValidationErrors = result.AsFaulted! });
    }
}
