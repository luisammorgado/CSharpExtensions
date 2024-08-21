using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    [ExcludeFromCodeCoverage]
    public static bool ContainsAny(this string theString, char[] characters)
    {
        foreach (char character in characters)
        {
            if (theString.Contains(character.ToString()))
                return true;
        }

        return false;
    }
}