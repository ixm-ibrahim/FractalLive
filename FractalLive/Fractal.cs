using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FractalLive
{
    public class Fractal
    {
        #region Enumerations
        public enum Type
        {
            Mandelbrot = 0, Julia = 1, Julia_Mating = 2
        }

        public enum Formula
        {
            Mandelbrot = 0, Lambda = 1, Custom = 2
        }

        public enum Buddhabrot
        {
            Normal, Inverse, Nebulabrot
        }

        // Note: the higher the bailout, the more dense the domain lines
        public enum Coloring
        {
            Black = 0, White = 1, Iteration = 2, Smooth = 3, Stripes_1 = 4, Stripes_2 = 5, Domain_1 = 6, Domain_2 = 7, Domain_3 = 8, Domain_4 = 9, Domain_5 = 10, Domain_6 = 11, Domain_7 = 12, Custom = 13
        }

        public enum OrbitTrap
        {
            Circle = 0, Square = 1, Real = 2, Imaginary = 3, Rectangle = 4, Spiral = 5, Points = 6, Lines = 7, Custom = 8
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
            Minimum = 0, Maximum = 1, Average = 2, First = 3, Last = 4
        }

        public enum Animation
        {
            Julia, Julia_Mating, OrbitTrap, Texture, Normals, Custom
        }

        public enum JuliaAnimation
        {
            Circle, Main_Cardioid, Main_Disk, Period_3_Cardioid, Period_3_Disk, Custom
        }

        #endregion

        #region Structures
        public struct Settings
        {
            public Settings(Type type = Type.Mandelbrot, Formula formula = Formula.Mandelbrot)
            {
                Zoom = 0;
                LockedZoom = 0;
                Center = Vector2.Zero;
                RiemannAngles = Vector2.Zero;

                InitialDisplayRadius = new FloatBounds(2, .01f, 100);

                Type = type;
                Formula = formula;
                Projection = Projection.Cartesian;
                Julia = new Vector2(-0.4f, 0.6f);
                JuliaMating1 = new Vector2(-1, 0);
                JuliaMating2 = new Vector2(-.123f, .745f);
                //JuliaMating1 = new Vector2(-.835046398f, -.231926809f);
                //JuliaMating2 = new Vector2(.284884537f, -.011121822f);
                //JuliaMating2 = new Vector2(0.285f, 0.01f);
                MatingIterations = 25;
                IntermediateMatingSteps = 16;
                CurrentMatingStep = -1;
                MaxIterations = new IntBounds(100, 1, 9999);
                MinIterations = new IntBounds(1, 1, 9999);
                UseConjugate = false;
                StartPosition = Vector2.Zero;
                C_Power = new Vector2(1, 0);
                Power = new Vector2(2, 0);
                FoldCount = 0;
                FoldAngle = 0;
                FoldOffset = new Vector2(0, 0);
                UseBuddhabrot = false;
                buddhabrotType = Buddhabrot.Normal;

                OrbitTrap = OrbitTrap.Circle;
                Bailout = 2;
                OrbitTrapCalculation = Calculation.Minimum;
                BailoutRectangle = new Vector2(2, 2);
                BailoutSpiral = new Vector4(0, 0, 0, 1);
                BailoutPoints = new Vector2[16];
                BailoutPoints[0] = Vector2.Zero;
                BailoutPointsCount = 1;
                BailoutLines = new Vector4[16];
                BailoutLines[0] = new Vector4(0, 0, 0, 1);
                BailoutLines[1] = new Vector4(0, 0, 1, 0);
                //BailoutLine = new Vector4(-8,-9.5f,-2,-3);
                BailoutTexture = "";
                BailoutTextureBlend = 0.5f;
                BailoutTextureScaleX = 1;
                BailoutTextureScaleY = 1;
                BailoutUsePolarTextureCoordinates = false;
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
                StripeDensity = 5;
                DomainCalculation = Calculation.Last;
                UseSecondDomainValue = false;
                SecondDomainValueFactor1 = 10;
                SecondDomainValueFactor2 = 7;
                MatchOrbitTrap = false;
                UseDomainIteration = false;
                UseDistanceEstimation = false;
                MaxDistanceEstimation = 100;
                DistanceEstimationFactor1 = 10;
                DistanceEstimationFactor2 = 6;
                UseNormals = false;
                Texture = "";
                TextureBlend = 0.5f;
                TextureScaleX = 1;
                TextureScaleY = 1;
                UsePolarTextureCoordinates = false;
                UseTextureDistortion = false;
                TextureDistortion = 5;

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
                I_StripeDensity = 5;
                I_DomainCalculation = Calculation.Last;
                I_UseSecondDomainValue = false;
                I_SecondDomainValueFactor1 = 10;
                I_SecondDomainValueFactor2 = 7;
                I_MatchOrbitTrap = false;
                I_UseDomainIteration = false;
                I_UseDistanceEstimation = false;
                I_MaxDistanceEstimation = 100;
                I_DistanceEstimationFactor1 = 10;
                I_DistanceEstimationFactor2 = 6;
                I_UseNormals = false;
                I_Texture = "";
                I_TextureBlend = 0.5f;
                I_TextureScaleX = 1;
                I_TextureScaleY = 1;
                I_UsePolarTextureCoordinates = false;
                I_UseTextureDistortion = false;
                I_TextureDistortion = 5;

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
                E_StripeDensity = 5;
                E_UseSecondDomainValue = false;
                E_SecondDomainValueFactor1 = 10;
                E_SecondDomainValueFactor2 = 7;
                E_UseDomainIteration = false;
                E_Texture = "";
                E_TextureBlend = 0.5f;
                E_TextureScaleX = 1;
                E_TextureScaleY = 1;
                E_UsePolarTextureCoordinates = false;
                E_UseTextureDistortion = false;
                E_TextureDistortion = 5;

                UseTerrainColor = false;
                TerrainHeight = new FloatBounds(0, (float)-maxVal, (float)maxVal);

                EditingAnimation = Animation.Julia;
                IsJuliaAnimationEnabled = false;
                JuliaAnimationSpeed = 1;
                UsePeriodicPoint = false;
            }

            public bool Is1DBailout => OrbitTrap >= OrbitTrap.Circle && OrbitTrap <= OrbitTrap.Imaginary;
            public bool Is2DBailout => OrbitTrap == OrbitTrap.Rectangle || OrbitTrap == OrbitTrap.Points;
            public bool Is3DBailout => OrbitTrap == OrbitTrap.Spiral;
            public bool IsDistanceBailout => OrbitTrap >= OrbitTrap.Points && OrbitTrap <= OrbitTrap.Lines;
            
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

            #region Color Menu
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
            
            public float GetStripeDensity()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_StripeDensity;
                    case Editing.Exterior:
                        return E_StripeDensity;
                    default:
                        return StripeDensity;
                }
            }
            public void SetStripeDensity(float stripeDensity)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_StripeDensity = stripeDensity;
                        break;
                    case Editing.Exterior:
                        E_StripeDensity = stripeDensity;
                        break;
                    default:
                        StripeDensity = stripeDensity;
                        break;
                }
            }
            public void AdjustStripeDensity(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_StripeDensity += offset;
                        break;
                    case Editing.Exterior:
                        E_StripeDensity += offset;
                        break;
                    default:
                        StripeDensity += offset;
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
            
            public float GetDistanceEstimationFactor1()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_DistanceEstimationFactor1;
                    case Editing.Exterior:
                        return I_DistanceEstimationFactor1;
                    default:
                        return DistanceEstimationFactor1;
                }
            }
            public void SetDistanceEstimationFactor1(float distanceEstimationFactor1)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_DistanceEstimationFactor1 = distanceEstimationFactor1;
                        break;
                    case Editing.Exterior:
                        I_DistanceEstimationFactor1 = distanceEstimationFactor1;
                        break;
                    default:
                        DistanceEstimationFactor1 = distanceEstimationFactor1;
                        break;
                }
            }
            public void AdjustDistanceEstimationFactor1(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_DistanceEstimationFactor1 += offset;
                        break;
                    case Editing.Exterior:
                        I_DistanceEstimationFactor1 += offset;
                        break;
                    default:
                        DistanceEstimationFactor1 += offset;
                        break;
                }
            }
            
            public float GetDistanceEstimationFactor2()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_DistanceEstimationFactor2;
                    case Editing.Exterior:
                        return I_DistanceEstimationFactor2;
                    default:
                        return DistanceEstimationFactor2;
                }
            }
            public void SetDistanceEstimationFactor2(float distanceEstimationFactor2)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_DistanceEstimationFactor2 = distanceEstimationFactor2;
                        break;
                    case Editing.Exterior:
                        I_DistanceEstimationFactor2 = distanceEstimationFactor2;
                        break;
                    default:
                        DistanceEstimationFactor2 = distanceEstimationFactor2;
                        break;
                }
            }
            public void AdjustDistanceEstimationFactor2(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_DistanceEstimationFactor2 += offset;
                        break;
                    case Editing.Exterior:
                        I_DistanceEstimationFactor2 += offset;
                        break;
                    default:
                        DistanceEstimationFactor2 += offset;
                        break;
                }
            }

            public bool GetUseNormals()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_UseNormals;
                    case Editing.Exterior:
                        return I_UseNormals;
                    default:
                        return UseNormals;
                }
            }
            public void SetUseNormals(bool useNormals)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_UseNormals = useNormals;
                        break;
                    case Editing.Exterior:
                        I_UseNormals = useNormals;
                        break;
                    default:
                        UseNormals = useNormals;
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

            public bool GetUseTextureDistortion()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_UseTextureDistortion;
                    case Editing.Exterior:
                        return E_UseTextureDistortion;
                    default:
                        return UseTextureDistortion;
                }
            }
            public void SetUseTextureDistortion(bool useTextureDistortion)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_UseTextureDistortion = useTextureDistortion;
                        break;
                    case Editing.Exterior:
                        E_UseTextureDistortion = useTextureDistortion;
                        break;
                    default:
                        UseTextureDistortion = useTextureDistortion;
                        break;
                }
            }
            
            public bool GetUsePolarTextureCoordinates()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_UsePolarTextureCoordinates;
                    case Editing.Exterior:
                        return E_UsePolarTextureCoordinates;
                    default:
                        return UsePolarTextureCoordinates;
                }
            }
            public void SetUsePolarTextureCoordinates(bool usePolarTextureCoordinates)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_UsePolarTextureCoordinates = usePolarTextureCoordinates;
                        break;
                    case Editing.Exterior:
                        E_UsePolarTextureCoordinates = usePolarTextureCoordinates;
                        break;
                    default:
                        UsePolarTextureCoordinates = usePolarTextureCoordinates;
                        break;
                }
            }

            public float GetTextureDistortion()
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        return I_TextureDistortion;
                    case Editing.Exterior:
                        return I_TextureDistortion;
                    default:
                        return TextureDistortion;
                }
            }
            public void SetTextureDistortion(float textureDistortion)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_TextureDistortion = textureDistortion;
                        break;
                    case Editing.Exterior:
                        I_TextureDistortion = textureDistortion;
                        break;
                    default:
                        TextureDistortion = textureDistortion;
                        break;
                }
            }
            public void AdjustTextureDistortion(float offset)
            {
                switch (EditingColor)
                {
                    case Editing.Interior:
                        I_TextureDistortion += offset;
                        break;
                    case Editing.Exterior:
                        I_TextureDistortion += offset;
                        break;
                    default:
                        TextureDistortion += offset;
                        break;
                }
            }
            #endregion

            public Vector2 Center;
            public float Zoom;
            public float LockedZoom;
            public Vector2 RiemannAngles;

            public FloatBounds InitialDisplayRadius;

            public Type Type;
            public Formula Formula;
            public Vector2 Julia;
            public Vector2 JuliaMating1;
            public Vector2 JuliaMating2;
            public int MatingIterations;
            public int IntermediateMatingSteps;
            public int CurrentMatingStep;
            public IntBounds MaxIterations;
            public IntBounds MinIterations;
            public bool UseConjugate;
            public Vector2 StartPosition;
            public Vector2 Power;
            public Vector2 C_Power;
            public float FoldCount;
            public float FoldAngle;
            public Vector2 FoldOffset;
            public bool UseBuddhabrot;
            public Buddhabrot buddhabrotType;

            public OrbitTrap OrbitTrap;
            public Projection Projection;
            public Calculation OrbitTrapCalculation;
            public IntBounds StartOrbit;
            public IntBounds OrbitRange;
            public float Bailout;
            public FloatBounds StartOrbitDistance;
            public Vector2 BailoutRectangle;
            public Vector4 BailoutSpiral;
            public Vector2[] BailoutPoints;
            public int BailoutPointsCount;
            public Vector4[] BailoutLines;
            public int BailoutLinesCount;
            public string BailoutTexture;
            public float BailoutTextureBlend;
            public float BailoutTextureScaleX;
            public float BailoutTextureScaleY;
            public bool BailoutUsePolarTextureCoordinates;
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
            public float StripeDensity;
            public Calculation DomainCalculation;
            public bool UseSecondDomainValue;
            public float SecondDomainValueFactor1;
            public float SecondDomainValueFactor2;
            public bool MatchOrbitTrap;
            public bool UseDomainIteration;
            public bool UseDistanceEstimation;
            public float MaxDistanceEstimation;
            public float DistanceEstimationFactor1;
            public float DistanceEstimationFactor2;
            public bool UseNormals;
            public string Texture;
            public float TextureBlend;
            public float TextureScaleX;
            public float TextureScaleY;
            public bool UsePolarTextureCoordinates;
            public bool UseTextureDistortion;
            public float TextureDistortion;

            public Coloring I_Coloring;
            public bool I_UseCustomPalette;
            public Color[] I_CustomPalette;
            public float I_ColorCycles;
            public float I_ColorFactor;
            public float I_OrbitTrapFactor;
            public float I_StripeDensity;
            public Calculation I_DomainCalculation;
            public bool I_UseSecondDomainValue;
            public float I_SecondDomainValueFactor1;
            public float I_SecondDomainValueFactor2;
            public bool I_MatchOrbitTrap;
            public bool I_UseDomainIteration;
            public bool I_UseDistanceEstimation;
            public float I_MaxDistanceEstimation;
            public float I_DistanceEstimationFactor1;
            public float I_DistanceEstimationFactor2;
            public bool I_UseNormals;
            public string I_Texture;
            public float I_TextureBlend;
            public float I_TextureScaleX;
            public float I_TextureScaleY;
            public bool I_UsePolarTextureCoordinates;
            public bool I_UseTextureDistortion;
            public float I_TextureDistortion;

            public Coloring E_Coloring;
            public bool E_UseCustomPalette;
            public Color[] E_CustomPalette;
            public float E_ColorCycles;
            public float E_ColorFactor;
            public float E_OrbitTrapFactor;
            public float E_StripeDensity;
            //public Calculation E_DomainCalculation;
            public bool E_UseSecondDomainValue;
            public float E_SecondDomainValueFactor1;
            public float E_SecondDomainValueFactor2;
            //public bool I_MatchOrbitTrap;
            public bool E_UseDomainIteration;
            //public bool I_UseDistanceEstimation;
            //public float I_MaxDistanceEstimation;
            //public float I_DistanceEstimationFactor1;
            //public float I_DistanceEstimationFactor2;
            //public bool I_UseNormals;
            public string E_Texture;
            public float E_TextureBlend;
            public float E_TextureScaleX;
            public float E_TextureScaleY;
            public bool E_UsePolarTextureCoordinates;
            public bool E_UseTextureDistortion;
            public float E_TextureDistortion;

            public bool UseTerrainColor;
            public FloatBounds TerrainHeight;

            public Animation EditingAnimation;
            public bool IsJuliaAnimationEnabled;
            public float JuliaAnimationSpeed;
            public bool UsePeriodicPoint;

        }

        // not gonna work for riemann sphere where faces are being culled
        public struct ShaderData
        {
            int sbo;

            public void UpdateShaderBuffer(Settings settings)
            {
                bool split = settings.EditingColor != Fractal.Editing.Both;
                float[] data =
                {
                    settings.Center.X,
                    settings.Center.Y,
                    settings.Zoom,
                    settings.LockedZoom,
                    (float) settings.Projection,
                    settings.RiemannAngles.X,
                    settings.RiemannAngles.Y,

                    (float) settings.Type,
                    (float) settings.Formula,
                    settings.InitialDisplayRadius.Value,
                    settings.UsePeriodicPoint ? 1 : 0,
                    settings.Julia.X,
                    settings.Julia.Y,
                    settings.JuliaMating1.X,
                    settings.JuliaMating1.Y,
                    settings.MaxIterations.Value,
                    settings.MinIterations.Value,
                    settings.StartPosition.X,
                    settings.StartPosition.Y,
                    settings.Power.X,
                    settings.Power.Y,
                    settings.C_Power.X,
                    settings.C_Power.Y,
                    settings.FoldCount,
                    settings.FoldAngle,
                    settings.FoldOffset.X,
                    settings.FoldOffset.Y,
                    settings.UseConjugate ? 1 : 0,
                    settings.UseBuddhabrot ? 1 : 0,
                    (float) settings.buddhabrotType,


                    (float) settings.OrbitTrap,
                    (float) settings.OrbitTrapCalculation,
                    settings.StartOrbit.Value,
                    settings.OrbitRange.Value,
                    settings.Bailout,
                    settings.StartOrbitDistance.Value,
                    settings.BailoutRectangle.X,
                    settings.BailoutRectangle.Y,
                    settings.BailoutPointsCount,
                    settings.BailoutPoints[0].X,
                    settings.BailoutPoints[0].Y,
                    settings.BailoutPoints[1].X,
                    settings.BailoutPoints[1].Y,
                    settings.BailoutPoints[2].X,
                    settings.BailoutPoints[2].Y,
                    settings.BailoutPoints[3].X,
                    settings.BailoutPoints[3].Y,
                    settings.BailoutPoints[4].X,
                    settings.BailoutPoints[4].Y,
                    settings.BailoutPoints[5].X,
                    settings.BailoutPoints[5].Y,
                    settings.BailoutPoints[6].X,
                    settings.BailoutPoints[6].Y,
                    settings.BailoutPoints[7].X,
                    settings.BailoutPoints[7].Y,
                    settings.BailoutPoints[8].X,
                    settings.BailoutPoints[8].Y,
                    settings.BailoutPoints[9].X,
                    settings.BailoutPoints[9].Y,
                    settings.BailoutPoints[10].X,
                    settings.BailoutPoints[10].Y,
                    settings.BailoutPoints[11].X,
                    settings.BailoutPoints[11].Y,
                    settings.BailoutPoints[12].X,
                    settings.BailoutPoints[12].Y,
                    settings.BailoutPoints[13].X,
                    settings.BailoutPoints[13].Y,
                    settings.BailoutPoints[14].X,
                    settings.BailoutPoints[14].Y,
                    settings.BailoutPoints[15].X,
                    settings.BailoutPoints[15].Y,
                    settings.BailoutLinesCount,
                    settings.BailoutLines[0].X,
                    settings.BailoutLines[0].Y,
                    settings.BailoutLines[0].Z,
                    settings.BailoutLines[0].W,
                    settings.BailoutLines[1].X,
                    settings.BailoutLines[1].Y,
                    settings.BailoutLines[1].Z,
                    settings.BailoutLines[1].W,
                    settings.BailoutLines[2].X,
                    settings.BailoutLines[2].Y,
                    settings.BailoutLines[2].Z,
                    settings.BailoutLines[2].W,
                    settings.BailoutLines[3].X,
                    settings.BailoutLines[3].Y,
                    settings.BailoutLines[3].Z,
                    settings.BailoutLines[3].W,
                    settings.BailoutLines[4].X,
                    settings.BailoutLines[4].Y,
                    settings.BailoutLines[4].Z,
                    settings.BailoutLines[4].W,
                    settings.BailoutLines[5].X,
                    settings.BailoutLines[5].Y,
                    settings.BailoutLines[5].Z,
                    settings.BailoutLines[5].W,
                    settings.BailoutLines[6].X,
                    settings.BailoutLines[6].Y,
                    settings.BailoutLines[6].Z,
                    settings.BailoutLines[6].W,
                    settings.BailoutLines[7].X,
                    settings.BailoutLines[7].Y,
                    settings.BailoutLines[7].Z,
                    settings.BailoutLines[7].W,
                    settings.BailoutLines[8].X,
                    settings.BailoutLines[8].Y,
                    settings.BailoutLines[8].Z,
                    settings.BailoutLines[8].W,
                    settings.BailoutLines[9].X,
                    settings.BailoutLines[9].Y,
                    settings.BailoutLines[9].Z,
                    settings.BailoutLines[9].W,
                    settings.BailoutLines[10].X,
                    settings.BailoutLines[10].Y,
                    settings.BailoutLines[10].Z,
                    settings.BailoutLines[10].W,
                    settings.BailoutLines[11].X,
                    settings.BailoutLines[11].Y,
                    settings.BailoutLines[11].Z,
                    settings.BailoutLines[11].W,
                    settings.BailoutLines[12].X,
                    settings.BailoutLines[12].Y,
                    settings.BailoutLines[12].Z,
                    settings.BailoutLines[12].W,
                    settings.BailoutLines[13].X,
                    settings.BailoutLines[13].Y,
                    settings.BailoutLines[13].Z,
                    settings.BailoutLines[13].W,
                    settings.BailoutLines[14].X,
                    settings.BailoutLines[14].Y,
                    settings.BailoutLines[14].Z,
                    settings.BailoutLines[14].W,
                    settings.BailoutLines[15].X,
                    settings.BailoutLines[15].Y,
                    settings.BailoutLines[15].Z,
                    settings.BailoutLines[15].W,
                    settings.BailoutFactor1,
                    settings.BailoutFactor2,
                    settings.UseSecondValue ? 1 : 0,
                    settings.SecondValueFactor1,
                    settings.SecondValueFactor2,

                    split ? 1 : 0,
                };
                

            }


            /*
            [FieldOffset(6 * sizeof(float))]
            public float EditingColor;

            [FieldOffset(6 * sizeof(float))]
            public float Coloring;
            [FieldOffset(6 * sizeof(float))]
            public float UseCustomPalette;
            [FieldOffset(6 * sizeof(float))]
            public Color[] CustomPalette;
            [FieldOffset(6 * sizeof(float))]
            public float ColorCycles;
            [FieldOffset(6 * sizeof(float))]
            public float ColorFactor;
            [FieldOffset(6 * sizeof(float))]
            public float OrbitTrapFactor;
            [FieldOffset(6 * sizeof(float))]
            public float StripeDensity;
            [FieldOffset(6 * sizeof(float))]
            public float DomainCalculation;
            [FieldOffset(6 * sizeof(float))]
            public float UseSecondDomainValue;
            [FieldOffset(6 * sizeof(float))]
            public float SecondDomainValueFactor1;
            [FieldOffset(6 * sizeof(float))]
            public float SecondDomainValueFactor2;
            [FieldOffset(6 * sizeof(float))]
            public float MatchOrbitTrap;
            [FieldOffset(6 * sizeof(float))]
            public float UseDomainIteration;
            [FieldOffset(6 * sizeof(float))]
            public float UseDistanceEstimation;
            [FieldOffset(6 * sizeof(float))]
            public float MaxDistanceEstimation;
            [FieldOffset(6 * sizeof(float))]
            public float DistanceEstimationFactor1;
            [FieldOffset(6 * sizeof(float))]
            public float DistanceEstimationFactor2;
            [FieldOffset(6 * sizeof(float))]
            public float UseNormals;
            [FieldOffset(6 * sizeof(float))]
            public string Texture;
            [FieldOffset(6 * sizeof(float))]
            public float TextureBlend;
            [FieldOffset(6 * sizeof(float))]
            public float TextureScaleX;
            [FieldOffset(6 * sizeof(float))]
            public float TextureScaleY;
            [FieldOffset(6 * sizeof(float))]
            public float UsePolarTextureCoordinates;
            [FieldOffset(6 * sizeof(float))]
            public float UseTextureDistortion;
            [FieldOffset(6 * sizeof(float))]
            public float TextureDistortion;

            [FieldOffset(6 * sizeof(float))]
            public float I_Coloring;
            [FieldOffset(6 * sizeof(float))]
            public float I_UseCustomPalette;
            [FieldOffset(6 * sizeof(float))]
            public Color[] I_CustomPalette;
            [FieldOffset(6 * sizeof(float))]
            public float I_ColorCycles;
            [FieldOffset(6 * sizeof(float))]
            public float I_ColorFactor;
            [FieldOffset(6 * sizeof(float))]
            public float I_OrbitTrapFactor;
            [FieldOffset(6 * sizeof(float))]
            public float I_StripeDensity;
            [FieldOffset(6 * sizeof(float))]
            public float I_DomainCalculation;
            [FieldOffset(6 * sizeof(float))]
            public float I_UseSecondDomainValue;
            [FieldOffset(6 * sizeof(float))]
            public float I_SecondDomainValueFactor1;
            [FieldOffset(6 * sizeof(float))]
            public float I_SecondDomainValueFactor2;
            [FieldOffset(6 * sizeof(float))]
            public float I_MatchOrbitTrap;
            [FieldOffset(6 * sizeof(float))]
            public float I_UseDomainIteration;
            [FieldOffset(6 * sizeof(float))]
            public float I_UseDistanceEstimation;
            [FieldOffset(6 * sizeof(float))]
            public float I_MaxDistanceEstimation;
            [FieldOffset(6 * sizeof(float))]
            public float I_DistanceEstimationFactor1;
            [FieldOffset(6 * sizeof(float))]
            public float I_DistanceEstimationFactor2;
            [FieldOffset(6 * sizeof(float))]
            public float I_UseNormals;
            [FieldOffset(6 * sizeof(float))]
            public string I_Texture;
            [FieldOffset(6 * sizeof(float))]
            public float I_TextureBlend;
            [FieldOffset(6 * sizeof(float))]
            public float I_TextureScaleX;
            [FieldOffset(6 * sizeof(float))]
            public float I_TextureScaleY;
            [FieldOffset(6 * sizeof(float))]
            public float I_UsePolarTextureCoordinates;
            [FieldOffset(6 * sizeof(float))]
            public float I_UseTextureDistortion;
            [FieldOffset(6 * sizeof(float))]
            public float I_TextureDistortion;*/
        }
        #endregion

        #region Constants
        const double maxVal = 1e99;
        const double minVal = 1e-99;
        #endregion
    }
}
