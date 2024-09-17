namespace CSharp.FunctionalExtensions;

[DebuggerDisplay("{thisType}, EitherOfType = {_currentType}; Type = {_currentValueType?.Name}; Value = '{ToString()}'")]
public readonly struct EitherOf<TFirst, TSecond> : IEquatable<EitherOf<TFirst, TSecond>>
{
    private static string thisType => $"EitherOf<{typeof(TFirst).Name}, {typeof(TSecond).Name}>";

    private readonly int numberOfTypes;
    private readonly TFirst? first;
    private readonly TSecond? second;

    public readonly EitherOfType[] EitherOfTypes => [EitherOfType.First, EitherOfType.Second];
    public readonly Type[] Types => [typeof(TFirst), typeof(TSecond)];
    public readonly bool IsUndefined => CurrentType == EitherOfType.Undefined;
    public readonly bool IsFirst => CurrentType == EitherOfType.First;
    public readonly bool IsSecond => CurrentType == EitherOfType.Second;

    public static implicit operator EitherOf<TFirst, TSecond>(TFirst value) => new(value);

    public static implicit operator TFirst(EitherOf<TFirst, TSecond> @this) => @this.First;

    public EitherOf([NotNull] TFirst value)
    {
        numberOfTypes = 2;
        CurrentType = EitherOfType.First;
        CurrentValue = value;
        CurrentValueType = typeof(TFirst);
        first = value;
        second = default;
    }

    public TFirst First
    {
        get
        {
            Validate(EitherOfType.First);

            return First1;
        }
    }

    public static implicit operator EitherOf<TFirst, TSecond>(TSecond value) => new(value);

    public static implicit operator TSecond(EitherOf<TFirst, TSecond> @this) => @this.Second;

    public EitherOf([NotNull] TSecond value)
    {
        numberOfTypes = 2;
        CurrentType = EitherOfType.Second;
        CurrentValue = value;
        CurrentValueType = typeof(TSecond);
        second = value;
        first = default;
    }

    public TSecond? Second
    {
        get
        {
            Validate(EitherOfType.Second);

            return second;
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

    public TFirst First1 => first;

    public override int GetHashCode()
    {
        var fields = new object[]
        {
                numberOfTypes,
                CurrentValue,
                CurrentType,
                First1,
                second,
                typeof(TFirst),
                typeof(TSecond),
        };

        return HashCodeCalculator.GetHashCode(fields);
    }

    public bool Equals(EitherOf<TFirst, TSecond> other) =>
        CurrentType == other.CurrentType &&
        numberOfTypes == other.numberOfTypes &&
        EqualityComparer<object>.Default.Equals(CurrentValue, other.CurrentValue) &&
        EqualityComparer<TFirst>.Default.Equals(First1, other.First1) &&
        EqualityComparer<TSecond>.Default.Equals(second, other.second);

    public static bool operator ==(EitherOf<TFirst, TSecond> obj1, EitherOf<TFirst, TSecond> obj2) =>
        EqualityComparer<EitherOf<TFirst, TSecond>>.Default.Equals(obj1, obj2);

    public static bool operator !=(EitherOf<TFirst, TSecond> obj1, EitherOf<TFirst, TSecond> obj2) =>
        !(obj1 == obj2);

    public override bool Equals(object obj) =>
        obj is EitherOf<TFirst, TSecond> o && Equals(o);

    public override string ToString() =>
        IsUndefined ? EitherOf.Null : $"{CurrentValue}";
}