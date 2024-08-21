using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CSharp.Guard;

public static partial class Guard
{
    [DebuggerStepThrough]
    public static void SpecialCharacters(string argument, string argumentName) =>
        Guard.NotIsMatch(argument, argumentName, @"[~`!@#$%^&*()-+=|\{}':;.,<>/?]");
}