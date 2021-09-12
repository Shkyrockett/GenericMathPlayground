// <copyright file="Size3.cs" company="Shkyrockett" >
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
    public class Size3<T>
        : ISize3<T>
        where T : INumber<T>
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private ValueSize3<T> value;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Size3() => value = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Size3(ValueSize3<T> value) => this.value = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Size3(IVector3<T> value) => this.value = new(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public Size3((T Width, T Height, T Depth) tuple) => value = new(tuple);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        public Size3(T width, T height, T depth) => value = new(width, height, depth);
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
        public ValueSize3<T> Value { get { return value; } set { this.value = value; } }

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
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValueSize3<T>(Size3<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator Size3<T>(ValueSize3<T> value) => new(value);
        #endregion
    }
}