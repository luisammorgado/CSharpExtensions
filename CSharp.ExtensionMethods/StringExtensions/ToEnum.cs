using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    /// <summary>
    /// Converts the string to an enum
    /// </summary>
    /// <returns></returns>
    [ExcludeFromCodeCoverage]
    public static T ToEnum<T>(this string @this)
        where T : struct => (T)Enum.Parse(typeof(T), @this, true);
}