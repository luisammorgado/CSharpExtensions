using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class Extensions
{
    [ExcludeFromCodeCoverage]
    public static void Each<T>(this IEnumerable<T> items, Action<T> action)
    {
        if (items == null)
            return;

        var cached = items;

        foreach (var item in cached)
            action(item);
    }
}