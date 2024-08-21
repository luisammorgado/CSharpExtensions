using System.Diagnostics;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void Alphabet(string argument, string argumentName) =>
        Guard.NotIsMatch(argument, argumentName, @"[a-zA-Z]");
}