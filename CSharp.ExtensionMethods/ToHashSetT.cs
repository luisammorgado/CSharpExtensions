using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class Extensions
{
    [ExcludeFromCodeCoverage]
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Func<T, bool> filterParam) =>
        list.Where(filterParam);
}