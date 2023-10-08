using ChimeMate.Extensions;

namespace ChimeMate.Api.Endpoints.Contacts.CreateContact;

public sealed record CreateContactResponse
{
    public sealed record Ok
    {
        public Guid ContactId { get; set; }
    }

    public sealed record BadRequest
    {
        public ICollection<ValidationError> ValidationErrors { get; set; }
    }
}
