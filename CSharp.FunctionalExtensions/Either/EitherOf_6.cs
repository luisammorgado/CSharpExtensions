using System.Diagnostics;

namespace CSharp.FunctionalExtensions;

[DebuggerDisplay("{thisType}, EitherOfType = {_currentType}; Type = {_currentValueType?.Name}; Value = '{ToString()}'")]
public readonly struct EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> : IEquatable<EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>>
{
    private static string thisType => $"EitherOf<{typeof(TFirst).Name}, {typeof(TSecond).Name}, {typeof(TThird).Name}, {typeof(TFourth).Name}, {typeof(TFifth).Name}, {typeof(TSixth).Name}>";

    private readonly int numberOfTypes;
    private readonly TFirst? first;
    private readonly TSecond? second;
    private readonly TThird? third;
    private readonly TFourth? fourth;
    private readonly TFifth? fifth;
    private readonly TSixth? sixth;

    public readonly EitherOfType[] EitherOfTypes => [EitherOfType.First, EitherOfType.Second, EitherOfType.Third, EitherOfType.Fourth, EitherOfType.Fifth, EitherOfType.Sixth];
    public readonly Type[] Types => [typeof(TFirst), typeof(TSecond), typeof(TThird), typeof(TFourth), typeof(TFifth), typeof(TSixth)];
    public readonly bool IsUndefined => CurrentType == EitherOfType.Undefined;
    public readonly bool IsFirst => CurrentType == EitherOfType.First;
    public readonly bool IsSecond => CurrentType == EitherOfType.Second;
    public readonly bool IsThird => CurrentType == EitherOfType.Third;
    public readonly bool IsFourth => CurrentType == EitherOfType.Fourth;
    public readonly bool IsFifth => CurrentType == EitherOfType.Fifth;
    public readonly bool IsSixth => CurrentType == EitherOfType.Sixth;

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(TFirst value) => new(value);

    public static implicit operator TFirst(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> @this) => @this.First;

    public EitherOf(TFirst value)
    {
        numberOfTypes = 6;
        CurrentType = EitherOfType.First;
        CurrentValue = value;
        CurrentValueType = typeof(TFirst);
        first = value;
        second = default;
        third = default;
        fourth = default;
        fifth = default;
        sixth = default;
    }

    public TFirst? First
    {
        get
        {
            Validate(EitherOfType.First);

            return first;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(TSecond value) => new(value);

    public static implicit operator TSecond(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> @this) => @this.Second;

    public EitherOf(TSecond value)
    {
        numberOfTypes = 6;
        CurrentType = EitherOfType.Second;
        CurrentValue = value;
        CurrentValueType = typeof(TSecond);
        second = value;
        first = default;
        third = default;
        fourth = default;
        fifth = default;
        sixth = default;
    }

    public TSecond? Second
    {
        get
        {
            Validate(EitherOfType.Second);

            return second;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(TThird value) => new(value);

    public static implicit operator TThird(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> @this) => @this.Third;

    public EitherOf(TThird value)
    {
        numberOfTypes = 6;
        CurrentType = EitherOfType.Third;
        CurrentValue = value;
        CurrentValueType = typeof(TThird);
        third = value;
        first = default;
        second = default;
        fourth = default;
        fifth = default;
        sixth = default;
    }

    public TThird? Third
    {
        get
        {
            Validate(EitherOfType.Third);

            return third;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(TFourth value) => new(value);

    public static implicit operator TFourth(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> @this) => @this.Fourth;

    public EitherOf(TFourth value)
    {
        numberOfTypes = 6;
        CurrentType = EitherOfType.Fourth;
        CurrentValue = value;
        CurrentValueType = typeof(TFourth);
        fourth = value;
        first = default;
        second = default;
        third = default;
        fifth = default;
        sixth = default;
    }

    public TFourth? Fourth
    {
        get
        {
            Validate(EitherOfType.Fourth);

            return fourth;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(TFifth value) => new(value);

    public static implicit operator TFifth(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> @this) => @this.Fifth;

    public EitherOf(TFifth value)
    {
        numberOfTypes = 6;
        CurrentType = EitherOfType.Fifth;
        CurrentValue = value;
        CurrentValueType = typeof(TFifth);
        fifth = value;
        first = default;
        second = default;
        third = default;
        fourth = default;
        sixth = default;
    }

    public TFifth? Fifth
    {
        get
        {
            Validate(EitherOfType.Fifth);

            return fifth;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(TSixth value) => new(value);

    public static implicit operator TSixth(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> @this) => @this.Sixth;

    public EitherOf(TSixth value)
    {
        numberOfTypes = 6;
        CurrentType = EitherOfType.Sixth;
        CurrentValue = value;
        CurrentValueType = typeof(TSixth);
        sixth = value;
        first = default;
        second = default;
        third = default;
        fourth = default;
        fifth = default;
    }

    public TSixth? Sixth
    {
        get
        {
            Validate(EitherOfType.Sixth);

            return sixth;
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
                fifth,
                sixth,
                typeof(TFirst),
                typeof(TSecond),
                typeof(TThird),
                typeof(TFourth),
                typeof(TFifth),
                typeof(TSixth),
        };

        return HashCodeCalculator.GetHashCode(fields);
    }

    public bool Equals(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> other) =>
        CurrentType == other.CurrentType &&
        numberOfTypes == other.numberOfTypes &&
        EqualityComparer<object>.Default.Equals(CurrentValue, other.CurrentValue) &&
        EqualityComparer<TFirst>.Default.Equals(first, other.first) &&
        EqualityComparer<TSecond>.Default.Equals(second, other.second) &&
        EqualityComparer<TThird>.Default.Equals(third, other.third) &&
        EqualityComparer<TFourth>.Default.Equals(fourth, other.fourth) &&
        EqualityComparer<TFifth>.Default.Equals(fifth, other.fifth) &&
        EqualityComparer<TSixth>.Default.Equals(sixth, other.sixth);

    public static bool operator ==(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> obj1, EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> obj2)
    => EqualityComparer<EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>>.Default.Equals(obj1, obj2);

    public static bool operator !=(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> obj1, EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> obj2)
    => !(obj1 == obj2);

    public override bool Equals(object obj)
    => obj is EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth> o && Equals(o);

    public override string ToString() =>
        IsUndefined ? EitherOf.Null : $"{CurrentValue}";
}