﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace CSharp.Guard.UnitTests;

[TestFixture]
public partial class GuardTests
{
    [Test]
    public void NotAny_InvalidInput_ThrowsException()
    {
        var items = new List<int>();
        var exception = new Exception("error message");

        Should.Throw<Exception>(() => Guard.NotAny(items, exception));
    }

    [Test]
    [TestCase(null)]
    [TestCase("custom message")]
    public void NotAny_InvalidNullCustomException2_ThrowsException(string message)
    {
        var items = new List<int>();

        if (message == null)
        {
            Should.Throw<InvalidOperationException>(() => Guard.NotAny<int, InvalidOperationException>(items));
        }
        else
        {
            Should
                .Throw<InvalidOperationException>(() => Guard.NotAny<int, InvalidOperationException>(items, message))
                .Message
                .ShouldBe(message);
        }
    }

    [Test]
    public void NotAny_InvalidInputNullCustomException_ThrowsException()
    {
        var items = new List<int>();
        Exception exception = null;

        Should.Throw<ArgumentNullException>(() => Guard.NotAny(items, exception));
    }

    [Test]
    public void NotAny_NullInput_ThrowsException()
    {
        List<int> items = null;
        Exception exception = new();

        Should.Throw<ArgumentNullException>(() => Guard.NotAny(items, exception));
    }

    [Test]
    public void NotAny_ValidInput_DoesNotThrowException()
    {
        List<int> items = [1];
        Should.NotThrow(() => Guard.NotAny(items, nameof(items)));
    }
}