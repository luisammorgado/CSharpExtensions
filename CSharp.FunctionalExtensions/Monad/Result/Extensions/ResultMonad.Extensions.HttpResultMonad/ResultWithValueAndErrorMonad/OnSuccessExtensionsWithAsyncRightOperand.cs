using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CSharp.FunctionalExtensions.Monad.HttpResultMonad;
using CSharp.FunctionalExtensions.Monad.HttpResultMonad.State;

namespace CSharp.FunctionalExtensions.Monad.ResultMonad.Extensions.ResultWithValueAndErrorMonad
{
    public static class OnSuccessExtensionsWithAsyncRightOperand
    {
        [DebuggerStepThrough]
        public static Task<HttpResultWithError<TError>> OnSuccessToHttpResultWithError<TValue, TError>(
            this Result<TValue, TError> result,
            Func<TValue, Task<HttpResultWithError<TError>>> onSuccessFunc)
        {
            return result.IsFailure
                ? Task.FromResult(HttpResultWithError.Fail(result.Error, HttpState.Empty))
                : onSuccessFunc(result.Value);
        }

        [DebuggerStepThrough]
        public static Task<HttpResult<KValue, TError>> OnSuccessToHttpResultWithValueAndError<TValue, TError, KValue>(
            this Result<TValue, TError> result,
            Func<TValue, Task<HttpResult<KValue, TError>>> onSuccessFunc)
        {
            return result.IsFailure
                ? Task.FromResult(HttpResult.Fail<KValue, TError>(result.Error, HttpState.Empty))
                : onSuccessFunc(result.Value);
        }
    }
}