using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class Extensions
{
    [ExcludeFromCodeCoverage]
    public static byte[] ConvertToByteArray(this System.IO.Stream stream)
    {
        var streamLength = Convert.ToInt32(stream.Length);
        byte[] data = new byte[streamLength + 1];

        //convert to to a byte array
        stream.Read(data, 0, streamLength);
        stream.Close();

        return data;
    }
}