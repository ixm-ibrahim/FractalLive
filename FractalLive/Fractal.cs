using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalLive
{
    public class Fractal
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
            Custom = -1, Black = 0, White = 1, Iteration = 2, Smooth = 3, Stripes = 4, Domain_1 = 5, Domain_2 = 6, Domain_3 = 7, Domain_4 = 8, Domain_5 = 9, Domain_6 = 10, Domain_7 = 11
        }

        public enum OrbitTrap
        {
            Custom = -1, Circle = 0, Square = 1, Real = 2, Imaginary = 3, Rectangle = 4, Points = 5, Lines = 6, COUNT
        }

        public enum Projection
        {
            Cartesian, Riemann_Flat, Riemann_Sphere
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
                Center = Vector2.Zero;
                RiemannAngles = Vector2.Zero;

                Type = type;
                Formula = formula;
                InitialDisplayRadius = new FloatBounds(2, .01f, 100);
                Projection = Projection.Cartesian;
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
                FoldCount = 0;
                FoldAngle = 0;
                FoldOffset = new Vector2(0,0);

                OrbitTrap = OrbitTrap.Circle;
                Bailout = 100;
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
                UseCustomPalette = false;
                CustomPalette = new Color[6];
                CustomPalette[0] = Color.Red;
                CustomPalette[1] = Color.Orange;
                CustomPalette[2] = Color.Yellow;
                CustomPalette[3] = Color.Green;
                CustomPalette[4] = Color.Blue;
                CustomPalette[5] = Color.Purple;
                ColorCycles = 1;
                ColorFactor = 6;
                OrbitTrapFactor = 10;
                DomainCalculation = Calculation.Last;
                UseSecondDomainValue = false;
                SecondDomainValueFactor1 = 10;
                SecondDomainValueFactor2 = 7;
                MatchOrbitTrap = false;
                UseDomainIteration = false;
                UseDistanceEstimation = false;
                MaxDistanceEstimation = 100;
                DistanceEstimationFactor = 10;
                Texture = "";
                TextureBlend = 0.5f;
                TextureScaleX = 1;
                TextureScaleY = 1;

                I_Coloring = Coloring.Smooth;
                I_UseCustomPalette = false;
                I_CustomPalette = new Color[6];
                I_CustomPalette[0] = Color.Red;
                I_CustomPalette[1] = Color.Orange;
                I_CustomPalette[2] = Color.Yellow;
                I_CustomPalette[3] = Color.Green;
                I_CustomPalette[4] = Color.Blue;
                I_CustomPalette[5] = Color.Purple;
                I_ColorCycles = 1;
                I_ColorFactor = 6;
                I_OrbitTrapFactor = 10;
                I_DomainCalculation = Calculation.Last;
                I_UseSecondDomainValue = false;
                I_SecondDomainValueFactor1 = 10;
                I_SecondDomainValueFactor2 = 7;
                I_MatchOrbitTrap = false;
                I_UseDomainIteration = false;
                I_UseDistanceEstimation = false;
                I_MaxDistanceEstimation = 100;
                I_DistanceEstimationFactor = 10;
                I_Texture = "";
                I_TextureBlend = 0.5f;
                I_TextureScaleX = 1;
                I_TextureScaleY = 1;

                E_Coloring = Coloring.Smooth;
                E_UseCustomPalette = false;
                E_CustomPalette = new Color[6];
                E_CustomPalette[0] = Color.Red;
                E_CustomPalette[1] = Color.Orange;
                E_CustomPalette[2] = Color.Yellow;
                E_CustomPalette[3] = Color.Green;
                E_CustomPalette[4] = Color.Blue;
                E_CustomPalette[5] = Color.Purple;
                E_ColorCycles = 1;
                E_ColorFactor = 6;
                E_OrbitTrapFactor = 10;
                E_UseSecondDomainValue = false;
                E_SecondDomainValueFactor1 = 10;
                E_SecondDomainValueFactor2 = 7;
                E_UseDomainIteration = false;
                E_Texture = "";
                E_TextureBlend = 0.5f;
                E_TextureScaleX = 1;
                E_TextureScaleY = 1;

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
                    case Editing.Exterior:
                        return E_Coloring;
                    default:
                        return Coloring;
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

            public bool GetUseCustomPalette()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_UseCustomPalette;
                    case Editing.Exterior:
                        return E_UseCustomPalette;
                    default:
                        return UseCustomPalette;
                }
            }
            public void SetUseCustomPalette(bool useCustomPalette)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_UseCustomPalette = useCustomPalette;
                        break;
                    case Editing.Exterior:
                        E_UseCustomPalette = useCustomPalette;
                        break;
                    default:
                        UseCustomPalette = useCustomPalette;
                        break;
                }
            }

            public Color GetCustomPalette(int index)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_CustomPalette[index];
                    case Editing.Exterior:
                        return E_CustomPalette[index];
                    default:
                        return CustomPalette[index];
                }
            }
            public void SetCustomPalette(int index, Color color)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_CustomPalette[index] = color;
                        break;
                    case Editing.Exterior:
                        E_CustomPalette[index] = color;
                        break;
                    default:
                        CustomPalette[index] = color;
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

            public Calculation GetDomainCalculation()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_DomainCalculation;
                    case Editing.Exterior:
                        return I_DomainCalculation;
                    default:
                        return DomainCalculation;
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
                        I_DomainCalculation = domainCalculation;
                        break;
                    default:
                        DomainCalculation = domainCalculation;
                        break;
                }
            }
            
            public bool GetUseDomainIteration()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_UseDomainIteration;
                    case Editing.Exterior:
                        return E_UseDomainIteration;
                    default:
                        return UseDomainIteration;
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

            public bool GetUseSecondDomainValue()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_UseSecondDomainValue;
                    case Editing.Exterior:
                        return E_UseSecondDomainValue;
                    default:
                        return UseSecondDomainValue;
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

            public float GetSecondDomainValueFactor1()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_SecondDomainValueFactor1;
                    case Editing.Exterior:
                        return E_SecondDomainValueFactor1;
                    default:
                        return SecondDomainValueFactor1;
                }
            }
            public void SetSecondDomainValueFactor1(float secondDomainValueFactor1)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_SecondDomainValueFactor1 = secondDomainValueFactor1;
                        break;
                    case Editing.Exterior:
                        E_SecondDomainValueFactor1 = secondDomainValueFactor1;
                        break;
                    default:
                        SecondDomainValueFactor1 = secondDomainValueFactor1;
                        break;
                }
            }
            public void AdjustSecondDomainValueFactor1(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_SecondDomainValueFactor1 += offset;
                        break;
                    case Editing.Exterior:
                        E_SecondDomainValueFactor1 += offset;
                        break;
                    default:
                        SecondDomainValueFactor1 += offset;
                        break;
                }
            }

            public float GetSecondDomainValueFactor2()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_SecondDomainValueFactor2;
                    case Editing.Exterior:
                        return E_SecondDomainValueFactor2;
                    default:
                        return SecondDomainValueFactor2;
                }
            }
            public void SetSecondDomainValueFactor2(float secondDomainValueFactor2)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_SecondDomainValueFactor2 = secondDomainValueFactor2;
                        break;
                    case Editing.Exterior:
                        E_SecondDomainValueFactor2 = secondDomainValueFactor2;
                        break;
                    default:
                        SecondDomainValueFactor2 = secondDomainValueFactor2;
                        break;
                }
            }
            public void AdjustSecondDomainValueFactor2(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_SecondDomainValueFactor2 += offset;
                        break;
                    case Editing.Exterior:
                        E_SecondDomainValueFactor2 += offset;
                        break;
                    default:
                        SecondDomainValueFactor2 += offset;
                        break;
                }
            }

            public bool GetMatchOrbitTrap()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_MatchOrbitTrap;
                    case Editing.Exterior:
                        return I_MatchOrbitTrap;
                    default:
                        return MatchOrbitTrap;
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
                        I_MatchOrbitTrap = matchOrbitTrap;
                        break;
                    default:
                        MatchOrbitTrap = matchOrbitTrap;
                        break;
                }
            }
            
            public bool GetUseDistanceEstimation()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_UseDistanceEstimation;
                    case Editing.Exterior:
                        return I_UseDistanceEstimation;
                    default:
                        return UseDistanceEstimation;
                }
            }
            public void SetUseDistanceEstimation(bool useDistanceEstimation)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_UseDistanceEstimation = useDistanceEstimation;
                        break;
                    case Editing.Exterior:
                        I_UseDistanceEstimation = useDistanceEstimation;
                        break;
                    default:
                        UseDistanceEstimation = useDistanceEstimation;
                        break;
                }
            }

            public float GetMaxDistanceEstimation()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_MaxDistanceEstimation;
                    case Editing.Exterior:
                        return I_MaxDistanceEstimation;
                    default:
                        return MaxDistanceEstimation;
                }
            }
            public void SetMaxDistanceEstimation(float maxDistanceEstimation)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_MaxDistanceEstimation = maxDistanceEstimation;
                        break;
                    case Editing.Exterior:
                        I_MaxDistanceEstimation = maxDistanceEstimation;
                        break;
                    default:
                        MaxDistanceEstimation = maxDistanceEstimation;
                        break;
                }
            }
            public void AdjustMaxDistanceEstimation(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_MaxDistanceEstimation += offset;
                        break;
                    case Editing.Exterior:
                        I_MaxDistanceEstimation += offset;
                        break;
                    default:
                        MaxDistanceEstimation += offset;
                        break;
                }
            }
            
            public float GetDistanceEstimationFactor()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_DistanceEstimationFactor;
                    case Editing.Exterior:
                        return I_DistanceEstimationFactor;
                    default:
                        return DistanceEstimationFactor;
                }
            }
            public void SetDistanceEstimationFactor(float distanceEstimationFactor)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_DistanceEstimationFactor = distanceEstimationFactor;
                        break;
                    case Editing.Exterior:
                        I_DistanceEstimationFactor = distanceEstimationFactor;
                        break;
                    default:
                        DistanceEstimationFactor = distanceEstimationFactor;
                        break;
                }
            }
            public void AdjustDistanceEstimationFactor(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_DistanceEstimationFactor += offset;
                        break;
                    case Editing.Exterior:
                        I_DistanceEstimationFactor += offset;
                        break;
                    default:
                        DistanceEstimationFactor += offset;
                        break;
                }
            }

            public string GetTexture()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_Texture;
                    case Editing.Exterior:
                        return E_Texture;
                    default:
                        return Texture;
                }
            }
            public void SetTexture(string texture)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_Texture = texture;
                        break;
                    case Editing.Exterior:
                        E_Texture = texture;
                        break;
                    default:
                        Texture = texture;
                        break;
                }
            }

            public float GetTextureBlend()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_TextureBlend;
                        break;
                    case Editing.Exterior:
                        return E_TextureBlend;
                        break;
                    default:
                        return TextureBlend;
                        break;
                }
            }
            public void SetTextureBlend(float textureBlend)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_TextureBlend = textureBlend;
                        break;
                    case Editing.Exterior:
                        E_TextureBlend = textureBlend;
                        break;
                    default:
                        TextureBlend = textureBlend;
                        break;
                }
            }
            public void AdjustTextureBlend(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_TextureBlend += offset;
                        break;
                    case Editing.Exterior:
                        E_TextureBlend += offset;
                        break;
                    default:
                        TextureBlend += offset;
                        break;
                }
            }

            public float GetTextureScaleX()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_TextureScaleX;
                    case Editing.Exterior:
                        return E_TextureScaleX;
                    default:
                        return TextureScaleX;
                }
            }
            public void SetTextureScaleX(float textureScaleX)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_TextureScaleX = textureScaleX;
                        break;
                    case Editing.Exterior:
                        E_TextureScaleX = textureScaleX;
                        break;
                    default:
                        TextureScaleX = textureScaleX;
                        break;
                }
            }
            public void AdjustTextureScaleX(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_TextureScaleX += offset;
                        break;
                    case Editing.Exterior:
                        E_TextureScaleX += offset;
                        break;
                    default:
                        TextureScaleX += offset;
                        break;
                }
            }

            public float GetTextureScaleY()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_TextureScaleY;
                    case Editing.Exterior:
                        return E_TextureScaleY;
                    default:
                        return TextureScaleY;
                }
            }
            public void SetTextureScaleY(float textureScaleY)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_TextureScaleY = textureScaleY;
                        break;
                    case Editing.Exterior:
                        E_TextureScaleY = textureScaleY;
                        break;
                    default:
                        TextureScaleY = textureScaleY;
                        break;
                }
            }
            public void AdjustTextureScaleY(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_TextureScaleY += offset;
                        break;
                    case Editing.Exterior:
                        E_TextureScaleY += offset;
                        break;
                    default:
                        TextureScaleY += offset;
                        break;
                }
            }

            public Vector2 Center;
            public float Zoom;
            public float LockedZoom;
            public Vector2 RiemannAngles;

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
            public float FoldCount;
            public float FoldAngle;
            public Vector2 FoldOffset;

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
            public bool UseCustomPalette;
            public Color[] CustomPalette;
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
            public float MaxDistanceEstimation;
            public float DistanceEstimationFactor;
            public string Texture;
            public float TextureBlend;
            public float TextureScaleX;
            public float TextureScaleY;

            public Coloring I_Coloring;
            public bool I_UseCustomPalette;
            public Color[] I_CustomPalette;
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
            public float I_MaxDistanceEstimation;
            public float I_DistanceEstimationFactor;
            public string I_Texture;
            public float I_TextureBlend;
            public float I_TextureScaleX;
            public float I_TextureScaleY;

            public Coloring E_Coloring;
            public bool E_UseCustomPalette;
            public Color[] E_CustomPalette;
            public float E_ColorCycles;
            public float E_ColorFactor;
            public float E_OrbitTrapFactor;
            //public Calculation E_DomainCalculation;
            public bool E_UseSecondDomainValue;
            public float E_SecondDomainValueFactor1;
            public float E_SecondDomainValueFactor2;
            //public bool I_MatchOrbitTrap;
            public bool E_UseDomainIteration;
            //public bool I_UseDistanceEstimation;
            //public float I_MaxDistanceEstimation;
            //public float I_DistanceEstimationFactor;
            public string E_Texture;
            public float E_TextureBlend;
            public float E_TextureScaleX;
            public float E_TextureScaleY;

            public bool UseLighting;
            public bool UseTerrainColor;
            public FloatBounds TerrainHeight;

        }
        #endregion

        #region Constants
        const double maxVal = 1e99;
        const double minVal = 1e-99;
        #endregion
    }
}
