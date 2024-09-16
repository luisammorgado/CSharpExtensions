using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    /// Converts an IEnumerable to a HashSet </summary> <typeparam name="T">The IEnumerable
    /// type</typeparam> <param name="enumerable">The IEnumerable</param> <returns>A new HashSet</returns>
    [ExcludeFromCodeCoverage]
    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable)
    {
        HashSet<T> hs = [.. enumerable];

        return hs;
    }
}