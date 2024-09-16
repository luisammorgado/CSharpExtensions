using System.Diagnostics.CodeAnalysis;

namespace CSharp.Guard;

public static partial class Guard
{
    private const string GenericParameterName = "parameter";
    private const string ForMessageTemplate = "Precondition not met.";

    private static TException CreateException<TException>(string message = "")
    where TException : Exception, new()
    {
        if (String.IsNullOrWhiteSpace(message))
            return new TException();

        try
        {
            return (TException)Activator.CreateInstance(typeof(TException), message)!;
        }
        catch (MissingMethodException)
        {
            return new TException();
        }
    }
}