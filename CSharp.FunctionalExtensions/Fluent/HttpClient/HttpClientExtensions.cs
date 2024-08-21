namespace CSharp.FunctionalExtensions.Fluent.HttpClient;

/// <summary>
/// Extension methods for generating the <see cref="HttpRequestBuilder" />
/// </summary>
public static class HttpClientExtensions
{
    /// <summary>
    /// Returns instance of <see cref="HttpRequestBuilder" /> that can be used to configure and send
    /// an <see cref="HttpRequestMessage" />
    /// </summary>
    /// <param name="client">HttpClient instance to be used for request</param>
    /// <param name="route">
    /// Endpoint URL, can be empty if the base address already targets the endpoint
    /// </param>
    public static HttpRequestBuilder UsingRoute(this System.Net.Http.HttpClient client, string route)
    {
        return new HttpRequestBuilder(client, route);
    }

    /// <summary>
    /// Returns instance of <see cref="HttpRequestBuilder" /> that can be used to configure and send
    /// an <see cref="HttpRequestMessage" />
    /// </summary>
    /// <param name="client">HttpClient instance to be used for request</param>
    /// <remarks>The request will be sent using the Uri specified by the <see cref="HttpClient.BaseAddress" /></remarks>
    public static HttpRequestBuilder WithoutRoute(this System.Net.Http.HttpClient client)
    {
        return new HttpRequestBuilder(client);
    }
}