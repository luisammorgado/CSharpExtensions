using System;
using System.Diagnostics;
using CSharp.FunctionalExtensions.Monad.ResultMonad;

namespace CSharp.FunctionalExtensions.Monad.ResultMonad.Extensions.ResultWithValueAndErrorMonad;

public static class ResultWithValueAndErrorMonadOnErrorExtensions
{
    [DebuggerStepThrough]
    public static Result<TValue, KError> OnErrorToResultWithValueAndError<TValue, TError, KError>(
        this Result<TValue, TError> result,
        Func<TError, KError> onErrorFunc)
    {
        if (result.IsSuccess)
            return Result.Ok<TValue, KError>(result.Value);

        var error = onErrorFunc(result.Error);

        return Result.Fail<TValue, KError>(error);
    }

    [DebuggerStepThrough]
    public static ResultWithError<KError> OnErrorToResultWithError<TValue, TError, KError>(
        this Result<TValue, TError> result,
        Func<TError, KError> onErrorFunc)
    {
        if (result.IsSuccess)
            return ResultWithError.Ok<KError>();

        var error = onErrorFunc(result.Error);

        return ResultWithError.Fail(error);
    }
}