namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    public static Boolean HasItems(this System.Collections.IEnumerable @this)
    {
        if (@this is null)
            return false;

        try
        {
            var enumerator = @this.GetEnumerator();

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