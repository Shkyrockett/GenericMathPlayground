﻿// <copyright file="ExpandableCollectionPropertyDescriptor.cs" company="Shkyrockett" >
//     Copyright © 2005 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks></remarks>

using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace GenericMathPlayground.Framework;

/// <summary>
/// The expandable collection property descriptor class.
/// </summary>
/// <acknowledgment>
/// http://stackoverflow.com/questions/32582504/propertygrid-expandable-collection
/// </acknowledgment>
public class ExpandableCollectionPropertyDescriptor
    : PropertyDescriptor
{
    #region Fields
    /// <summary>
    /// The collection.
    /// </summary>
    private readonly IList? collection;

    /// <summary>
    /// The index (readonly). Value: -1.
    /// </summary>
    private readonly int index = -1;
    #endregion Fields

    #region Events
    /// <summary>
    /// The refresh required event of the <see cref="EventHandler"/>.
    /// </summary>
    internal event EventHandler? RefreshRequired;
    #endregion Events

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpandableCollectionPropertyDescriptor"/> class.
    /// </summary>
    /// <param name="collection">The coll.</param>
    /// <param name="idx">The idx.</param>
    public ExpandableCollectionPropertyDescriptor(IList? collection, int idx)
        : base(GetDisplayName(collection, idx), null)
    {
        this.collection = collection;
        index = idx;
    }
    #endregion Constructors

    #region Properties
    /// <summary>
    /// Gets the name.
    /// </summary>
    public override string Name => index.ToString(CultureInfo.InvariantCulture);

    /// <summary>
    /// Gets a value indicating whether 
    /// </summary>
    public override bool IsReadOnly => false;

    /// <summary>
    /// Gets a value indicating whether 
    /// </summary>
    public override bool SupportsChangeEvents => true;

    /// <summary>
    /// Gets the component type.
    /// </summary>
    public override Type ComponentType => collection?.GetType() ?? typeof(object);

    /// <summary>
    /// Gets the property type.
    /// </summary>
    public override Type PropertyType => collection?[index]?.GetType() ?? typeof(object);

    ///// <summary>
    ///// 
    ///// </summary>
    //public override AttributeCollection Attributes => new AttributeCollection(null);
    #endregion Properties

    #region Methods
    /// <summary>
    /// The can reset value.
    /// </summary>
    /// <param name="component">The component.</param>
    /// <returns>The <see cref="bool"/>.</returns>
    public override bool CanResetValue(object component) => true;

    /// <summary>
    /// Reset the value.
    /// </summary>
    /// <param name="component">The component.</param>
    public override void ResetValue(object component)
    { }

    /// <summary>
    /// Get the value.
    /// </summary>
    /// <param name="component">The component.</param>
    /// <returns>The <see cref="object"/>.</returns>
    public override object? GetValue(object? component)
    {
        OnRefreshRequired();
        return collection?[index];
    }

    /// <summary>
    /// Set the value.
    /// </summary>
    /// <param name="component">The component.</param>
    /// <param name="value">The value.</param>
    public override void SetValue(object? component, object? value)
    {
        if (collection is not null)
        {
            collection[index] = value;
        }
    }

    /// <summary>
    /// The should serialize value.
    /// </summary>
    /// <param name="component">The component.</param>
    /// <returns>The <see cref="bool"/>.</returns>
    public override bool ShouldSerializeValue(object? component) => true;

    /// <summary>
    /// Get the display name.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="index">The index.</param>
    /// <returns>The <see cref="string"/>.</returns>
    private static string GetDisplayName(IList? list, int index)
    {
        var n = list?.Count ?? 0;
        var digits = n == 0 ? 1 : (int)Math.Floor(Math.Log10(Math.Abs(n)) + 1);
        return $"[{index.ToString(CultureInfo.InvariantCulture).PadLeft(digits, '0')}]";
        //return $"{CSharpName(list[index].GetType())} [{index,4}]";
    }

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="type"></param>
    ///// <returns></returns>
    //private static string CSharpName(Type type)
    //{
    //    var name = type.Name;
    //    if (!type.IsGenericType)
    //        return name;
    //    return $"{name.Substring(0, name.IndexOf('`'))}<{string.Join(", ", type.GetGenericArguments().Select(CSharpName))}>";
    //}

    /// <summary>
    /// Raises the refresh required event.
    /// </summary>
    protected virtual void OnRefreshRequired() => RefreshRequired?.Invoke(this, EventArgs.Empty);
    #endregion Methods
}
