namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    public static T ToEnum<T>(this string enumString) =>
        (T)Enum.Parse(typeof(T), enumString);

    public static T ToEnum<T>(this int enumValue) =>
        (T)Enum.ToObject(typeof(T), enumValue);
}