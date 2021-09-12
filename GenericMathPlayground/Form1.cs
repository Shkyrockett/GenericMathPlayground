using GenericMathPlayground.Geometry;
using GenericMathPlayground.Mathematics;
using GenericMathPlayground.Physics;
using System.Windows.Forms;

namespace GenericMathPlayground
{
    public partial class Form1
        : Form
    {
        public Form1()
        {
            InitializeComponent();

            var a = new ValuePoint2<FeetUnit>(1d, 0d);
            var b = new ValueVector2<FeetUnit>(0d, 1d);
            var c = new ValueSize2<FeetUnit>(2d, 2d);
            var d = (a + b) * c;
            label1.Text = $"({a} + {b}) * {c} = {d}";
        }
    }
}
