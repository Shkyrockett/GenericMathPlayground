// <copyright file="Point5.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Mathematics;
using System;

namespace GenericMathPlayground.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Point5<T>
        : IPoint5<T>
        where T : INumber<T>
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private ValuePoint5<T> value;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Point5() => value = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Point5(ValuePoint5<T> value) => this.value = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Point5(IVector5<T> value) => this.value = new(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public Point5((T X, T Y, T Z, T W, T V) tuple) => value = new(tuple);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        /// <param name="v"></param>
        public Point5(T x, T y, T z, T w, T v) => value = new(x, y, z, w, v);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <param name="W"></param>
        /// <param name="V"></param>
        public void Deconstruct(out T X, out T Y, out T Z, out T W, out T V) => (X, Y, Z, W, V) = value;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ValuePoint5<T> Value { get { return value; } set { this.value = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T X { get { return value.X; } set { this.value.X = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T Y { get { return value.Y; } set { this.value.Y = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T Z { get { return value.Z; } set { this.value.Z = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T W { get { return value.W; } set { this.value.W = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T V { get { return value.V; } set { this.value.V = value; } }
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValuePoint5<T>(Point5<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator Point5<T>(ValuePoint5<T> value) => new(value);
        #endregion
    }
}