// <copyright file="IVector4.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;

namespace GenericMathPlayground.Mathematics
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IVector4<T>
        : IVector3<T>
        where T : INumber<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T W { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <param name="W"></param>
        public void Deconstruct(out T X, out T Y, out T Z, out T W) => (X, Y, Z, W) = (this.X, this.Y, this.Z, this.W);
    }
}
