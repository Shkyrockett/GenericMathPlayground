// <copyright file="ARGB.cs" company="Shkyrockett" >
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
    public struct ARGB<T>
        : IColor<T>, IEquatable<ARGB<T>>
        where T : INumber<T>
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        public ARGB(T a, T r, T g, T b) => (A, R, G, B) = (a, r, g, b);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        /// <param name="A"></param>
        public void Deconstruct(out T A, out T R, out T G, out T B) => (A, R, G, B) = (this.A, this.R, this.G, this.B);
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public T A { get; set; }

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
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ARGB<T> left, ARGB<T> right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ARGB<T> left, ARGB<T> right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ARGB<T>(RGBA<T> value) => value;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) => obj is ARGB<T> aRGB && Equals(aRGB);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ARGB<T> other) => A.Equals(other.A) && R.Equals(other.R) && G.Equals(other.G) && B.Equals(other.B);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => HashCode.Combine(A, R, G, B);

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
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ARGB<T>)}: ({nameof(A)}: {A.ToString(format, formatProvider)}, {nameof(R)}: {R.ToString(format, formatProvider)}, {nameof(G)}: {G.ToString(format, formatProvider)}, {nameof(B)}: {B.ToString(format, formatProvider)})";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string? GetDebuggerDisplay() => ToString();
    }
}
