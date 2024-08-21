using System.Runtime.CompilerServices;

namespace CSharp.FunctionalExtensions;

[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public static class Guards
{
    [ExcludeFromCodeCoverage]
    internal static class CoreStrings
    {
        public static string ArgumentPropertyNull(string property, string argument)
        => $"The property '{property}' of the argument '{argument}' cannot be null.";

        public static string ArgumentIsEmpty(string? argumentName)
        => $"Value cannot be empty. (Parameter '{argumentName}')";

        public static string CollectionArgumentIsEmpty(string? argumentName)
        => $"The collection argument '{argumentName}' must contain at least one element.";
    }

    public static T Condition<T>(T value, Predicate<T> predicate, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        NotNull(predicate, nameof(predicate));

        if (!predicate(value))
        {
            NotNullOrEmpty(parameterName, nameof(parameterName));

            throw new ArgumentOutOfRangeException(parameterName);
        }

        return value;
    }

    public static T NotNull<T>(T value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        if (value is null)
        {
            NotNullOrEmpty(parameterName, nameof(parameterName));

            throw new ArgumentNullException(parameterName);
        }

        return value;
    }

    public static T NotNull<T>(T value, string parameterName, string propertyName)
    {
        if (value is null)
        {
            NotNullOrEmpty(parameterName, nameof(parameterName));
            NotNullOrEmpty(propertyName, nameof(propertyName));

            throw new ArgumentException(CoreStrings.ArgumentPropertyNull(propertyName, parameterName));
        }

        return value;
    }

    public static IEnumerable<T> NotNullOrEmpty<T>(IEnumerable<T> value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        IEnumerable<T> result = NotNull(value, parameterName);

        if (!result.Any())
        {
            NotNullOrEmpty(parameterName, nameof(parameterName));

            throw new ArgumentException(CoreStrings.CollectionArgumentIsEmpty(parameterName));
        }

        return result;
    }

    public static string NotNullOrEmpty(string? value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        if (value is null)
        {
            NotNullOrEmpty(parameterName, nameof(parameterName));

            throw new ArgumentNullException(parameterName);
        }

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException(CoreStrings.ArgumentIsEmpty(parameterName));
        }

        return value;
    }

    public static string NotNullOrWhiteSpace(string? value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        if (value is null)
        {
            NotNullOrEmpty(parameterName, nameof(parameterName));

            throw new ArgumentNullException(parameterName);
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(CoreStrings.ArgumentIsEmpty(parameterName));
        }

        return value;
    }

    public static IEnumerable<T> HasNoNulls<T>(IEnumerable<T> value, [CallerArgumentExpression(nameof(value))] string? parameterName = null)
    {
        if (value is null)
        {
            NotNullOrEmpty(parameterName, nameof(parameterName));

            throw new ArgumentNullException(parameterName);
        }

        if (value.Any(v => v is null))
        {
            NotNullOrEmpty(parameterName, nameof(parameterName));

            throw new ArgumentException(parameterName);
        }

        return value;
    }
}