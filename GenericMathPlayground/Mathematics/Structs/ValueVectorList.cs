// <copyright file="VectorList.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueVectorList<T>
    : IEquatable<ValueVectorList<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueVectorList() : this(Array.Empty<IVector<T>>()) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="items"></param>
    public ValueVectorList(params IVector<T>[] items)
    {
        Items = new List<IVector<T>>(items);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="items"></param>
    public ValueVectorList(Span<IVector<T>> items)
    {
        Items = new List<IVector<T>>(items.ToArray());
    }
    #endregion

    #region Properties
    /// <summary>
    /// 
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
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(Items);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is ValueVectorList<T> list && Equals(list);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValueVectorList<T> other) => EqualityComparer<List<IVector<T>>>.Default.Equals(Items, other.Items);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string? ToString() => base.ToString();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
    #endregion
}
