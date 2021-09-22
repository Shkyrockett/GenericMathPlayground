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
using System;

namespace GenericMathPlayground.Mathematics
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
        public Vector2((T I, T J) tuple) => value = new(tuple);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public Vector2(T i, T j) => value = new(i, j);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="I"></param>
        /// <param name="J"></param>
        public void Deconstruct(out T I, out T J) => (I, J) = value;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ValueVector2<T> Value { get { return value; } set { this.value = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T I { get { return value.I; } set { this.value.I = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T J { get { return value.J; } set { this.value.J = value; } }

        /// <summary>
        /// 
        /// </summary>
        T IVector2<T>.X { get { return I; } set { I = value; } }

        /// <summary>
        /// 
        /// </summary>
        T IVector2<T>.Y { get { return J; } set { J = value; } }
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