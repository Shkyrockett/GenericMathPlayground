// <copyright file="ILengthUnit.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Diagnostics.CodeAnalysis;

namespace GenericMathPlayground.Physics;

/// <summary>
/// The length unit.
/// </summary>
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)]
public interface ILengthUnit
{
    /// <summary>
    /// Gets the value.
    /// </summary>
    double Value { get; }

    /// <summary>
    /// Gets the conversion unit in meters.
    /// </summary>
    /// <remarks>
    /// A dumb hack to gain access to the <see cref="UnitOfMeters"/> static property. 
    /// This must be overridden in the struct with 1d / UnitOfMeters. 
    /// Sadly default interface methods do not work for properties.
    /// </remarks>
    abstract double UnitInMeters { get; }

    /// <summary>
    /// Gets the conversion of unit in meters.
    /// </summary>
    static abstract double UnitOfMeters { get; }
}
