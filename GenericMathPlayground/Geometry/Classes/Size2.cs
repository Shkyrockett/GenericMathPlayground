// <copyright file="Size2.cs" company="Shkyrockett" >
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
    public class Size2<T>
        : IVector2<T>
        where T : INumber<T>
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private ValueSize2<T> value;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Size2() => value = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Size2(ValueSize2<T> value) => this.value = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Size2(IVector2<T> value) => this.value = new(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public Size2((T Width, T Height) tuple) => value = new(tuple);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Size2(T width, T height) => value = new(width, height);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        public void Deconstruct(out T Width, out T Height) => (Width, Height) = value;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ValueSize2<T> Value { get { return value; } set { this.value = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T Width { get { return value.Width; } set { this.value.Width = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T Height { get { return value.Height; } set { this.value.Height = value; } }

        /// <summary>
        /// 
        /// </summary>
        T IVector2<T>.X { get { return value.Width; } set { this.value.Width = value; } }

        /// <summary>
        /// 
        /// </summary>
        T IVector2<T>.Y { get { return value.Height; } set { this.value.Height = value; } }
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValueSize2<T>(Size2<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator Size2<T>(ValueSize2<T> value) => new(value);
        #endregion
    }
}