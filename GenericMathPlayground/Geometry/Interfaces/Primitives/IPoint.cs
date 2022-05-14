// <copyright file="IPoint.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Mathematics;
using System.Numerics;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// The point.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPoint<T>
    : IVector<T>
    where T : INumber<T>
{
}
