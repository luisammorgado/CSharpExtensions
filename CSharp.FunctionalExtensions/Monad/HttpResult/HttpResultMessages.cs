namespace CSharp.FunctionalExtensions.Monad.HttpResultMonad;

internal static class HttpResultMessages
{
    public const string NoValueForFailure = "There is no value for failure.";
    public const string NoErrorForSuccess = "There is no error for success.";
    public const string SuccessResultMustHaveValue = "Success result must have a value.";
    public const string FailureResultMustHaveError = "Failure result must have an error.";
}