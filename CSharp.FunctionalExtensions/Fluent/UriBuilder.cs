using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.FunctionalExtensions.Fluent;

public static partial class UriBuilderExtensions
{
    /// <summary>
    /// Appends a query string parameter with a key, and many values. Multiple values will be comma
    /// seperated. If only 1 value is passed and its null or value, the key will be added to the QS.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="key"></param>
    /// <param name="values"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static UriBuilder WithParameter(this UriBuilder builder, string key, params string[] values) =>
        builder.WithParameter(key, valuesEnum: values);

    /// <summary>
    /// Appends query strings from a list of key-value pairs (usually a dictionary).
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="parameterDictionary"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static UriBuilder WithParameter(this UriBuilder builder, IEnumerable<KeyValuePair<string, string>> parameterDictionary)
    {
        ArgumentNullException.ThrowIfNull(builder);

        ArgumentNullException.ThrowIfNull(parameterDictionary);

        foreach (var item in parameterDictionary)
        {
            builder.WithParameter(item.Key, item.Value);
        }

        return builder;
    }

    /// <summary>
    /// Appends a query string parameter with a key, and many values. Multiple values will be comma
    /// seperated. If only 1 value is passed and its null or value, the key will be added to the QS.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="key"></param>
    /// <param name="valuesEnum"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static UriBuilder WithParameter(this UriBuilder builder, string key, IEnumerable<object> valuesEnum)
    {
        ArgumentNullException.ThrowIfNull(builder);

        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        valuesEnum ??= [];

        var intitialValue = string.IsNullOrWhiteSpace(builder.Query)
            ? "" :
            $"{builder.Query.TrimStart('?')}&";

        builder.Query = intitialValue.AppendKeyValue(key, valuesEnum);

        return builder;
    }

    /// <summary>
    /// Appends a fragments parameter with a key, and many values. Multiple values will be comma
    /// seperated. If only 1 value is passed and its null or value, the key will be added to the fragment.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="key"></param>
    /// <param name="values"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static UriBuilder WithFragment(this UriBuilder builder, string key, params string[] values) =>
        builder.WithFragment(key, valuesEnum: values);

    /// <summary>
    /// Appends fragments from dictionary
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="fragmentDictionary"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static UriBuilder WithFragment(this UriBuilder builder, IDictionary<string, string> fragmentDictionary)
    {
        ArgumentNullException.ThrowIfNull(builder);

        ArgumentNullException.ThrowIfNull(fragmentDictionary);

        foreach (var item in fragmentDictionary)
        {
            builder.WithFragment(item.Key, item.Value);
        }

        return builder;
    }

    /// <summary>
    /// Appends a fragments with a key, and many values. Multiple values will be comma seperated. If
    /// only 1 value is passed and its null or value, the key will be added to the fragment.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="key"></param>
    /// <param name="valuesEnum"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static UriBuilder WithFragment(this UriBuilder builder, string key, IEnumerable<object> valuesEnum)
    {
        ArgumentNullException.ThrowIfNull(builder);

        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        valuesEnum ??= [];

        var intitialValue = string.IsNullOrWhiteSpace(builder.Fragment) ? "" : $"{builder.Fragment.TrimStart('#')}&";
        builder.Fragment = intitialValue.AppendKeyValue(key, valuesEnum);

        return builder;
    }

    /// <summary>
    /// Sets the port to be the port number
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="port"></param>
    /// <exception cref="ArgumentOutOfRangeException">Throws if port is less than one</exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static UriBuilder WithPort(this UriBuilder builder, int port)
    {
        ArgumentNullException.ThrowIfNull(builder);

        ArgumentOutOfRangeException.ThrowIfLessThan(port, 1);

        builder.Port = port;

        return builder;
    }

    /// <summary>
    /// Removes the port number for default ports
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static UriBuilder WithoutDefaultPort(this UriBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        if (builder.Uri.IsDefaultPort)
            builder.Port = -1;

        return builder;
    }

    /// <summary>
    /// appends a path segment to the path. Can be called multiple times to append multiple segments
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="pathSegment"></param>
    /// <exception cref="ArgumentNullException">You pass a string as a path segment</exception>
    /// <returns></returns>
    public static UriBuilder WithPathSegment(this UriBuilder builder, string pathSegment)
    {
        ArgumentNullException.ThrowIfNull(builder);

        if (string.IsNullOrWhiteSpace(pathSegment))
            throw new ArgumentNullException(nameof(pathSegment));

        var path = pathSegment.TrimStart('/');

        builder.Path = $"{builder.Path.TrimEnd('/')}/{path}";

        return builder;
    }

    /// <summary>
    /// Sets your Uri Scheme
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="scheme"></param>
    /// <exception cref="ArgumentNullException">You must pass a scheme</exception>
    /// <returns></returns>
    public static UriBuilder WithScheme(this UriBuilder builder, string scheme)
    {
        ArgumentNullException.ThrowIfNull(builder);

        if (string.IsNullOrWhiteSpace(scheme))
            throw new ArgumentNullException(nameof(scheme));

        builder.Scheme = scheme;

        return builder;
    }

    /// <summary>
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="host"></param>
    /// <exception cref="ArgumentNullException">You must pass a ho0st</exception>
    /// <returns></returns>
    public static UriBuilder WithHost(this UriBuilder builder, string host)
    {
        ArgumentNullException.ThrowIfNull(builder);

        if (string.IsNullOrWhiteSpace(host))
            throw new ArgumentNullException(nameof(host));

        builder.Host = host;

        return builder;
    }

    public static string PathAndQuery(this UriBuilder builder) =>
        (builder.Path + builder.Query);

    /// <summary>
    /// Use Https?
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="predicate">default true, if false sets scheme to http</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static UriBuilder UseHttps(this UriBuilder builder, bool predicate = true)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Scheme = predicate ? "https" : "http";

        return builder;
    }

    /// <summary>
    /// Escape the whole Url string
    /// </summary>
    /// <param name="builder"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static string ToEscapeDataString(this UriBuilder builder) =>
        Uri.EscapeDataString(builder.Uri.ToString());

    /// <summary>
    /// Returns the Uri string
    /// </summary>
    /// <param name="builder"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static string ToUriString(this UriBuilder builder) =>
        builder.Uri.ToString();

    /// <summary>
    /// Appends x-www-form-urlencoded key and valuesEnum into initialValue.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private static string AppendKeyValue(this string intitialValue, string key, IEnumerable<object> valuesEnum)
    {
        var encodedKey = Uri.EscapeDataString(key);

        var sb = new StringBuilder($"{intitialValue}{encodedKey}");

        var Values = (
            from x in valuesEnum
            let v = x?.ToString()
            where !string.IsNullOrWhiteSpace(v)
            select Uri.EscapeDataString(v)
            ).ToArray();

        if (Values.Length > 0)
        {
            sb.Append('=');
            sb.Append(string.Join(",", Values));
        }

        return sb.ToString();
    }

    /// <summary>
    /// Appends query strings from dictionary
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="parameterDictionary"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <returns></returns>
    public static UriBuilder WithParameter(this UriBuilder builder, IEnumerable<(string, string)> parameterDictionary)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(parameterDictionary);

        foreach (var item in parameterDictionary)
        {
            builder.WithParameter(item.Item1, item.Item2);
        }

        return builder;
    }
}