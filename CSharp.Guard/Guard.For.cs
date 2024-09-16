using System.Diagnostics.CodeAnalysis;

namespace CSharp.Guard;

public static partial class Guard
{
    /// <summary>
    /// Guards the specified <paramref name="predicate" /> from being violated by throwing an
    /// exception of type <typeparamref name="TException" /> when the precondition has not been met
    /// </summary>
    /// <param name="predicate">The precondition that has to be met</param>
    public static void For<TException>([NotNull] Func<bool> predicate)
    where TException : Exception, new() =>
        Guard.For<TException>(predicate, ForMessageTemplate);

    /// <summary>
    /// Guards the specified <paramref name="predicate" /> from being violated by throwing an
    /// exception of type <typeparamref name="TException" /> with a specific
    /// <paramref name="message" /> when the precondition has not been met
    /// </summary>
    /// <param name="predicate">The precondition that has to be met</param>
    /// <param name="message">The message that will be included in the exception</param>
    public static void For<TException>(Func<bool> predicate, string message)
    where TException : Exception, new()
    {
        message ??= ForMessageTemplate;

        TException exception = CreateException<TException>(message);

        Guard.For(predicate, exception);
    }

    /// <summary>
    /// Guards the specified <paramref name="predicate" /> from being violated by throwing an
    /// <paramref name="exception" /> when the precondition has not been met
    /// </summary>
    /// <typeparam name="TException">The exception Type (Exception)</typeparam>
    /// <param name="predicate">The precondition that has to be met</param>
    /// <param name="exception">The exception to be thrown when the precondition has not been met</param>
    public static void For<TException>(Func<bool> predicate, TException exception)
    where TException : Exception, new()
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(exception);

        bool conditionNotMet = predicate.Invoke();
        if (conditionNotMet)
            throw exception;
    }
}