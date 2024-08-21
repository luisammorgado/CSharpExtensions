using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    /// <summary>
    /// Removes extra spaces from a string.
    /// </summary>
    /// <param name="this"></param>
    /// <param name="trimEnd"></param>
    /// <returns></returns>
    [ExcludeFromCodeCoverage]
    public static string RemoveExtraSpaces(this string @this, bool trimEnd = false)
    {
        const RegexOptions options = RegexOptions.None;
        var regex = new Regex("[ ]{2,}", options);
        var result = regex.Replace(@this, " ");

        return trimEnd ? result.TrimEnd() : result;
    }
}