using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalLive
{
    class Fractal
    {
        #region Enumerations
        public enum Type
        {
            Custom = -1, Mandelbrot = 0, Julia = 1, Julia_Mating = 2
        }

        public enum Formula
        {
            Custom = -1, Classic = 0, Lambda = 1
        }

        public enum Buddhabrot
        {
            Normal, Inverse, Nebulabrot
        }

        public enum Coloring
        {
            Custom, Black, White, Classic, Smooth, Domain_A, Domain_B, Domain_C, Domain_D, Domain_E, Domain_F, Domain_G, COUNT
        }

        public enum EditingOrbitTrap
        {
            Both, Interior, Exterior
        }
        
        public enum OrbitTrap
        {
            Custom = -1, Circle = 0, Square = 1, Real = 2, Imaginary = 3, Rectangle = 4, Points = 5, Lines = 6, COUNT
        }

        public enum Projection
        {
            Normal, Inverse, Riemann_Sphere
        }

        #endregion

        #region Structures
        public struct Settings
        {
            public Settings(Type type = Type.Mandelbrot, Formula formula = Formula.Classic)
            {
                Type = type;
                Formula = formula;
                buddhabrot = Buddhabrot.Normal;
                ExteriorColoring = Coloring.White;
                InteriorColoring = Coloring.Black;
                Projection = Projection.Normal;
                IsBuddhabrot = false;
                IsConjugate = false;
                IsJulia = false;
                IsJuliaCentered = false;
                UseDistance = false;
                UseLighting = false;
                UseTerrainColor = false;
                InitialDisplayRadius = new FloatBounds(2, .01f, 100);
                C_Power = 1;
                FoldAngle = new FloatBounds(0, (float)-maxVal, (float)maxVal);
                FoldCount = new IntBounds(0, 0, 100);
                MaxIterations = new IntBounds(100, 0, 9999);
                MaxOrbitDistance = new FloatBounds(100, 0, (float)maxVal);
                Power = 2;
                TerrainHeight = new FloatBounds(0, (float)-maxVal, (float)maxVal);
                Zoom = new FloatBounds(0, (float)-maxVal, (float)maxVal);
                Center = new Vector2(0, 0);
                Julia = new Vector2(-0.4f, 0.6f);
                JuliaMating = new Vector2(0.285f, 0.01f);
                FoldOffset = new Vector4(0,0,0,0);
                //BailoutLine = new Vector4(-8,-9.5f,-2,-3);
                EditingOrbitTrap = EditingOrbitTrap.Both;
                OrbitTrap = OrbitTrap.Circle;
                StartOrbit = 1;
                OrbitRange = MaxIterations.Value;
                Bailout = 2;
                BailoutFactor1 = 0.25f;
                BailoutFactor2 = 7;
                BailoutRectangle = new Vector2(2,2);
                BailoutPoints = new Vector2[16];
                BailoutPoints[0] = Vector2.Zero;
                BailoutLines = new Vector4[16];
                BailoutLines[0] = new Vector4(0,0,0,1);
                BailoutLines[1] = new Vector4(0,0,1,0);
                I_OrbitTrap = OrbitTrap.Circle;
                I_StartOrbit = 1;
                I_OrbitRange = MaxIterations.Value;
                I_Bailout = 2;
                I_BailoutFactor1 = 0.25f;
                I_BailoutFactor2 = 7;
                I_BailoutRectangle = new Vector2(2,2);
                I_BailoutPoints = new Vector2[16];
                I_BailoutPoints[0] = Vector2.Zero;
                I_BailoutLines = new Vector4[16];
                I_BailoutLines[0] = new Vector4(0,0,0,1);
                I_BailoutLines[1] = new Vector4(0,0,1,0);
                E_OrbitTrap = OrbitTrap.Circle;
                E_StartOrbit = 1;
                E_OrbitRange = MaxIterations.Value;
                E_Bailout = 2;
                E_BailoutFactor1 = 0.25f;
                E_BailoutFactor2 = 7;
                E_BailoutRectangle = new Vector2(2,2);
                E_BailoutPoints = new Vector2[16];
                E_BailoutPoints[0] = Vector2.Zero;
                E_BailoutLines = new Vector4[16];
                E_BailoutLines[0] = new Vector4(0,0,0,1);
                E_BailoutLines[1] = new Vector4(0,0,1,0);
            }

            public bool Is1DBailout => (EditingOrbitTrap == EditingOrbitTrap.Both && OrbitTrap >= OrbitTrap.Circle && OrbitTrap <= OrbitTrap.Imaginary)
                                    || (EditingOrbitTrap == EditingOrbitTrap.Interior && I_OrbitTrap >= OrbitTrap.Circle && I_OrbitTrap <= OrbitTrap.Imaginary)
                                    || (EditingOrbitTrap == EditingOrbitTrap.Exterior && E_OrbitTrap >= OrbitTrap.Circle && E_OrbitTrap <= OrbitTrap.Imaginary);
            public bool Is2DBailout => (EditingOrbitTrap == EditingOrbitTrap.Both && OrbitTrap >= OrbitTrap.Rectangle && OrbitTrap <= OrbitTrap.Points)
                                    || (EditingOrbitTrap == EditingOrbitTrap.Interior && I_OrbitTrap >= OrbitTrap.Rectangle && I_OrbitTrap <= OrbitTrap.Points)
                                    || (EditingOrbitTrap == EditingOrbitTrap.Exterior && E_OrbitTrap >= OrbitTrap.Rectangle && E_OrbitTrap <= OrbitTrap.Points);
            //public bool Is3DBailout => OrbitTrap >= OrbitTrap.Triangle && OrbitTrap <= OrbitTrap.Triangle;
            //public bool Is4DBailout => OrbitTrap >= OrbitTrap.Line && OrbitTrap <= OrbitTrap.Line;

            public void CopyIToE()
            {
                E_OrbitTrap = I_OrbitTrap;
                E_StartOrbit = I_StartOrbit;
                E_OrbitRange = I_OrbitRange;
                E_Bailout = I_Bailout;
                E_BailoutFactor1 = I_BailoutFactor1;
                E_BailoutFactor2 = I_BailoutFactor2;
                E_BailoutRectangle = I_BailoutRectangle;
                I_BailoutPoints.CopyTo(E_BailoutPoints, 0);
                I_BailoutLines.CopyTo(E_BailoutLines, 0);
            }
            public void CopyEToI()
            {
                I_OrbitTrap = E_OrbitTrap;
                I_StartOrbit = E_StartOrbit;
                I_OrbitRange = E_OrbitRange;
                I_Bailout = E_Bailout;
                I_BailoutFactor1 = E_BailoutFactor1;
                I_BailoutFactor2 = E_BailoutFactor2;
                I_BailoutRectangle = E_BailoutRectangle;
                E_BailoutPoints.CopyTo(I_BailoutPoints, 0);
                E_BailoutLines.CopyTo(I_BailoutLines, 0);
            }

            public void SetOrbitTrap(OrbitTrap orbitTrap)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                       I_OrbitTrap = orbitTrap;
                       break;
                    case EditingOrbitTrap.Exterior:
                       E_OrbitTrap = orbitTrap;
                       break;
                    default:
                       OrbitTrap = orbitTrap;
                       break;
                }
            }

            public OrbitTrap GetOrbitTrap()
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        return I_OrbitTrap;
                    case EditingOrbitTrap.Exterior:
                        return E_OrbitTrap;
                    default:
                        return OrbitTrap;
                }
            }

            public float GetBailout()
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        return I_Bailout;
                    case EditingOrbitTrap.Exterior:
                        return E_Bailout;
                    default:
                        return Bailout;
                }
            }
            public void SetBailout(float bailout)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_Bailout = bailout;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_Bailout = bailout;
                        break;
                    default:
                        Bailout = bailout;
                        break;
                }
            }
            public void AdjustBailout(float offset)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_Bailout += offset;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_Bailout += offset;
                        break;
                    default:
                        Bailout += offset;
                        break;
                }
            }

            public Vector2 GetRectangle()
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        return I_BailoutRectangle;
                    case EditingOrbitTrap.Exterior:
                        return E_BailoutRectangle;
                    default:
                        return BailoutRectangle;
                }
            }
            public void SetRectangleX(float value)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutRectangle.X = value;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutRectangle.X = value;
                        break;
                    default:
                        BailoutRectangle.X = value;
                        break;
                }
            }
            public void AdjustRectangleX(float offset)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutRectangle.X += offset;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutRectangle.X += offset;
                        break;
                    default:
                        BailoutRectangle.X += offset;
                        break;
                }
            }
            public void SetRectangleY(float value)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutRectangle.Y = value;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutRectangle.Y = value;
                        break;
                    default:
                        BailoutRectangle.Y = value;
                        break;
                }
            }
            public void AdjustRectangleY(float offset)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutRectangle.Y += offset;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutRectangle.Y += offset;
                        break;
                    default:
                        BailoutRectangle.Y += offset;
                        break;
                }
            }

            public Vector2[] GetPoints()
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        return I_BailoutPoints;
                    case EditingOrbitTrap.Exterior:
                        return E_BailoutPoints;
                    default:
                        return BailoutPoints;
                }
            }
            public void SetPoints(List<Vector2> list)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutPoints = list.ToArray();
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutPoints = list.ToArray();
                        break;
                    default:
                        BailoutPoints = list.ToArray();
                        break;
                }
            }
            public Vector2 GetPoint(int index)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        return I_BailoutPoints[index];
                    case EditingOrbitTrap.Exterior:
                        return E_BailoutPoints[index];
                    default:
                        return BailoutPoints[index];
                }
            }
            public void SetPoint(int index, Vector2 point)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutPoints[index] = point;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutPoints[index] = point;
                        break;
                    default:
                        BailoutPoints[index] = point;
                        break;
                }
            }
            public void SetPointX(int index, float value)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutPoints[index].X = value;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutPoints[index].X = value;
                        break;
                    default:
                        BailoutPoints[index].X = value;
                        break;
                }
            }
            public void AdjustPointX(int index, float offset)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutPoints[index].X += offset;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutPoints[index].X += offset;
                        break;
                    default:
                        BailoutPoints[index].X += offset;
                        break;
                }
            }
            public void SetPointY(int index, float value)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutPoints[index].Y = value;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutPoints[index].Y = value;
                        break;
                    default:
                        BailoutPoints[index].Y = value;
                        break;
                }
            }
            public void AdjustPointY(int index, float offset)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutPoints[index].Y += offset;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutPoints[index].Y += offset;
                        break;
                    default:
                        BailoutPoints[index].Y += offset;
                        break;
                }
            }

            public Vector4[] GetLines()
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        return I_BailoutLines;
                    case EditingOrbitTrap.Exterior:
                        return E_BailoutLines;
                    default:
                        return BailoutLines;
                }
            }
            public void SetLines(List<Vector4> list)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutLines = list.ToArray();
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutLines = list.ToArray();
                        break;
                    default:
                        BailoutLines = list.ToArray();
                        break;
                }
            }
            public Vector4 GetLine(int index)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        return I_BailoutLines[index];
                    case EditingOrbitTrap.Exterior:
                        return E_BailoutLines[index];
                    default:
                        return BailoutLines[index];
                }
            }
            public Vector4 SetLine(int index, Vector4 line)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        return I_BailoutLines[index] = line;
                    case EditingOrbitTrap.Exterior:
                        return E_BailoutLines[index] = line;
                    default:
                        return BailoutLines[index] = line;
                }
            }
            public void SetLineX(int index, float value)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutLines[index].X = value;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutLines[index].X = value;
                        break;
                    default:
                        BailoutLines[index].X = value;
                        break;
                }
            }
            public void AdjustLineX(int index, float offset)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutLines[index].X += offset;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutLines[index].X += offset;
                        break;
                    default:
                        BailoutLines[index].X += offset;
                        break;
                }
            }
            public void SetLineY(int index, float value)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutLines[index].Y = value;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutLines[index].Y = value;
                        break;
                    default:
                        BailoutLines[index].Y = value;
                        break;
                }
            }
            public void AdjustLineY(int index, float offset)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutLines[index].Y += offset;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutLines[index].Y += offset;
                        break;
                    default:
                        BailoutLines[index].Y += offset;
                        break;
                }
            }
            public void SetLineZ(int index, float value)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutLines[index].Z = value;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutLines[index].Z = value;
                        break;
                    default:
                        BailoutLines[index].Z = value;
                        break;
                }
            }
            public void AdjustLineZ(int index, float offset)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutLines[index].Z += offset;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutLines[index].Z += offset;
                        break;
                    default:
                        BailoutLines[index].Z += offset;
                        break;
                }
            }
            public void SetLineW(int index, float value)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutLines[index].W = value;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutLines[index].W = value;
                        break;
                    default:
                        BailoutLines[index].W = value;
                        break;
                }
            }
            public void AdjustLineW(int index, float offset)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutLines[index].W += offset;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutLines[index].W += offset;
                        break;
                    default:
                        BailoutLines[index].W += offset;
                        break;
                }
            }

            public Type Type;
            public Formula Formula;
            public Buddhabrot buddhabrot;
            public Coloring ExteriorColoring;
            public Coloring InteriorColoring;
            public EditingOrbitTrap EditingOrbitTrap;
            private OrbitTrap OrbitTrap;
            private OrbitTrap I_OrbitTrap;
            private OrbitTrap E_OrbitTrap;
            public Projection Projection;
            public bool IsBuddhabrot;
            public bool IsConjugate;
            public bool IsJulia;
            public bool IsJuliaCentered;
            public bool UseDistance;
            public bool UseLighting;
            public bool UseTerrainColor;
            private int StartOrbit;
            private int I_StartOrbit;
            private int E_StartOrbit;
            private int OrbitRange;
            private int I_OrbitRange;
            private int E_OrbitRange;
            private float Bailout;
            private float BailoutFactor1;
            private float BailoutFactor2;
            private float I_Bailout;
            private float I_BailoutFactor1;
            private float I_BailoutFactor2;
            private float E_Bailout;
            private float E_BailoutFactor1;
            private float E_BailoutFactor2;
            public FloatBounds InitialDisplayRadius;
            public float C_Power;
            public FloatBounds FoldAngle;
            public IntBounds FoldCount;
            public IntBounds MaxIterations;
            public FloatBounds MaxOrbitDistance;
            public float Power;
            public FloatBounds TerrainHeight;
            public FloatBounds Zoom;
            private Vector2 BailoutRectangle;
            private Vector2 I_BailoutRectangle;
            private Vector2 E_BailoutRectangle;
            public Vector2 Center;
            public Vector2 Julia;
            public Vector2 JuliaMating;
            private Vector2[] BailoutPoints;
            private Vector4[] BailoutLines;
            private Vector2[] I_BailoutPoints;
            private Vector2[] E_BailoutPoints;
            private Vector4[] I_BailoutLines;
            private Vector4[] E_BailoutLines;
            public Vector4 FoldOffset;
        }
        #endregion

        #region Constructors

        #endregion

        #region Methods

        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Constants
        const double maxVal = 1e99;
        const double minVal = 1e-99;
        #endregion
    }
}
