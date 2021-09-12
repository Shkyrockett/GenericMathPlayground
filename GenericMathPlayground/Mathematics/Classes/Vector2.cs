// <copyright file="Vector2.cs" company="Shkyrockett" >
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
    public class Vector2<T>
        : IVector2<T>
        where T : INumber<T>
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private ValueVector2<T> value;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Vector2() => value = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Vector2(ValueVector2<T> value) => this.value = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Vector2(IVector2<T> value) => this.value = new(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public Vector2((T X, T Y) tuple) => value = new(tuple);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(T x, T y) => value = new(x, y);
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
        public ValueVector2<T> Value { get { return value; } set { this.value = value; } }

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
        public static implicit operator ValueVector2<T>(Vector2<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator Vector2<T>(ValueVector2<T> value) => new(value);
        #endregion
    }
}