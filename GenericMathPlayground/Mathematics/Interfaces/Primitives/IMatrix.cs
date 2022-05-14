// <copyright file="IMatrix.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Numerics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// The matrix.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMatrix<T>
    where T : INumber<T>
{
    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    T[,] Items { get; set; }

    /// <summary>
    /// Gets the rows.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    int Rows { get; }

    /// <summary>
    /// Gets the columns.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    int Columns { get; }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => Rows * Columns;

    /// <summary>
    /// Gets the determinant.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T Determinant { get; }
}
