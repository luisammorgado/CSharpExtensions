namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    public static Boolean HasItems(this System.Collections.IEnumerable enumerable)
    {
        if (enumerable is null)
            return false;

        try
        {
            var enumerator = enumerable.GetEnumerator();

            if (enumerator is not null && enumerator.MoveNext())
            {
                return true;
            }
        }
        catch
        {
        }

        return false;
    }
}