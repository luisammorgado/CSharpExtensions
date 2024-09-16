namespace CSharp.ExtensionMethods;

public static class EnumHelper
{
    public static T ToEnum<T>(this string enumString) =>
        (T)Enum.Parse(typeof(T), enumString);

    public static T ToEnum<T>(this int enumValue) =>
        (T)Enum.ToObject(typeof(T), enumValue);
}