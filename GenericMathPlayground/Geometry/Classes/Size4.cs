// <copyright file="Size4.cs" company="Shkyrockett" >
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
    public class Size4<T>
        : ISize4<T>
        where T : INumber<T>
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private ValueSize4<T> value;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Size4() => value = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Size4(ValueSize4<T> value) => this.value = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Size4(IVector4<T> value) => this.value = new(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public Size4((T Width, T Height, T Depth, T Breadth) tuple) => value = new(tuple);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="breadth"></param>
        public Size4(T width, T height, T depth, T breadth) => value = new(width, height, depth, breadth);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        /// <param name="Breadth"></param>
        public void Deconstruct(out T Width, out T Height, out T Depth, out T Breadth) => (Width, Height, Depth, Breadth) = value;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ValueSize4<T> Value { get { return value; } set { this.value = value; } }

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
        public T Depth { get { return value.Depth; } set { this.value.Depth = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T Breadth { get { return value.Breadth; } set { this.value.Breadth = value; } }
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValueSize4<T>(Size4<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator Size4<T>(ValueSize4<T> value) => new(value);
        #endregion
    }
}