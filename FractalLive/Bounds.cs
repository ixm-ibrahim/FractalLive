using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalLive
{
    public class IntBounds
    {
        public IntBounds()
        {
            Value = 0;
            Minimum = -1;
            Maximum = 1;
        }
        public IntBounds(int value, int minimum, int maximum)
        {
            Value = value;
            Minimum = minimum;
            Maximum = maximum;

            if (Maximum < Minimum)
                Maximum = Minimum;
        }

        public bool SetValue(int val)
        {
            Value = val;

            if (Value < Minimum)
            {
                Value = Minimum;
                return false;
            }
            if (Value > Maximum)
            {
                Value = Maximum;
                return false;
            }

            return true;
        }

        public int Value { get; set; }
        public int Maximum { get; set; }
        public int Minimum { get; set; }

        public static IntBounds operator +(IntBounds b, int val)
        {
            b.Value += val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
        public static IntBounds operator -(IntBounds b, int val)
        {
            b.Value -= val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
        public static IntBounds operator *(IntBounds b, int val)
        {
            b.Value *= val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
        public static IntBounds operator /(IntBounds b, int val)
        {
            b.Value /= val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
    }

    public class FloatBounds
    {
        public FloatBounds()
        {
            Value = 0;
            Minimum = -1;
            Maximum = 1;
        }
        public FloatBounds(float value, float minimum, float maximum)
        {
            Value = value;
            Minimum = minimum;
            Maximum = maximum;
        }

        public bool SetValue(float val)
        {
            Value = val;

            if (Value < Minimum)
            {
                Value = Minimum;
                return false;
            }
            if (Value > Maximum)
            {
                Value = Maximum;
                return false;
            }

            return true;
        }

        public float Value { get; set; }
        public float Maximum { get; set; }
        public float Minimum { get; set; }

        public static FloatBounds operator +(FloatBounds b, float val)
        {
            b.Value += val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
        public static FloatBounds operator -(FloatBounds b, float val)
        {
            b.Value -= val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
        public static FloatBounds operator *(FloatBounds b, float val)
        {
            b.Value *= val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
        public static FloatBounds operator /(FloatBounds b, float val)
        {
            b.Value /= val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
    }

    public class DoubleBounds
    {
        public DoubleBounds()
        {
            Value = 0;
            Minimum = -1;
            Maximum = 1;
        }
        public DoubleBounds(double value, double minimum, double maximum)
        {
            Value = value;
            Minimum = minimum;
            Maximum = maximum;
        }

        public bool SetValue(double val)
        {
            Value = val;

            if (Value < Minimum)
            {
                Value = Minimum;
                return false;
            }
            if (Value > Maximum)
            {
                Value = Maximum;
                return false;
            }

            return true;
        }

        public double Value { get; set; }
        public double Maximum { get; set; }
        public double Minimum { get; set; }

        public static DoubleBounds operator +(DoubleBounds b, double val)
        {
            b.Value += val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
        public static DoubleBounds operator -(DoubleBounds b, double val)
        {
            b.Value -= val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
        public static DoubleBounds operator *(DoubleBounds b, double val)
        {
            b.Value *= val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
        public static DoubleBounds operator /(DoubleBounds b, double val)
        {
            b.Value /= val;

            if (b.Value < b.Minimum)
                b.Value = b.Minimum;
            if (b.Value > b.Maximum)
                b.Value = b.Maximum;

            return b;
        }
    }
}
