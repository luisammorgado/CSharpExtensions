using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class Extensions
{
    [ExcludeFromCodeCoverage]
    public static MemoryStream ToMemoryStream(this Byte[] buffer)
    {
        MemoryStream ms = new(buffer)
        {
            Position = 0
        };

        return ms;
    }
}