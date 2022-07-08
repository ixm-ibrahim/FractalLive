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

        public enum OrbitTrap
        {
            Custom = -1, Circle = 0, Square = 1, Real = 2, Imaginary = 3, Rectangle = 4, Point = 5, Triangle = 6, Line = 7, Cross = 8, COUNT
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
                OrbitTrap = OrbitTrap.Circle;
                Projection = Projection.Normal;
                IsBuddhabrot = false;
                IsConjugate = false;
                IsJulia = false;
                IsJuliaCentered = false;
                UseDistance = false;
                UseLighting = false;
                UseTerrainColor = false;
                InitialDisplayRadius = new FloatBounds(2, .01f, 100);
                Bailout = new FloatBounds(2, 0, (float)maxVal);
                C_Power = new FloatBounds(1, (float)-maxVal, (float)maxVal);
                FoldAngle = new FloatBounds(0, (float)-maxVal, (float)maxVal);
                FoldCount = new IntBounds(0, 0, 100);
                MaxIterations = new IntBounds(100, 0, 9999);
                MaxOrbitDistance = new FloatBounds(100, 0, (float)maxVal);
                Power = new FloatBounds(2, (float)-maxVal, (float)maxVal);
                TerrainHeight = new FloatBounds(0, (float)-maxVal, (float)maxVal);
                Zoom = new FloatBounds(0, (float)-maxVal, (float)maxVal);
                BailoutRectangle = new Vector2(2,2);
                BailoutPoint = new Vector2(0,0);
                Center = new Vector2(0, 0);
                Julia = new Vector2(-0.4f, 0.6f);
                JuliaMating = new Vector2(0.285f, 0.01f);
                BailoutLine = new Vector4(0,0,0,1);
                BailoutLine2 = new Vector4(0,1,0,0);
                FoldOffset = new Vector4(0,0,0,0);
            }

            public bool Is1DBailout => OrbitTrap >= OrbitTrap.Circle && OrbitTrap <= OrbitTrap.Imaginary;
            public bool Is2DBailout => OrbitTrap >= OrbitTrap.Rectangle && OrbitTrap <= OrbitTrap.Point;
            public bool Is3DBailout => OrbitTrap >= OrbitTrap.Triangle && OrbitTrap <= OrbitTrap.Triangle;
            public bool Is4DBailout => OrbitTrap >= OrbitTrap.Line && OrbitTrap <= OrbitTrap.Line;

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
            public FloatBounds InitialDisplayRadius;
            public FloatBounds Bailout;
            public FloatBounds C_Power;
            public FloatBounds FoldAngle;
            public IntBounds FoldCount;
            public IntBounds MaxIterations;
            public FloatBounds MaxOrbitDistance;
            public FloatBounds Power;
            public FloatBounds TerrainHeight;
            public FloatBounds Zoom;
            public Vector2 BailoutRectangle;
            public Vector2 BailoutPoint;
            public Vector2 Center;
            public Vector2 Julia;
            public Vector2 JuliaMating;
            public Vector4 BailoutLine;
            public Vector4 BailoutLine2;
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
