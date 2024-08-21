using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    /// <summary>
    /// Returns the last few characters of the string with a length
    /// specified by the given parameter. If the string's length is less than the
    /// given length the complete string is returned. If length is zero or
    /// less an empty string is returned
    /// </summary>
    /// <param name="this">the string to process</param>
    /// <param name="length">Number of characters to return</param>
    /// <returns></returns>
    [ExcludeFromCodeCoverage]
    public static string Right(this string @this, int length)
    {
        length = Math.Max(length, 0);

        return (@this.Length > length)
            ? @this.Substring(@this.Length - length, length)
            : @this;
    }
}