using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    [ExcludeFromCodeCoverage]
    public static bool ContainsAny(this string @this, char[] characters)
    {
        foreach (char character in characters)
        {
            if (@this.Contains(character.ToString()))
                return true;
        }

        return false;
    }
}