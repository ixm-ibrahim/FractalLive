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
            CUSTOM, CIRCLE, SQUARE, RECTANGLE, REAL, IMAGINARY, POINT, LINE, CROSS, COUNT
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
                Bailout = 2;
                C_Power = 1;
                FoldAngle = 0;
                FoldCount = 0;
                MaxIterations = 100;
                MaxOrbitDistance = 100;
                Power = 2;
                TerrainHeight = 0;
                Zoom = 0;
                BailoutPoint = new Vector2d(0,0);
                Center = new Vector2d(0, 0);
                Julia = new Vector2d(-0.4, 0.6);
                JuliaMating = new Vector2d(0.285, 0.01);
                BailoutLine = new Vector4d(0,0,0,1);
                FoldOffset = new Vector4d(0,0,0,0);
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
            public double Bailout { get; set; }
            public double C_Power { get; set; }
            public double FoldAngle { get; set; }
            public double FoldCount { get; set; }
            public double MaxIterations { get; set; }
            public double MaxOrbitDistance { get; set; }
            public double Power { get; set; }
            public double TerrainHeight { get; set; }
            public double Zoom { get; set; }
            public Vector2d BailoutPoint { get; set; }
            public Vector2d Center { get; set; }
            public Vector2d Julia { get; set; }
            public Vector2d JuliaMating { get; set; }
            public Vector4d BailoutLine { get; set; }
            public Vector4d FoldOffset { get; set; }
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

        #region Variables


        #endregion
    }
}
