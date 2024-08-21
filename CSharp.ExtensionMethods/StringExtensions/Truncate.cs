using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    /// <summary>
    /// Truncate a string to a specified length
    /// </summary>
    /// <param name="this"></param>
    /// <param name="maxLength"></param>
    /// <returns></returns>
    [ExcludeFromCodeCoverage]
    public static string Truncate(this string @this, int maxLength)
    {
        const string suffix = "...";
        string resultString = @this;

        if (maxLength <= 0)
            return resultString;

        int length = maxLength - suffix.Length;

        if (length <= 0)
            return resultString;

        if (@this == null || @this.Length <= maxLength)
            return resultString;

        resultString = @this[..length];
        resultString = resultString.TrimEnd();
        resultString += suffix;

        return resultString;
    }
}