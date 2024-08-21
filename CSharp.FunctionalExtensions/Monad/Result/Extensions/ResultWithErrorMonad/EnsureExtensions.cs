using CSharp.FunctionalExtensions.Monad.ResultMonad;

namespace CSharp.FunctionalExtensions.Monad.ResultMonad.Extensions.ResultWithErrorMonad;

public static class ResultWithErrorMonadEnsureExtensions
{
    [DebuggerStepThrough]
    public static ResultWithError<TError> EnsureToResultWithError<TError>(
        this ResultWithError<TError> resultWithError,
        Func<bool> predicate,
        TError error)
    {
        if (resultWithError.IsFailure)
            return ResultWithError.Fail(resultWithError.Error);

        return predicate()
            ? ResultWithError.Ok<TError>()
            : ResultWithError.Fail(error);
    }
}