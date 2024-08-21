using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    /// <summary>
    /// Trims the last character of a string.
    /// </summary>
    /// <param name="this"></param>
    /// <returns></returns>
    [ExcludeFromCodeCoverage]
    public static string TrimLastCharacter(this string @this)
    => string.IsNullOrWhiteSpace(@this) ?
        @this :
        @this[..^1];
}