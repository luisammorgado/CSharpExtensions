using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class StringExtensions
{
    [ExcludeFromCodeCoverage]
    public static MemoryStream ToStream(this string @this)
        => new(System.Text.Encoding.ASCII.GetBytes(@this));
}