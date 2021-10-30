# GenericMathPlayground

A project to play around with C# new Generic Math feature.

## Notes while porting code to Generic Math

You can't just use `T?` to pass nulls around using generic Math. You also have to declare the `T` as something that is Nullable such as struct.

```cs
public static T Bisect(T x0, Func<T, T> f, Func<T, T> df, int maxIterations, T? min = null, T? max = null)
    where T : struct, INumber<T>
{
...
}
```

The same goes for returning nullable generic values.


```cs
public static T? ConstrainedDistanceLineSegmentPoint<T>(T aX, T aY, T bX, T bY, T pX, T pY)
    where T : struct, INumber<T>
{
...
    return null;
}
```

It seems like it may be possible to have something similar to a constants by using static variables in a static generic typed class. 

```cs
public static class MathFloatConsts<T>
    where T : IFloatingPoint<T>
{
    public static readonly T OneThird = T.Create(1) / T.Create(4);

    public static readonly T OneHalf = T.Create(1) / T.Create(2);

    public static readonly T OneAndOneHalf =  T.Create(3) / T.Create(2);

    public static readonly T Hau = OneHalf * T.Pi;

    public static readonly T Pau = OneAndOneHalf * T.Pi;
}
```

This ought to be useful when different values are needed depending in the precision available. For example, since `T.MinValue`, and `T.MaxValue` are not defined on the `INumeric<T>` types we may need to see more code like this:

```
public static class MathConsts<T>
    where T : struct, INumber<T>
{
    public static readonly T? MaxValue = T.Zero switch
    {
        char => T.Create(char.MaxValue),
        sbyte => T.Create(sbyte.MaxValue),
        byte => T.Create(byte.MaxValue),
        short => T.Create(short.MaxValue),
        ushort => T.Create(ushort.MaxValue),
        int => T.Create(int.MaxValue),
        uint => T.Create(uint.MaxValue),
        long => T.Create(long.MaxValue),
        ulong => T.Create(ulong.MaxValue),
        Half => T.Create(Half.MaxValue),
        float => T.Create(float.MaxValue),
        double => T.Create(double.MaxValue),
        decimal => T.Create(decimal.MaxValue),
        _ => null
    };

    public static readonly T? MinValue = T.Zero switch
    {
        char => T.Create(char.MinValue),
        sbyte => T.Create(sbyte.MinValue),
        byte => T.Create(byte.MinValue),
        short => T.Create(short.MinValue),
        ushort => T.Create(ushort.MinValue),
        int => T.Create(int.MinValue),
        uint => T.Create(uint.MinValue),
        long => T.Create(long.MinValue),
        ulong => T.Create(ulong.MinValue),
        Half => T.Create(Half.MinValue),
        float => T.Create(float.MinValue),
        double => T.Create(double.MinValue),
        decimal => T.Create(decimal.MinValue),
        _ => null
    };
}
```

However, it seems like it simply is not possible to use generic types for default parameters. Values that would be constants have to be created, which means they aren't constants, and can't be used in default parameters.'
There are some standard constants, but they are implemented as static properties, and using static properties for constants means you can't create default parameters for generic type values:

```cs
public static Wrap<T>(T value, min = T.Zero, T max = T.Create(2))
    where T : INumber<T>
{
...
}
```

To work around this, multiple methods without the default parameters have to be created

```cs
public static Wrap<T>(T value) where T : INumber<T> => Wrap<T>(value, T.Zero)

public static Wrap<T>(T value, min) where T : INumber<T> => Wrap<T>(value, min, T.Create(2))

public static Wrap<T>(T value, min, T max)
    where T : INumber<T>
{
...
}
```
