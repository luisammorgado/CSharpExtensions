using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void Space(string argument, string argumentName)
    {
        if (argument.Contains(' '))
            throw new ArgumentException(@"{0} is not allowing space", argumentName);
    }
}