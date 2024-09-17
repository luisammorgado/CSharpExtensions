namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Linq extension to be able to fluently wait for all of <see cref="IEnumerable{T}" /> of
    /// <see cref="Task" /> just like <see cref="Task.WhenAll(System.Threading.Tasks.Task[])" />.
    /// </summary>
    /// <param name="this">The tasks.</param>
    /// <returns>An awaitable task</returns>
    /// <remarks></remarks>
    /// <example>var something = await foos.Select(foo =&gt; BarAsync(foo)).WhenAll();</example>
    /// <exception cref="System.ArgumentNullException"></exception>
    /// <exception cref="System.ArgumentException"></exception>
    public static Task WhenAll(this IEnumerable<Task> @this)
    {
        var enumeratedTasks = @this as Task[] ?? @this?.ToArray();

        return Task.WhenAll(enumeratedTasks);
    }

    /// <summary>
    /// Linq extension to be able to fluently wait for all of <see cref="IEnumerable{T}" /> of
    /// <see cref="Task" /> just like <see cref="Task.WhenAll(System.Threading.Tasks.Task{TResult}[])" />.
    /// </summary>
    /// <param name="this">The tasks.</param>
    /// <returns>An awaitable task</returns>
    /// <remarks></remarks>
    /// <example>var bars = await foos.Select(foo =&gt; BarAsync(foo)).WhenAll();</example>
    /// <exception cref="System.ArgumentNullException"></exception>
    /// <exception cref="System.ArgumentException"></exception>
    public static async Task<IEnumerable<TResult>> WhenAll<TResult>(this IEnumerable<Task<TResult>> @this)
    {
        var enumeratedTasks = @this as Task<TResult>[] ?? @this.ToArray();

        var result = await Task.WhenAll(enumeratedTasks);

        return result;
    }
}