using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    /// <summary>
    /// Replaces the last occurrence of a string with another string.
    /// </summary>
    /// <param name="this"></param>
    /// <param name="find"></param>
    /// <param name="replace"></param>
    /// <returns></returns>
    [ExcludeFromCodeCoverage]
    public static string ReplaceLastOccurrence(this string @this, string find, string replace)
    {
        int place = @this.LastIndexOf(find, StringComparison.Ordinal);
        return place == -1 ?
            @this :
            @this.Remove(place, find.Length)
                .Insert(place, replace);
    }
}