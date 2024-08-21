namespace CSharp.FunctionalExtensions;

internal static class HashCodeCalculator
{
    public static int GetHashCode(IEnumerable<object> hashFieldValues)
    {
        const int offset = unchecked((int)2166136261);
        const int prime = 16777619;

        static int HashCodeAggregator(int hashCode, object value) => value == null
            ? (hashCode ^ 0) * prime
            : (hashCode ^ value.GetHashCode()) * prime;

        return hashFieldValues.Aggregate(offset, HashCodeAggregator);
    }
}