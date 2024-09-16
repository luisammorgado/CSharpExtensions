namespace CSharp.ExtensionMethods;

public static partial class EnumExtensions
{
    public static T Parse<T>(string value) =>
    (T)Enum.Parse(typeof(T), value);

    public static T Parse<T>(string value, bool ignoreCase) =>
        (T)Enum.Parse(typeof(T), value, ignoreCase);
}