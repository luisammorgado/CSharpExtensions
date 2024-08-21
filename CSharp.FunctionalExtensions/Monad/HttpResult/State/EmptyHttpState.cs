using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSharp.FunctionalExtensions.Monad.HttpResultMonad.State;

/*
* The purpose of this class is just for syntax usage
* It allows the following syntax: HttpState.Empty to instanciate an empty http state
*/

public static class HttpState
{
    public static IHttpState Empty => new EmptyHttpHttpState();
}

public class EmptyHttpHttpState : IEquatable<EmptyHttpHttpState>, IHttpState
{
    internal EmptyHttpHttpState()
    { }

    public Uri Url { get; }

    public string HttpMethod { get; }

    public int HttpStatusCode { get; }

    public long? RequestContentLength { get; }

    public long? ResponseContentLength { get; }

    public List<KeyValuePair<string, IEnumerable<string>>> RequestHeaders { get; }

    public List<KeyValuePair<string, IEnumerable<string>>> ResponseHeaders { get; }

    public Task<Stream> ReadRequestBodyAsStreamAsync() => Task.FromResult(Stream.Null);

    public Task<Stream> ReadResponseBodyAsStreamAsync() => Task.FromResult(Stream.Null);

    public Task<string> ReadRequestBodyAsStringAsync() => Task.FromResult(string.Empty);

    public Task<string> ReadResponseBodyAsStringAsync() => Task.FromResult(string.Empty);

    public Task<byte[]> ReadRequestBodyAsByteArrayAsync() => Task.FromResult(Array.Empty<byte>());

    public Task<byte[]> ReadResponseBodyAsByteArrayAsync() => Task.FromResult(Array.Empty<byte>());

    public bool Equals(EmptyHttpHttpState other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return GetType() == other.GetType();
    }

    public override bool Equals(object obj) => Equals(obj as EmptyHttpHttpState);

    public override int GetHashCode() => 0;

    public void Dispose()
    { }
}