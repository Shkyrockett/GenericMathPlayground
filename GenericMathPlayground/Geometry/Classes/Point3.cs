// <copyright file="Point3.cs" company="Shkyrockett" >
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
    public class Point3<T>
        : IPoint3<T>
        where T : INumber<T>
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private ValuePoint3<T> value;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Point3() => value = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Point3(ValuePoint3<T> value) => this.value = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Point3(IVector3<T> value) => this.value = new(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public Point3((T X, T Y, T Z) tuple) => value = new(tuple);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point3(T x, T y, T z) => value = new(x, y, z);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = value;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ValuePoint3<T> Value { get { return value; } set { this.value = value; } }

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
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValuePoint3<T>(Point3<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator Point3<T>(ValuePoint3<T> value) => new(value);
        #endregion
    }
}