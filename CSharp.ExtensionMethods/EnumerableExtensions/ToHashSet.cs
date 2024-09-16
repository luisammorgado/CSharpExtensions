namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable)
    {
        var hs = new HashSet<T>();

        foreach (T item in enumerable)
            hs.Add(item);

        return hs;
    }