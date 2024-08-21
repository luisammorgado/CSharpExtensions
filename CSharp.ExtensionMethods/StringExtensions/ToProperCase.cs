using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    /// <summary>
    /// Converts the string to proper case
    /// </summary>
    /// <returns></returns>
    [ExcludeFromCodeCoverage]
    public static string ToProperCase(this string @this)
    {
        System.Globalization.CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;

        return textInfo.ToTitleCase(@this);
    }
}