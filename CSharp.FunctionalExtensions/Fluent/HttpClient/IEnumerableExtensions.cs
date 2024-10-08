using System.Collections;

namespace CSharp.FunctionalExtensions.Fluent.HttpClient;

/// <summary>
/// Extension method for converting a <see cref="NameValueCollection" /> into a query string.
/// </summary>
internal static class ListExtensions
{
    /// <summary>
    /// Converts the list of key/value pairs into a query string.
    /// </summary>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static string ToQueryString(this List<string> collection) =>
        (collection.Count == 0)
        ? string.Empty
        : $"?{string.Join("&", collection)}";
}