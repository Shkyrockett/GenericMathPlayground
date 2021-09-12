namespace GenericMathPlayground.Mathematics;

public static partial class Operations
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryCast<T, TResult>(this T value, out TResult result) where T : INumber<T> where TResult : INumber<TResult> => TResult.TryCreate(value, out result);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TResult? TryCastOrDefault<T, TResult>(this T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.TryCreate(value, out TResult? result) ? result : default;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TResult? Cast<T, TResult>(this T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.Create(value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TResult? CastSaturating<T, TResult>(this T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.CreateSaturating(value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TResult? CastTruncating<T, TResult>(this T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.CreateTruncating(value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/#trying-out-the-features
    /// </acknowledgment>
    public static T Add<T>(T left, T right) where T : INumber<T> => left + right;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static T Subtract<T>(T left, T right) where T : INumber<T> => left - right;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static T Multiply<T>(T left, T right) where T : INumber<T> => left * right;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static T Divide<T>(T left, T right) where T : INumber<T> => left / right;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/#generic-math
    /// </acknowledgment>
    public static TResult Sum<T, TResult>(IEnumerable<T> values)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = TResult.Zero;

        foreach (var value in values)
        {
            result += TResult.Create(value);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/#generic-math
    /// </acknowledgment>
    public static TResult Average<T, TResult>(IEnumerable<T> values)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var sum = Sum<T, TResult>(values);
        return TResult.Create(sum) / TResult.Create(values.Count());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/#generic-math
    /// </acknowledgment>
    public static TResult StandardDeviation<T, TResult>(IEnumerable<T> values)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        var standardDeviation = TResult.Zero;

        if (values.Any())
        {
            TResult average = Average<T, TResult>(values);
            TResult sum = Sum<TResult, TResult>(values.Select((value) =>
            {
                var deviation = TResult.Create(value) - average;
                return deviation * deviation;
            }));
            standardDeviation = TResult.Sqrt(sum / TResult.Create(values.Count() - 1));
        }

        return standardDeviation;
    }
}
