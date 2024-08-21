namespace CSharp.FunctionalExtensions.Fluent.HttpClient;

/// <summary>
/// Global options used by <see cref="FluentHttpClient" />.
/// </summary>
public static class FluentHttpClientOptions
{
    /// <summary>
    /// Default JsonSerializerOptions that will be use when serializing and deserializing if none
    /// are provided.
    /// </summary>
    public static JsonSerializerOptions DefaultJsonSerializerOptions { get; set; } = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
}