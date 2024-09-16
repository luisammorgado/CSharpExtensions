using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods.StreamExtensions;

public static partial class StreamExtensions
{
    [ExcludeFromCodeCoverage]
    public static byte[] ConvertToByteArray(this Stream stream)
    {
        var streamLength = Convert.ToInt32(stream.Length);
        byte[] data = new byte[streamLength + 1];

        //convert to to a byte array
        stream.Read(data, 0, streamLength);
        stream.Close();

        return data;
    }
}