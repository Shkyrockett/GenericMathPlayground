// <copyright file="Form1.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Geometry;
using GenericMathPlayground.Mathematics;
using GenericMathPlayground.Physics;
using System.Globalization;
using System.Windows.Forms;

namespace GenericMathPlayground
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1
        : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            var a = new ValuePoint2<MetersUnit>(1d, 0d);
            var b = new ValueVector2<MetersUnit>(0d, 1d);
            var c = new ValueSize2<MetersUnit>(2d, 2d);
            var d = (a + b) * c;

            var l = new VectorList(a, b, c, d);

            var u = new MetersUnit(2);
            UnitConversion.ConvertTo(u, out FeetUnit v);

            textBox1.Text = $"({a} + {b}) * {c} = {d}\r\n\r\n{u.ToString("R", CultureInfo.InvariantCulture)} = {v.ToString("R", CultureInfo.InvariantCulture)}";
            propertyGrid1.SelectedObject = l;
        }
    }
}
