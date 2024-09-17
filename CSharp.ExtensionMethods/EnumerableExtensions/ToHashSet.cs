namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> @this)
    {
        var hs = new HashSet<T>();

        foreach (T item in @this)
            hs.Add(item);

        return hs;
    }
}