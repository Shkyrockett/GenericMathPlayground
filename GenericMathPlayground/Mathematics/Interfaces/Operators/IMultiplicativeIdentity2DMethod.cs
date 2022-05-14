// <copyright file="IMultiplicativeIdentity2DMethod.cs" company="Shkyrockett" >
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
/// The multiplicative identity2 d method.
/// </summary>
/// <typeparam name="TSelf"></typeparam>
/// <typeparam name="TResult"></typeparam>
[RequiresPreviewFeatures]
public interface IMultiplicativeIdentity2DMethod<TSelf, TResult>
    where TSelf : IMultiplicativeIdentity2DMethod<TSelf, TResult>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    /// <returns></returns>
    static abstract TResult MultiplicativeIdentity(int horizontal, int vertical);
}
