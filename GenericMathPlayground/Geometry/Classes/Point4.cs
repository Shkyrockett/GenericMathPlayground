// <copyright file="Point4.cs" company="Shkyrockett" >
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
    public class Point4<T>
        : IPoint4<T>
        where T : INumber<T>
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private ValuePoint4<T> value;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Point4() => value = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Point4(ValuePoint4<T> value) => this.value = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Point4(IVector4<T> value) => this.value = new(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public Point4((T X, T Y, T Z, T W) tuple) => value = new(tuple);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public Point4(T x, T y, T z, T w) => value = new(x, y, z, w);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <param name="W"></param>
        public void Deconstruct(out T X, out T Y, out T Z, out T W) => (X, Y, Z, W) = value;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ValuePoint4<T> Value { get { return value; } set { this.value = value; } }

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
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValuePoint4<T>(Point4<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator Point4<T>(ValuePoint4<T> value) => new(value);
        #endregion
    }
}