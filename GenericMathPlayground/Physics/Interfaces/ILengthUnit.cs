// <copyright file="ILengthUnit.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

namespace GenericMathPlayground.Physics
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILengthUnit
    {
        /// <summary>
        /// 
        /// </summary>
        double Value { get; }

        /// <summary>
        /// 
        /// </summary>
        static abstract double InMeters {  get; }
    }
}
