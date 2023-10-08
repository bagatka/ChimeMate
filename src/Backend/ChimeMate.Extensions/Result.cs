namespace ChimeMate.Extensions;

public sealed class Result<TValue, TError>
{
    private enum ResultState : byte
    {
        Faulted,
        Success
    }

    private readonly ResultState _state;
    private readonly TValue? _value;
    private readonly TError? _error;

    public Result(TValue value)
    {
        _state = ResultState.Success;
        _value = value;
    }

    public Result(TError error)
    {
        _state = ResultState.Faulted;
        _error = error;
    }

    public bool IsSuccess  => _state == ResultState.Success;

    public bool IsFaulted => _state == ResultState.Faulted;

    public TValue? AsSuccess => _value;

    public TError? AsFaulted => _error;
}


