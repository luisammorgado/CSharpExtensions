﻿using System;
using System.Diagnostics;
using CSharp.FunctionalExtensions.Monad.ResultMonad;

namespace CSharp.FunctionalExtensions.Monad.ResultMonad.Extensions.ResultWithValueAndErrorMonad;

public static class ResultWithValueAndErrorMonadEnsureExtensions
{
    [DebuggerStepThrough]
    public static Result<TValue, TError> EnsureToResultWithValueAndError<TValue, TError>(
        this Result<TValue, TError> result,
        Func<TValue, bool> predicate,
        TError error)
    {
        if (result.IsFailure)
            return Result.Fail<TValue, TError>(result.Error);

        if (!predicate(result.Value))
            return Result.Fail<TValue, TError>(error);

        return Result.Ok<TValue, TError>(result.Value);
    }

    [DebuggerStepThrough]
    public static Result<TValue, TError> EnsureToResultWithValueAndError<TValue, TError>(
        this Result<TValue, TError> result,
        Func<bool> predicate,
        TError error)
    {
        if (result.IsFailure)
            return Result.Fail<TValue, TError>(result.Error);

        if (!predicate())
            return Result.Fail<TValue, TError>(error);

        return Result.Ok<TValue, TError>(result.Value);
    }

    [DebuggerStepThrough]
    public static Result<TValue, TError> EnsureToResultWithValueAndError<TValue, TError>(
       this Result<TValue, TError> result,
       Func<TValue, bool> predicate,
       Func<TValue, TError> errorFunc)
    {
        if (result.IsFailure)
            return Result.Fail<TValue, TError>(result.Error);

        if (!predicate(result.Value))
        {
            var error = errorFunc(result.Value);

            return Result.Fail<TValue, TError>(error);
        }

        return Result.Ok<TValue, TError>(result.Value);
    }
}