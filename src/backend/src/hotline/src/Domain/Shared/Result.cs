namespace Hotline.Domain.Shared;

public readonly record struct Result<T>
{
    public T? Value { get; init; }
    public bool IsSuccess { get; init; }
    public string[] Errors { get; init; }

    private Result(T? value, bool isSuccess, string[] errors)
    {
        Value = value;
        IsSuccess = isSuccess;
        Errors = errors;
    }
    
    public static Result<T> Success(T value) => new(value, true, []);
    public static Result<T> Failure(params string[] errors) => new(default, false, errors);
    
    public static implicit operator Result<T>(T value) => Success(value);
    
    
    public Result<TOut> Map<TOut>(Func<T, TOut> mapper)
    {
        if (!IsSuccess)
            return Result<TOut>.Failure(Errors);

        return Result<TOut>.Success(mapper(Value!));
    }
}