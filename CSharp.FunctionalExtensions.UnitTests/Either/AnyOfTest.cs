using CSharp.FunctionalExtensions;
using FluentAssertions;

namespace CSharp.FunctionalExtensions.UnitTests;

public sealed class EitherOfTest
{
    [Fact]
    public void EitherOf_GetHashCode()
    {
        // Arrange
        var EitherOfIntAndStringTypeWithIntValue1 = new EitherOf<int, string>(42);
        var EitherOfIntAndStringTypeWithIntValue2 = new EitherOf<int, string>(42);
        var EitherOfIntAndStringTypeWithIntValue3 = new EitherOf<int, string>(5);
        var EitherOfIntAndBoolTypeWithBoolValue = new EitherOf<int, bool>(42);

        // Assert
        EitherOfIntAndStringTypeWithIntValue1
            .GetHashCode()
            .Should()
            .Be(EitherOfIntAndStringTypeWithIntValue2.GetHashCode());

        EitherOfIntAndStringTypeWithIntValue1
            .GetHashCode()
            .Should()
            .NotBe(EitherOfIntAndStringTypeWithIntValue3.GetHashCode());

        EitherOfIntAndStringTypeWithIntValue1
            .GetHashCode()
            .Should()
            .NotBe(EitherOfIntAndBoolTypeWithBoolValue.GetHashCode());
    }

    [Fact]
    public void EitherOf_Equals_Method()
    {
        // Arrange
        var EitherOfIntAndStringTypeWithIntValue1 = new EitherOf<int, string>(42);
        var EitherOfIntAndStringTypeWithIntValue2 = new EitherOf<int, string>(42);
        var EitherOfIntAndStringTypeWithIntValue3 = new EitherOf<int, string>(5);
        var EitherOfIntAndStringTypeWithStringValue1 = new EitherOf<int, string>("abc");
        var EitherOfIntAndStringTypeWithStringValue2 = new EitherOf<int, string>("abc");
        var EitherOfIntAndStringTypeWithStringValue3 = new EitherOf<int, string>("x");
        var EitherOfIntAndBoolTypeWithBoolValue = new EitherOf<int, bool>(42);
        var normalInt = 42;
        var normalString = "abc";

        // Assert
        EitherOfIntAndStringTypeWithIntValue1.Equals(EitherOfIntAndStringTypeWithIntValue2).Should().BeTrue();
        EitherOfIntAndStringTypeWithIntValue1.Equals(EitherOfIntAndStringTypeWithIntValue3).Should().BeFalse();
        EitherOfIntAndStringTypeWithIntValue1.Equals(EitherOfIntAndBoolTypeWithBoolValue).Should().BeFalse();
        EitherOfIntAndStringTypeWithIntValue1.Equals(normalInt).Should().BeTrue();

        EitherOfIntAndStringTypeWithStringValue1.Equals(EitherOfIntAndStringTypeWithStringValue2).Should().BeTrue();
        EitherOfIntAndStringTypeWithStringValue1.Equals(EitherOfIntAndStringTypeWithStringValue3).Should().BeFalse();
        EitherOfIntAndStringTypeWithStringValue1.Equals(EitherOfIntAndBoolTypeWithBoolValue).Should().BeFalse();
        EitherOfIntAndStringTypeWithStringValue1.Equals(normalString).Should().BeTrue();
    }

    [Fact]
    public void EitherOf_Equals_Operator()
    {
        // Arrange
        var EitherOfIntAndStringTypeWithIntValue1 = new EitherOf<int, string>(42);
        var EitherOfIntAndStringTypeWithIntValue2 = new EitherOf<int, string>(42);
        var EitherOfIntAndStringTypeWithIntValue3 = new EitherOf<int, string>(5);
        var EitherOfIntAndStringTypeWithStringValue = new EitherOf<int, string>("x");
        var EitherOfIntAndBoolTypeWithIntValue = new EitherOf<int, bool>(42);
        var EitherOfIntAndBoolTypeWithBoolValue = new EitherOf<int, bool>(true);
        var normalBool = true;
        var normalInt = 42;
        var normalString = "x";

        // Assert
        (EitherOfIntAndStringTypeWithIntValue1 == EitherOfIntAndStringTypeWithIntValue2).Should().BeTrue();
        (EitherOfIntAndStringTypeWithIntValue1 == EitherOfIntAndBoolTypeWithIntValue).Should().BeTrue();

        (EitherOfIntAndStringTypeWithIntValue1 == normalInt).Should().BeTrue();
        (EitherOfIntAndStringTypeWithIntValue1 == normalString).Should().BeFalse();
        (EitherOfIntAndBoolTypeWithBoolValue == normalBool).Should().BeTrue();
        (EitherOfIntAndStringTypeWithStringValue == normalString).Should().BeTrue();

        (EitherOfIntAndStringTypeWithIntValue1 == EitherOfIntAndStringTypeWithIntValue3).Should().BeFalse();
        (EitherOfIntAndStringTypeWithIntValue1 == EitherOfIntAndBoolTypeWithIntValue).Should().BeTrue();
        (EitherOfIntAndStringTypeWithIntValue1 == EitherOfIntAndStringTypeWithStringValue).Should().BeFalse();
    }

    [Fact]
    public void EitherOf_Equals_Operator_Throws_Exception()
    {
        // Arrange
        var EitherOfIntAndStringTypeWithIntValue1 = new EitherOf<int, string>(42);
        var EitherOfIntAndBoolTypeWithBoolValue = new EitherOf<int, bool>(true);

        // Assert
        Func<bool> a = () => EitherOfIntAndStringTypeWithIntValue1 == EitherOfIntAndBoolTypeWithBoolValue;
        a.Should().Throw<Exception>();
    }
}