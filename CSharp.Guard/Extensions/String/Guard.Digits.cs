using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void Digits(string argument, string argumentName) =>
        Guard.NotIsMatch(argument, argumentName, @"[0-9]");
}