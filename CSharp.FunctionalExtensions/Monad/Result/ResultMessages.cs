namespace CSharp.FunctionalExtensions.Monad.ResultMonad;

internal static class ResultMessages
{
    public const string NoValueForFailure = "There is no value for failure.";
    public const string NoErrorForSuccess = "There is no error for success.";
    public const string SuccessResultMustHaveValue = "Success result must have a value.";
    public const string FailureResultMustHaveError = "Error result must have an error.";
}