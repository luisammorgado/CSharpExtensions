using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

/// <summary>
/// Utility class for string manipulation.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Converts a string into a "SecureString"
    /// </summary>
    /// <param name="this">Input String</param>
    /// <returns></returns>
    [ExcludeFromCodeCoverage]
    public static System.Security.SecureString ToSecureString(this string @this)
    {
        System.Security.SecureString secureString = new();
        foreach (Char c in @this)
            secureString.AppendChar(c);

        return secureString;
    }
}