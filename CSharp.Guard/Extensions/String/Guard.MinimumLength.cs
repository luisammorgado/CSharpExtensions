using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void MinimumLength(string argument, string argumentName, int minLength)
    {
        if (argument.Length < minLength)
            throw new ArgumentException($"{argumentName} is not allowing characters less than {minLength}");
    }
}