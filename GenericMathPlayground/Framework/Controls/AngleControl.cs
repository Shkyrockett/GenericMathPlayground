// <copyright file="AngleControl.cs" company="Shkyrockett" >
//     Copyright © 2016 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks></remarks>

using GenericMathPlayground.Framework;
using GenericMathPlayground.Mathematics;
using GenericMathPlayground.Physics;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace GenericMathPlayground
{
    /// <summary>
    /// The angle control class.
    /// </summary>
    public partial class AngleControl
        : UserControl
    {
        /// <summary>
        /// The value changed delegate.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The value changed event arguments.</param>
        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

        /// <summary>
        /// The value changed event of the <see cref="ValueChangedEventHandler"/>.
        /// </summary>
        [Category("Value")]
        [Description("This event is raised if the value changes.")]
        public event ValueChangedEventHandler? ValueChanged;

        /// <summary>
        /// The method.
        /// </summary>
        private Angle method;

        /// <summary>
        /// Initializes a new instance of the <see cref="AngleControl"/> class.
        /// </summary>
        [Category("Value")]
        [DefaultValue(0)]
        [Bindable(true)]
        public AngleControl()
        {
            InitializeComponent();

            method = Physics.Angle.Degree;
            numericUpDown.Value = Operations.RadiansToDegrees<double, decimal>(Angle);
            numericUpDown.Maximum = 360;
            numericUpDown.Minimum = -360;
            numericUpDown.Increment = 15;
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        public double Angle
        {
            get => needleControl1.Angle;
            set => needleControl1.Angle = value;
        }

        /// <summary>
        /// Gets or sets the editor service.
        /// </summary>
        public IWindowsFormsEditorService? EditorService { get; set; }

        /// <summary>
        /// The tab control selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabControl = sender as TabControl;
            if (tabControl?.SelectedIndex == 0)
            {
                method = Physics.Angle.Degree;
            }
            else if (tabControl?.SelectedIndex == 1)
            {
                method = Physics.Angle.Radian;
            }

            switch (method)
            {
                case Physics.Angle.Degree:
                    numericUpDown.Increment = 15;
                    numericUpDown.Maximum = 360;
                    numericUpDown.Minimum = -360;
                    numericUpDown.Value = Angle.RadiansToDegrees<double, decimal>();
                    break;
                case Physics.Angle.Radian:
                    numericUpDown.Value = (decimal)Angle;
                    numericUpDown.Increment = (decimal)Operations.DegreesToRadians<double, double>(15d);
                    numericUpDown.Maximum = (decimal)Math.Tau;
                    numericUpDown.Minimum = -(decimal)Math.Tau;
                    break;
            }
        }

        /// <summary>
        /// The needle control1 value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The value changed event arguments.</param>
        private void NeedleControl1_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            switch (method)
            {
                case Physics.Angle.Degree:
                    numericUpDown.Value = (decimal)Angle.RadiansToDegrees<double, decimal>();
                    break;
                case Physics.Angle.Radian:
                    numericUpDown.Value = (decimal)Angle;
                    break;
            }

            ValueChanged?.Invoke(this, new ValueChangedEventArgs(e.Value));
        }

        /// <summary>
        /// The needle control1 value committed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The value changed event arguments.</param>
        private void NeedleControl1_ValueCommitted(object sender, ValueChangedEventArgs e) => EditorService?.CloseDropDown();

        /// <summary>
        /// The numeric up down value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var nums = sender as NumericUpDown;
            switch (method)
            {
                case Physics.Angle.Degree:
                    Angle = Operations.DegreesToRadians<decimal, double>(nums?.Value ?? (decimal)0d);
                    break;
                case Physics.Angle.Radian:
                    Angle = (double?)nums?.Value ?? 0d;
                    break;
            }

            needleControl1.Invalidate();
        }

        /// <summary>
        /// The numeric up down key down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The key event arguments.</param>
        private void NumericUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                EditorService?.CloseDropDown();
            }
        }

        /// <summary>
        /// The tab control draw item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The draw item event arguments.</param>
        private void TabControl_DrawItem(object sender, DrawItemEventArgs e) => needleControl1.Invalidate();

        /// <summary>
        /// The tab page degrees paint.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The paint event arguments.</param>
        private void TabPageDegrees_Paint(object sender, PaintEventArgs e) => needleControl1.Invalidate();

        /// <summary>
        /// The tab page radians paint.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The paint event arguments.</param>
        private void TabPageRadians_Paint(object sender, PaintEventArgs e) => needleControl1.Invalidate();
    }
}
