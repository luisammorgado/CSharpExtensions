using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.Guard;

public static partial class Guard
{
    private const string NotEqualToTemplate = "Equality precondition not met.";

    /// <summary>
    /// Guards the specified <paramref name="param" /> from not being equal to the specified
    /// <paramref name="value" /> by throwing an exception of type
    /// <typeparamref name="TException" /> when the precondition has not been met
    /// </summary>
    /// <typeparam name="TParam">The param Type (any value type)</typeparam>
    /// <typeparam name="TException">The exception Type (Exception)</typeparam>
    /// <param name="param">The param to be checked</param>
    /// <param name="value">The value against which the param will be checked for equality</param>
    public static void NotEqualTo<TParam, TException>([NotNull] TParam param, [NotNull] TParam @value) where TException : Exception, new() =>
        Guard.NotEqualTo<TParam, TException>(param, value, NotEqualToTemplate);

    /// <summary>
    /// Guards the specified <paramref name="param" /> from not being equal to the specified
    /// <paramref name="value" /> by throwing an exception of type
    /// <typeparamref name="TException" /> with a specific <paramref name="message" /> when the
    /// precondition has not been met
    /// </summary>
    /// <typeparam name="TParam">The param Type (any value type)</typeparam>
    /// <typeparam name="TException">The exception Type (Exception)</typeparam>
    /// <param name="param">The param to be checked</param>
    /// <param name="value">The value against which the param will be checked for equality</param>
    /// <param name="message">The message that will be included in the exception</param>
    public static void NotEqualTo<TParam, TException>(TParam param, [NotNull] TParam @value, [NotNull] string message) where TException : Exception, new()
    {
        message ??= NotEqualToTemplate;

        TException exception = CreateException<TException>(message);

        Guard.NotEqualTo(param, value, exception);
    }

    /// <summary>
    /// Guards the specified <paramref name="param" /> from not being equal to the specified
    /// <paramref name="value" /> by throwing an <paramref name="exception" /> when the precondition
    /// has not been met
    /// </summary>
    /// <typeparam name="TParam">The param Type (any value type)</typeparam>
    /// <typeparam name="TException">The exception Type (Exception)</typeparam>
    /// <param name="param">The param to be checked</param>
    /// <param name="value">The value against which the param will be checked for equality</param>
    /// <param name="exception">The exception to be thrown when the precondition has not been met</param>
    public static void NotEqualTo<TParam, TException>([NotNull] TParam param, TParam @value, [NotNull] TException exception)
    where TException : Exception, new()
    {
        ArgumentNullException.ThrowIfNull(exception);

        var comparer = EqualityComparer<TParam>.Default;

        Guard.For(() => !comparer.Equals(param, @value), exception);
    }
}