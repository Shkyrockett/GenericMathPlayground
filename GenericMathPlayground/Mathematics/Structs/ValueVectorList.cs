// <copyright file="VectorList.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Framework;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// The value vector list.
/// </summary>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueVectorList<T>
    : IEquatable<ValueVectorList<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVectorList{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueVectorList() : this(Array.Empty<IVector<T>>()) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVectorList{T}"/> class.
    /// </summary>
    /// <param name="items">The items.</param>
    public ValueVectorList(params IVector<T>[] items)
    {
        Items = new List<IVector<T>>(items);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVectorList{T}"/> class.
    /// </summary>
    /// <param name="items">The items.</param>
    public ValueVectorList(Span<IVector<T>> items)
    {
        Items = new List<IVector<T>>(items.ToArray());
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    [TypeConverter(typeof(ExpandableCollectionConverter))]
    public List<IVector<T>> Items { get; set; }
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueVectorList<T> left, ValueVectorList<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueVectorList<T> left, ValueVectorList<T> right) => !(left == right);
    #endregion

    #region Methods
    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(Items);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValueVectorList<T> list && Equals(list);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueVectorList<T> other) => EqualityComparer<List<IVector<T>>>.Default.Equals(Items, other.Items);

    /// <summary>
    /// Tos the string.
    /// </summary>
    /// <returns>A string? .</returns>
    public override string? ToString() => base.ToString();

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>A string? .</returns>
    private string? GetDebuggerDisplay() => ToString();
    #endregion
}
