namespace ChimeMate.Api.Endpoints.Contacts.CreateContact;

public sealed record CreateContactRequest
{
    public string Name { get; set; }
    public Guid? CircleId { get; set; }
}
