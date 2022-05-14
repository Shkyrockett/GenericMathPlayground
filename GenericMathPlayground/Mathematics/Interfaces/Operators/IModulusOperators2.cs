// <copyright file="IModulusOperators2.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Runtime.Versioning;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// The modulus operators2.
/// </summary>
/// <typeparam name="TOther"></typeparam>
/// <typeparam name="TSelf"></typeparam>
/// <typeparam name="TResult"></typeparam>
[RequiresPreviewFeatures]
public interface IModulusOperators2<TOther, TSelf, TResult>
    where TSelf : IModulusOperators2<TOther, TSelf, TResult>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static abstract TResult operator %(TOther left, TSelf right);
}

