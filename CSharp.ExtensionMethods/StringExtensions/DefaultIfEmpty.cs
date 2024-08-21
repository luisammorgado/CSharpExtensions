using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    [ExcludeFromCodeCoverage]
    public static string DefaultIfEmpty(
        this string str,
        string defaultValue,
        bool considerWhiteSpaceIsEmpty
    ) =>
        (considerWhiteSpaceIsEmpty ? string.IsNullOrWhiteSpace(str) : string.IsNullOrEmpty(str)) ? defaultValue : str;
}