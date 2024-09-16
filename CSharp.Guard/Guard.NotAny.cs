using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CSharp.Guard;

public static partial class Guard
{
    private const string NotAnyTemplate = @"[{0}] cannot be empty (should contain at least one element).";

    /// <summary>
    /// Guards the specified <paramref name="param" /> from containing no elements by throwing an
    /// exception of type <see cref="ArgumentException" /> when the precondition has not been met
    /// </summary>
    /// <param name="param">The param to be checked</param>
    /// <param name="paramName">
    /// The name of the param to be checked, that will be included in the exception
    /// </param>
    public static void NotAny<T>([NotNull] IEnumerable<T> param, [NotNull] string paramName) =>
        NotAny(param, paramName, "");

    /// <summary>
    /// Guards the specified <paramref name="param" /> from containing no elements by throwing an
    /// exception of type <see cref="ArgumentException" /> with a specific
    /// <paramref name="message" /> when the precondition has not been met
    /// </summary>
    /// <param name="param">The param to be checked</param>
    /// <param name="paramName">
    /// The name of the param to be checked, that will be included in the exception
    /// </param>
    /// <param name="message">The message that will be included in the exception</param>
    public static void NotAny<T>([NotNull] IEnumerable<T> param, [NotNull] string paramName, [NotNull] string message)
    {
        if (String.IsNullOrWhiteSpace(paramName))
            paramName = GenericParameterName;

        message ??= String.Format(NotAnyTemplate, paramName);

        var argumentException = new ArgumentException(message, paramName);

        Guard.NotAny(param, argumentException);
    }

    /// <summary>
    /// Guards the specified <paramref name="param" /> from containing no elements by throwing an
    /// exception of type <typeparamref name="TException" /> when the precondition has not been met
    /// </summary>
    /// <param name="param">The param to be checked</param>
    public static void NotAny<T, TException>([NotNull] IEnumerable<T> param)
    where TException : Exception, new()
    {
        var message = string.Format(NotAnyTemplate, GenericParameterName);

        Guard.NotAny<T, TException>(param, message);
    }

    /// <summary>
    /// Guards the specified <paramref name="param" /> from containing no elements by throwing an
    /// exception of type <typeparamref name="TException" /> with a specific
    /// <paramref name="message" /> when the precondition has not been met
    /// </summary>
    /// <param name="param">The param to be checked</param>
    /// <param name="message">The message that will be included in the exception</param>
    public static void NotAny<T, TException>([NotNull] IEnumerable<T> param, [NotNull] string message) where TException : Exception, new()
    {
        message ??= String.Format(NotAnyTemplate, GenericParameterName);

        TException exception = CreateException<TException>(message);

        Guard.NotAny(param, exception);
    }

    /// <summary>
    /// Guards the specified <paramref name="param" /> from containing no elements by throwing an
    /// <paramref name="exception" /> of type <typeparamref name="TException" /> when the
    /// precondition has not been met
    /// </summary>
    /// <typeparam name="TException">The exception Type (Exception)</typeparam>
    /// <typeparam name="T"></typeparam>
    /// <param name="param">The param to be checked</param>
    /// <param name="exception">The exception to be thrown when the precondition has not been met</param>
    public static void NotAny<T, TException>([NotNull] IEnumerable<T> param, [NotNull] TException exception) where TException : Exception, new()
    {
        ArgumentNullException.ThrowIfNull(param);
        ArgumentNullException.ThrowIfNull(exception);

        Guard.For(() => !param.Any(), exception);
    }
}