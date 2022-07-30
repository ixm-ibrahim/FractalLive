using System;
using System.Linq;
using System.Collections.Generic;
using OpenTK;

namespace FractalLive
{
	public struct Complex
	{
		public double R;
		public double I;

		public Complex(double real, double imaginary)
		{
			R = real;
			I = imaginary;
		}
		public static Complex NaN
		{
			get { return new Complex(Double.NaN, Double.NaN); }
		}

		public static Complex Zero
		{
			get { return new Complex(0, 0); }
		}

		public static Complex i
		{
			get { return new Complex(0, 1); }
		}

		public double Real
		{
			get { return R; }

			set { R = 1; }
		}

		public double Imaginary
		{
			get { return I; }

			set { I = 1; }
		}

		public double Radius
		{
			get { return Abs(new Complex(R, I)); }
		}

		public double RadiusSquared
		{
			get { return R * R + I * I; }
		}

		public double Angle
		{
			get { return Arg(new Complex(R, I)); }
		}

		public override string ToString()
		{
			return (System.String.Format("({0}, {1}i)", R, I));
		}

		public override bool Equals(object obj)
		{
			return this == (Complex)obj;
		}

		public override int GetHashCode()
		{
			return R.GetHashCode() ^ I.GetHashCode();
		}

		public static bool operator ==(Complex z, int d)
		{
			return z.R.Equals(d);
		}
		public static bool operator ==(int d, Complex z)
		{
			return z.R.Equals(d);
		}
		public static bool operator ==(Complex z, double d)
		{
			return z.R.Equals(d);
		}
		public static bool operator ==(double d, Complex z)
		{
			return z.R.Equals(d);
		}
		public static bool operator ==(Complex z, Complex d)
		{
			return z.R.Equals(d.R) && z.I.Equals(d.I);
		}

		public static bool operator !=(Complex z, int d)
		{
			return !z.R.Equals(d);
		}
		public static bool operator !=(int d, Complex z)
		{
			return !z.R.Equals(d);
		}
		public static bool operator !=(Complex z, double d)
		{
			return !z.R.Equals(d);
		}
		public static bool operator !=(double d, Complex z)
		{
			return !z.R.Equals(d);
		}
		public static bool operator !=(Complex z, Complex d)
		{
			return !(z == d);
		}

		public static Complex operator +(Complex z, int d)
		{
			return z + System.Convert.ToDouble(d);
		}
		public static Complex operator +(int d, Complex z)
		{
			return z + System.Convert.ToDouble(d);
		}
		public static Complex operator +(Complex z, double d)
		{
			return d + z;
		}
		public static Complex operator +(double d, Complex z)
		{
			return new Complex(z.R + d, z.I);
		}
		public static Complex operator +(Complex z, Complex d)
		{
			return new Complex(z.R + d.R, z.I + d.I);
		}

		public static Complex operator -(Complex z)
		{
			return z * -1;
		}
		public static Complex operator -(Complex z, int d)
		{
			return new Complex(z.R - d, z.I);
		}
		public static Complex operator -(int d, Complex z)
		{
			return new Complex(d - z.R, -z.I);
		}
		public static Complex operator -(Complex z, double d)
		{
			return new Complex(z.R - d, z.I);
		}
		public static Complex operator -(double d, Complex z)
		{
			return new Complex(d - z.R, -z.I);
		}
		public static Complex operator -(Complex z, Complex d)
		{
			return new Complex(z.R - d.R, z.I - d.I);
		}

		public static Complex operator *(Complex z, int d)
		{
			return z * System.Convert.ToDouble(d);
		}
		public static Complex operator *(int d, Complex z)
		{
			return z * System.Convert.ToDouble(d);
		}
		public static Complex operator *(Complex z, double d)
		{
			return new Complex(z.R * d, z.I * d);
		}
		public static Complex operator *(double d, Complex z)
		{
			return new Complex(z.R * d, z.I * d);
		}
		public static Complex operator *(Complex z, Complex d)
		{
			return new Complex(z.R * d.R - z.I * d.I, z.R * d.I + d.R * z.I);
		}

		public static Complex operator /(Complex z, int d)
		{
			return new Complex(z.R / d, z.I / d);
		}
		public static Complex operator /(int d, Complex z)
		{
			double x = z.R * z.R + z.I * z.I;

			return new Complex(d * z.R / x, -d * z.I / x);
		}
		public static Complex operator /(Complex z, double d)
		{
			return new Complex(z.R / d, z.I / d);
		}
		public static Complex operator /(double db, Complex z)
		{
			//Console.WriteLine("DOUBLE: " + db + " / " + z);
			/*
			// NAIVE

			double x = z.R * z.R + z.I * z.I;

			return new Complex(d * z.R / x, -d * z.I / x);
			*/
			// ROBUST DIVISION
			double a = db;
			double b = 0;
			double c = z.R;
			double d = z.I;

			double half = 0.5;
			double two = 2.0;

			double ab = Math.Max(Math.Abs(a), Math.Abs(b));
			double cd = Math.Max(Math.Abs(c), Math.Abs(d));

			double ov = double.MaxValue;
			double un = double.MinValue;
			double ϵ = double.Epsilon;

			double bs = two / (ϵ * ϵ);
			double s = 1.0;

			if (ab >= half * ov)
			{
				a = half * a;
				b = half * b;
				s = two * s;
			}
			if (cd >= half * ov)
			{
				c = half * c;
				d = half * d;
				s = s * half;
			}
			if (ab <= un * two / ϵ)
			{
				a = a * bs;
				b = b * bs;
				s = s / bs;
			}
			if (cd <= un * two / ϵ)
			{
				c = c * bs;
				d = d * bs;
				s = s * bs;
			}

			double p;
			double q;

			if (Math.Abs(d) <= Math.Abs(c))
				robust_cdiv1(a, b, c, d, out p, out q);
			else
			{
				robust_cdiv1(b, a, d, c, out p, out q);

				q = -q;
			}

			return new Complex(p * s, q * s);
		}
		public static Complex operator /(Complex x, Complex y)
		{
			//Console.WriteLine("COMPLEX: " + x + " / " + y);
			/*
			// NAIVE DIVISION
			double r = x.R * x.R + y.I * y.I;
			
			if (Double.IsInfinity(x.R))
				return Zero;
			if (r == 0)
				return new Complex(double.PositiveInfinity, 0);

			return new Complex((x.R * x.R + y.I * y.I) / r, (x.R * x.I - y.R * y.I) / r);
			*/

			/*
			// IMPROVED DIVISION
			double a = x.R;
			double b = x.I;
			double c = y.R;
			double d = y.I;

			double e;
			double f;

			if (Math.Abs(d) <= Math.Abs(c))
				improved_internal(a, b, c, d, out e, out f);
			else
			{
				improved_internal(b, a, d, c, out e, out f);

				f = -f;
			}

			return new Complex(e, f);
			*/

			// ROBUST DIVISION
			double a = x.R;
			double b = x.I;
			double c = y.R;
			double d = y.I;

			double half = 0.5;
			double two = 2.0;

			double ab = Math.Max(Math.Abs(a), Math.Abs(b));
			double cd = Math.Max(Math.Abs(c), Math.Abs(d));

			double ov = double.MaxValue;
			double un = double.MinValue;
			double ϵ = double.Epsilon;

			double bs = two / (ϵ * ϵ);
			double s = 1.0;

			if (ab >= half * ov)
			{
				a = half * a;
				b = half * b;
				s = two * s;
			}
			if (cd >= half * ov)
			{
				c = half * c;
				d = half * d;
				s = s * half;
			}
			if (ab <= un * two / ϵ)
			{
				a = a * bs;
				b = b * bs;
				s = s / bs;
			}
			if (cd <= un * two / ϵ)
			{
				c = c * bs;
				d = d * bs;
				s = s * bs;
			}

			double p;
			double q;

			if (Math.Abs(d) <= Math.Abs(c))
				robust_cdiv1(a, b, c, d, out p, out q);
			else
			{
				robust_cdiv1(b, a, d, c, out p, out q);

				q = -q;
			}

			return new Complex(p * s, q * s);
		}

		static void robust_cdiv1(double a, double b, double c, double d, out double p, out double q)
		{
			double r = d / c;
			double t = 1.0 / (c + d * r);

			p = robust_cdiv2(a, b, c, d, r, t);

			q = robust_cdiv2(b, -a, c, d, r, t);
		}

		static double robust_cdiv2(double a, double b, double c, double d, double r, double t)
		{
			if (r != 0)
			{
				double br = b * r;

				return br != 0 ? (a + br) * t : a * t + (b * t) * r;
			}

			return (a + d * (b / c)) * t;
		}

		static void improved_internal(double a, double b, double c, double d, out double e, out double f)
		{
			double r = d / c;
			double t = 1 / (c + d * r);

			if (r != 0)
			{
				e = (a + b * r) * t;
				f = (b - a * r) * t;
			}
			else
			{
				e = (a + d * (b / c)) * t;
				f = (b - d * (a / c)) * t;
			}
		}


		public static Complex operator ^(Complex z, int p)
		{
			Complex nz = z;

			if (p.Equals(0))
				return new Complex(1, 0);
			if (p.Equals(1))
				return z;
			if (p > 0)
			{
				for (int i = 0; i < p - 1; i++)
					nz = nz * z;

				return nz;
			}

			// p < 0
			for (int i = 0; i < -p - 1; i++)
				nz = nz * z;

			if (Complex.IsZero(nz))
				return Complex.Zero;

			return 1 / nz;
		}
		public static Complex operator ^(int d, Complex z)
		{
			double r = Math.Pow(d, z.R),
				   theta = z.I * Math.Log(d);

			return Double.IsNaN(theta) || Double.IsNaN(r) ? z : new Complex(r * Math.Cos(theta), r * Math.Sin(theta));
		}
		public static Complex operator ^(Complex z, double p)
		{
			if (p.Equals(0))
				return new Complex(1, 0);
			if (p.Equals(1))
				return z;
			if (p > 0 && p.Equals((int)p))
			{
				Complex nz = z;

				for (int i = 0; i < p - 1; i++)
					nz = nz * z;

				return nz;
			}
			if (p < 0 && p.Equals((int)p))
			{
				Complex nz = z;

				for (int i = 0; i < -p - 1; i++)
					nz = nz * z;

				if (Complex.IsZero(nz))
					return Complex.Zero;

				return 1 / nz;
			}

			double r = Math.Pow(Abs(z), p),
				   theta = Arg(z);

			return Double.IsNaN(theta) || Double.IsNaN(r) ? z : new Complex(r * Math.Cos(theta * p), r * Math.Sin(theta * p));
		}
		public static Complex operator ^(double d, Complex z)
		{
			double r = Math.Pow(d, z.R),
				   theta = z.I * Math.Log(d);

			return Double.IsNaN(theta) || Double.IsNaN(r) ? z : new Complex(r * Math.Cos(theta), r * Math.Sin(theta));
		}
		public static Complex operator ^(Complex z, Complex p)
		{
			return ((z.R * z.R + z.I * z.I) ^ (p / 2)) * Exp((new Complex(0, 1)) * p * Arg(z));
		}

		public Complex Pow(int d)
		{
			return this ^ d;
		}
		public Complex Pow(double d)
		{
			return this ^ d;
		}
		public Complex Pow(Complex c)
		{
			return this ^ c;
		}

		public static bool IsZero(Complex z)
		{
			return z.R.Equals(0) && z.I.Equals(0);
		}

		public static bool IsNaN(Complex z)
		{
			return Double.IsNaN(z.R) || Double.IsNaN(z.I);
		}

		public static bool IsInfinity(Complex z)
		{
			return Double.IsInfinity(z.R) || Double.IsInfinity(z.I);
		}

		public static bool IsPositiveInfinity(Complex z)
		{
			return Double.IsPositiveInfinity(z.R) || Double.IsPositiveInfinity(z.I);
		}

		public static bool IsNegativeInfinity(Complex z)
		{
			return Double.IsNegativeInfinity(z.R) || Double.IsNegativeInfinity(z.I);
		}

		public static Complex Inverse(Complex z)
		{
			double x = z.R * z.R + z.I * z.I;

			return new Complex(z.R / x, -z.I / x);
		}

		public static Complex Conjugate(Complex z)
		{
			return new Complex(z.R, -z.I);
		}

		public static int Sign(Complex z)
		{
			return z.R.Equals(0) ? Math.Sign(z.I) : Math.Sign(z.R);
		}

		public static double Magnitude(Complex z)
		{
			return z.Radius;
		}

		public static Complex Proj(Complex z)
		{
			if (!IsNaN(z) && !IsInfinity(z))
				return z;

			return new Complex(double.PositiveInfinity, 0);
		}

		public static double Arg(Complex z)
		{
			double arg = 0;

			/* 
 			 * 	Atan2 (four-quadrant arctangent):
	    	 * 		
	    	 * 		double atan = Math.Atan(z.I/z.R);
	    	 * 		
	    	 * 		if (z.R > 0)
	    	 * 			arg = atan;
	    	 * 		if (z.R < 0 && z.I >= 0)
	    	 * 			arg = atan + Math.PI;
	    	 * 		if (z.R < 0 && z.I < 0)
	    	 * 			arg = atan - Math.PI;
	    	 * 		if (z.R.Equals(0) && z.I > 0)
	    	 * 			arg = Math.PI / 2;
	    	 * 		if (z.R.Equals(0) && z.I < 0)
	    	 * 			arg = -Math.PI / 2;
	    	 * 		if (z == new Complex (0,0))
	    	 * 			arg = Double.NaN;
	    	 * 
	    	 */

			if (z.R.Equals(0))
			{
				if (z.I < 0 || z.I.Equals(-1))
					arg = -Math.PI / 2;
				else if (z.I.Equals(0))
					return Double.NaN;
				else if (z.I > 0 || z.I.Equals(1))
					arg = Math.PI / 2;
			}
			else if (z.I.Equals(0))
			{
				if (z.R.Equals(1))
					arg = 0;
				else if (z.R.Equals(-1))
					arg = Math.PI;
			}
			else if (z == new Complex(1, 1))
				arg = Math.PI / 4;
			else
				arg = Math.Atan2(z.I, z.R);

			return arg;
		}

		public static double Abs(Complex z)
		{
			/*
			if (Double.IsPositiveInfinity(z.R))
				z.R = 10e99;
			else if (Double.IsNegativeInfinity(z.R))
				z.R = -10e99;
			if (Double.IsPositiveInfinity(z.I))
				z.I = 10e99;
			else if (Double.IsNegativeInfinity(z.I))
				z.I = -10e99;
				*/
			return Math.Sqrt(z.R * z.R + z.I * z.I);
		}

		public static Complex Exp(Complex z)
		{
			double r = Math.Exp(z.R);

			if (z.R.Equals(0))
				return new Complex(Math.Cos(z.I), Math.Sin(z.I));
			if (z.I.Equals(0))
				return new Complex(r, 0);

			return IsNaN(z) ? z : new Complex(r * Math.Cos(z.I), r * Math.Sin(z.I));
		}

		public static Complex Ln(Complex z)
		{
			if (z.R.Equals(0))
				return new Complex(Math.Log(z.I), Math.PI / 2);
			if (z.I.Equals(0))
				return new Complex(Math.Log(z.R), 0);

			return new Complex(.5 * Math.Log(z.R * z.R + z.I * z.I), Math.Atan2(z.I, z.R));
		}

		public static Complex Log10(Complex z)
		{
			double ln10 = Math.Log(10);

			return new Complex(0.5 * Math.Log(z.R * z.R + z.I * z.I) / ln10, Arg(z) / ln10);
		}

		public static Complex Test(Complex z)
		{
			double x = (z.R + (.5 * Math.Sqrt(2) * Math.Sqrt(Abs((z * z + 1)) + (z * z + 1).R)));
			double y = (z.R + (.5 * Math.Sqrt(2) * Math.Sign((z * z + 1).I) * Math.Sqrt(Abs((z * z + 1)) - (z * z + 1).R)));

			x = .5 * Math.Log((z.R + (.5 * Math.Sqrt(2) * Math.Sqrt(Abs((z * z + 1)) + (z * z + 1).R))) * (z.R + (.5 * Math.Sqrt(2) * Math.Sqrt(Abs((z * z + 1)) + (z * z + 1).R))) + (z.R + (.5 * Math.Sqrt(2) * Math.Sign((z * z + 1).I) * Math.Sqrt(Abs((z * z + 1)) - (z * z + 1).R))) * (z.R + (.5 * Math.Sqrt(2) * Math.Sign((z * z + 1).I) * Math.Sqrt(Abs((z * z + 1)) - (z * z + 1).R))));
			y = Math.Atan2((z.R + (.5 * Math.Sqrt(2) * Math.Sign((z * z + 1).I) * Math.Sqrt(Abs((z * z + 1)) - (z * z + 1).R))), (z.R + (.5 * Math.Sqrt(2) * Math.Sqrt(Abs((z * z + 1)) + (z * z + 1).R))));




			return Complex.Zero;
		}

		public static Complex Log(double b, Complex a)
		{
			return Ln(a) / Math.Log(b);
		}
		public static Complex Log(Complex b, Complex a)
		{
			return Ln(a) / Ln(b);
		}

		public static Complex Sqrt(Complex z, bool switchSign = false)
		{
			if (IsNaN(z) || IsInfinity(z))
				return new Complex(double.PositiveInfinity, 0);

			double r = Abs(z);

			//return new Complex(.5 * Math.Sqrt(2 * (r + z.R)), .5 * Sign(new Complex(z.I, -r)) * Math.Sqrt(2 * (r - z.R)));
			//return .5 * Math.Sqrt(2) * new Complex(Math.Sqrt(r + z.R), Math.Sign(z.I) * Math.Sqrt(r - z.R));
			return (switchSign ? -1 : 1) * .5 * Math.Sqrt(2) * new Complex(Math.Sqrt(r + z.R), Math.Sign(z.I) * Math.Sqrt(r - z.R));
			//return .5 * Math.Sqrt(2) * new Complex(Math.Sqrt(r + z.R), Math.Sqrt(r - z.R));
			//return Math.Sqrt(r) * Exp(i * z.Angle / 2);
		}

		public static Complex Sin(Complex z)
		{
			if (z.R.Equals(0))
				return new Complex(0, Math.Sinh(z.I));
			if (z.I.Equals(0))
				return new Complex(Math.Sin(z.R), 0);

			return new Complex(Math.Sin(z.R % (2 * Math.PI)) * Math.Cosh(z.I), Math.Cos(z.R % (2 * Math.PI)) * Math.Sinh(z.I));
		}

		public static Complex Cos(Complex z)
		{
			if (z.R.Equals(0))
				return new Complex(Math.Cosh(z.I), 0);
			if (z.I.Equals(0))
				return new Complex(Math.Cos(z.R), 0);

			return new Complex(Math.Cos(z.R % (2 * Math.PI)) * Math.Cosh(z.I), -Math.Sin(z.R % (2 * Math.PI)) * Math.Sinh(z.I));
		}

		public static Complex Tan(Complex z)
		{
			if (z.R.Equals(0))
				return new Complex(0, Math.Tanh(z.I));
			if (z.I.Equals(0))
				return new Complex(Math.Tan(z.R % (2 * Math.PI)), 0);

			double cosr = Math.Cos(z.R % (2 * Math.PI));
			double sinhi = Math.Sinh(z.I % (2 * Math.PI));

			double denom = cosr * cosr + sinhi * sinhi;

			return new Complex(Math.Sin(z.R % (2 * Math.PI)) * cosr / denom, sinhi * Math.Cosh(z.I % (2 * Math.PI)) / denom);
		}

		public static Complex Sinh(Complex z)
		{
			if (z.R.Equals(0))
				return new Complex(0, Math.Sin(z.I % (2 * Math.PI)));
			if (z.I.Equals(0))
				return new Complex(Math.Sinh(z.R), 0);

			return new Complex(Math.Sinh(z.R) * Math.Cos(z.I % (2 * Math.PI)), Math.Cosh(z.R) * Math.Sin(z.I % (2 * Math.PI)));
		}

		public static Complex Cosh(Complex z)
		{
			if (z.R.Equals(0))
				return new Complex(Math.Cos(z.I % (2 * Math.PI)), 0);
			if (z.I.Equals(0))
				return new Complex(Math.Cosh(z.R), 0);

			return new Complex(Math.Cosh(z.R) * Math.Cos(z.I % (2 * Math.PI)), Math.Sinh(z.R) * Math.Sin(z.I % (2 * Math.PI)));
		}

		public static Complex Tanh(Complex z)
		{
			if (z.R.Equals(0))
				return new Complex(z.R, Math.Tan(z.I % (2 * Math.PI)));
			if (z.I.Equals(0))
				return new Complex(Math.Tanh(z.R), z.I);

			double sinhr = Math.Sinh(z.R);
			double cosi = Math.Cos(z.I % (2 * Math.PI));
			double denom = sinhr * sinhr + cosi * cosi;

			return Sinh(z) / Cosh(z);
		}

		public static Complex Asin(Complex z)
		{
			if (z.R.Equals(0))
				return new Complex(0, Math.Log(z.I + Math.Sqrt(z.I * z.I + 1)));
			if (z.I.Equals(0))
			{
				if (z.R >= -1 && z.R <= 1)
					return new Complex(Math.Asin(z.R), 0);

				return new Complex(Double.NaN, 0);
			}

			double ss = z.R * z.R + z.I * z.I + 1;
			double ssp2r = Math.Sqrt(ss + 2 * z.R);
			double ssm2r = Math.Sqrt(ss - 2 * z.R);
			double sum = .5 * (ssp2r + ssm2r);

			return new Complex(Math.Asin(.5 * (ssp2r - ssm2r)), Complex.Sign(new Complex(z.I, -z.R)) * Math.Log(sum + Math.Sqrt(sum * sum - 1)));
		}

		public static Complex Acos(Complex z)
		{
			//	    	if (z.R.Equals(0)) // Doesn't work
			//				return new Complex(Math.PI / 2, Math.Sign(z.I) * Math.Log(Math.Sqrt(z.I*z.I + 1) + Math.Sqrt(z.I*z.I)));
			if (z.I.Equals(0))
			{
				if (z.R >= -1 && z.R <= 1)
					return new Complex(Math.Acos(z.R), 0);

				return new Complex(Double.NaN, 0);
			}

			double ss = z.R * z.R + z.I * z.I + 1;
			double ssp2r = Math.Sqrt(ss + 2 * z.R);
			double ssm2r = Math.Sqrt(ss - 2 * z.R);
			double sum = .5 * (ssp2r + ssm2r);

			return new Complex(Math.Acos(ssp2r / 2 - ssm2r / 2), -Complex.Sign(new Complex(z.I, -z.R)) * Math.Log(sum + Math.Sqrt(sum * sum - 1)));
		}

		public static Complex Atan(Complex z)
		{
			if (z.I.Equals(0))
				return new Complex(Math.Atan(z.R), z.I);

			double opi = 1 + z.I;
			double omi = 1 - z.I;
			double rr = z.R * z.R;

			return new Complex(.5 * (Math.Atan2(z.R, omi) - Math.Atan2(-z.R, opi)), .25 * Math.Log((rr + opi * opi) / (rr + omi * omi)));
		}

		public static Complex Asinh(Complex z)
		{
			return Ln(z + Sqrt(z * z + 1));
		}

		public static Complex Acosh(Complex z)
		{
			return Ln(z + Sqrt(z * z - 1));
		}

		public static Complex Atanh(Complex z)
		{
			return .5 * Ln((1 + z) / (1 - z));
		}
	}

	public class BigDouble
	{
		double digits;
		int exponent;

		public BigDouble(double n)
		{
			var d = FromDouble(n);

			digits = d.Digits;
			exponent = d.exponent;
		}
		public BigDouble(double n, int e)
		{
			digits = n;
			exponent = e;

			Simplify();
		}


		public double Digits => digits;
		public int Exponent => exponent;


		public static BigDouble Zero => new BigDouble(0, 0);
		public static BigDouble One => new BigDouble(1, 0);
		public static BigDouble NaN => new BigDouble(double.NaN, 0);
		public static BigDouble PositiveInfinity => new BigDouble(double.PositiveInfinity, 0);
		public static BigDouble NegativeInfinity => new BigDouble(double.NegativeInfinity, 0);


		public override string ToString()
		{
			return (Exponent > 308) ? Digits + " x10^ " + Exponent : ToDouble().ToString();
		}
		public override bool Equals(object obj)
		{
			return this == (BigDouble)obj;
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}


		public int ToInt()
		{
			return (int)(digits * Math.Pow(10, exponent));
		}
		public double ToDouble()
		{
			return digits * Math.Pow(10, exponent);
		}
		public BigDouble FromInt(int n)
		{
			if (n == 0)
				return BigDouble.Zero;

			int e = GetExponent(n);

			return new BigDouble(n / Math.Pow(10, e), e);
		}
		public BigDouble FromDouble(double n)
		{
			if (n == 0)
				return BigDouble.Zero;
			if (n == Double.NaN)
				return BigDouble.NaN;
			if (n == Double.PositiveInfinity)
				return BigDouble.PositiveInfinity;
			if (n == Double.NegativeInfinity)
				return BigDouble.NegativeInfinity;

			int e = GetExponent(n);

			return new BigDouble(n / Math.Pow(10, e), e);
		}


		public static explicit operator float(BigDouble a)
		{
			return (float)a.ToDouble();
		}
		public static explicit operator double(BigDouble a)
		{
			return a.ToDouble();
		}


		public static bool operator ==(BigDouble a, double b)
		{
			return a.ToDouble() == b;
		}
		public static bool operator ==(double a, BigDouble b)
		{
			return b.ToDouble() == a;
		}
		public static bool operator ==(BigDouble a, BigDouble b)
		{
			return a.Digits == b.Digits && a.Exponent == b.Exponent;
		}

		public static bool operator !=(BigDouble a, double b)
		{
			return !(a == b);
		}
		public static bool operator !=(double a, BigDouble b)
		{
			return !(a == b);
		}
		public static bool operator !=(BigDouble a, BigDouble b)
		{
			return !(a == b);
		}

		public static bool operator <(BigDouble a, double b)
		{
			return a.ToDouble() < b;
		}
		public static bool operator <(double a, BigDouble b)
		{
			return a < b.ToDouble();
		}
		public static bool operator <(BigDouble a, BigDouble b)
		{
			return a.Exponent < b.Exponent || (a.Exponent == b.Exponent && a.Digits < b.Digits);
		}

		public static bool operator >(BigDouble a, double b)
		{
			return a.ToDouble() > b;
		}
		public static bool operator >(double a, BigDouble b)
		{
			return a > b.ToDouble();
		}
		public static bool operator >(BigDouble a, BigDouble b)
		{
			return a.Exponent > b.Exponent || (a.Exponent == b.Exponent && a.Digits > b.Digits);
		}


		public static BigDouble operator +(BigDouble a, double b)
		{
			return a + new BigDouble(b);
		}
		public static BigDouble operator +(double a, BigDouble b)
		{
			return b + new BigDouble(a);
		}
		public static BigDouble operator +(BigDouble a, BigDouble b)
		{
			double test = a.ToDouble() + b.ToDouble();

			if (!Double.IsNaN(test) && !Double.IsInfinity(test))
				return new BigDouble(test).Simplify();

			int diff = a.Exponent - b.Exponent;

			if (diff < -20)
				return b;
			if (diff > 20)
				return a;

			if (diff >= 0)
				return new BigDouble((a.digits * Math.Pow(10, diff)) + b.digits, b.exponent).Simplify();

			return new BigDouble(a.digits + (b.digits * Math.Pow(10, -diff)), a.exponent).Simplify();
		}

		public static BigDouble operator -(BigDouble a)
		{
			return new BigDouble(-a.Digits, a.Exponent);
		}
		public static BigDouble operator -(BigDouble a, double b)
		{
			return a + new BigDouble(-b);
		}
		public static BigDouble operator -(double a, BigDouble b)
		{
			return -b + new BigDouble(a);
		}
		public static BigDouble operator -(BigDouble a, BigDouble b)
		{
			return a + -b;
		}

		public static BigDouble operator *(BigDouble a, double b)
		{
			return new BigDouble(a.Digits * b, a.Exponent).Simplify();
		}
		public static BigDouble operator *(double a, BigDouble b)
		{
			return new BigDouble(a * b.Digits, b.Exponent).Simplify();
		}
		public static BigDouble operator *(BigDouble a, BigDouble b)
		{
			return new BigDouble(a.Digits * b.Digits, a.Exponent + b.Exponent).Simplify();
		}

		public static BigDouble operator /(BigDouble a, double b)
		{
			return new BigDouble(a.Digits / b, a.Exponent).Simplify();
		}
		public static BigDouble operator /(double a, BigDouble b)
		{
			return new BigDouble(a / b.Digits, -b.Exponent).Simplify();
		}
		public static BigDouble operator /(BigDouble a, BigDouble b)
		{
			return new BigDouble(a.Digits / b.Digits, a.Exponent - b.Exponent).Simplify();
		}

		public static BigDouble operator ^(BigDouble a, int b)
		{
			return new BigDouble(Math.Pow(a.Digits, b), a.Exponent * b).Simplify();
		}
		//@TODO: Fix potential overflow here, with the second pow method
		public static BigDouble operator ^(double a, BigDouble b)
		{
			return new BigDouble(Math.Pow(a, b.Digits) * Math.Pow(a, Math.Pow(10, b.Exponent))).Simplify();
		}
		//@TODO: Figure out how to take the power of a decimal (need to always have an integer exponent for standard scientific notation)
		/*
        public static BigDouble operator ^(BigDouble a, BigDouble b)
        {
            return (a ^ b.Digits) * (a ^ (int) Math.Pow(10, b.Exponent)).Simplify();
        }*/

		static int GetExponent(double n)
		{
			if (n == 0)
				return 0;
			else if (Math.Abs(n) < 1)
				return GetLeadingZeroNum(n);

			return GetDigitNum(n) - 1;
		}
		static int GetDigitNum(double n)
		{
			if (n == 0)
				return 1;

			return (int)Math.Floor(Math.Log10(Math.Abs(n)) + 1);
		}
		static int GetLeadingZeroNum(double n)
		{
			if (n == 0 || Math.Abs(n) > 1)
				return 0;

			int count = 0;

			while (Math.Abs(n) < 1)
			{
				n *= 10;
				count++;
			}

			return count;
		}
		public BigDouble Simplify()
		{
			if (Digits == 0)
				exponent = 0;
			else if (Math.Abs(Digits) < 1)
			{
				int n = GetLeadingZeroNum(Digits);

				digits *= Math.Pow(10, n);
				exponent -= n;
			}
			else
			{
				int n = GetDigitNum(Digits);

				if (n > 1)
				{
					digits /= Math.Pow(10, n - 1);
					exponent += n - 1;
				}
			}

			return this;
		}


		public static bool IsZero(BigDouble d)
		{
			return d.Digits == 0;
		}

		public static bool IsNaN(BigDouble d)
		{
			return Double.IsNaN(d.Digits);
		}

		public static bool IsInfinity(BigDouble d)
		{
			return IsPositiveInfinity(d) || IsNegativeInfinity(d);
		}

		public static bool IsPositiveInfinity(BigDouble d)
		{
			return Double.IsPositiveInfinity(d.Digits);
		}

		public static bool IsNegativeInfinity(BigDouble d)
		{
			return Double.IsNegativeInfinity(d.Digits);
		}


		public int Sign()
		{
			if (Digits > 0)
				return 1;
			else if (Digits < 0)
				return -1;

			return 0;
		}

		public static BigDouble Abs(BigDouble d)
		{
			return new BigDouble(Math.Abs(d.Digits), d.Exponent);
		}

		public static BigDouble Invert(BigDouble d)
		{
			return 1 / d;
		}

		public static BigDouble Sqrt(BigDouble d)
		{
			if (Math.Abs(d.Exponent) % 2 == 1)
				return new BigDouble(Math.Sqrt(d.Digits * 10), (d.Exponent - 1) / 2);

			return new BigDouble(Math.Sqrt(d.Digits), d.Exponent / 2);
		}
	}

	public struct BigComplex
	{
		public BigDouble R;
		public BigDouble I;

		public BigComplex(double real, double imaginary)
		{
			R = new BigDouble(real);
			I = new BigDouble(imaginary);
		}
		public BigComplex(BigDouble real, BigDouble imaginary)
		{
			R = real;
			I = imaginary;
		}
		public BigComplex(Complex z)
		{
			R = new BigDouble(z.R);
			I = new BigDouble(z.I);
		}


		public static BigComplex Zero
		{
			get { return new BigComplex(BigDouble.Zero, BigDouble.Zero); }
		}
		public static BigComplex One
		{
			get { return new BigComplex(BigDouble.One, BigDouble.Zero); }
		}
		public static BigComplex i
		{
			get { return new BigComplex(BigDouble.Zero, BigDouble.One); }
		}
		public static BigComplex NaN => new BigComplex(double.NaN, 0);
		public static BigComplex PositiveInfinity => new BigComplex(double.PositiveInfinity, 0);
		public static BigComplex NegativeInfinity => new BigComplex(double.NegativeInfinity, 0);


		public BigDouble Real
		{
			get { return R; }

			set { R = value; }
		}
		public BigDouble Imaginary
		{
			get { return I; }

			set { I = value; }
		}
		public BigDouble Radius
		{
			get { return BigDouble.Sqrt(R * R + I * I); }
		}
		public BigDouble RadiusSquared
		{
			get { return R * R + I * I; }
		}
		public double Angle
		{
			get { return Arg(new BigComplex(R, I)); }
		}


		public Complex ToComplex()
		{
			return new Complex(R.ToDouble(), I.ToDouble());
		}


		public override string ToString()
		{
			return String.Format("({0}, {1}i)", R, I);
		}
		public override bool Equals(object obj)
		{
			return this == (BigComplex)obj;
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}


		public static bool operator ==(BigComplex z, double d)
		{
			return z.R == d && z.I == BigDouble.Zero;
		}
		public static bool operator ==(double d, BigComplex z)
		{
			return z.R == d && z.I == BigDouble.Zero;
		}
		public static bool operator ==(BigComplex z, BigComplex d)
		{
			return z.R == d.R && z.I == d.I;
		}

		public static bool operator !=(BigComplex z, double d)
		{
			return !(z.R == d);
		}
		public static bool operator !=(double d, BigComplex z)
		{
			return !(z.R == d);
		}
		public static bool operator !=(BigComplex z, BigComplex d)
		{
			return !(z == d);
		}

		public static BigComplex operator +(BigComplex z, double d)
		{
			return new BigComplex(z.R + d, z.I);
		}
		public static BigComplex operator +(double d, BigComplex z)
		{
			return new BigComplex(z.R + d, z.I);
		}
		public static BigComplex operator +(BigComplex z, BigDouble d)
		{
			return new BigComplex(z.R + d, z.I);
		}
		public static BigComplex operator +(BigDouble d, BigComplex z)
		{
			return new BigComplex(z.R + d, z.I);
		}
		public static BigComplex operator +(BigComplex z, BigComplex d)
		{
			return new BigComplex(z.R + d.R, z.I + d.I);
		}

		public static BigComplex operator -(BigComplex z)
		{
			return new BigComplex(-z.R, -z.I);
		}
		public static BigComplex operator -(BigComplex z, double d)
		{
			return new BigComplex(z.R - d, z.I);
		}
		public static BigComplex operator -(double d, BigComplex z)
		{
			return new BigComplex(d - z.R, -z.I);
		}
		public static BigComplex operator -(BigComplex z, BigDouble d)
		{
			return new BigComplex(z.R - d, z.I);
		}
		public static BigComplex operator -(BigDouble d, BigComplex z)
		{
			return new BigComplex(d - z.R, -z.I);
		}
		public static BigComplex operator -(BigComplex z, BigComplex d)
		{
			return new BigComplex(z.R - d.R, z.I - d.I);
		}

		public static BigComplex operator *(BigComplex z, double d)
		{
			return new BigComplex(z.R * d, z.I * d);
		}
		public static BigComplex operator *(double d, BigComplex z)
		{
			return z * d;
		}
		public static BigComplex operator *(BigComplex z, BigDouble d)
		{
			return new BigComplex(z.R * d, z.I * d);
		}
		public static BigComplex operator *(BigDouble d, BigComplex z)
		{
			return z * d;
		}
		public static BigComplex operator *(BigComplex z, BigComplex d)
		{
			return new BigComplex((z.R * d.R) - (z.I * d.I), (z.R * d.I) + (d.R * z.I));
		}

		public static BigComplex operator /(BigComplex z, double d)
		{
			if (d == 0)
				return PositiveInfinity;
			if (d == Double.PositiveInfinity)
				return Zero;

			return new BigComplex(z.R / d, z.I / d);
		}
		public static BigComplex operator /(double d, BigComplex z)
		{
			if (z == Zero)
				return PositiveInfinity;
			if (z == PositiveInfinity)
				return Zero;

			if (z.I == 0)
				return new BigComplex(d / z.R, BigDouble.Zero);

			BigDouble x = (z.R * z.R) + (z.I * z.I);

			return new BigComplex(d * z.R / x, -d * z.I / x);
		}
		public static BigComplex operator /(BigComplex z, BigDouble d)
		{
			return new BigComplex(z.R / d, z.I / d);
		}
		public static BigComplex operator /(BigDouble d, BigComplex z)
		{
			if (z == Zero)
				return PositiveInfinity;
			if (z == PositiveInfinity)
				return Zero;

			BigDouble x = z.R * z.R + z.I * z.I;

			return new BigComplex(d * z.R / x, -d * z.I / x);
		}
		public static BigComplex operator /(BigComplex z, BigComplex d)
		{
			if (d == Zero)
				return PositiveInfinity;
			if (d == PositiveInfinity)
				return Zero;

			BigDouble r = d.R * d.R + d.I * d.I;

			if (r == 0)
				return Zero;

			return new BigComplex(((z.R * d.R) + (z.I * d.I)) / r, ((d.R * z.I) - (z.R * d.I)) / r);
		}

		public static BigComplex operator ^(BigComplex z, int p)
		{
			BigComplex nz = z;

			if (p.Equals(0))
				return One;
			if (p.Equals(1))
				return z;
			if (p > 0)
			{
				for (int i = 0; i < p - 1; i++)
					nz = nz * z;

				return nz;
			}

			// p < 0
			for (int i = 0; i < -p - 1; i++)
				nz = nz * z;

			if (IsZero(nz))
				return Zero;

			return 1 / nz;
		}


		public static bool IsZero(BigComplex z)
		{
			return z.R == 0 && z.I == 0;
		}
		public static bool IsNaN(BigComplex z)
		{
			return BigDouble.IsNaN(z.R) || BigDouble.IsNaN(z.I);
		}
		public static bool IsInfinity(BigComplex z)
		{
			return BigDouble.IsInfinity(z.R) || BigDouble.IsInfinity(z.I);
		}
		public static bool IsPositiveInfinity(BigComplex z)
		{
			return BigDouble.IsPositiveInfinity(z.R) || BigDouble.IsPositiveInfinity(z.I);
		}
		public static bool IsNegativeInfinity(BigComplex z)
		{
			return BigDouble.IsNegativeInfinity(z.R) || BigDouble.IsNegativeInfinity(z.I);
		}


		public BigComplex Pow(int d)
		{
			return this ^ d;
		}

		public static BigComplex Inverse(BigComplex z)
		{
			return 1 / z;
		}

		public static BigComplex Normalize(BigComplex z)
		{
			return z / z.Radius;
		}

		public static BigComplex Conjugate(BigComplex z)
		{
			return new BigComplex(z.R, -z.I);
		}

		public static int Sign(BigComplex z)
		{
			return z.R == 0 ? z.I.Sign() : z.R.Sign();
		}

		public static BigDouble Magnitude(BigComplex z)
		{
			return z.Radius;
		}

		public static double Arg(BigComplex bz)
		{
			double arg = 0;

			var z = Normalize(bz).ToComplex();

			/* 
 			 * 	Atan2 (four-quadrant arctangent):
	    	 * 		
	    	 * 		double atan = Math.Atan(z.I/z.R);
	    	 * 		
	    	 * 		if (z.R > 0)
	    	 * 			arg = atan;
	    	 * 		if (z.R < 0 && z.I >= 0)
	    	 * 			arg = atan + Math.PI;
	    	 * 		if (z.R < 0 && z.I < 0)
	    	 * 			arg = atan - Math.PI;
	    	 * 		if (z.R.Equals(0) && z.I > 0)
	    	 * 			arg = Math.PI / 2;
	    	 * 		if (z.R.Equals(0) && z.I < 0)
	    	 * 			arg = -Math.PI / 2;
	    	 * 		if (z == new Complex (0,0))
	    	 * 			arg = Double.NaN;
	    	 * 
	    	 */

			if (z.R.Equals(0))
			{
				if (z.I < 0 || z.I.Equals(-1))
					arg = -Math.PI / 2;
				else if (z.I.Equals(0))
					return Double.NaN;
				else if (z.I > 0 || z.I.Equals(1))
					arg = Math.PI / 2;
			}
			else if (z.I.Equals(0))
			{
				if (z.R.Equals(1))
					arg = 0;
				else if (z.R.Equals(-1))
					arg = Math.PI;
			}
			else if (z == new Complex(1, 1))
				arg = Math.PI / 4;
			else
				arg = Math.Atan2(z.I, z.R);

			return arg;
		}

		public static BigComplex Sqrt(BigComplex c)
		{
			if (IsNaN(c) || IsInfinity(c))
				return new BigComplex(double.PositiveInfinity, 0);

			if (c.I == 0)
				return new BigComplex(BigDouble.Sqrt(c.R), BigDouble.Zero);

			BigDouble r = c.Radius;
			double test = c.ToComplex().Radius - c.R.ToDouble();

			if (test == 0)
				return new BigComplex(Complex.Sqrt(c.ToComplex()));

			return .5 * Math.Sqrt(2) * new BigComplex(BigDouble.Sqrt(r + c.R), c.I.Sign() * BigDouble.Sqrt(r - c.R));


			//return .5 * Math.Sqrt(2) * new BigComplex(BigDouble.Sqrt(r + c.R), (test == 0) ? BigDouble.Zero : c.I.Sign() * BigDouble.Sqrt(r - c.R));
		}

		public static BigComplex Proj(BigComplex z)
		{
			if (!IsNaN(z) && !IsInfinity(z))
				return z;

			return PositiveInfinity;
		}
	}
}