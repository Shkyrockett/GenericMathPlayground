// <copyright file="VectorList.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Framework;
using GenericMathPlayground.Mathematics;
using GenericMathPlayground.Physics;
using System.Collections.Generic;
using System.ComponentModel;

namespace GenericMathPlayground
{
    /// <summary>
    /// 
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public struct VectorList
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public VectorList(params IVector<MetersUnit>[] items)
        {
            Items = new List<IVector<MetersUnit>>(items);
        }

        /// <summary>
        /// 
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        [TypeConverter(typeof(ExpandableCollectionConverter))]
        public List<IVector<MetersUnit>> Items { get; set; }
    }
}
