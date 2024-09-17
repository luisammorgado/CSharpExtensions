using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods.StreamExtensions;

public static partial class StreamExtensions
{
    [ExcludeFromCodeCoverage]
    public static byte[] ConvertToByteArray(this Stream @this)
    {
        var streamLength = Convert.ToInt32(@this.Length);
        byte[] data = new byte[streamLength + 1];

        //convert to to a byte array
        @this.Read(data, 0, streamLength);
        @this.Close();

        return data;
    }
}