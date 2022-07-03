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
        enum Type
        {
            CUSTOM, MANDELBROT, LAMBDA
        }

        enum Buddhabrot
        {
            NORMAL, INVERSE, NEBULABROT
        }

        enum Coloring
        {
            CUSTOM, BLACK, WHITE, CLASSIC, SMOOTH, DOMAIN_A, DOMAIN_B, DOMAIN_C, DOMAIN_D, DOMAIN_E, DOMAIN_F, DOMAIN_G, COUNT
        }

        enum OrbitTrap
        {
            CUSTOM, CIRCLE, SQUARE, RECTANGLE, REAL, IMAGINARY, POINT, LINE, CROSS, COUNT
        }

        enum Projection
        {
            NORMAL, INVERSE, RIEMANN_SPHERE
        }

        #endregion

        #region Structures
        struct Settings
        {
            public Settings(Type type = Type.MANDELBROT)
            {
                Type = type;
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
                BailoutLine = new Vector4d(0,0,0,1);
                FoldOffset = new Vector4d(0,0,0,0);
            }

            Type Type { get; set; }
            Buddhabrot buddhabrot { get; set; }
            Coloring ExteriorColoring { get; set; }
            Coloring InteriorColoring { get; set; }
            OrbitTrap OrbitTrap { get; set; }
            Projection Projection { get; set; }
            bool IsBuddhabrot { get; set; }
            bool IsConjugate { get; set; }
            bool IsJulia { get; set; }
            bool IsJuliaCentered { get; set; }
            bool UseDistance { get; set; }
            bool UseLighting { get; set; }
            bool UseTerrainColor { get; set; }
            double Bailout { get; set; }
            double C_Power { get; set; }
            double FoldAngle { get; set; }
            double FoldCount { get; set; }
            double MaxIterations { get; set; }
            double MaxOrbitDistance { get; set; }
            double Power { get; set; }
            double TerrainHeight { get; set; }
            double Zoom { get; set; }
            Vector2d BailoutPoint { get; set; }
            Vector2d Center { get; set; }
            Vector2d Julia { get; set; }
            Vector4d BailoutLine { get; set; }
            Vector4d FoldOffset { get; set; }
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
