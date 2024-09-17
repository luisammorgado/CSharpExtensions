namespace CSharp.ExtensionMethods;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Linq extension to be able to fluently wait for any of <see cref="IEnumerable{T}" /> of
    /// <see cref="Task" /> just like <see cref="Task.WhenAll(System.Threading.Tasks.Task[])" />.
    /// </summary>
    /// <param name="this">The tasks.</param>
    /// <returns>An awaitable task</returns>
    /// <remarks></remarks>
    /// <example>var something = await foos.Select(foo =&gt; BarAsync(foo)).WhenAll();</example>
    /// <exception cref="System.ArgumentNullException"></exception>
    /// <exception cref="System.ArgumentException"></exception>
    public static Task WhenAny(this IEnumerable<Task> @this)
    {
        var enumeratedTasks = @this as Task[] ?? @this.ToArray();

        return Task.WhenAny(enumeratedTasks);
    }

    /// <summary>
    /// Linq extension to be able to fluently wait for all of <see cref="IEnumerable{T}" /> of
    /// <see cref="Task" /> just like <see cref="Task.WhenAny(System.Threading.Tasks.Task{TResult}[])" />.
    /// </summary>
    /// <param name="tasks">The tasks.</param>
    /// <returns>An awaitable task</returns>
    /// <remarks></remarks>
    /// <example>var bar = await foos.Select(foo =&gt; BarAsync(foo)).WhenAll();</example>
    /// <exception cref="System.ArgumentNullException"></exception>
    /// <exception cref="System.ArgumentException"></exception>
    public static async Task<TResult> WhenAny<TResult>(this IEnumerable<Task<TResult>> tasks)
    {
        var enumeratedTasks = tasks as Task<TResult>[] ?? tasks.ToArray();

        var result = await await Task.WhenAny(enumeratedTasks);

        return result;
    }
}