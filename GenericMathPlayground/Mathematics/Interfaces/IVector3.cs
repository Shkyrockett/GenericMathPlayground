// <copyright file="IVector3.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

namespace GenericMathPlayground.Mathematics
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IVector3<T>
        : IVector2<T>
        where T : INumber<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Z { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = (this.X, this.Y, this.Z);
    }
}
