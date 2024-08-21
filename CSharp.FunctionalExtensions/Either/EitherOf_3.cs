using System.Diagnostics;

namespace CSharp.FunctionalExtensions;

[DebuggerDisplay("{thisType}, EitherOfType = {_currentType}; Type = {_currentValueType?.Name}; Value = '{ToString()}'")]
public readonly struct EitherOf<TFirst, TSecond, TThird> : IEquatable<EitherOf<TFirst, TSecond, TThird>>
{
    private static string thisType => $"EitherOf<{typeof(TFirst).Name}, {typeof(TSecond).Name}, {typeof(TThird).Name}>";

    private readonly int numberOfTypes;
    private readonly TFirst? first;
    private readonly TSecond? second;
    private readonly TThird? third;

    public readonly EitherOfType[] EitherOfTypes => [EitherOfType.First, EitherOfType.Second, EitherOfType.Third];
    public readonly Type[] Types => [typeof(TFirst), typeof(TSecond), typeof(TThird)];
    public readonly bool IsUndefined => CurrentType == EitherOfType.Undefined;
    public readonly bool IsFirst => CurrentType == EitherOfType.First;
    public readonly bool IsSecond => CurrentType == EitherOfType.Second;
    public readonly bool IsThird => CurrentType == EitherOfType.Third;

    public static implicit operator EitherOf<TFirst, TSecond, TThird>(TFirst value) => new(value);

    public static implicit operator TFirst(EitherOf<TFirst, TSecond, TThird> @this) => @this.First;

    public EitherOf(TFirst value)
    {
        numberOfTypes = 3;
        CurrentType = EitherOfType.First;
        CurrentValue = value;
        CurrentValueType = typeof(TFirst);
        first = value;
        second = default;
        third = default;
    }

    public TFirst? First
    {
        get
        {
            Validate(EitherOfType.First);

            return first;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird>(TSecond value) => new(value);

    public static implicit operator TSecond(EitherOf<TFirst, TSecond, TThird> @this) => @this.Second;

    public EitherOf(TSecond value)
    {
        numberOfTypes = 3;
        CurrentType = EitherOfType.Second;
        CurrentValue = value;
        CurrentValueType = typeof(TSecond);
        second = value;
        first = default;
        third = default;
    }

    public TSecond? Second
    {
        get
        {
            Validate(EitherOfType.Second);

            return second;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird>(TThird value) => new(value);

    public static implicit operator TThird(EitherOf<TFirst, TSecond, TThird> @this) => @this.Third;

    public EitherOf(TThird value)
    {
        numberOfTypes = 3;
        CurrentType = EitherOfType.Third;
        CurrentValue = value;
        CurrentValueType = typeof(TThird);
        third = value;
        first = default;
        second = default;
    }

    public TThird? Third
    {
        get
        {
            Validate(EitherOfType.Third);

            return third;
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
                typeof(TFirst),
                typeof(TSecond),
                typeof(TThird),
        };

        return HashCodeCalculator.GetHashCode(fields);
    }

    public bool Equals(EitherOf<TFirst, TSecond, TThird> other) =>
        CurrentType == other.CurrentType &&
        numberOfTypes == other.numberOfTypes &&
        EqualityComparer<object>.Default.Equals(CurrentValue, other.CurrentValue) &&
        EqualityComparer<TFirst>.Default.Equals(first, other.first) &&
        EqualityComparer<TSecond>.Default.Equals(second, other.second) &&
        EqualityComparer<TThird>.Default.Equals(third, other.third);

    public static bool operator ==(EitherOf<TFirst, TSecond, TThird> obj1, EitherOf<TFirst, TSecond, TThird> obj2) =>
        EqualityComparer<EitherOf<TFirst, TSecond, TThird>>.Default.Equals(obj1, obj2);

    public static bool operator !=(EitherOf<TFirst, TSecond, TThird> obj1, EitherOf<TFirst, TSecond, TThird> obj2) =>
        !(obj1 == obj2);

    public override bool Equals(object obj) =>
        obj is EitherOf<TFirst, TSecond, TThird> o && Equals(o);

    public override string ToString() =>
        IsUndefined ? EitherOf.Null : $"{CurrentValue}";
}