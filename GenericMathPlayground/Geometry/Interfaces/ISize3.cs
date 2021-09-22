// <copyright file="ISize3.cs" company="Shkyrockett" >
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
    public interface ISize3<T>
        : ISize2<T>, IVector3<T>
        where T : INumber<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Depth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        T IVector3<T>.Z { get { return Depth; } set { Depth = value; } }
    }
}