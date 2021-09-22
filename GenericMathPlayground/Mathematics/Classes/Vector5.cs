// <copyright file="Vector5.cs" company="Shkyrockett" >
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
    public class Vector5<T>
        : IVector5<T>
        where T : INumber<T>
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private ValueVector5<T> value;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Vector5() => value = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Vector5(ValueVector5<T> value) => this.value = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Vector5(IVector5<T> value) => this.value = new(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public Vector5((T I, T J, T K, T L, T M) tuple) => value = new(tuple);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="m"></param>
        public Vector5(T i, T j, T k, T l, T m) => value = new(i, j, k, l, m);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="I"></param>
        /// <param name="J"></param>
        /// <param name="K"></param>
        /// <param name="L"></param>
        /// <param name="M"></param>
        public void Deconstruct(out T I, out T J, out T K, out T L, out T M) => (I, J, K, L, M) = value;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ValueVector5<T> Value { get { return value; } set { this.value = value; } }

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
        public T K { get { return value.K; } set { this.value.K = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T L { get { return value.L; } set { this.value.L = value; } }

        /// <summary>
        /// 
        /// </summary>
        public T M { get { return value.M; } set { this.value.M = value; } }

        /// <summary>
        /// 
        /// </summary>
        T IVector2<T>.X { get { return I; } set { I = value; } }

        /// <summary>
        /// 
        /// </summary>
        T IVector2<T>.Y { get { return J; } set { J = value; } }

        /// <summary>
        /// 
        /// </summary>
        T IVector3<T>.Z { get { return K; } set { K = value; } }

        /// <summary>
        /// 
        /// </summary>
        T IVector4<T>.W { get { return L; } set { L = value; } }

        /// <summary>
        /// 
        /// </summary>
        T IVector5<T>.V { get { return M; } set { M = value; } }
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValueVector5<T>(Vector5<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator Vector5<T>(ValueVector5<T> value) => new(value);
        #endregion
    }
}