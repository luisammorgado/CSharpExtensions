using System.Diagnostics;

namespace CSharp.FunctionalExtensions;

[DebuggerDisplay("{thisType}, EitherOfType = {_currentType}; Type = {_currentValueType?.Name}; Value = '{ToString()}'")]
public readonly struct EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> : IEquatable<EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>>
{
    private static string _thisType => $"EitherOf<{typeof(TFirst).Name}, {typeof(TSecond).Name}, {typeof(TThird).Name}, {typeof(TFourth).Name}, {typeof(TFifth).Name}, {typeof(TSixth).Name}, {typeof(TSeventh).Name}, {typeof(TEighth).Name}>";

    private readonly int numberOfTypes;
    private readonly TFirst? first;
    private readonly TSecond? second;
    private readonly TThird? third;
    private readonly TFourth? fourth;
    private readonly TFifth? fifth;
    private readonly TSixth? sixth;
    private readonly TSeventh? seventh;
    private readonly TEighth? eighth;

    public readonly EitherOfType[] EitherOfTypes => [EitherOfType.First, EitherOfType.Second, EitherOfType.Third, EitherOfType.Fourth, EitherOfType.Fifth, EitherOfType.Sixth, EitherOfType.Seventh, EitherOfType.Eighth];
    public readonly Type[] Types => [typeof(TFirst), typeof(TSecond), typeof(TThird), typeof(TFourth), typeof(TFifth), typeof(TSixth), typeof(TSeventh), typeof(TEighth)];
    public readonly bool IsUndefined => CurrentType == EitherOfType.Undefined;
    public readonly bool IsFirst => CurrentType == EitherOfType.First;
    public readonly bool IsSecond => CurrentType == EitherOfType.Second;
    public readonly bool IsThird => CurrentType == EitherOfType.Third;
    public readonly bool IsFourth => CurrentType == EitherOfType.Fourth;
    public readonly bool IsFifth => CurrentType == EitherOfType.Fifth;
    public readonly bool IsSixth => CurrentType == EitherOfType.Sixth;
    public readonly bool IsSeventh => CurrentType == EitherOfType.Seventh;
    public readonly bool IsEighth => CurrentType == EitherOfType.Eighth;

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(TFirst value) => new(value);

    public static implicit operator TFirst(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> @this) => @this.First;

    public EitherOf(TFirst value)
    {
        numberOfTypes = 8;
        CurrentType = EitherOfType.First;
        CurrentValue = value;
        CurrentValueType = typeof(TFirst);
        first = value;
        second = default;
        third = default;
        fourth = default;
        fifth = default;
        sixth = default;
        seventh = default;
        eighth = default;
    }

    public TFirst? First
    {
        get
        {
            Validate(EitherOfType.First);

            return first;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(TSecond value) => new(value);

    public static implicit operator TSecond(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> @this) => @this.Second;

    public EitherOf(TSecond value)
    {
        numberOfTypes = 8;
        CurrentType = EitherOfType.Second;
        CurrentValue = value;
        CurrentValueType = typeof(TSecond);
        second = value;
        first = default;
        third = default;
        fourth = default;
        fifth = default;
        sixth = default;
        seventh = default;
        eighth = default;
    }

    public TSecond? Second
    {
        get
        {
            Validate(EitherOfType.Second);

            return second;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(TThird value) => new(value);

    public static implicit operator TThird(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> @this) => @this.Third;

    public EitherOf(TThird value)
    {
        numberOfTypes = 8;
        CurrentType = EitherOfType.Third;
        CurrentValue = value;
        CurrentValueType = typeof(TThird);
        third = value;
        first = default;
        second = default;
        fourth = default;
        fifth = default;
        sixth = default;
        seventh = default;
        eighth = default;
    }

    public TThird? Third
    {
        get
        {
            Validate(EitherOfType.Third);

            return third;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(TFourth value) => new(value);

    public static implicit operator TFourth(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> @this) => @this.Fourth;

    public EitherOf(TFourth value)
    {
        numberOfTypes = 8;
        CurrentType = EitherOfType.Fourth;
        CurrentValue = value;
        CurrentValueType = typeof(TFourth);
        fourth = value;
        first = default;
        second = default;
        third = default;
        fifth = default;
        sixth = default;
        seventh = default;
        eighth = default;
    }

    public TFourth? Fourth
    {
        get
        {
            Validate(EitherOfType.Fourth);

            return fourth;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(TFifth value) => new(value);

    public static implicit operator TFifth(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> @this) => @this.Fifth;

    public EitherOf(TFifth value)
    {
        numberOfTypes = 8;
        CurrentType = EitherOfType.Fifth;
        CurrentValue = value;
        CurrentValueType = typeof(TFifth);
        fifth = value;
        first = default;
        second = default;
        third = default;
        fourth = default;
        sixth = default;
        seventh = default;
        eighth = default;
    }

    public TFifth? Fifth
    {
        get
        {
            Validate(EitherOfType.Fifth);

            return fifth;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(TSixth value) => new(value);

    public static implicit operator TSixth(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> @this) => @this.Sixth;

    public EitherOf(TSixth value)
    {
        numberOfTypes = 8;
        CurrentType = EitherOfType.Sixth;
        CurrentValue = value;
        CurrentValueType = typeof(TSixth);
        sixth = value;
        first = default;
        second = default;
        third = default;
        fourth = default;
        fifth = default;
        seventh = default;
        eighth = default;
    }

    public TSixth? Sixth
    {
        get
        {
            Validate(EitherOfType.Sixth);

            return sixth;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(TSeventh value) => new(value);

    public static implicit operator TSeventh(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> @this) => @this.Seventh;

    public EitherOf(TSeventh value)
    {
        numberOfTypes = 8;
        CurrentType = EitherOfType.Seventh;
        CurrentValue = value;
        CurrentValueType = typeof(TSeventh);
        seventh = value;
        first = default;
        second = default;
        third = default;
        fourth = default;
        fifth = default;
        sixth = default;
        eighth = default;
    }

    public TSeventh? Seventh
    {
        get
        {
            Validate(EitherOfType.Seventh);

            return seventh;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(TEighth value) => new(value);

    public static implicit operator TEighth(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> @this) => @this.Eighth;

    public EitherOf(TEighth value)
    {
        numberOfTypes = 8;
        CurrentType = EitherOfType.Eighth;
        CurrentValue = value;
        CurrentValueType = typeof(TEighth);
        eighth = value;
        first = default;
        second = default;
        third = default;
        fourth = default;
        fifth = default;
        sixth = default;
        seventh = default;
    }

    public TEighth? Eighth
    {
        get
        {
            Validate(EitherOfType.Eighth);

            return eighth;
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
                seventh,
                eighth,
                typeof(TFirst),
                typeof(TSecond),
                typeof(TThird),
                typeof(TFourth),
                typeof(TFifth),
                typeof(TSixth),
                typeof(TSeventh),
                typeof(TEighth),
        };
        return HashCodeCalculator.GetHashCode(fields);
    }

    public bool Equals(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> other) =>
        CurrentType == other.CurrentType &&
        numberOfTypes == other.numberOfTypes &&
        EqualityComparer<object>.Default.Equals(CurrentValue, other.CurrentValue) &&
        EqualityComparer<TFirst>.Default.Equals(first, other.first) &&
        EqualityComparer<TSecond>.Default.Equals(second, other.second) &&
        EqualityComparer<TThird>.Default.Equals(third, other.third) &&
        EqualityComparer<TFourth>.Default.Equals(fourth, other.fourth) &&
        EqualityComparer<TFifth>.Default.Equals(fifth, other.fifth) &&
        EqualityComparer<TSixth>.Default.Equals(sixth, other.sixth) &&
        EqualityComparer<TSeventh>.Default.Equals(seventh, other.seventh) &&
        EqualityComparer<TEighth>.Default.Equals(eighth, other.eighth);

    public static bool operator ==(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> obj1, EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> obj2)
    => EqualityComparer<EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>>.Default.Equals(obj1, obj2);

    public static bool operator !=(EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> obj1, EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> obj2)
    => !(obj1 == obj2);

    public override bool Equals(object obj)
    => obj is EitherOf<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth> o && Equals(o);

    public override string ToString() => IsUndefined ? EitherOf.Null : $"{CurrentValue}";
}