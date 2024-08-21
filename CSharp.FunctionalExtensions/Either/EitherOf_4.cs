using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.FunctionalExtensions;

[DebuggerDisplay("{thisType}, EitherOfType = {_currentType}; Type = {_currentValueType?.Name}; Value = '{ToString()}'")]
public readonly struct EitherOf<TFirst, TSecond, TThird, TFourth> : IEquatable<EitherOf<TFirst, TSecond, TThird, TFourth>>
{
    private static string thisType => $"EitherOf<{typeof(TFirst).Name}, {typeof(TSecond).Name}, {typeof(TThird).Name}, {typeof(TFourth).Name}>";

    private readonly int numberOfTypes;
    private readonly TFirst? first;
    private readonly TSecond? second;
    private readonly TThird? third;
    private readonly TFourth? fourth;

    public readonly EitherOfType[] EitherOfTypes => [EitherOfType.First, EitherOfType.Second, EitherOfType.Third, EitherOfType.Fourth];
    public readonly Type[] Types => [typeof(TFirst), typeof(TSecond), typeof(TThird), typeof(TFourth)];
    public readonly bool IsUndefined => CurrentType == EitherOfType.Undefined;
    public readonly bool IsFirst => CurrentType == EitherOfType.First;
    public readonly bool IsSecond => CurrentType == EitherOfType.Second;
    public readonly bool IsThird => CurrentType == EitherOfType.Third;
    public readonly bool IsFourth => CurrentType == EitherOfType.Fourth;

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth>(TFirst value) => new(value);

    public static implicit operator TFirst(EitherOf<TFirst, TSecond, TThird, TFourth> @this) => @this.First;

    public EitherOf(TFirst value)
    {
        numberOfTypes = 4;
        CurrentType = EitherOfType.First;
        CurrentValue = value;
        CurrentValueType = typeof(TFirst);
        first = value;
        second = default;
        third = default;
        fourth = default;
    }

    public TFirst? First
    {
        get
        {
            Validate(EitherOfType.First);

            return first;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth>(TSecond value) => new(value);

    public static implicit operator TSecond(EitherOf<TFirst, TSecond, TThird, TFourth> @this) => @this.Second;

    public EitherOf(TSecond value)
    {
        numberOfTypes = 4;
        CurrentType = EitherOfType.Second;
        CurrentValue = value;
        CurrentValueType = typeof(TSecond);
        second = value;
        first = default;
        third = default;
        fourth = default;
    }

    public TSecond? Second
    {
        get
        {
            Validate(EitherOfType.Second);

            return second;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth>(TThird value) => new(value);

    public static implicit operator TThird(EitherOf<TFirst, TSecond, TThird, TFourth> @this) => @this.Third;

    public EitherOf(TThird value)
    {
        numberOfTypes = 4;
        CurrentType = EitherOfType.Third;
        CurrentValue = value;
        CurrentValueType = typeof(TThird);
        third = value;
        first = default;
        second = default;
        fourth = default;
    }

    public TThird? Third
    {
        get
        {
            Validate(EitherOfType.Third);

            return third;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth>(TFourth value) => new(value);

    public static implicit operator TFourth(EitherOf<TFirst, TSecond, TThird, TFourth> @this) => @this.Fourth;

    public EitherOf(TFourth value)
    {
        numberOfTypes = 4;
        CurrentType = EitherOfType.Fourth;
        CurrentValue = value;
        CurrentValueType = typeof(TFourth);
        fourth = value;
        first = default;
        second = default;
        third = default;
    }

    public TFourth? Fourth
    {
        get
        {
            Validate(EitherOfType.Fourth);

            return fourth;
        }
    }

    private void Validate(EitherOfType desiredType)
    {
        if (desiredType != CurrentType)
            throw new InvalidOperationException($"Attempting to get {desiredType} when {CurrentType} is set");
    }

    public EitherOfType CurrentType { get; }

    public object? CurrentValue { get; }

    public Type CurrentValueType { get; }

    public override int GetHashCode()
    {
        var fields = new object?[]
        {
                numberOfTypes,
                CurrentValue,
                CurrentType,
                first,
                second,
                third,
                fourth,
                typeof(TFirst),
                typeof(TSecond),
                typeof(TThird),
                typeof(TFourth),
        };

        return HashCodeCalculator.GetHashCode(fields);
    }

    public bool Equals(EitherOf<TFirst, TSecond, TThird, TFourth> other) =>
        CurrentType == other.CurrentType &&
        numberOfTypes == other.numberOfTypes &&
        EqualityComparer<object>.Default.Equals(CurrentValue, other.CurrentValue) &&
        EqualityComparer<TFirst>.Default.Equals(first, other.first) &&
        EqualityComparer<TSecond>.Default.Equals(second, other.second) &&
        EqualityComparer<TThird>.Default.Equals(third, other.third) &&
        EqualityComparer<TFourth>.Default.Equals(fourth, other.fourth);

    public static bool operator ==(EitherOf<TFirst, TSecond, TThird, TFourth> obj1, EitherOf<TFirst, TSecond, TThird, TFourth> obj2)
    => EqualityComparer<EitherOf<TFirst, TSecond, TThird, TFourth>>.Default.Equals(obj1, obj2);

    public static bool operator !=(EitherOf<TFirst, TSecond, TThird, TFourth> obj1, EitherOf<TFirst, TSecond, TThird, TFourth> obj2)
    => !(obj1 == obj2);

    public override bool Equals([NotNull] object obj)
    => obj is EitherOf<TFirst, TSecond, TThird, TFourth> o && Equals(o);

    public override string ToString() =>
        IsUndefined ? EitherOf.Null : $"{CurrentValue}";
}