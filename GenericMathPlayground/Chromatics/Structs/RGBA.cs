// <copyright file="RGBA.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;
using System.Diagnostics;
using System.Globalization;

namespace GenericMathPlayground.Chromatics
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public struct RGBA<T>
        : IColor<T>, IEquatable<RGBA<T>>
        where T : INumber<T>
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public RGBA(T r, T g, T b, T a) => (R, G, B, A) = (r, g, b, a);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        /// <param name="A"></param>
        public void Deconstruct(out T R, out T G, out T B, out T A) => (R, G, B, A) = (this.R, this.G, this.B, this.A);
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public T R { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T G { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T B { get; set; }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) => obj is RGBA<T> rgba && Equals(rgba);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(RGBA<T> other) => R.Equals(other.R) && G.Equals(other.G) && B.Equals(other.B) && A.Equals(other.A);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => HashCode.Combine(R, G, B, A);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(RGBA<T>)}: ({nameof(R)}: {R.ToString(format, formatProvider)}, {nameof(G)}: {G.ToString(format, formatProvider)}, {nameof(B)}: {B.ToString(format, formatProvider)}, {nameof(A)}: {A.ToString(format, formatProvider)})";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string? GetDebuggerDisplay() => ToString();
    }
}
