using System.Diagnostics;
using CSharp.FunctionalExtensions.Monad.HttpResultMonad;

namespace CSharp.FunctionalExtensions.Monad.HttpResultMonad.Extensions
{
    public static class HttpResultWithValueAndError
    {
        [DebuggerStepThrough]
        public static HttpResultWithError<TError> ToHttpResultWithError<TValue, TError>(this HttpResult<TValue, TError> result)
        {
            return result.IsSuccess
                ? HttpResultWithError.Ok<TError>(result.HttpState)
                : HttpResultWithError.Fail(result.Error, result.HttpState);
        }
    }
}