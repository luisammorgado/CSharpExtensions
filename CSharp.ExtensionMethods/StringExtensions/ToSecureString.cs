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
    /// <param name="str">Input String</param>
    /// <returns></returns>
    [ExcludeFromCodeCoverage]
    public static System.Security.SecureString ToSecureString(this String str)
    {
        System.Security.SecureString secureString = new();
        foreach (Char c in str)
            secureString.AppendChar(c);

        return secureString;
    }
}