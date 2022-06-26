// <copyright file="Operations.Roots.cs" company="Shkyrockett" >
//     Copyright © .NET Foundation.
// </copyright>
// <license>
//     Licensed to the .NET Foundation under one or more agreements.
//     The .NET Foundation licenses this file to you under the MIT license.
//     See the LICENSE file in the project root for more information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using Microsoft.Toolkit.HighPerformance;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground;

/// <summary>
/// 
/// </summary>
public static class SpanExtensions
{
    /// <summary>
    /// Delimits all leading occurrences of whitespace characters from the span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <acknowledgment>
    /// https://github.com/dotnet/coreclr/blob/master/src/System.Private.CoreLib/shared/System/MemoryExtensions.Trim.cs
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int ClampStart(this Span<char> span)
    {
        var start = 0;

        for (; start < span.Length; start++)
        {
            if (!char.IsWhiteSpace(span[start]))
            {
                break;
            }
        }

        return start;
    }

    /// <summary>
    /// Delimits all leading occurrences of a specified element from the span.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="span">The source span from which the element is removed.</param>
    /// <param name="trimElement">The specified element to look for and remove.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/dotnet/coreclr/blob/master/src/System.Private.CoreLib/shared/System/MemoryExtensions.Trim.cs
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int ClampStart<T>(this Span<T> span, T trimElement)
#nullable disable // to enable use with both T and T? for reference types due to IEquatable<T> being invariant
            where T : IEquatable<T>
#nullable restore
    {
        var start = 0;

        if (trimElement != null)
        {
            for (; start < span.Length; start++)
            {
                if (!trimElement.Equals(span[start]))
                {
                    break;
                }
            }
        }
        else
        {
            for (; start < span.Length; start++)
            {
                if (span[start] != null)
                {
                    break;
                }
            }
        }

        return start;
    }

    /// <summary>
    /// Delimits all leading occurrences of a set of elements specified
    /// in a readonly span from the span.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="span">The source span from which the elements are removed.</param>
    /// <param name="trimElements">The span which contains the set of elements to remove.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/dotnet/coreclr/blob/master/src/System.Private.CoreLib/shared/System/MemoryExtensions.Trim.cs
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int ClampStart<T>(this Span<T> span, Span<T> trimElements)
#nullable disable // to enable use with both T and T? for reference types due to IEquatable<T> being invariant
            where T : IEquatable<T>
#nullable restore
    {
        var start = 0;
        for (; start < span.Length; start++)
        {
            if (!trimElements.Contains(span[start]))
            {
                break;
            }
        }

        return start;
    }

    /// <summary>
    /// Delimits all trailing occurrences of whitespace characters from the span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="start">The start index from which to being searching.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/dotnet/coreclr/blob/master/src/System.Private.CoreLib/shared/System/MemoryExtensions.Trim.cs
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int ClampEnd(this Span<char> span, int start)
    {
        // Initially, start==len==0. If ClampStart trims all, start==len
        Debug.Assert((uint)start <= span.Length);

        var end = span.Length - 1;

        for (; end >= start; end--)
        {
            if (!char.IsWhiteSpace(span[end]))
            {
                break;
            }
        }

        return end - start + 1;
    }

    /// <summary>
    /// Delimits all trailing occurrences of a specified element from the span.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="span">The source span from which the element is removed.</param>
    /// <param name="start">The start index from which to being searching.</param>
    /// <param name="trimElement">The specified element to look for and remove.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/dotnet/coreclr/blob/master/src/System.Private.CoreLib/shared/System/MemoryExtensions.Trim.cs
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int ClampEnd<T>(this Span<T> span, int start, T trimElement)
#nullable disable // to enable use with both T and T? for reference types due to IEquatable<T> being invariant
            where T : IEquatable<T>
#nullable restore
    {
        // Initially, start==len==0. If ClampStart trims all, start==len
        Debug.Assert((uint)start <= span.Length);

        var end = span.Length - 1;

        if (trimElement != null)
        {
            for (; end >= start; end--)
            {
                if (!trimElement.Equals(span[end]))
                {
                    break;
                }
            }
        }
        else
        {
            for (; end >= start; end--)
            {
                if (span[end] != null)
                {
                    break;
                }
            }
        }

        return end - start + 1;
    }

    /// <summary>
    /// Delimits all trailing occurrences of a set of elements specified
    /// in a readonly span from the span.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="span">The source span from which the elements are removed.</param>
    /// <param name="start">The start index from which to being searching.</param>
    /// <param name="trimElements">The span which contains the set of elements to remove.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/dotnet/coreclr/blob/master/src/System.Private.CoreLib/shared/System/MemoryExtensions.Trim.cs
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int ClampEnd<T>(this Span<T> span, int start, Span<T> trimElements)
#nullable disable // to enable use with both T and T? for reference types due to IEquatable<T> being invariant
            where T : IEquatable<T>
#nullable restore
    {
        // Initially, start==len==0. If ClampStart trims all, start==len
        Debug.Assert((uint)start <= span.Length);

        var end = span.Length - 1;
        for (; end >= start; end--)
        {
            if (!trimElements.Contains(span[end]))
            {
                break;
            }
        }

        return end - start + 1;
    }

    /// <summary>
    ///  Projects each element of a sequence into a new form. (map in every other language)
    /// </summary>        
    /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
    /// <param name="selector">A transform function to apply (map) to each element.</param>
    /// <returns>A sequence whose elements are the result of invoking the transform function on each element (mapping) of source.</returns>
    /// <acknowledgment>
    /// https://github.com/jackmott/LinqFaster/blob/master/LinqFaster/Select.cs#L167
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] Select<TSource, TResult>(this Span<TSource> source, Func<TSource, TResult> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        var result = new TResult[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            result[i] = selector(source[i]);
        }

        return result;
    }

    /// <summary>
    ///  Projects each element of a sequence into a new form. (map in every other language)
    /// </summary>        
    /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
    /// <param name="selector">A transform function to apply (map) to each element.</param>
    /// <returns>A sequence whose elements are the result of invoking the transform function on each element (mapping) of source.</returns>
    /// <acknowledgment>
    /// https://github.com/jackmott/LinqFaster/blob/master/LinqFaster/Select.cs#L167
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] Select<TSource, TResult>(this Span<TSource> source, Func<TSource, int, TResult> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        var result = new TResult[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            result[i] = selector(source[i], i);
        }

        return result;
    }

    /// <summary>
    ///  Projects each element of a sequence into a new form. (map in every other language)
    /// </summary>        
    /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
    /// <param name="selector">A transform function to apply (map) to each element.</param>
    /// <returns>A sequence whose elements are the result of invoking the transform function on each element (mapping) of source.</returns>
    /// <acknowledgment>
    /// https://github.com/jackmott/LinqFaster/blob/master/LinqFaster/Select.cs#L167
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] Select<TSource, TResult>(this TSource[,] source, Func<TSource, TResult> selector)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        var index = 0;
        var result = new TResult[source.Length];
        for (int i = 0; i < source.GetLength(0); i++)
        {
            for (int j = 0; j < source.GetLength(1); j++)
            {
                result[index++] = selector(source[i, j]);
            }
        }

        return result;
    }

    /// <summary>
    ///  Projects each element of a sequence into a new form. (map in every other language)
    /// </summary>        
    /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
    /// <param name="selector">A transform function to apply (map) to each element.</param>
    /// <returns>A sequence whose elements are the result of invoking the transform function on each element (mapping) of source.</returns>
    /// <acknowledgment>
    /// https://github.com/jackmott/LinqFaster/blob/master/LinqFaster/Select.cs#L167
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] Select<TSource, TResult>(this Span2D<TSource> source, Func<TSource, TResult> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        var index = 0;
        var result = new TResult[source.Length];
        for (int i = 0; i < source.Width; i++)
        {
            for (int j = 0; j < source.Height; j++)
            {
                result[index++] = selector(source[i, j]);
            }
        }

        return result;
    }

    /// <summary>
    ///  Projects each element of a sequence into a new form. (map in every other language)
    /// </summary>        
    /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
    /// <param name="selector">A transform function to apply (map) to each element.</param>
    /// <returns>A sequence whose elements are the result of invoking the transform function on each element (mapping) of source.</returns>
    /// <acknowledgment>
    /// https://github.com/jackmott/LinqFaster/blob/master/LinqFaster/Select.cs#L167
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] Select<TSource, TResult>(this TSource[,] source, Func<TSource, int, int, TResult> selector)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector is null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        var index = 0;
        var result = new TResult[source.Length];
        for (int i = 0; i < source.GetLength(0); i++)
        {
            for (int j = 0; j < source.GetLength(1); j++)
            {
                result[index++] = selector(source[i, j], i, j);
            }
        }

        return result;
    }

    /// <summary>
    ///  Projects each element of a sequence into a new form. (map in every other language)
    /// </summary>        
    /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
    /// <param name="selector">A transform function to apply (map) to each element.</param>
    /// <returns>A sequence whose elements are the result of invoking the transform function on each element (mapping) of source.</returns>
    /// <acknowledgment>
    /// https://github.com/jackmott/LinqFaster/blob/master/LinqFaster/Select.cs#L167
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] Select<TSource, TResult>(this Span2D<TSource> source, Func<TSource, int, int, TResult> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var index = 0;
        var result = new TResult[source.Length];
        for (int i = 0; i < source.Width; i++)
        {
            for (int j = 0; j < source.Height; j++)
            {
                result[index++] = selector(source[i, j], i, j);
            }
        }

        return result;
    }
}
