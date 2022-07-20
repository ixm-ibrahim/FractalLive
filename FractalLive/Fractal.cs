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

        public enum Calculation
        {
            Custom = -1, Minimum = 0, Maximum = 1, Average = 2, First = 3, Last = 4
        }

        #endregion

        #region Structures
        public struct Settings
        {
            public Settings(Type type = Type.Mandelbrot, Formula formula = Formula.Classic)
            {
                Zoom = 0;
                LockedZoom = 0;
                Center = new Vector2(0, 0);

                Type = type;
                Formula = formula;
                InitialDisplayRadius = new FloatBounds(2, .01f, 100);
                Projection = Projection.Normal;
                IsJulia = false;
                IsJuliaCentered = false;
                Julia = new Vector2(-0.4f, 0.6f);
                JuliaMating = new Vector2(0.285f, 0.01f);
                IsConjugate = false;
                IsBuddhabrot = false;
                buddhabrot = Buddhabrot.Normal;
                MaxIterations = new IntBounds(100, 1, 9999);
                MinIterations = new IntBounds(1, 1, 9999);
                C_Power = 1;
                Power = 2;
                FoldAngle = new FloatBounds(0, (float)-maxVal, (float)maxVal);
                FoldCount = new IntBounds(0, 0, 100);
                FoldOffset = new Vector4(0,0,0,0);

                OrbitTrap = OrbitTrap.Circle;
                Bailout = 2;
                OrbitTrapCalculation = Calculation.Minimum;
                BailoutRectangle = new Vector2(2,2);
                BailoutPoints = new Vector2[16];
                BailoutPoints[0] = Vector2.Zero;
                BailoutPointsCount = 1;
                BailoutLines = new Vector4[16];
                BailoutLines[0] = new Vector4(0,0,0,1);
                BailoutLines[1] = new Vector4(0,0,1,0);
                //BailoutLine = new Vector4(-8,-9.5f,-2,-3);
                BailoutLinesCount = 2;
                BailoutFactor1 = 0.25f;
                BailoutFactor2 = 7;
                UseSecondValue = false;
                SecondValueFactor1 = 4;
                SecondValueFactor2 = 20;
                
                StartOrbitDistance = new FloatBounds(2, 0, (float)maxVal);
                StartOrbit = new IntBounds(1, 1, 9999);
                OrbitRange = new IntBounds(MaxIterations.Value, 1, 9999);

                EditingColor = Editing.Both;

                Coloring = Coloring.Smooth;
                ColorCycles = 1;
                ColorFactor = 6;
                OrbitTrapFactor = 10;
                DomainCalculation = Calculation.Last;
                UseSecondDomainValue = true;
                SecondDomainValueFactor1 = 1;
                SecondDomainValueFactor2 = 1;
                MatchOrbitTrap = false;
                UseDomainIteration = false;
                UseDistanceEstimation = false;
                MaxDistance = 1e20f;
                DistFineness = 1;
                Texture = "";
                TextureBlend = 0.5f;

                I_Coloring = Coloring.Smooth;
                I_ColorCycles = 1;
                I_ColorFactor = 1;
                I_OrbitTrapFactor = 1;
                I_DomainCalculation = Calculation.Last;
                I_UseSecondDomainValue = true;
                I_SecondDomainValueFactor1 = 1;
                I_SecondDomainValueFactor2 = 1;
                I_MatchOrbitTrap = false;
                I_UseDomainIteration = false;
                I_UseDistanceEstimation = false;
                I_MaxDistance = 1e20f;
                I_DistFineness = 1;
                I_Texture = "";
                I_TextureBlend = 0.5f;

                E_Coloring = Coloring.Smooth;
                E_ColorCycles = 1;
                E_ColorFactor = 1;
                E_OrbitTrapFactor = 1;
                E_DomainCalculation = Calculation.Last;
                E_UseSecondDomainValue = true;
                E_SecondDomainValueFactor1 = 1;
                E_SecondDomainValueFactor2 = 1;
                E_MatchOrbitTrap = false;
                E_UseDomainIteration = false;
                E_UseDistanceEstimation = false;
                E_MaxDistance = 1e20f;
                E_DistFineness = 1;
                E_Texture = "";
                E_TextureBlend = 0.5f;

                UseLighting = false;
                UseTerrainColor = false;
                TerrainHeight = new FloatBounds(0, (float)-maxVal, (float)maxVal);
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

            public Coloring GetColoring()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_Coloring;
                        break;
                    case Editing.Exterior:
                        return E_Coloring;
                        break;
                    default:
                        return Coloring;
                        break;
                }
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

            public float GetColorCycles()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_ColorCycles;
                    case Editing.Exterior:
                        return E_ColorCycles;
                    default:
                        return ColorCycles;
                }
            }
            public void SetColorCycles(float colorCycles)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_ColorCycles = colorCycles;
                        break;
                    case Editing.Exterior:
                        E_ColorCycles = colorCycles;
                        break;
                    default:
                        ColorCycles = colorCycles;
                        break;
                }
            }
            public void AdjustColorCycles(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_ColorCycles += offset;
                        break;
                    case Editing.Exterior:
                        E_ColorCycles += offset;
                        break;
                    default:
                        ColorCycles += offset;
                        break;
                }
            }

            public float GetColorFactor()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_ColorFactor;
                    case Editing.Exterior:
                        return E_ColorFactor;
                    default:
                        return ColorFactor;
                }
            }
            public void SetColorFactor(float colorFactor)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_ColorFactor = colorFactor;
                        break;
                    case Editing.Exterior:
                        E_ColorFactor = colorFactor;
                        break;
                    default:
                        ColorFactor = colorFactor;
                        break;
                }
            }
            public void AdjustColorFactor(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_ColorFactor += offset;
                        break;
                    case Editing.Exterior:
                        E_ColorFactor += offset;
                        break;
                    default:
                        ColorFactor += offset;
                        break;
                }
            }

            public float GetOrbitTrapFactor()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_OrbitTrapFactor;
                    case Editing.Exterior:
                        return E_OrbitTrapFactor;
                    default:
                        return OrbitTrapFactor;
                }
            }
            public void SetOrbitTrapFactor(float orbitTrapFactor)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_OrbitTrapFactor = orbitTrapFactor;
                        break;
                    case Editing.Exterior:
                        E_OrbitTrapFactor = orbitTrapFactor;
                        break;
                    default:
                        OrbitTrapFactor = orbitTrapFactor;
                        break;
                }
            }
            public void AdjustOrbitTrapFactor(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_OrbitTrapFactor += offset;
                        break;
                    case Editing.Exterior:
                        E_OrbitTrapFactor += offset;
                        break;
                    default:
                        OrbitTrapFactor += offset;
                        break;
                }
            }

            public void SetDomainCalculation(Calculation domainCalculation)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_DomainCalculation = domainCalculation;
                        break;
                    case Editing.Exterior:
                        E_DomainCalculation = domainCalculation;
                        break;
                    default:
                        DomainCalculation = domainCalculation;
                        break;
                }
            }
            
            public void SetUseDomainIteration(bool useDomainIteration)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_UseDomainIteration = useDomainIteration;
                        break;
                    case Editing.Exterior:
                        E_UseDomainIteration = useDomainIteration;
                        break;
                    default:
                        UseDomainIteration = useDomainIteration;
                        break;
                }
            }
            
            public void SetUseSecondDomainValue(bool useSecondDomainValue)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_UseSecondDomainValue = useSecondDomainValue;
                        break;
                    case Editing.Exterior:
                        E_UseSecondDomainValue = useSecondDomainValue;
                        break;
                    default:
                        UseSecondDomainValue = useSecondDomainValue;
                        break;
                }
            }
            
            public void SetMatchOrbitTrap(bool matchOrbitTrap)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_MatchOrbitTrap = matchOrbitTrap;
                        break;
                    case Editing.Exterior:
                        E_MatchOrbitTrap = matchOrbitTrap;
                        break;
                    default:
                        MatchOrbitTrap = matchOrbitTrap;
                        break;
                }
            }

            public Vector2 Center;
            public float Zoom;
            public float LockedZoom;

            public Type Type;
            public Formula Formula;
            public FloatBounds InitialDisplayRadius;
            public bool IsJulia;
            public bool IsJuliaCentered;
            public Vector2 Julia;
            public Vector2 JuliaMating;
            public bool IsConjugate;
            public bool IsBuddhabrot;
            public Buddhabrot buddhabrot;
            public IntBounds MaxIterations;
            public IntBounds MinIterations;
            public float Power;
            public float C_Power;
            public FloatBounds FoldAngle;
            public IntBounds FoldCount;
            public Vector4 FoldOffset;

            public OrbitTrap OrbitTrap;
            public Projection Projection;
            public Calculation OrbitTrapCalculation;
            public IntBounds StartOrbit;
            public IntBounds OrbitRange;
            public float Bailout;
            public FloatBounds StartOrbitDistance;
            public Vector2 BailoutRectangle;
            public Vector2[] BailoutPoints;
            public int BailoutPointsCount;
            public Vector4[] BailoutLines;
            public int BailoutLinesCount;
            public float BailoutFactor1;
            public float BailoutFactor2;
            public bool UseSecondValue;
            public float SecondValueFactor1;
            public float SecondValueFactor2;

            public Editing EditingColor;

            public Coloring Coloring;
            public float ColorCycles;
            public float ColorFactor;
            public float OrbitTrapFactor;
            public Calculation DomainCalculation;
            public bool UseSecondDomainValue;
            public float SecondDomainValueFactor1;
            public float SecondDomainValueFactor2;
            public bool MatchOrbitTrap;
            public bool UseDomainIteration;
            public bool UseDistanceEstimation;
            public float MaxDistance;
            public float DistFineness;
            public string Texture;
            public float TextureBlend;

            public Coloring I_Coloring;
            public float I_ColorCycles;
            public float I_ColorFactor;
            public float I_OrbitTrapFactor;
            public Calculation I_DomainCalculation;
            public bool I_UseSecondDomainValue;
            public float I_SecondDomainValueFactor1;
            public float I_SecondDomainValueFactor2;
            public bool I_MatchOrbitTrap;
            public bool I_UseDomainIteration;
            public bool I_UseDistanceEstimation;
            public float I_MaxDistance;
            public float I_DistFineness;
            public string I_Texture;
            public float I_TextureBlend;

            public Coloring E_Coloring;
            public float E_ColorCycles;
            public float E_ColorFactor;
            public float E_OrbitTrapFactor;
            public Calculation E_DomainCalculation;
            public bool E_UseSecondDomainValue;
            public float E_SecondDomainValueFactor1;
            public float E_SecondDomainValueFactor2;
            public bool E_MatchOrbitTrap;
            public bool E_UseDomainIteration;
            public bool E_UseDistanceEstimation;
            public float E_MaxDistance;
            public float E_DistFineness;
            public string E_Texture;
            public float E_TextureBlend;

            public bool UseLighting;
            public bool UseTerrainColor;
            public FloatBounds TerrainHeight;

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
