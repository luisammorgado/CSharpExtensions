using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    [ExcludeFromCodeCoverage]
    public static Collection<T> ToCollection<T>(this IEnumerable<T> @this)
    {
        var collection = new Collection<T>();

        foreach (T i in @this)
            collection.Add(i);

        return collection;
    }
}