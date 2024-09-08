namespace Application.Common.Models;

public class Result<T>
{
    internal Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Data = default;
        Errors = errors.ToArray();
    }

    internal Result(bool succeeded, T data, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Data = data;
        Errors = errors.ToArray();
    }

    public bool Succeeded { get; init; }

    public string[] Errors { get; init; }
    public T? Data { get; init; }

    public static Result<T> Success()
    {
        return new Result<T>(true, []);
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(true, data, []);
    }

    public static Result<T> Failure(IEnumerable<string> errors)
    {
        return new Result<T>(false, errors);
    }
}
