﻿// <copyright file="IMatrix4Rows.cs" company="Shkyrockett" >
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
    public interface IMatrix4Rows<T, TVector>
        : IMatrix3Rows<T, TVector>
        where T : INumber<T>
        where TVector : IVector<T>
    {
        /// <summary>
        /// 
        /// </summary>
        TVector RowW { get; set; }
    }
}
