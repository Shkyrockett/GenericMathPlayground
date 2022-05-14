// <copyright file="IMultiplicativeIdentityMethod.cs" company="Shkyrockett" >
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
/// The multiplicative identity method.
/// </summary>
/// <typeparam name="TSelf"></typeparam>
/// <typeparam name="TResult"></typeparam>
[RequiresPreviewFeatures]
public interface IMultiplicativeIdentityMethod<TSelf, TResult>
    where TSelf : IMultiplicativeIdentityMethod<TSelf, TResult>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    static abstract TResult MultiplicativeIdentity(int size);
}
