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
            Custom = -1, Black = 0, White = 1, Iteration = 2, Smooth = 3, Domain_1 = 4, Domain_2 = 5, Domain_3 = 6, Domain_4 = 7, Domain_5 = 8, Domain_6 = 9, Domain_7 = 10, COUNT
        }

        public enum OrbitTrap
        {
            Custom = -1, Circle = 0, Square = 1, Real = 2, Imaginary = 3, Rectangle = 4, Points = 5, Lines = 6, COUNT
        }

        public enum Projection
        {
            Normal, Inverse, Riemann_Sphere
        }

        public enum Editing
        {
            Both, Interior, Exterior
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
                Zoom = 0;
                LockedZoom = 0;
                Center = new Vector2(0, 0);
                Julia = new Vector2(-0.4f, 0.6f);
                JuliaMating = new Vector2(0.285f, 0.01f);
                FoldOffset = new Vector4(0,0,0,0);
                //BailoutLine = new Vector4(-8,-9.5f,-2,-3);
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

                EditingColor = Editing.Both;

                Coloring = Coloring.Smooth;
                ColorCycle = 1;
                ColorFactor = 1;
                UseDistanceEstimation = false;
                MaxDistance = 1e20f;
                DistFineness = 1;
                Texture = "";
                TextureBlend = 0.5f;

                I_Coloring = Coloring.Smooth;
                I_ColorCycle = 1;
                I_ColorFactor = 1;
                I_UseDistanceEstimation = false;
                I_MaxDistance = 1e20f;
                I_DistFineness = 1;
                I_Texture = "";
                I_TextureBlend = 0.5f;

                E_Coloring = Coloring.Smooth;
                E_ColorCycle = 1;
                E_ColorFactor = 1;
                E_UseDistanceEstimation = false;
                E_MaxDistance = 1e20f;
                E_DistFineness = 1;
                E_Texture = "";
                E_TextureBlend = 0.5f;
        }

            public bool Is1DBailout => OrbitTrap >= OrbitTrap.Circle && OrbitTrap <= OrbitTrap.Imaginary;
            public bool Is2DBailout => OrbitTrap >= OrbitTrap.Rectangle && OrbitTrap <= OrbitTrap.Points;
            public bool IsDistanceBailout => OrbitTrap >= OrbitTrap.Points && OrbitTrap <= OrbitTrap.Lines;
            //public bool Is3DBailout => OrbitTrap >= OrbitTrap.Triangle && OrbitTrap <= OrbitTrap.Triangle;
            //public bool Is4DBailout => OrbitTrap >= OrbitTrap.Line && OrbitTrap <= OrbitTrap.Line;
            
            public void AddPoint(Vector2 point)
            {
                BailoutPoints[BailoutPointsCount++] = point;
            }
            public void RemovePoint(int index)
            {
                var tmp = new List<Vector2>(BailoutPoints);
                tmp.RemoveAt(index);
                BailoutPoints = tmp.ToArray();
                BailoutPointsCount--;
            }

            public void AddLine(Vector4 line)
            {
                BailoutLines[BailoutLinesCount++] = line;
            }
            public void RemoveLine(int index)
            {
                var tmp = new List<Vector4>(BailoutLines);
                tmp.RemoveAt(index);
                BailoutLines = tmp.ToArray();
                BailoutLinesCount--;
            }

            public void SetColoring(Coloring coloring)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_Coloring = coloring;
                        break;
                    case Editing.Exterior:
                        E_Coloring = coloring;
                        break;
                    default:
                        Coloring = coloring;
                        break;
                }
            }

            public Type Type;
            public Formula Formula;
            public Buddhabrot buddhabrot;
            public Coloring ExteriorColoring;
            public Coloring InteriorColoring;
            public OrbitTrap OrbitTrap;
            public Projection Projection;
            public bool IsBuddhabrot;
            public bool IsConjugate;
            public bool IsJulia;
            public bool IsJuliaCentered;
            public bool UseDistance;
            public bool UseLighting;
            public bool UseTerrainColor;
            public int StartOrbit;
            public int OrbitRange;
            public float Bailout;
            public float BailoutFactor1;
            public float BailoutFactor2;
            public FloatBounds InitialDisplayRadius;
            public float C_Power;
            public FloatBounds FoldAngle;
            public IntBounds FoldCount;
            public IntBounds MaxIterations;
            public FloatBounds MaxOrbitDistance;
            public float Power;
            public FloatBounds TerrainHeight;
            public float Zoom;
            public float LockedZoom;
            public Vector2 BailoutRectangle;
            public Vector2 Center;
            public Vector2 Julia;
            public Vector2 JuliaMating;
            public Vector2[] BailoutPoints;
            public int BailoutPointsCount;
            public Vector4[] BailoutLines;
            public int BailoutLinesCount;
            public Vector4 FoldOffset;

            public Editing EditingColor;

            public Coloring Coloring;
            public float ColorCycle;
            public float ColorFactor;
            public bool UseDistanceEstimation;
            public float MaxDistance;
            public float DistFineness;
            public string Texture;
            public float TextureBlend;

            public Coloring I_Coloring;
            public float I_ColorCycle;
            public float I_ColorFactor;
            public bool I_UseDistanceEstimation;
            public float I_MaxDistance;
            public float I_DistFineness;
            public string I_Texture;
            public float I_TextureBlend;

            public Coloring E_Coloring;
            public float E_ColorCycle;
            public float E_ColorFactor;
            public bool E_UseDistanceEstimation;
            public float E_MaxDistance;
            public float E_DistFineness;
            public string E_Texture;
            public float E_TextureBlend;
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
