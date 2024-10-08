﻿using System;
using System.Diagnostics;
using System.Linq;
using CSharp.FunctionalExtensions.Monad.HttpResultMonad.Extensions;
using CSharp.FunctionalExtensions.Monad.HttpResultMonad.State;
using CSharp.FunctionalExtensions.Monad.MaybeMonad;

namespace CSharp.FunctionalExtensions.Monad.HttpResultMonad;

public readonly struct HttpResult : IEquatable<HttpResult>, IDisposable
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly HttpResultStatus _httpResultStatus;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly IHttpState _httpState;

    [DebuggerStepThrough]
    private HttpResult(HttpResultStatus httpResultStatus, IHttpState httpState)
    {
        _httpResultStatus = httpResultStatus;
        _httpState = httpState ?? throw new ArgumentNullException(nameof(httpState));
    }

    public bool IsFailure
    {
        [DebuggerStepThrough]
        get
        {
            return _httpResultStatus == HttpResultStatus.Fail;
        }
    }

    public bool IsSuccess
    {
        [DebuggerStepThrough]
        get
        {
            return !IsFailure;
        }
    }

    public IHttpState HttpState
    {
        [DebuggerStepThrough]
        get
        {
            return _httpState;
        }
    }

    #region [IEquatable]

    [DebuggerStepThrough]
    public static bool operator ==(HttpResult first, HttpResult second)
    {
        return first.Equals(second);
    }

    [DebuggerStepThrough]
    public static bool operator !=(HttpResult first, HttpResult second)
    {
        return !(first == second);
    }

    [DebuggerStepThrough]
    public override bool Equals(object obj)
    {
        if (obj is HttpResult other)
        {
            return Equals(other);
        }

        return false;
    }

    [DebuggerStepThrough]
    public bool Equals(HttpResult other)
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
    public override int GetHashCode()
    {
        unchecked
        {
            return (int)_httpResultStatus;
        }
    }

    #endregion [IEquatable]

    [DebuggerStepThrough]
    public static HttpResult Ok()
    {
        return new HttpResult(HttpResultStatus.Ok, State.HttpState.Empty);
    }

    [DebuggerStepThrough]
    public static HttpResult Ok(IHttpState httpState)
    {
        return new HttpResult(HttpResultStatus.Ok, httpState);
    }

    [DebuggerStepThrough]
    public static HttpResult Fail()
    {
        return new HttpResult(HttpResultStatus.Fail, State.HttpState.Empty);
    }

    [DebuggerStepThrough]
    public static HttpResult Fail(IHttpState httpState)
    {
        return new HttpResult(HttpResultStatus.Fail, httpState);
    }

    [DebuggerStepThrough]
    public static HttpResult<TValue> Ok<TValue>(TValue value)
    {
        return new HttpResult<TValue>(HttpResultStatus.Ok, value, State.HttpState.Empty);
    }

    [DebuggerStepThrough]
    public static HttpResult<TValue> Ok<TValue>(TValue value, IHttpState httpState)
    {
        return new HttpResult<TValue>(HttpResultStatus.Ok, value, httpState);
    }

    [DebuggerStepThrough]
    public static HttpResult<TValue> Fail<TValue>()
    {
        return new HttpResult<TValue>(HttpResultStatus.Fail, Maybe<TValue>.Nothing, State.HttpState.Empty);
    }

    [DebuggerStepThrough]
    public static HttpResult<TValue> Fail<TValue>(IHttpState httpState)
    {
        return new HttpResult<TValue>(HttpResultStatus.Fail, Maybe<TValue>.Nothing, httpState);
    }

    [DebuggerStepThrough]
    public static HttpResult<TValue, TError> Ok<TValue, TError>(TValue value)
    {
        return new HttpResult<TValue, TError>(HttpResultStatus.Ok, value, Maybe<TError>.Nothing, State.HttpState.Empty);
    }

    [DebuggerStepThrough]
    public static HttpResult<TValue, TError> Ok<TValue, TError>(TValue value, IHttpState httpState)
    {
        return new HttpResult<TValue, TError>(HttpResultStatus.Ok, value, Maybe<TError>.Nothing, httpState);
    }

    [DebuggerStepThrough]
    public static HttpResult<TValue, TError> Fail<TValue, TError>(TError error)
    {
        return new HttpResult<TValue, TError>(HttpResultStatus.Fail, Maybe<TValue>.Nothing, error, State.HttpState.Empty);
    }

    [DebuggerStepThrough]
    public static HttpResult<TValue, TError> Fail<TValue, TError>(TError error, IHttpState httpState)
    {
        return new HttpResult<TValue, TError>(HttpResultStatus.Fail, Maybe<TValue>.Nothing, error, httpState);
    }

    [DebuggerStepThrough]
    public static HttpResult Combine(params HttpResult[] results)
    {
        var anyFailure = results.Any(x => x.IsFailure);
        return !anyFailure
            ? Ok(State.HttpState.Empty)
            : results.First(x => x.IsFailure);
    }

    [DebuggerStepThrough]
    public static HttpResult Combine<T>(params HttpResult<T>[] results)
    {
        var anyFailure = results.Any(x => x.IsFailure);
        return !anyFailure
            ? Ok(State.HttpState.Empty)
            : results.First(x => x.IsFailure).ToHttpResult();
    }

    [DebuggerStepThrough]
    public static HttpResultWithError<TError> Combine<TError>(params HttpResultWithError<TError>[] resultsWithError)
    {
        var anyFailure = resultsWithError.Any(x => x.IsFailure);
        return !anyFailure
            ? HttpResultWithError.Ok<TError>(State.HttpState.Empty)
            : resultsWithError.First(x => x.IsFailure);
    }

    [DebuggerStepThrough]
    public static HttpResultWithError<TError> Combine<TValue, TError>(params HttpResult<TValue, TError>[] results)
    {
        var anyFailure = results.Any(x => x.IsFailure);
        return !anyFailure
            ? HttpResultWithError.Ok<TError>(State.HttpState.Empty)
            : results.First(x => x.IsFailure).ToHttpResultWithError();
    }

    public void Dispose()
    {
        _httpState.Dispose();
    }
}