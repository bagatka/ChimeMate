using ChimeMate.Extensions;

namespace ChimeMate.Api.Endpoints.Contacts.CreateCircle;

public class CreateCircleResponse
{
    public sealed record Ok
    {
        public Guid CircleId { get; set; }
    }

    public sealed record BadRequest
    {
        public ICollection<ValidationError> ValidationErrors { get; set; }
    }
}
