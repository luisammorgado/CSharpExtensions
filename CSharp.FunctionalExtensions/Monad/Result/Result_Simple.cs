using System;
using System.Diagnostics;
using System.Linq;
using CSharp.FunctionalExtensions.Monad.ResultMonad.Extensions;
using CSharp.FunctionalExtensions.Monad.MaybeMonad;

namespace CSharp.FunctionalExtensions.Monad.ResultMonad;

public readonly struct Result : IEquatable<Result>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly ResultStatus _resultStatus;

    [DebuggerStepThrough]
    private Result(ResultStatus resultStatus)
    {
        _resultStatus = resultStatus;
    }

    public bool IsFailure
    {
        [DebuggerStepThrough]
        get => _resultStatus == ResultStatus.Fail;
    }

    public bool IsSuccess
    {
        [DebuggerStepThrough]
        get => !IsFailure;
    }

    #region [IEquatable]

    [DebuggerStepThrough]
    public static bool operator ==(Result first, Result second) => first.Equals(second);

    [DebuggerStepThrough]
    public static bool operator !=(Result first, Result second) => !(first == second);

    [DebuggerStepThrough]
    public override bool Equals(object obj)
    {
        if (obj is Result other)
        {
            return Equals(other);
        }

        return false;
    }

    [DebuggerStepThrough]
    public bool Equals(Result other)
    {
        if (IsFailure && other.IsFailure)
        {
            return true;
        }

        if (IsSuccess && other.IsSuccess)
        {
            return true;
        }

        return false;
    }

    [DebuggerStepThrough]
    public override int GetHashCode() =>
        (int)_resultStatus;

    #endregion [IEquatable]

    [DebuggerStepThrough]
    public static Result Ok() =>
        new(ResultStatus.Ok);

    [DebuggerStepThrough]
    public static Result Fail() =>
        new(ResultStatus.Fail);

    [DebuggerStepThrough]
    public static Result<TValue> Ok<TValue>(TValue value) =>
        new(ResultStatus.Ok, value);

    [DebuggerStepThrough]
    public static Result<TValue> Fail<TValue>() =>
        new(ResultStatus.Fail, Maybe<TValue>.Nothing);

    [DebuggerStepThrough]
    public static Result<TValue, TError> Ok<TValue, TError>(TValue value) =>
        new(ResultStatus.Ok, value, Maybe<TError>.Nothing);

    [DebuggerStepThrough]
    public static Result<TValue, TError> Fail<TValue, TError>(TError error) =>
        new(ResultStatus.Fail, Maybe<TValue>.Nothing, error);

    [DebuggerStepThrough]
    public static Result<TValue> From<TValue>(Func<bool> predicate, TValue value) =>
        predicate() ? Ok(value) : Fail<TValue>();

    [DebuggerStepThrough]
    public static Result<TValue, TError> From<TValue, TError>(Func<bool> predicate, TValue value, TError error) =>
        predicate() ?
        Ok<TValue, TError>(value) :
        Fail<TValue, TError>(error);

    [DebuggerStepThrough]
    public static Result Combine(params Result[] results)
    {
        var anyFailure = results.Any(x => x.IsFailure);

        return !anyFailure ?
            Ok() :
            Fail();
    }

    [DebuggerStepThrough]
    public static Result Combine<T>(params Result<T>[] results)
    {
        var anyFailure = results.Any(x => x.IsFailure);

        return !anyFailure ?
            Ok() :
            Fail();
    }

    [DebuggerStepThrough]
    public static ResultWithError<TError> Combine<TError>(params ResultWithError<TError>[] resultsWithError)
    {
        var anyFailure = resultsWithError.Any(x => x.IsFailure);

        return !anyFailure ?
            ResultWithError.Ok<TError>() :
            resultsWithError.First(x => x.IsFailure);
    }

    [DebuggerStepThrough]
    public static ResultWithError<TError> Combine<TValue, TError>(params Result<TValue, TError>[] results)
    {
        var anyFailure = results.Any(x => x.IsFailure);

        return !anyFailure ?
            ResultWithError.Ok<TError>() :
            results.First(x => x.IsFailure).ToResultWithError();
    }
}