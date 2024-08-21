using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void LeadingAndTailingSpace(string argument, string argumentName)
    {
        if (argument.Trim() != argument)
            throw new ArgumentException($"{0} is not allowing leading and tailing space", argumentName);
    }
}