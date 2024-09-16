namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    public static void Each<T>(this IEnumerable<T> items, Action<T> action)
    {
        if (items == null)
            return;

        foreach (var item in items)
            action(item);
    }
}