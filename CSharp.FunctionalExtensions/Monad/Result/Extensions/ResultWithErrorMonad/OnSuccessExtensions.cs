using System;
using System.Diagnostics;
using CSharp.FunctionalExtensions.Monad.ResultMonad;

namespace CSharp.FunctionalExtensions.Monad.ResultMonad.Extensions.ResultWithErrorMonad;

public static class ResultWithErrorMonadOnSuccessExtensions
{
    [DebuggerStepThrough]
    public static Result<TValue, TError> OnSuccessToResultWithValueAndError<TValue, TError>(
        this ResultWithError<TError> resultWithError,
        Func<TValue> onSuccessFunc)
    {
        if (resultWithError.IsFailure)
        {
            return Result.Fail<TValue, TError>(resultWithError.Error);
        }

        var newValue = onSuccessFunc();
        return Result.Ok<TValue, TError>(newValue);
    }
}