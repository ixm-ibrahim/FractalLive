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
            Both = 0, Interior = 1, Exterior = 2
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
                BailoutPointsCount = 1;
                BailoutLines = new Vector4[16];
                BailoutLines[0] = new Vector4(0,0,0,1);
                BailoutLines[1] = new Vector4(0,0,1,0);
                BailoutLinesCount = 2;
                I_OrbitTrap = OrbitTrap.Circle;
                I_StartOrbit = 1;
                I_OrbitRange = MaxIterations.Value;
                I_Bailout = 2;
                I_BailoutFactor1 = 0.25f;
                I_BailoutFactor2 = 7;
                I_BailoutRectangle = new Vector2(2,2);
                I_BailoutPoints = new Vector2[16];
                I_BailoutPoints[0] = Vector2.Zero;
                I_BailoutPointsCount = 1;
                I_BailoutLines = new Vector4[16];
                I_BailoutLines[0] = new Vector4(0,0,0,1);
                I_BailoutLines[1] = new Vector4(0,0,1,0);
                I_BailoutLinesCount = 2;
                E_OrbitTrap = OrbitTrap.Circle;
                E_StartOrbit = 1;
                E_OrbitRange = MaxIterations.Value;
                E_Bailout = 2;
                E_BailoutFactor1 = 0.25f;
                E_BailoutFactor2 = 7;
                E_BailoutRectangle = new Vector2(2,2);
                E_BailoutPoints = new Vector2[16];
                E_BailoutPoints[0] = Vector2.Zero;
                E_BailoutPointsCount = 1;
                E_BailoutLines = new Vector4[16];
                E_BailoutLines[0] = new Vector4(0,0,0,1);
                E_BailoutLines[1] = new Vector4(0,0,1,0);
                E_BailoutLinesCount = 2;
            }

            public bool Is1DBailout => (EditingOrbitTrap == EditingOrbitTrap.Both && OrbitTrap >= OrbitTrap.Circle && OrbitTrap <= OrbitTrap.Imaginary)
                                    || (EditingOrbitTrap == EditingOrbitTrap.Interior && I_OrbitTrap >= OrbitTrap.Circle && I_OrbitTrap <= OrbitTrap.Imaginary)
                                    || (EditingOrbitTrap == EditingOrbitTrap.Exterior && E_OrbitTrap >= OrbitTrap.Circle && E_OrbitTrap <= OrbitTrap.Imaginary);
            public bool Is2DBailout => (EditingOrbitTrap == EditingOrbitTrap.Both && OrbitTrap >= OrbitTrap.Rectangle && OrbitTrap <= OrbitTrap.Points)
                                    || (EditingOrbitTrap == EditingOrbitTrap.Interior && I_OrbitTrap >= OrbitTrap.Rectangle && I_OrbitTrap <= OrbitTrap.Points)
                                    || (EditingOrbitTrap == EditingOrbitTrap.Exterior && E_OrbitTrap >= OrbitTrap.Rectangle && E_OrbitTrap <= OrbitTrap.Points);
            //public bool Is3DBailout => OrbitTrap >= OrbitTrap.Triangle && OrbitTrap <= OrbitTrap.Triangle;
            //public bool Is4DBailout => OrbitTrap >= OrbitTrap.Line && OrbitTrap <= OrbitTrap.Line;

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
            public int GetPointsCount()
            {
                if (EditingOrbitTrap == EditingOrbitTrap.Interior)
                    return I_BailoutPointsCount;
                if (EditingOrbitTrap == EditingOrbitTrap.Exterior)
                    return E_BailoutPointsCount;

                return BailoutPointsCount;
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
            public void AddPoint(Vector2 point)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutPoints[I_BailoutPointsCount++] = point;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutPoints[E_BailoutPointsCount++] = point;
                        break;
                    default:
                        BailoutPoints[BailoutPointsCount++] = point;
                        break;
                }
            }
            public void RemovePoint(int index)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                    {
                        var tmp = new List<Vector2>(I_BailoutPoints);
                        tmp.RemoveAt(index);
                        I_BailoutPoints = tmp.ToArray();
                        I_BailoutPointsCount--;
                        break;
                    }
                    case EditingOrbitTrap.Exterior:
                    {
                        var tmp = new List<Vector2>(E_BailoutPoints);
                        tmp.RemoveAt(index);
                        E_BailoutPoints = tmp.ToArray();
                        E_BailoutPointsCount--;
                        break;
                    }
                    default:
                    {
                        var tmp = new List<Vector2>(BailoutPoints);
                        tmp.RemoveAt(index);
                        BailoutPoints = tmp.ToArray();
                        BailoutPointsCount--;
                        break;
                    }
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
            public int GetLinesCount()
            {
                if (EditingOrbitTrap == EditingOrbitTrap.Interior)
                    return I_BailoutLinesCount;
                if (EditingOrbitTrap == EditingOrbitTrap.Exterior)
                    return E_BailoutLinesCount;

                return BailoutLinesCount;
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
            public void AddLine(Vector4 line)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                        I_BailoutLines[I_BailoutLinesCount++] = line;
                        break;
                    case EditingOrbitTrap.Exterior:
                        E_BailoutLines[E_BailoutLinesCount++] = line;
                        break;
                    default:
                        BailoutLines[BailoutLinesCount++] = line;
                        break;
                }
            }
            public void RemoveLine(int index)
            {
                switch (EditingOrbitTrap)
                {
                    case EditingOrbitTrap.Interior:
                    {
                        var tmp = new List<Vector4>(I_BailoutLines);
                        tmp.RemoveAt(index);
                        I_BailoutLines = tmp.ToArray();
                        I_BailoutLinesCount--;
                        break;
                    }
                    case EditingOrbitTrap.Exterior:
                    {
                        var tmp = new List<Vector4>(E_BailoutLines);
                        tmp.RemoveAt(index);
                        E_BailoutLines = tmp.ToArray();
                        E_BailoutLinesCount--;
                        break;
                    }
                    default:
                    {
                        var tmp = new List<Vector4>(BailoutLines);
                        tmp.RemoveAt(index);
                        BailoutLines = tmp.ToArray();
                        BailoutLinesCount--;
                        break;
                    }
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
            public OrbitTrap OrbitTrap;
            public OrbitTrap I_OrbitTrap;
            public OrbitTrap E_OrbitTrap;
            public Projection Projection;
            public bool IsBuddhabrot;
            public bool IsConjugate;
            public bool IsJulia;
            public bool IsJuliaCentered;
            public bool UseDistance;
            public bool UseLighting;
            public bool UseTerrainColor;
            public int StartOrbit;
            public int I_StartOrbit;
            public int E_StartOrbit;
            public int OrbitRange;
            public int I_OrbitRange;
            public int E_OrbitRange;
            public float Bailout;
            public float BailoutFactor1;
            public float BailoutFactor2;
            public float I_Bailout;
            public float I_BailoutFactor1;
            public float I_BailoutFactor2;
            public float E_Bailout;
            public float E_BailoutFactor1;
            public float E_BailoutFactor2;
            public FloatBounds InitialDisplayRadius;
            public float C_Power;
            public FloatBounds FoldAngle;
            public IntBounds FoldCount;
            public IntBounds MaxIterations;
            public FloatBounds MaxOrbitDistance;
            public float Power;
            public FloatBounds TerrainHeight;
            public FloatBounds Zoom;
            public Vector2 BailoutRectangle;
            public Vector2 I_BailoutRectangle;
            public Vector2 E_BailoutRectangle;
            public Vector2 Center;
            public Vector2 Julia;
            public Vector2 JuliaMating;
            public Vector2[] BailoutPoints;
            public int BailoutPointsCount;
            public Vector4[] BailoutLines;
            public int BailoutLinesCount;
            public Vector2[] I_BailoutPoints;
            public int I_BailoutPointsCount;
            public Vector2[] E_BailoutPoints;
            public int E_BailoutPointsCount;
            public Vector4[] I_BailoutLines;
            public int I_BailoutLinesCount;
            public Vector4[] E_BailoutLines;
            public int E_BailoutLinesCount;
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
