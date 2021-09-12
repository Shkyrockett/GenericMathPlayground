// <copyright file="Point2.cs" company="Shkyrockett" >
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

namespace GenericMathPlayground.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Point2<T>
        : IPoint2<T>
        where T : INumber<T>
    {
        #region Fields
        private ValuePoint2<T> value;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Point2() => value = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Point2(ValuePoint2<T> value) => this.value = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Point2(IVector2<T> value) => this.value = new(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public Point2((T X, T Y) tuple) => value = new(tuple);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point2(T x, T y) => value = new(x, y);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void Deconstruct(out T X, out T Y) => (X, Y) = value;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ValuePoint2<T> Value { get { return value; } set { this.value = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T X { get { return value.X; } set { this.value.X = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T Y { get { return value.Y; } set { this.value.Y = value; } }
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValuePoint2<T>(Point2<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator Point2<T>(ValuePoint2<T> value) => new(value);
        #endregion
    }
}