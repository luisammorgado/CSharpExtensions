using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void MaximumLength(string argument, string argumentName, int maxLength)
    {
        if (argument.Length > maxLength)
            throw new ArgumentException($"{argumentName} is not allowing characters more than {maxLength}");
    }
}