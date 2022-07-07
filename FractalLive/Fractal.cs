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
            CUSTOM, JULIA, MANDELBROT, JULIA_MATING
        }

        public enum Formula
        {
            CUSTOM, MANDELBROT, LAMBDA
        }

        public enum Buddhabrot
        {
            NORMAL, INVERSE, NEBULABROT
        }

        public enum Coloring
        {
            CUSTOM, BLACK, WHITE, CLASSIC, SMOOTH, DOMAIN_A, DOMAIN_B, DOMAIN_C, DOMAIN_D, DOMAIN_E, DOMAIN_F, DOMAIN_G, COUNT
        }

        public enum OrbitTrap
        {
            CUSTOM = -1, CIRCLE = 0, SQUARE = 1, REAL = 2, IMAGINARY = 3, RECTANGLE = 4, POINT = 5, LINE = 6, CROSS = 7, COUNT
        }

        public enum Projection
        {
            NORMAL, INVERSE, RIEMANN_SPHERE
        }

        #endregion

        #region Structures
        public struct Settings
        {
            public Settings(Type type = Type.MANDELBROT, Formula formula = Formula.MANDELBROT)
            {
                Type = type;
                Formula = formula;
                buddhabrot = Buddhabrot.NORMAL;
                ExteriorColoring = Coloring.WHITE;
                InteriorColoring = Coloring.BLACK;
                OrbitTrap = OrbitTrap.CIRCLE;
                Projection = Projection.NORMAL;
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
                BailoutPoint = new Vector2(0,0);
                Center = new Vector2(0, 0);
                Julia = new Vector2(-0.4f, 0.6f);
                JuliaMating = new Vector2(0.285f, 0.01f);
                BailoutLine = new Vector4(0,0,0,1);
                FoldOffset = new Vector4(0,0,0,0);
            }

            public Type Type { get; set; }
            public Formula Formula { get; set; }
            public Buddhabrot buddhabrot { get; set; }
            public Coloring ExteriorColoring { get; set; }
            public Coloring InteriorColoring { get; set; }
            public OrbitTrap OrbitTrap { get; set; }
            public Projection Projection { get; set; }
            public bool IsBuddhabrot { get; set; }
            public bool IsConjugate { get; set; }
            public bool IsJulia { get; set; }
            public bool IsJuliaCentered { get; set; }
            public bool UseDistance { get; set; }
            public bool UseLighting { get; set; }
            public bool UseTerrainColor { get; set; }
            public FloatBounds InitialDisplayRadius { get; set; }
            public FloatBounds Bailout { get; set; }
            public FloatBounds C_Power { get; set; }
            public FloatBounds FoldAngle { get; set; }
            public IntBounds FoldCount { get; set; }
            public IntBounds MaxIterations { get; set; }
            public FloatBounds MaxOrbitDistance { get; set; }
            public FloatBounds Power { get; set; }
            public FloatBounds TerrainHeight { get; set; }
            public FloatBounds Zoom { get; set; }
            public Vector2 BailoutPoint { get; set; }
            public Vector2 Center { get; set; }
            public Vector2 Julia { get; set; }
            public Vector2 JuliaMating { get; set; }
            public Vector4 BailoutLine { get; set; }
            public Vector4 FoldOffset { get; set; }
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
