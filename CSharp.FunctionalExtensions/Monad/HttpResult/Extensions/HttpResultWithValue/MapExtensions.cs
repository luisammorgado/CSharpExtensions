using System.Diagnostics;
using CSharp.FunctionalExtensions.Monad.HttpResultMonad;

namespace CSharp.FunctionalExtensions.Monad.HttpResultMonad.Extensions
{
    public static class HttpResultWithValue
    {
        [DebuggerStepThrough]
        public static HttpResult ToHttpResult<TValue>(this HttpResult<TValue> result)
        {
            return result.IsSuccess
                ? HttpResult.Ok(result.HttpState)
                : HttpResult.Fail(result.HttpState);
        }
    }
}