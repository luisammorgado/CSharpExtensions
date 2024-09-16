using System.Diagnostics.CodeAnalysis;

namespace CSharp.ExtensionMethods;

public static partial class Extensions
{
    /// <summary>
    /// if the object this method is called on is not null, runs the given function and returns the
    /// value. if the object is null, returns default(TResult)
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static TResult? IfNotNull<T, TResult>(this T target, Func<T, TResult> getValue)
    {
        return target != null ? getValue(target) : default;
    }
}