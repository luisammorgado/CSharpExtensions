namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    public static T ToEnum<T>(this string @this) =>
        (T)Enum.Parse(typeof(T), @this);

    public static T ToEnum<T>(this int @this) =>
        (T)Enum.ToObject(typeof(T), @this);
}