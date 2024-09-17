namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    public static void Each<T>(this IEnumerable<T> @this, Action<T> action)
    {
        if (@this == null)
            return;

        foreach (var item in @this)
            action(item);
    }
}