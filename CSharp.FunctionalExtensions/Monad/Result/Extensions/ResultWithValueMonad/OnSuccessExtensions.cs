using System;
using System.Diagnostics;
using CSharp.FunctionalExtensions.Monad.ResultMonad;

namespace CSharp.FunctionalExtensions.Monad.ResultMonad.Extensions.ResultWithValueMonad;

public static class ResultWithValueMonadOnSuccessExtensions
{
    [DebuggerStepThrough]
    public static Result<KValue> OnSuccessToResultWithValue<TValue, KValue>(
       this Result<TValue> result,
       Func<TValue, Result<KValue>> onSuccessFunc)
    {
        return result.IsFailure
            ? Result.Fail<KValue>()
            : onSuccessFunc(result.Value);
    }
}