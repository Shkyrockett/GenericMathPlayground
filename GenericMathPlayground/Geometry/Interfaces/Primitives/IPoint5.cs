// <copyright file="IPoint5.cs" company="Shkyrockett" >
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
/// the point5.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPoint5<T>
    : IPoint<T>, IVector5<T>
    where T : INumber<T>
{
}
