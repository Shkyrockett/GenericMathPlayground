// <copyright file="RGBA.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Chromatics;

/// <summary>
/// The r g b a.
/// </summary>
/// <typeparam name="T"></typeparam>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct RGBA<T>
    : IColor<T>, IEquatable<RGBA<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="RGBA{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public RGBA() : this(T.Zero, T.Zero, T.Zero, T.One) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="RGBA{T}"/> class.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="g">The g.</param>
    /// <param name="b">The b.</param>
    /// <param name="a">The a.</param>
    public RGBA(T r, T g, T b, T a) => (R, G, B, A) = (r, g, b, a);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="R">The r.</param>
    /// <param name="G">The g.</param>
    /// <param name="B">The b.</param>
    /// <param name="A">The a.</param>
    public void Deconstruct(out T R, out T G, out T B, out T A) => (R, G, B, A) = (this.R, this.G, this.B, this.A);
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the r.
    /// </summary>
    public T R { get; set; }

    /// <summary>
    /// Gets or sets the g.
    /// </summary>
    public T G { get; set; }

    /// <summary>
    /// Gets or sets the b.
    /// </summary>
    public T B { get; set; }

    /// <summary>
    /// Gets or sets the a.
    /// </summary>
    public T A { get; set; }
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(RGBA<T> left, RGBA<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(RGBA<T> left, RGBA<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator RGBA<T>(ARGB<T> value) => value;
    #endregion

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is RGBA<T> rgba && Equals(rgba);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(RGBA<T> other) => R.Equals(other.R) && G.Equals(other.G) && B.Equals(other.B) && A.Equals(other.A);

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(R, G, B, A);

    /// <summary>
    /// Tos the string.
    /// </summary>
    /// <returns>A string? .</returns>
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Tos the string.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>A string.</returns>
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// Tos the string.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>A string.</returns>
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(RGBA<T>)}: ({nameof(R)}: {R.ToString(format, formatProvider)}, {nameof(G)}: {G.ToString(format, formatProvider)}, {nameof(B)}: {B.ToString(format, formatProvider)}, {nameof(A)}: {A.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>A string? .</returns>
    private string? GetDebuggerDisplay() => ToString();
}
