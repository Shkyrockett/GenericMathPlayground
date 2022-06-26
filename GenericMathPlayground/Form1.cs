// <copyright file="Form1.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
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
using System.Text;

namespace GenericMathPlayground;

/// <summary>
/// The form1.
/// </summary>
public partial class Form1
    : Form
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Form1"/> class.
    /// </summary>
    public Form1()
    {
        InitializeComponent();
        SetDoubleBuffered(this);

        var a = new ValuePoint2<MetersUnit>(1d, 0d);
        var b = new ValueVector2<MetersUnit>(0d, 1d);
        var c = new ValueSize2<MetersUnit>(2d, 2d);
        var d = (a + b) * c;

        var l = new ValueVectorList<MetersUnit>(a, b, c, d);

        var e = new MetersUnit(2d);
        var f = new FeetUnit(e);
        //UnitConversion.ConvertTo(e, out FeetUnit f);

        var m = ValueMatrix<double>.MultiplicativeIdentity(2, 2) + ValueMatrix<double>.MultiplicativeIdentity(2, 2).RotateClockwise() * 2d;
        var v = ValueVector<double>.MultiplicativeIdentity(2) * 2d;

        var r = m * v;

        var lines = new StringBuilder();
        lines.AppendLine($"({a} + {b}) * {c} = {d}");
        lines.AppendLine();
        lines.AppendLine($"{e} = {f}");
        lines.AppendLine();
        lines.AppendLine($"{m} * {v} = {r}");
        lines.AppendLine();

        textBox1.Text = lines.ToString();
        propertyGrid1.SelectedObject = l;
    }
}
