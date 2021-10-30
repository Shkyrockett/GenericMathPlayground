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
using System.Text;
using System.Windows.Forms;

namespace GenericMathPlayground;

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
        SetDoubleBuffered(this);

        var a = new ValuePoint2<MetersUnit>(1d, 0d);
        var b = new ValueVector2<MetersUnit>(0d, 1d);
        var c = new ValueSize2<MetersUnit>(2d, 2d);
        var d = (a + b) * c;

        var l = new ValueVectorList<MetersUnit>(a, b, c, d);

        var e = new MetersUnit(2);
        UnitConversion.ConvertTo(e, out FeetUnit f);

        var m = ValueMatrix<double>.MultiplicativeIdentity(2, 2) + ValueMatrix<double>.MultiplicativeIdentity(2, 2).RotateClockwise() * 2;
        var v = ValueVector<double>.MultiplicativeIdentity(2) * 2;

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
