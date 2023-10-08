namespace ChimeMate.Extensions;

public sealed class ValidationError
{
    public string Field { get; init; }
    public string ErrorMessage { get; init; }

    public ValidationError(string field, string errorMessage)
    {
        Field = field;
        ErrorMessage = errorMessage;
    }
}
