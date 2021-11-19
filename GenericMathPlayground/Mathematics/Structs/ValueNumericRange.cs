// <copyright file="NumericRange.cs" company="Shkyrockett" >
//     Copyright © 2016 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks></remarks>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics
{
    /// <summary>
    /// Numeric range class.
    /// </summary>
    /// <seealso cref="IEnumerable{T}" />
    /// <seealso cref="IEquatable{T}" />
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public struct NumericRange<T>
        : IEnumerable<T>, IEquatable<NumericRange<T>>
        where T : INumber<T>
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public NumericRange()
            : this(T.Zero, T.One, T.Zero, T.One, T.Create(1 / 10), Overflow.Clamp)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericRange{T}" /> struct;
        /// </summary>
        /// <param name="min">Minimum value of the <see cref="NumericRange{T}" />.</param>
        /// <param name="max">Maximum value of the <see cref="NumericRange{T}" />.</param>
        /// <param name="unitMin">Minimum value of a periodic unit that wraps back to the maximum value.</param>
        /// <param name="unitMax">Maximum value of a periodic unit that wraps back to the minimum value.</param>
        /// <param name="step">Amount to advance for each iteration</param>
        /// <param name="overflow">Overflow rules.</param>
        public NumericRange(T min, T max, T unitMin, T unitMax, T step, Overflow overflow = Overflow.Clamp)
        {
            Min = min;
            Max = max;
            UnitMin = unitMin;
            UnitMax = unitMax;
            Step = step;
            Overflow = overflow;
        }
        #endregion

        #region Indexers
        /// <summary>
        /// Provides access to the enumeration of the linear interpolation from the <see cref="Min" /> value to the <see cref="Max" /> value.
        /// </summary>
        /// <value>
        /// The indexed value.
        /// </value>
        /// <param name="index">The position between the min and max to interpolate.</param>
        /// <returns>
        /// The linear interpolation of a value between the <see cref="Min" /> and <see cref="Max" /> values.
        /// </returns>
        public T this[T index] => Overflow switch
        {
            Overflow.Clamp => Interpolators.Linear(Operations.Clamp(index, UnitMin, UnitMax), Min, Max),
            Overflow.Wrap => Interpolators.Linear(Operations.Wrap(index, UnitMin, UnitMax), Min, Max),
            _ => Interpolators.Linear(index, Min, Max),
        };
        #endregion

        #region Properties
        /// <summary>
        /// Gets the minimum value of the <see cref="NumericRange{T}" />.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        [DataMember, XmlAttribute, SoapAttribute]
        public T Min { get; }

        /// <summary>
        /// Gets the maximum value of the <see cref="NumericRange{T}" />.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        [DataMember, XmlAttribute, SoapAttribute]
        public T Max { get; }

        /// <summary>
        /// Gets the minimum value of a periodic unit that wraps back to the <see cref="UnitMax" /> value.
        /// </summary>
        /// <value>
        /// The unit minimum.
        /// </value>
        [DataMember, XmlAttribute, SoapAttribute]
        public T UnitMin { get; }

        /// <summary>
        /// Gets the Maximum value of a periodic unit that wraps back to the <see cref="UnitMin" /> value.
        /// </summary>
        /// <value>
        /// The unit maximum.
        /// </value>
        [DataMember, XmlAttribute, SoapAttribute]
        public T UnitMax { get; }

        /// <summary>
        /// Gets the amount to advance for each iteration.
        /// </summary>
        /// <value>
        /// The step.
        /// </value>
        [DataMember, XmlAttribute, SoapAttribute]
        public T Step { get; }

        /// <summary>
        /// Gets a value indicating whether to wrap the return value or clamp it between max and min.
        /// </summary>
        /// <value>
        /// The overflow.
        /// </value>
        [DataMember, XmlAttribute, SoapAttribute]
        public Overflow Overflow { get; }
        #endregion

        #region Operators
        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(NumericRange<T> left, NumericRange<T> right) => left.Equals(right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(NumericRange<T> left, NumericRange<T> right) => !(left == right);
        #endregion

        #region Factories
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericRange{T}" /> struct for iteration of a range from 0 to 1.
        /// </summary>
        /// <param name="count">The number of steps to have between 0 and 1.</param>
        /// <returns>
        /// A new <see cref="NumericRange{T}" /> struct set up for 0 to 1 iteration.
        /// </returns>
        public static NumericRange<T> IteratorRange(T count) => new(T.Zero, T.One, T.Zero, T.One, T.One / count, Overflow.Clamp);

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericRange{T}" /> struct for iteration from the start for a designated length.
        /// </summary>
        /// <param name="start">The start value of the <see cref="NumericRange{T}" />.</param>
        /// <param name="length">The length of the <see cref="NumericRange{T}" />.</param>
        /// <param name="count">The number of steps to have between the start and end.</param>
        /// <returns>
        /// A new <see cref="NumericRange{T}" /> struct set up for iteration from the start for a designated length.
        /// </returns>
        public static NumericRange<T> StartLengthCountRange(T start, T length, int count) => new(start, start + length, start, start + length, length / T.Create(count), Overflow.Clamp);

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericRange{T}" /> struct for iteration in Radians.
        /// </summary>
        /// <param name="start">The start angle in radians.</param>
        /// <param name="end">The end angle in radians.</param>
        /// <param name="count">The number of steps to have between the start and end.</param>
        /// <returns>
        /// A new <see cref="NumericRange{T}" /> struct set up for iterating radians.
        /// </returns>
        public static NumericRange<R> RadiansRange<R>(R start, R end, int count) where R : IFloatingPoint<R> => new(start, end, -R.Pi, R.Pi, (end - start) / R.Create(count), Overflow.Wrap);

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericRange{T}" /> struct for iteration in Degrees.
        /// </summary>
        /// <param name="start">The start angle in degrees.</param>
        /// <param name="end">The end angle in degrees.</param>
        /// <returns>
        /// A new <see cref="NumericRange{T}" /> struct set up for iterating degrees.
        /// </returns>
        public static NumericRange<R> DegreesRange<R>(R start, R end) where R : IFloatingPoint<R> => new(start, end, R.Zero, R.Create(360), R.One, Overflow.Wrap);
        #endregion

        #region Standard Methods
        /// <summary>
        /// Enumerate all values at the <see cref="Step" /> interval between the <see cref="Max" /> and <see cref="Min" /> values.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var i = Min; i < Max; i += Step)
            {
                yield return this[i];
            }
        }

        /// <summary>
        /// Enumerate all values at the <see cref="Step" /> interval between the <see cref="Max" /> and <see cref="Min" /> values.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (var i = Min; i < Max; i += Step)
            {
                yield return this[i];
            }
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => HashCode.Combine(Min, Max, UnitMin, UnitMax, Step, Overflow);

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <see langword="true" /> if the specified <see cref="object" /> is equal to this instance; otherwise, <see langword="false" />.
        /// </returns>
        public override bool Equals(object? obj) => obj is NumericRange<T> d && Equals(d);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals([AllowNull] NumericRange<T> other) => Min == other.Min && Max == other.Max && UnitMin == other.UnitMin && UnitMax == other.UnitMax && Step == other.Step && Overflow == other.Overflow;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string? GetDebuggerDisplay() => ToString();
        #endregion
    }
}
