using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    public static Collection<T> ToCollection<T>(this IEnumerable<T> enumerable)
    {
        var collection = new Collection<T>();

        foreach (T i in enumerable)
            collection.Add(i);

        return collection;
    }
}