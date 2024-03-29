﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace FractalLive
{
    public partial class MainDlg : Form
    {
        #region Structures
        public struct InputState
        {
            public void Init()
            {
                keysDown = new Dictionary<Keys, bool>();

                Focus = false;
                MouseRightDown = false;
                MouseLeftDown = false;
                PreviousMouseX = MousePosition.X;
                PreviousMouseY = MousePosition.Y;
                GLMousePositionX = 0;
                GLMousePositionY = 0;

                // modifiers
                keysDown[Keys.ControlKey] = false;
                keysDown[Keys.RControlKey] = false;
                keysDown[Keys.LControlKey] = false;
                keysDown[Keys.ShiftKey] = false;
                keysDown[Keys.RShiftKey] = false;
                keysDown[Keys.LShiftKey] = false;
                keysDown[Keys.Oemtilde] = false;    
                // projection
                keysDown[Keys.Space] = false;
                // time
                keysDown[Keys.Oemcomma] = false;
                keysDown[Keys.OemPeriod] = false;
                keysDown[Keys.OemQuestion] = false;
                // panning/movement
                keysDown[Keys.W] = false;
                keysDown[Keys.A] = false;
                keysDown[Keys.S] = false;
                keysDown[Keys.D] = false;
                keysDown[Keys.Z] = false;
                keysDown[Keys.X] = false;
                // rolling
                keysDown[Keys.Q] = false;
                keysDown[Keys.E] = false;
                // zooming
                keysDown[Keys.R] = false;
                keysDown[Keys.F] = false;
                // axes
                keysDown[Keys.OemSemicolon] = false;
                keysDown[Keys.OemQuotes] = false;
                // riemann center
                keysDown[Keys.I] = false;
                keysDown[Keys.J] = false;
                keysDown[Keys.K] = false;
                keysDown[Keys.L] = false;
                keysDown[Keys.U] = false;
                keysDown[Keys.O] = false;
                // fractal settings
                keysDown[Keys.D1] = false;
                keysDown[Keys.D2] = false;
                keysDown[Keys.D3] = false;
                keysDown[Keys.D4] = false;
                keysDown[Keys.D5] = false;
                keysDown[Keys.D6] = false;
                keysDown[Keys.D7] = false;
                keysDown[Keys.D8] = false;
                keysDown[Keys.D9] = false;
                keysDown[Keys.D0] = false;
                keysDown[Keys.OemMinus] = false;
                keysDown[Keys.Oemplus] = false;
                keysDown[Keys.Back] = false;
            }

            public bool IsKeyDown(Keys key)
            {
                return keysDown.GetValueOrDefault(key);
            }

            public bool IsMovementKeyDown()
            {
                return IsKeyDown(Keys.W) || IsKeyDown(Keys.A) || IsKeyDown(Keys.S) || IsKeyDown(Keys.D) || IsKeyDown(Keys.Q) || IsKeyDown(Keys.E) || IsKeyDown(Keys.Z) || IsKeyDown(Keys.X) || IsKeyDown(Keys.R) || IsKeyDown(Keys.F);
            }

            public bool IsSecondaryMovementKeyDown()
            {
                return IsKeyDown(Keys.I) || IsKeyDown(Keys.J) || IsKeyDown(Keys.K) || IsKeyDown(Keys.L) || IsKeyDown(Keys.U) || IsKeyDown(Keys.O);
            }

            public Dictionary<Keys, bool> keysDown;

            public bool Focus { get; set; }
            public bool MouseRightDown { get; set; }
            public bool MouseLeftDown { get; set; }
            public bool ControlDown => keysDown[Keys.ControlKey] || keysDown[Keys.RControlKey] || keysDown[Keys.LControlKey];
            public bool ShiftDown => keysDown[Keys.ShiftKey] || keysDown[Keys.RShiftKey] || keysDown[Keys.LShiftKey];
            public int PreviousMouseX { get; set; }
            public int PreviousMouseY { get; set; }
            public int GLMousePositionX { get; set; }
            public int GLMousePositionY { get; set; }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor for MainDlg
        /// </summary>
        public MainDlg()
        {
            inputState.Init();

            InitializeComponent();
        }

        #endregion

        #region Methods

        private void InitObjects()
        {
            TexturedVertex[] plane =
            {
                new TexturedVertex(-1, 1,0,0,0,0,0,1),  //  1,-1 +----+ 1,1
                new TexturedVertex(-1,-1,0,0,0,0,0,0),  //       |   /|
                new TexturedVertex( 1, 1,0,0,0,0,1,1),  //       |  / |
                new TexturedVertex(-1,-1,0,0,0,0,0,0),  //       | /  |
                new TexturedVertex( 1,-1,0,0,0,0,1,0),  //       |/   |
                new TexturedVertex( 1, 1,0,0,0,0,1,1),  // -1,-1 +----+ -1,1
            };

            vboPlane = GL.GenBuffer();
            vaoPlane = GL.GenVertexArray();

            GL.BindVertexArray(vaoPlane);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboPlane);
            GL.BufferData(BufferTarget.ArrayBuffer, plane.Length * TexturedVertex.Size, plane, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            // --------------------------------------------------------------

            vboSphere = GL.GenBuffer();
            vaoSphere = GL.GenVertexArray();

            GL.BindVertexArray(vaoSphere);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboSphere);
            GL.BufferData(BufferTarget.ArrayBuffer, sphereVertices.Length * TexturedVertex.Size, sphereVertices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(2);
        }

        private void InitShaders()
        {
            mandelbrotShader = new Shader("Shaders/geometry.vert", "Shaders/mandelbrot.frag");
            mandelbrotShader.Use();

            juliaJulia = new Shader("Shaders/geometry.vert", "Shaders/julia.frag");
            juliaJulia.Use();

            juliaMatingShader = new Shader("Shaders/geometry.vert", "Shaders/julia_mating.frag");
            juliaMatingShader.Use();

            mandelbulbShader = new Shader("Shaders/rayplane.vert", "Shaders/mandelbulb.frag");
            mandelbulbShader.Use();
        }

        private void Log(string message)
        {
            LogTextBox.AppendText(message + "\r\n");
        }

        // https://math.stackexchange.com/questions/3763732/finding-periodic-fixed-points-in-the-julia-sets-close-to-the-period-3-cardioid
        Complex guess = Complex.Zero;
        private bool m_d_attractor_step(ref Complex z, Complex z_guess, Complex c, int period)
        {
            Complex zz = z_guess;
            Complex dzz = new Complex(1,0);
            double epsilon2 = 1.9721522630525295e-31;

            for (int i = 0; i < period; ++i)
            {
                dzz = 2 * zz * dzz;
                zz = zz * zz + c;
            }

            if ((zz - z_guess).RadiusSquared <= epsilon2)
            {
                z = z_guess;
                return true;
            }
            Complex z_new = z_guess - (zz - z_guess) / (dzz - 1);
            Complex d = z_new - z_guess;
            if (d.RadiusSquared <= epsilon2)
            {
                z = z_new;
                return true;
            }
            if (Complex.IsFinite(d))
            {
                z = z_new;
                return false;
            }
            else
            {
                z = z_guess;
                return true;
            }
        }
        private bool m_d_attractor(out Complex z_out, Complex z_guess, Complex c, int period, int maxsteps)
        {
            bool result = false;
            Complex z = z_guess;

            for (int i = 0; i < maxsteps; ++i)
                if (false != (result = m_d_attractor_step(ref z, z_guess, c, period)))
                    break;

            z_out = z;
            return result;
        }

        private Vector2 GetCenter()
        {
            if (CurrentSettings.IsJuliaAnimationEnabled && CurrentSettings.UsePeriodicPoint)
            {
                //float theta = (float)Math.Atan2(juliaSettings.Julia.Y, juliaSettings.Julia.X) + fractalTime * juliaSettings.AnimationSpeed;
                float theta = animationTime;
                Vector2 j = GetJulia();
                Complex julia = new Complex(j.X, j.Y);

                bool switchSign = false;

                if (juliaSettings.JuliaAnimationPath == Fractal.JuliaAnimationPath.Circle || (juliaSettings.JuliaAnimationRadius > 1 && juliaSettings.JuliaAnimationPath != Fractal.JuliaAnimationPath.Period_2 && juliaSettings.JuliaAnimationPath != Fractal.JuliaAnimationPath.Period_3_2))
                    switchSign = (theta % (float)(4*Math.PI)) < 2*Math.PI;

                Complex sqrt = Complex.Sqrt(new Complex(1,0) - 4 * julia, switchSign);
                Complex c = (1 - sqrt) / 2;
                    
                if (juliaSettings.JuliaAnimationPath == Fractal.JuliaAnimationPath.Custom)
                {

                }
                else if (juliaSettings.JuliaAnimationPath == Fractal.JuliaAnimationPath.Period_3_1)
                {
                    //var guess = new Complex(juliaSettings.Center.X, juliaSettings.Center.Y);
                    m_d_attractor(out c, guess, julia, 3, 10);
                    guess = c;
                }
                
                Vector2 center = new Vector2((float)c.R, (float)c.I);
                juliaSettings.Center = center;
                input_Center.Text = Make2D(center.X, center.Y);

                return center;
            }

            return CurrentSettings.Center;
        }

        private Vector2 GetJulia()
        {
            if (currentFractalType == Fractal.Type.Julia && CurrentSettings.IsJuliaAnimationEnabled)
                return GetJulia(juliaSettings.JuliaAnimationPath, juliaSettings.JuliaAnimationRadius, juliaSettings.Julia);

            return juliaSettings.Julia;
        }
        private Vector2 GetJulia(Fractal.JuliaAnimationPath animationPath, float radius, Vector2 defaultJulia, float offset = 0, bool reverseTheta = false)
        {
            float theta = (animationTime + offset*2*(float)Math.PI) % (float)(4*Math.PI);

            if (reverseTheta)
                theta = -theta;

            if (animationPath == Fractal.JuliaAnimationPath.Circle)
                return new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) * radius;
            if (animationPath == Fractal.JuliaAnimationPath.Period_1)
                return new Vector2((float)(.5 * Math.Cos(theta) - .25 * Math.Cos(2 * theta)), (float)(.5 * Math.Sin(theta) - .25 * Math.Sin(2 * theta))) * radius;
            if (animationPath == Fractal.JuliaAnimationPath.Period_2)
                return (new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta)) / 4 * radius) - new Vector2(1, 0);
            if (animationPath == Fractal.JuliaAnimationPath.Custom)
            {
                return defaultJulia;
            }

            var c = new Complex();
            var unitCircle = new Complex(Math.Cos(theta), Math.Sin(theta));
            var w = Complex.Asinh((88 - 27 * unitCircle) / (80 * Math.Sqrt(5))) / 3;
            var w0 = Complex.Asinh(new Complex(88 / (80 * Math.Sqrt(5)), 0)) / 3;

            if (animationPath == Fractal.JuliaAnimationPath.Period_3_1)
            {
                var z = -1.75 - 20 * (Complex.Sinh(w) - 1.0 / (4 * Math.Sqrt(5))).Pow(2) / 9;
                var z0 = -1.75 - 20 * (Complex.Sinh(w0) - 1.0 / (4 * Math.Sqrt(5))).Pow(2) / 9;
                c = radius * (z - z0) + z0;
            }
            else if (animationPath == Fractal.JuliaAnimationPath.Period_3_2)
            {
                var zp = -1.75 - 20 * (Complex.Sinh(w + 2 * Math.PI * Complex.i / 3.0) - 1.0 / (4 * Math.Sqrt(5))).Pow(2) / 9;
                var zp0 = -1.75 - 20 * (Complex.Sinh(w0 + 2 * Math.PI * Complex.i / 3.0) - 1.0 / (4 * Math.Sqrt(5))).Pow(2) / 9;
                c = radius * (zp - zp0) + zp0;
            }
                
            return new Vector2((float)c.R, (float)c.I);
        }

        private void GetJuliaMating()
        {
            if (CurrentSettings.IsJuliaMatingAnimationEnabled)
                juliaMating.InitializeMating
                (
                    GetJulia(juliaMatingSettings.JuliaMatingAnimationPath1, juliaMatingSettings.JuliaMatingAnimationRadius1, juliaMatingSettings.JuliaMating1),
                    GetJulia(juliaMatingSettings.JuliaMatingAnimationPath2, juliaMatingSettings.JuliaMatingAnimationRadius2, juliaMatingSettings.JuliaMating2, juliaMatingSettings.JuliaMatingAnimationOffset.Value, juliaMatingSettings.UseJuliaMatingAnimationReverse),
                    juliaMatingSettings.MatingIterations,
                    1,
                    true
                );
        }

        private void Render()
        {
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            ref Fractal.Settings fractalSettings = ref CurrentSettings;
            ref Shader shader = ref CurrentShader;
            ref Camera camera = ref CurrentCamera;

            camera.Render();

            GL.DispatchCompute(glControl.Width, glControl.Height, 1);
            GL.MemoryBarrier(MemoryBarrierFlags.ShaderImageAccessBarrierBit);

            if (fractalSettings.NeedsRayMarching)
            {
                shader.SetFloat("time", fractalTime);

                shader.SetMatrix4("view", camera.GetViewMatrix());
                shader.SetVector3("pos", camera.Position);
                shader.SetFloat("fov", MathHelper.DegreesToRadians(camera.FOV));
                shader.SetInt("longerDim", Math.Max(minGLWidth, minGLHeight));
                shader.SetFloat("normalizedCoordsWidth", (float)glControl.Width / Math.Max(minGLWidth, minGLHeight));
                shader.SetFloat("normalizedCoordsHeight", (float)glControl.Height / Math.Max(minGLWidth, minGLHeight));

                shader.SetBool("sphereTrace", true);
                //shader.SetBool("sphereTrace", false);
                //shader.SetBool("postMarch", false);
                shader.SetBool("postMarch", true);
                shader.SetInt("raymarchIterations", 128);
                shader.SetInt("postMarchIterations", 200);
                shader.SetFloat("postMarchBackDist", 1f);
                shader.SetFloat("fixedStep", .01f);
                shader.SetFloat("minRaymarchDist", 0.0001f);
                shader.SetFloat("maxRaymarchDist", 10.0f);
                shader.SetFloat("universeRadius", camera.CurrentSettings.farClipping);


                // Menu 1
                //shader.SetInt("maxIterations", fractalSettings.MaxIterations.Value);
                shader.SetInt("maxIterations", 4);
                shader.SetFloat("power", 8);
            }
            else
            {
                shader.SetMatrix4("projection", camera.GetProjectionMatrix());
                shader.SetMatrix4("view", camera.GetViewMatrix());
                shader.SetMatrix4("model", Matrix4.Identity);

                shader.SetInt("proj", (int)fractalSettings.Projection);
                shader.SetBool("is3D", camera.Is3D());
                shader.SetFloat("zoom", fractalSettings.Zoom);
                shader.SetFloat("lockedZoom", fractalSettings.LockedZoom);
                shader.SetFloat("initialRadius", fractalSettings.InitialDisplayRadius.Value);
                shader.SetFloat("normalizedCoordsWidth", (float)glControl.Width / Math.Max(minGLWidth, minGLHeight));
                shader.SetFloat("normalizedCoordsHeight", (float)glControl.Height / Math.Max(minGLWidth, minGLHeight));

                shader.SetVector2("center", GetCenter());
                shader.SetFloat("rollAngle", camera.Roll);
                shader.SetVector2("riemannAngles", fractalSettings.RiemannAngles);

                if (currentFractalType == Fractal.Type.Julia)
                {
                    shader.SetVector2("julia", GetJulia());
                }
                else if (currentFractalType == Fractal.Type.Julia_Mating)
                {
                    int s = (int)juliaMating.CurrentStep % juliaMating.IntermediateSteps;
                    int n = ((int)juliaMating.CurrentStep - s) / juliaMating.IntermediateSteps;

                    shader.SetInt("currentMatingIteration", n);
                    shader.SetVector2("p", juliaMating.P.ToComplex());
                    shader.SetVector2("q", juliaMating.Q.ToComplex());

                    shader.SetDouble("R_t", juliaMating.R_t);
                    shader.SetVector2Array("ma", juliaMating.Ma_Step);
                    shader.SetVector2Array("mb", juliaMating.Mb_Step);
                    shader.SetVector2Array("mc", juliaMating.Mc_Step);
                    shader.SetVector2Array("md", juliaMating.Md_Step);
                }

                // Menu 1
                shader.SetInt("formula", (int)fractalSettings.Formula);
                shader.SetInt("maxIterations", fractalSettings.MaxIterations.Value);
                shader.SetInt("minIterations", fractalSettings.MinIterations.Value);
                shader.SetBool("useConjugate", fractalSettings.UseConjugate);
                shader.SetVector2("startPosition", fractalSettings.StartPosition);
                shader.SetVector2("power", fractalSettings.Power);
                shader.SetVector2("c_power", fractalSettings.C_Power);
                shader.SetFloat("foldCount", fractalSettings.FoldCount);
                shader.SetFloat("foldAngle", MathHelper.DegreesToRadians(fractalSettings.FoldAngle));
                shader.SetVector2("foldOffset", fractalSettings.FoldOffset);

                // Menu 2
                shader.SetInt("orbitTrap", (int)fractalSettings.OrbitTrap);
                shader.SetFloat("bailout", fractalSettings.Bailout);
                shader.SetVector2("bailoutRectangle", fractalSettings.BailoutRectangle);
                shader.SetVector4("bailoutSpiral", fractalSettings.BailoutSpiral);
                shader.SetVector2Array("bailoutPoints", fractalSettings.BailoutPoints);
                shader.SetInt("bailoutPointsCount", fractalSettings.BailoutPointsCount);
                shader.SetVector4Array("bailoutLines", fractalSettings.BailoutLines);
                shader.SetInt("bailoutLinesCount", fractalSettings.BailoutLinesCount);
                shader.SetInt("bailoutTexture", 0);
                shader.SetInt("orbitTrapCalculation", (int)fractalSettings.OrbitTrapCalculation);
                shader.SetBool("useSecondValue", fractalSettings.UseSecondValue);
                shader.SetFloat("startOrbitDistance", fractalSettings.StartOrbitDistance.Value);
                shader.SetInt("startOrbit", fractalSettings.StartOrbit.Value);
                shader.SetInt("orbitRange", fractalSettings.OrbitRange.Value);
                shader.SetFloat("bailoutFactor1", fractalSettings.BailoutFactor1);
                shader.SetFloat("bailoutFactor2", fractalSettings.BailoutFactor2);
                shader.SetFloat("secondValueFactor1", fractalSettings.SecondValueFactor1);
                shader.SetFloat("secondValueFactor2", fractalSettings.SecondValueFactor2);
                shader.SetBool("useBailoutTexture", fractalSettings.BailoutTexture != "");
                shader.SetFloat("bailoutTextureBlend", fractalSettings.BailoutTextureBlend);
                shader.SetVector2("bailoutTextureScale", new Vector2(fractalSettings.BailoutTextureScaleX, fractalSettings.BailoutTextureScaleY));
                shader.SetBool("bailoutUsePolarTextureCoordinates", fractalSettings.BailoutUsePolarTextureCoordinates);

                // Menu 3
                shader.SetFloat("time", fractalTime + 150);
                bool split = fractalSettings.EditingColor != Fractal.Editing.Both;
                shader.SetBool("splitInteriorExterior", split);

                shader.SetBool("useCustomPalette", split ? fractalSettings.E_UseCustomPalette : fractalSettings.UseCustomPalette);
                shader.SetVector4Array("customPalette", split ? fractalSettings.E_CustomPalette : fractalSettings.CustomPalette);
                shader.SetInt("coloring", (int)(split ? fractalSettings.E_Coloring : fractalSettings.Coloring));
                shader.SetFloat("colorCycles", split ? fractalSettings.E_ColorCycles : fractalSettings.ColorCycles);
                shader.SetFloat("colorFactor", split ? fractalSettings.E_ColorFactor : fractalSettings.ColorFactor);
                shader.SetFloat("orbitTrapFactor", split ? fractalSettings.E_OrbitTrapFactor : fractalSettings.OrbitTrapFactor);
                shader.SetFloat("stripeDensity", split ? fractalSettings.E_StripeDensity : fractalSettings.StripeDensity);
                shader.SetInt("domainCalculation", (int)(split ? fractalSettings.I_DomainCalculation : fractalSettings.DomainCalculation));
                shader.SetBool("matchOrbitTrap", (split ? fractalSettings.I_MatchOrbitTrap : fractalSettings.MatchOrbitTrap) && fractalSettings.OrbitTrap >= Fractal.OrbitTrap.Points);
                shader.SetBool("useDomainSecondValue", split ? fractalSettings.E_UseSecondDomainValue : fractalSettings.UseSecondDomainValue);
                shader.SetFloat("secondDomainValueFactor1", split ? fractalSettings.E_SecondDomainValueFactor1 : fractalSettings.SecondDomainValueFactor1);
                shader.SetFloat("secondDomainValueFactor2", split ? fractalSettings.E_SecondDomainValueFactor2 : fractalSettings.SecondDomainValueFactor2);
                shader.SetBool("useDomainIteration", split ? fractalSettings.E_UseDomainIteration : fractalSettings.UseDomainIteration);
                shader.SetBool("useDistanceEstimation", split ? fractalSettings.I_UseDistanceEstimation : fractalSettings.UseDistanceEstimation);
                shader.SetFloat("maxDistanceEstimation", split ? fractalSettings.I_MaxDistanceEstimation : fractalSettings.MaxDistanceEstimation);
                shader.SetFloat("distanceEstimationFactor1", split ? fractalSettings.I_DistanceEstimationFactor1 : fractalSettings.DistanceEstimationFactor1);
                shader.SetFloat("distanceEstimationFactor2", split ? fractalSettings.I_DistanceEstimationFactor2 : fractalSettings.DistanceEstimationFactor2);
                shader.SetBool("useNormals", split ? fractalSettings.I_UseNormals : fractalSettings.UseNormals);
                shader.SetBool("useTexture", (split ? fractalSettings.E_Texture : fractalSettings.Texture) != "");
                shader.SetInt("e_texture", split ? 3 : 1);
                shader.SetFloat("textureBlend", split ? fractalSettings.E_TextureBlend : fractalSettings.TextureBlend);
                shader.SetFloat("textureScaleX", split ? fractalSettings.E_TextureScaleX : fractalSettings.TextureScaleX);
                shader.SetFloat("textureScaleY", split ? fractalSettings.E_TextureScaleY : fractalSettings.TextureScaleY);
                shader.SetBool("usePolarTextureCoordinates", split ? fractalSettings.E_UsePolarTextureCoordinates : fractalSettings.UsePolarTextureCoordinates);
                shader.SetBool("useDistortedTexture", split ? fractalSettings.E_UseTextureDistortion : fractalSettings.UseTextureDistortion);
                shader.SetFloat("textureDistortionFactor", split ? fractalSettings.E_TextureDistortion : fractalSettings.TextureDistortion);

                shader.SetInt("i_coloring", (int)fractalSettings.I_Coloring);
                shader.SetBool("i_useCustomPalette", fractalSettings.I_UseCustomPalette);
                shader.SetVector4Array("i_customPalette", fractalSettings.I_CustomPalette);
                shader.SetFloat("i_colorCycles", fractalSettings.I_ColorCycles);
                shader.SetFloat("i_colorFactor", fractalSettings.I_ColorFactor);
                shader.SetFloat("i_orbitTrapFactor", fractalSettings.I_OrbitTrapFactor);
                shader.SetFloat("i_stripeDensity", fractalSettings.I_StripeDensity);
                shader.SetBool("i_useDomainSecondValue", fractalSettings.I_UseSecondDomainValue);
                shader.SetFloat("i_secondDomainValueFactor1", fractalSettings.I_SecondDomainValueFactor1);
                shader.SetFloat("i_secondDomainValueFactor2", fractalSettings.I_SecondDomainValueFactor2);
                shader.SetBool("i_useDomainIteration", fractalSettings.I_UseDomainIteration);
                shader.SetBool("i_useTexture", fractalSettings.I_Texture != "");
                shader.SetInt("i_texture", 2);
                shader.SetFloat("i_textureBlend", fractalSettings.I_TextureBlend);
                shader.SetFloat("i_textureScaleX", fractalSettings.I_TextureScaleX);
                shader.SetFloat("i_textureScaleY", fractalSettings.I_TextureScaleY);
                shader.SetBool("i_usePolarTextureCoordinates", fractalSettings.I_UsePolarTextureCoordinates);
                shader.SetBool("i_useDistortedTexture", fractalSettings.I_UseTextureDistortion);
                shader.SetFloat("i_textureDistortionFactor", fractalSettings.I_TextureDistortion);
            }
            
            shader.Use();

            if (CurrentSettings.Projection == Fractal.Projection.Riemann_Sphere)
            {
                GL.BindVertexArray(vaoSphere);
                GL.DrawArrays(PrimitiveType.Triangles, 0, sphereVertices.Length);
            }
            else
            {
                GL.BindVertexArray(vaoPlane);
                GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
            }

            glControl.SwapBuffers();
        }
        #endregion

        #region MainDlg Callbacks

        /// <summary>
        /// Callback when form is loaded
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitObjects();
            InitShaders();

            applicationTime = new Stopwatch();
            fractalTime = 0;
            animationTime = 0;
            currentFractalType = Fractal.Type.Mandelbrot;

            mandelbrotSettings = new Fractal.Settings(Fractal.Type.Mandelbrot);
            mandelbrotSettings.Julia = Vector2.Zero;
            mandelbrotSettings.JuliaMating1 = Vector2.Zero;
            mandelbrotSettings.JuliaMating2 = Vector2.Zero;
            mandelbrotCamera = new Camera();

            juliaSettings = new Fractal.Settings(Fractal.Type.Julia);
            juliaSettings.JuliaMating1 = Vector2.Zero;
            juliaSettings.JuliaMating2 = Vector2.Zero;
            juliaCamera = new Camera();

            juliaMatingSettings = new Fractal.Settings(Fractal.Type.Julia_Mating);
            juliaMatingCamera = new Camera();

            mandelbulbSettings = new Fractal.Settings(Fractal.Type.Mandelbulb);
            mandelbulbSettings.Julia = Vector2.Zero;
            mandelbulbSettings.JuliaMating1 = Vector2.Zero;
            mandelbulbSettings.JuliaMating2 = Vector2.Zero;
            mandelbulbCamera = new Camera();
            mandelbulbCamera.ChangeMode(Camera.Mode.FPS);

            input_FractalType.SelectedIndex = (int)CurrentSettings.Type;
            input_FractalType_SelectionChangeCommitted(null, null);

            // Callbacks
            glControl.Resize += glControl_Resize;
            glControl.Paint += glControl_Update;

            glControl.GotFocus += (sender, e) => inputState.Focus = true;
            glControl.LostFocus += (sender, e) => inputState.Focus = false;

            // Log WinForms keyboard/mouse events.
            glControl.MouseDown += (sender, e) =>
            {
                glControl.Focus();

                if (e.Button == MouseButtons.Left)
                    inputState.MouseLeftDown = true;
                if (e.Button == MouseButtons.Right)
                {
                    inputState.MouseRightDown = true;
                    Cursor.Hide();
                }
            };
            glControl.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    inputState.MouseLeftDown = false;
                if (e.Button == MouseButtons.Right)
                {
                    inputState.MouseRightDown = false;
                    Cursor.Show();
                }
            };
            glControl.MouseMove += glControl_MouseMove;
            glControl.MouseWheel += glControl_MouseWheel;
            glControl.KeyDown += glControl_KeyDown;
            glControl.KeyUp += glControl_KeyUp;
            glControl.KeyPress += glControl_KeyPress;

            // Redraw the screen every 1/60 of a second.
            _timer = new Timer();
            _timer.Tick += (sender, e) =>
            {
                glControl_Update(glControl, null);
            };
            _timer.Interval = 1000 / fps;   // 1000 ms per sec / 16.67 ms per frame = 60 FPS
            _timer.Start();

            // Start window
            // Ensure that the viewport and projection matrix are set correctly initially.
            glControl_Resize(glControl, EventArgs.Empty);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);

            glControl.Focus();
            button_Menu1_Click(null, null);

            applicationTime.Start();
            lastFrame = applicationTime.ElapsedMilliseconds;
        }

        private void MainDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            // Delete all the resources.
            GL.DeleteBuffer(vboPlane);
            GL.DeleteVertexArray(vaoPlane);
            GL.DeleteBuffer(vboSphere);
            GL.DeleteVertexArray(vaoSphere);

            GL.DeleteProgram(mandelbrotShader.Handle);
            GL.DeleteProgram(juliaJulia.Handle);
            GL.DeleteProgram(juliaMatingShader.Handle);
            GL.DeleteProgram(mandelbulbShader.Handle);
        }

        /// <summary>
        /// Callback upon window resize
        /// </summary>
        private void glControl_Resize(object sender, EventArgs e)
        {
            glControl.MakeCurrent();

            if (glControl.ClientSize.Height == 0)
                glControl.ClientSize = new System.Drawing.Size(glControl.ClientSize.Width, 1);

            GL.Viewport(0, 0, glControl.ClientSize.Width, glControl.ClientSize.Height);

            float aspect_ratio = Math.Max(glControl.ClientSize.Width, 1) / (float)Math.Max(glControl.ClientSize.Height, 1);

            juliaCamera.AspectRatio = aspect_ratio;
            mandelbrotCamera.AspectRatio = aspect_ratio;
            //juliaMatingCamera.AspectRatio = aspect_ratio;
            mandelbulbCamera.AspectRatio = aspect_ratio;
        }

        /// <summary>
        /// Callback upon window update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControl_Update(object sender, PaintEventArgs e)
        {
            if (glControl.IsDisposed)
                return;

            if (currentFractalType == Fractal.Type.Julia_Mating)
                if (juliaMatingSettings.IsJuliaMatingAnimationEnabled)
                {
                    GetJuliaMating();
                    input_CurrentMatingStep.Enabled = false;
                    label_CurrentMatingStep.Text = "GENERATING:";
                }
                else if (juliaMating.IsInitialized && !juliaMating.Completed)
                {
                    juliaMating.UpdateMating();
                    input_CurrentMatingStep.Value = (int)juliaMating.CurrentStep;
                    CurrentSettings.CurrentMatingStep = juliaMating.CurrentStep;
                }
                else if (!input_CurrentMatingStep.Enabled)
                {
                    input_CurrentMatingStep.Value = (int)juliaMating.CurrentStep;
                    input_CurrentMatingStep.Enabled = true;
                    label_CurrentMatingStep.Text = "Current Step:*";
                }

            glControl.MakeCurrent();

            float currentFrame = applicationTime.ElapsedMilliseconds;
            deltaTime = (currentFrame - lastFrame) / 1000;
            lastFrame = currentFrame;

            // input
            float modifier = inputState.keysDown[Keys.Oemtilde] ? -deltaTime : deltaTime;
            if (inputState.ShiftDown)
                modifier *= 5;
            if (inputState.ControlDown)
                modifier /= 5;
            float zoomedModifier = modifier / (float)Math.Pow(2, Math.Max(0, CurrentSettings.Zoom));

            // time
            float timeFactor = inputState.keysDown[Keys.OemQuestion] ? modifier*5 : (inputState.keysDown[Keys.Oemcomma] ? -modifier*5 : 1);

            if (!pauseTime || timeFactor != 1)
            {
                fractalTime += deltaTime * timeFactor;
                animationTime += deltaTime * timeFactor * CurrentSettings.AnimationSpeed / (float)Math.Pow(2, CurrentSettings.Formula == Fractal.Formula.Lambda ? CurrentSettings.Zoom + 2 : CurrentSettings.Zoom);
            }
            
            // menu controls
            if (panel_FormulaMenu.Enabled)
            {
                if (inputState.keysDown[Keys.D1] && currentFractalType == Fractal.Type.Julia)
                {
                    CurrentSettings.Julia.X += zoomedModifier / 2;
                    input_JuliaX.Text = CurrentSettings.Julia.X.ToString();
                }
                if (inputState.keysDown[Keys.D2] && currentFractalType == Fractal.Type.Julia)
                {
                    CurrentSettings.Julia.Y += zoomedModifier / 2;
                    input_JuliaY.Text = CurrentSettings.Julia.Y.ToString();
                }
                if (inputState.keysDown[Keys.D3] && input_CurrentMatingStep.Enabled)
                {
                    CurrentSettings.CurrentMatingStep = Math.Clamp(CurrentSettings.CurrentMatingStep + (inputState.ShiftDown ? 1 : 3) * (inputState.keysDown[Keys.Oemtilde] ? -1 : 1), 0, CurrentSettings.MatingIterations*CurrentSettings.IntermediateMatingSteps);
                    input_CurrentMatingStep.Value = CurrentSettings.CurrentMatingStep;
                    juliaMating.CurrentStep = CurrentSettings.CurrentMatingStep;
                }
                if (inputState.keysDown[Keys.D4])
                {
                    CurrentSettings.StartPosition.X += zoomedModifier / 2;
                    input_StartPositionX.Text = CurrentSettings.StartPosition.X.ToString();
                }
                if (inputState.keysDown[Keys.D5])
                {
                    CurrentSettings.StartPosition.Y += zoomedModifier / 2;
                    input_StartPositionY.Text = CurrentSettings.StartPosition.Y.ToString();
                }
                if (inputState.keysDown[Keys.D6])
                {
                    CurrentSettings.Power.X += zoomedModifier / 1;
                    input_Power.Text = Replace2D(CurrentSettings.Power.X.ToString(), input_Power.Text, true);
                }
                if (inputState.keysDown[Keys.D7])
                {
                    CurrentSettings.Power.Y += zoomedModifier / 1;
                    input_Power.Text = Replace2D(CurrentSettings.Power.Y.ToString(), input_Power.Text, false);
                }
                if (inputState.keysDown[Keys.D8])
                {
                    CurrentSettings.C_Power.X += zoomedModifier / 1;
                    input_CPower.Text = Replace2D(CurrentSettings.C_Power.X.ToString(), input_CPower.Text, true);
                }
                if (inputState.keysDown[Keys.D9])
                {
                    CurrentSettings.C_Power.Y += zoomedModifier / 1;
                    input_CPower.Text = Replace2D(CurrentSettings.C_Power.Y.ToString(), input_CPower.Text, false);
                }
                if (inputState.keysDown[Keys.D0])
                {
                    CurrentSettings.FoldCount += modifier / 1;
                    input_FoldCount.Text = CurrentSettings.FoldCount.ToString();
                }
                if (inputState.keysDown[Keys.OemMinus])
                {
                    CurrentSettings.FoldAngle = (CurrentSettings.FoldAngle + modifier*20 + 360) % 360;
                    input_FoldAngle.Text = CurrentSettings.FoldAngle.ToString();
                }
                if (inputState.keysDown[Keys.Oemplus])
                {
                    CurrentSettings.FoldOffset.X += modifier / 1;
                    input_FoldOffsetX.Text = CurrentSettings.FoldOffset.X.ToString();
                }
                if (inputState.keysDown[Keys.Back])
                {
                    CurrentSettings.FoldOffset.Y += modifier / 1;
                    input_FoldOffsetY.Text = CurrentSettings.FoldOffset.Y.ToString();
                }
            }
            else if (panel_OrbitTrapMenu.Enabled)
            {
                int editingBailoutTrapIndex = (int)input_EditingBailoutTrapList.Value - 1;

                if (inputState.keysDown[Keys.D1])
                {
                    CurrentSettings.Bailout += modifier * 10;
                    input_Bailout.Text = CurrentSettings.Bailout.ToString();
                }
                if (inputState.keysDown[Keys.D2])
                {
                    if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Rectangle)
                    {
                        CurrentSettings.BailoutRectangle.X += zoomedModifier / 1;
                        input_BailoutX.Text = CurrentSettings.BailoutRectangle.X.ToString();
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Spiral)
                    {
                        CurrentSettings.BailoutSpiral.X += zoomedModifier / 1;
                        input_BailoutX.Text = Replace2D(CurrentSettings.BailoutSpiral.X.ToString(), input_BailoutX.Text, true);
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
                    {
                        CurrentSettings.BailoutPoints[editingBailoutTrapIndex].X += zoomedModifier / 1;
                        input_BailoutX.Text = CurrentSettings.BailoutPoints[editingBailoutTrapIndex].X.ToString();
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                    {
                        CurrentSettings.BailoutLines[editingBailoutTrapIndex].X += zoomedModifier / 1;
                        input_BailoutX.Text = Replace2D(CurrentSettings.BailoutLines[editingBailoutTrapIndex].X.ToString(), input_BailoutX.Text, true);
                    }
                }
                if (inputState.keysDown[Keys.D3])
                {
                    if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Rectangle)
                    {
                        CurrentSettings.BailoutRectangle.Y += zoomedModifier / 1;
                        input_BailoutY.Text = CurrentSettings.BailoutRectangle.Y.ToString();
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Spiral)
                    {
                        CurrentSettings.BailoutSpiral.Y += zoomedModifier / 1;
                        input_BailoutX.Text = Replace2D(CurrentSettings.BailoutSpiral.Y.ToString(), input_BailoutX.Text, false);
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
                    {
                        CurrentSettings.BailoutPoints[editingBailoutTrapIndex].Y += zoomedModifier / 1;
                        input_BailoutY.Text = CurrentSettings.BailoutPoints[editingBailoutTrapIndex].Y.ToString();
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                    {
                        CurrentSettings.BailoutLines[editingBailoutTrapIndex].Y += zoomedModifier / 1;
                        input_BailoutX.Text = Replace2D(CurrentSettings.BailoutLines[editingBailoutTrapIndex].Y.ToString(), input_BailoutX.Text, false);
                    }
                }
                if (inputState.keysDown[Keys.D4])
                {
                    if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Spiral)
                    {
                        CurrentSettings.BailoutSpiral.Z = (CurrentSettings.BailoutSpiral.Z + modifier*4 + (float)(2*Math.PI)) % (float)(2*Math.PI);
                        input_BailoutY.Text = Replace2D(MathHelper.RadiansToDegrees(CurrentSettings.BailoutSpiral.Z).ToString(), input_BailoutY.Text, true);
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                    {
                        CurrentSettings.BailoutLines[editingBailoutTrapIndex].Z += zoomedModifier / 1;
                        input_BailoutY.Text = Replace2D(CurrentSettings.BailoutLines[editingBailoutTrapIndex].Z.ToString(), input_BailoutY.Text, true);
                    }
                }
                if (inputState.keysDown[Keys.D5])
                {
                    if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Spiral)
                    {
                        CurrentSettings.BailoutSpiral.W += zoomedModifier / 1;
                        input_BailoutY.Text = Replace2D(CurrentSettings.BailoutSpiral.W.ToString(), input_BailoutY.Text, false);
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                    {
                        CurrentSettings.BailoutLines[editingBailoutTrapIndex].W += zoomedModifier / 1;
                        input_BailoutY.Text = Replace2D(CurrentSettings.BailoutLines[editingBailoutTrapIndex].W.ToString(), input_BailoutY.Text, false);
                    }
                }
                if (inputState.keysDown[Keys.D6] && input_StartDistance.Enabled)
                {
                    CurrentSettings.StartOrbitDistance.Value += modifier;
                    input_StartDistance.Text = CurrentSettings.StartOrbitDistance.Value.ToString();
                }
                if (inputState.keysDown[Keys.D7] && input_OrbitTrapBlendingFactor.Enabled)
                {
                    CurrentSettings.BailoutFactor1 += modifier / 2;
                    input_OrbitTrapBlendingFactor.Text = CurrentSettings.BailoutFactor1.ToString();
                }
                if (inputState.keysDown[Keys.D8] && input_OrbitTrapThicknessFactor.Enabled)
                {
                    CurrentSettings.BailoutFactor2 += modifier * 5;
                    input_OrbitTrapThicknessFactor.Text = CurrentSettings.BailoutFactor2.ToString();
                }
                if (inputState.keysDown[Keys.D9] && input_SecondValueFactor1.Enabled)
                {
                    CurrentSettings.SecondValueFactor1 += modifier * 5;
                    input_SecondValueFactor1.Text = CurrentSettings.SecondValueFactor1.ToString();
                }
                if (inputState.keysDown[Keys.D0] && input_SecondValueFactor2.Enabled)
                {
                    CurrentSettings.SecondValueFactor2 += modifier * 5;
                    input_SecondValueFactor2.Text = CurrentSettings.SecondValueFactor2.ToString();
                }
            }
            else if (panel_ColorMenu.Enabled)
            {
                if (inputState.keysDown[Keys.D1])
                {
                    CurrentSettings.AdjustColorCycles(modifier / 2);
                    input_ColorCycles.Text = CurrentSettings.GetColorCycles().ToString();
                }
                if (inputState.keysDown[Keys.D2])
                {
                    CurrentSettings.AdjustColorFactor(modifier * 5);
                    input_ColorFactor.Text = CurrentSettings.GetColorFactor().ToString();
                }
                if (inputState.keysDown[Keys.D3])
                {
                    CurrentSettings.AdjustOrbitTrapFactor(modifier * 5);
                    input_OrbitTrapFactor.Text = CurrentSettings.GetOrbitTrapFactor().ToString();
                }
                if (inputState.keysDown[Keys.D4] && input_StripeDensity.Enabled)
                {
                    CurrentSettings.AdjustStripeDensity(modifier / 1);
                    input_StripeDensity.Text = CurrentSettings.GetStripeDensity().ToString();
                }
                if (inputState.keysDown[Keys.D5] && input_SecondDomainValueFactor1.Enabled)
                {
                    CurrentSettings.AdjustSecondDomainValueFactor1(modifier * 5);
                    input_SecondDomainValueFactor1.Text = CurrentSettings.GetSecondDomainValueFactor1().ToString();
                }
                if (inputState.keysDown[Keys.D6] && input_SecondDomainValueFactor2.Enabled)
                {
                    CurrentSettings.AdjustSecondDomainValueFactor2(modifier * 5);
                    input_SecondDomainValueFactor2.Text = CurrentSettings.GetSecondDomainValueFactor2().ToString();
                }
                if (inputState.keysDown[Keys.D7] && input_MaxDistanceEstimation.Enabled)
                {
                    CurrentSettings.AdjustMaxDistanceEstimation(modifier * 5);
                    input_MaxDistanceEstimation.Text = CurrentSettings.GetMaxDistanceEstimation().ToString();
                }
                if (inputState.keysDown[Keys.D8] && input_DistanceEstimationFactor1.Enabled)
                {
                    CurrentSettings.AdjustDistanceEstimationFactor1(modifier / 1);
                    input_DistanceEstimationFactor1.Text = CurrentSettings.GetDistanceEstimationFactor1().ToString();
                }
                if (inputState.keysDown[Keys.D9] && input_DistanceEstimationFactor2.Enabled)
                {
                    CurrentSettings.AdjustDistanceEstimationFactor2(modifier / 1);
                    input_DistanceEstimationFactor2.Text = CurrentSettings.GetDistanceEstimationFactor2().ToString();
                }
                if (inputState.keysDown[Keys.D0] && input_TextureBlend.Enabled)
                {
                    CurrentSettings.AdjustTextureBlend(modifier / 2);
                    input_TextureBlend.Text = CurrentSettings.GetTextureBlend().ToString();
                }
                if (inputState.keysDown[Keys.OemMinus] && input_TextureScaleX.Enabled)
                {
                    CurrentSettings.AdjustTextureScaleX(modifier * 5);
                    input_TextureScaleX.Text = CurrentSettings.GetTextureScaleX().ToString();
                }
                if (inputState.keysDown[Keys.Oemplus] && input_TextureScaleY.Enabled)
                {
                    CurrentSettings.AdjustTextureScaleY(modifier * 5);
                    input_TextureScaleY.Text = CurrentSettings.GetTextureScaleY().ToString();
                }
                if (inputState.keysDown[Keys.Back] && input_TextureDistortionFactor.Enabled)
                {
                    CurrentSettings.AdjustTextureDistortion(modifier / 1);
                    input_TextureDistortionFactor.Text = CurrentSettings.GetTextureDistortion().ToString();
                }
            }
            else if (panel_MiscMenu.Enabled)
            {
                if (inputState.keysDown[Keys.D1])
                {
                    juliaSettings.AnimationSpeed += zoomedModifier / 2;
                    input_AnimationSpeed.Text = juliaSettings.AnimationSpeed.ToString();
                }
                if (inputState.keysDown[Keys.D2])
                {
                    if (currentFractalType == Fractal.Type.Julia)
                    {
                        juliaSettings.JuliaAnimationRadius += zoomedModifier / 2;
                        input_JuliaAnimationRadius.Text = juliaSettings.JuliaAnimationRadius.ToString();
                    }
                    else if (currentFractalType == Fractal.Type.Julia_Mating)
                    {
                        juliaSettings.JuliaMatingAnimationRadius1 += zoomedModifier / 2;
                        input_JuliaAnimationRadius.Text = juliaSettings.JuliaMatingAnimationRadius1.ToString();
                    }
                }
                if (inputState.keysDown[Keys.D3] && currentFractalType == Fractal.Type.Julia_Mating)
                {
                    juliaSettings.JuliaMatingAnimationRadius1 += zoomedModifier / 2;
                    input_JuliaAnimationRadius.Text = juliaSettings.JuliaMatingAnimationRadius1.ToString();
                }
            }

            // keyboard controls
            switch (CurrentCamera.CurrentMode)
            {
                case Camera.Mode.Flat:
                {
                    if (inputState.IsMovementKeyDown())
                    {
                        float rad = MathHelper.DegreesToRadians(CurrentCamera.Roll);
                        float rad90 = rad + MathHelper.Pi / 2;
                        float factor = CurrentCamera.CurrentPanSpeed / (float)Math.Pow(2, CurrentSettings.Zoom);

                        float delta = modifier * 50;
                        float deltaX = inputState.keysDown[Keys.D] ? delta : (inputState.keysDown[Keys.A] ? -delta : 0);
                        float deltaY = inputState.keysDown[Keys.W] ? delta : (inputState.keysDown[Keys.S] ? -delta : 0);

                        CurrentSettings.Center += new Vector2((float)Math.Cos(rad), (float)Math.Sin(rad)) * (float)deltaX * factor;
                        CurrentSettings.Center += new Vector2((float)Math.Cos(rad90), (float)Math.Sin(rad90)) * (float)deltaY * factor;

                        input_Center.Text = Make2D(CurrentSettings.Center.X, CurrentSettings.Center.Y);
                    }
                    if (inputState.keysDown[Keys.Q] || inputState.keysDown[Keys.E])
                    {
                        CurrentCamera.Roll -= modifier * 20 * (inputState.keysDown[Keys.Q] ? 1 : -1);
                        input_CameraRoll.Text = CurrentCamera.Roll.ToString();
                    }
                    if (inputState.keysDown[Keys.R] || inputState.keysDown[Keys.F])
                    {
                        CurrentSettings.Zoom += modifier / 1 * (inputState.keysDown[Keys.R] ? 1 : -1);
                        input_Zoom.Text = CurrentSettings.Zoom.ToString();

                        if (!checkBox_LockZoomFactor.Checked)
                        {
                            CurrentSettings.LockedZoom = CurrentSettings.Zoom;
                            input_LockedZoom.Text = CurrentSettings.LockedZoom.ToString();
                        }
                    }

                    if (CurrentSettings.Projection == Fractal.Projection.Riemann_Flat && inputState.IsSecondaryMovementKeyDown())
                    {
                        if (inputState.keysDown[Keys.I] || inputState.keysDown[Keys.K])
                            CurrentSettings.RiemannAngles.X -= modifier / 1 * (inputState.keysDown[Keys.I] ? 1 : -1);
                        if (inputState.keysDown[Keys.J] || inputState.keysDown[Keys.L])
                            CurrentSettings.RiemannAngles.Y -= modifier / 1 * (inputState.keysDown[Keys.J] ? 1 : -1);
                        
                        input_RiemannAngles.Text = Make2D(MathHelper.RadiansToDegrees(CurrentSettings.RiemannAngles.X), MathHelper.RadiansToDegrees(CurrentSettings.RiemannAngles.Y));
                    }

                    break;
                }
                case Camera.Mode.FPS:
                case Camera.Mode.Free:
                {
                    if (inputState.IsMovementKeyDown())
                    {
                        float delta = modifier * 100;

                        float deltaSide = inputState.keysDown[Keys.D] ? delta : (inputState.keysDown[Keys.A] ? -delta : 0);
                        float deltaUp = inputState.keysDown[Keys.Z] ? delta : (inputState.keysDown[Keys.X] ? -delta : 0);
                        float deltaForward = inputState.keysDown[Keys.W] ? delta : (inputState.keysDown[Keys.S] ? -delta : 0);
                        float deltaZoom = inputState.keysDown[Keys.R] ? delta : (inputState.keysDown[Keys.F] ? -delta : 0);
                        float deltaRoll = inputState.keysDown[Keys.Q] ? delta : (inputState.keysDown[Keys.E] ? -delta : 0);

                        if (CurrentCamera.Lock)
                        {
                            if (deltaSide != 0) CurrentCamera.RotateYaw(-deltaSide);
                            if (deltaForward != 0) CurrentCamera.RotatePitch(deltaForward);
                        }
                        else
                        {
                            if (deltaSide != 0) CurrentCamera.MoveAlongAxis(CurrentCamera.Right, deltaSide);
                            if (deltaUp != 0) CurrentCamera.MoveAlongAxis(CurrentCamera.Up, deltaUp);
                            if (deltaForward != 0) CurrentCamera.MoveAlongAxis(CurrentCamera.Direction, deltaForward);
                        }
                        
                        if (deltaZoom != 0) CurrentCamera.ZoomDirection(deltaZoom, 1);
                        if (deltaRoll != 0) CurrentCamera.RotateRoll(deltaRoll);

                        input_CameraPosition.Text = Make3D(CurrentCamera.Position.X, CurrentCamera.Position.Y, CurrentCamera.Position.Z);
                        input_CameraAngles.Text = Make2D(CurrentCamera.Yaw, CurrentCamera.Pitch);
                        input_CameraRoll.Text = CurrentCamera.Roll.ToString();
                    }
                    if (inputState.IsSecondaryMovementKeyDown())
                    {
                        float delta = zoomedModifier * 30 * CurrentCamera.CurrentPanSpeed;
                        float deltaX = inputState.keysDown[Keys.J] ? delta : (inputState.keysDown[Keys.L] ? -delta : 0);
                        float deltaY = inputState.keysDown[Keys.I] ? delta : (inputState.keysDown[Keys.K] ? -delta : 0);

                        CurrentSettings.Center.X += deltaX;
                        CurrentSettings.Center.Y += deltaY;

                        input_Center.Text = Make2D(CurrentSettings.Center.X, CurrentSettings.Center.Y);

                        if (inputState.keysDown[Keys.U] || inputState.keysDown[Keys.O])
                        {
                            CurrentSettings.Zoom += modifier * (inputState.keysDown[Keys.O] ? 1 : -1);
                            input_Zoom.Text = CurrentSettings.Zoom.ToString();

                            if (!checkBox_LockZoomFactor.Checked)
                            {
                                CurrentSettings.LockedZoom = CurrentSettings.Zoom;
                                input_LockedZoom.Text = CurrentSettings.LockedZoom.ToString();
                            }
                        }
                    }

                    break;
                }
            }

            // update controls
            //Log(CurrentSettings.OrbitTrap.ToString());
            //Log(CurrentCamera.TargetDistance.ToString());
            //Log((applicationTime.ElapsedMilliseconds / 1000f).ToString());

            // update fractal
            Render();
        }

        #endregion

        #region Keyboard and Mouse

        private void glControl_MouseMove(object? sender, MouseEventArgs e)
        {
            inputState.GLMousePositionX = e.X;
            inputState.GLMousePositionY = e.Y;

            inputState.GLMousePositionX = Math.Clamp(inputState.GLMousePositionX, 0, glControl.Width);
            inputState.GLMousePositionY = Math.Clamp(inputState.GLMousePositionY, 0, glControl.Height);

            int deltaX = inputState.PreviousMouseX - inputState.GLMousePositionX;
            int deltaY = inputState.PreviousMouseY - inputState.GLMousePositionY;
            
            if (inputState.MouseRightDown)
            {
                Cursor.Position = glControl.PointToScreen(e.Location);

                if (CurrentCamera.CurrentMode == Camera.Mode.Flat)
                {
                    float rad = MathHelper.DegreesToRadians(CurrentCamera.Roll);
                    float rad90 = rad + MathHelper.Pi / 2;
                    float factor = CurrentCamera.CurrentPanSpeed / (float)Math.Pow(2, CurrentSettings.Zoom);

                    CurrentSettings.Center += new Vector2((float)Math.Cos(rad), (float)Math.Sin(rad)) * (float)deltaX * factor;
                    CurrentSettings.Center -= new Vector2((float)Math.Cos(rad90), (float)Math.Sin(rad90)) * (float)deltaY * factor;
                }
                else
                {
                    CurrentCamera.RotateYaw(deltaX);
                    CurrentCamera.RotatePitch(deltaY);

                    input_CameraPosition.Text = Make3D(CurrentCamera.Position.X, CurrentCamera.Position.Y, CurrentCamera.Position.Z);
                    input_CameraAngles.Text = Make2D(CurrentCamera.Yaw, CurrentCamera.Pitch);
                }

                input_Center.Text = Make2D(CurrentSettings.Center.X, CurrentSettings.Center.Y);
            }
            if (inputState.MouseLeftDown/* && CurrentSettings.Type == Fractal.Type.Julia && juliaSettings.UsePeriodicPoint*/)
            {
                float theta = MathHelper.DegreesToRadians(CurrentCamera.Roll);

                Vector2 normalized = new Vector2(inputState.GLMousePositionX/(float)glControl.Width - 0.5f, inputState.GLMousePositionY/(float)glControl.Height - 0.5f) * new Vector2(2,-2);
                Vector2 rolled = new Vector2((float)(normalized.X*Math.Cos(theta) - normalized.Y*Math.Sin(theta)), (float)(normalized.X*Math.Sin(theta) + normalized.Y*Math.Cos(theta)));
                Vector2 zoomed = rolled * CurrentSettings.InitialDisplayRadius.Value / (float)Math.Pow(2, CurrentSettings.Zoom);
                Vector2 centered = zoomed + CurrentSettings.Center;

                if (CurrentCamera.CurrentMode == Camera.Mode.Flat)
                {
                    guess = new Complex(centered.X, centered.Y);
                }
            }

            inputState.PreviousMouseX = inputState.GLMousePositionX;
            inputState.PreviousMouseY = inputState.GLMousePositionY;
        }

        private void glControl_MouseWheel(object? sender, MouseEventArgs e)
        {
            int scrollOffset = e.Delta > 0 ? 1 : (e.Delta < 1 ? -1 : 0);

            if (CurrentCamera.CurrentMode == Camera.Mode.Flat)
            {
                float rad = MathHelper.DegreesToRadians(CurrentCamera.Roll);
                float rad90 = rad + MathHelper.Pi / 2;

                Vector2 xRoll = new Vector2((float)Math.Cos(rad), (float)Math.Sin(rad));
                Vector2 yRoll = new Vector2((float)Math.Cos(rad90), (float)Math.Sin(rad90));

                Vector2 normalizedMousePos = new Vector2((float)inputState.GLMousePositionX / glControl.Width, (float)inputState.GLMousePositionY / glControl.Height) * 2 - new Vector2(1, 1);
                Vector2 aspectRatio = new Vector2(glControl.Width, -glControl.Height) / Math.Max(minGLWidth, minGLHeight);
                Vector2 offset = normalizedMousePos * CurrentSettings.InitialDisplayRadius.Value * aspectRatio;

                Vector2 mousePos = CurrentSettings.Center + (xRoll * offset.X + yRoll * offset.Y) / (float)Math.Pow(2, CurrentSettings.Zoom);
                CurrentSettings.Zoom += scrollOffset * CurrentCamera.CurrentZoomSpeed;
                CurrentSettings.Center = mousePos - (xRoll * offset.X + yRoll * offset.Y) / (float)Math.Pow(2, CurrentSettings.Zoom);

                input_Center.Text = Make2D(CurrentSettings.Center.X, CurrentSettings.Center.Y);
                input_Zoom.Text = CurrentSettings.Zoom.ToString();

                if (!checkBox_LockZoomFactor.Checked)
                {
                    CurrentSettings.LockedZoom = CurrentSettings.Zoom;
                    input_LockedZoom.Text = CurrentSettings.LockedZoom.ToString();
                }
            }
            else
            {
                CurrentCamera.ZoomDirection(scrollOffset * 5, 1);
                input_CameraPosition.Text = Make3D(CurrentCamera.Position.X, CurrentCamera.Position.Y, CurrentCamera.Position.Z);
            }
        }

        private void glControl_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                inputState.keysDown[Keys.W] = true;
            else if (e.KeyCode == Keys.A)
                inputState.keysDown[Keys.A] = true;
            else if (e.KeyCode == Keys.S)
                inputState.keysDown[Keys.S] = true;
            else if (e.KeyCode == Keys.D)
                inputState.keysDown[Keys.D] = true;
            else if (e.KeyCode == Keys.Q)
                inputState.keysDown[Keys.Q] = true;
            else if (e.KeyCode == Keys.E)
                inputState.keysDown[Keys.E] = true;
            else if (e.KeyCode == Keys.Z)
                inputState.keysDown[Keys.Z] = true;
            else if (e.KeyCode == Keys.X)
                inputState.keysDown[Keys.X] = true;
            else if (e.KeyCode == Keys.R)
                inputState.keysDown[Keys.R] = true;
            else if (e.KeyCode == Keys.F)
                inputState.keysDown[Keys.F] = true;
            else if (e.KeyCode == Keys.I)
                inputState.keysDown[Keys.I] = true;
            else if (e.KeyCode == Keys.J)
                inputState.keysDown[Keys.J] = true;
            else if (e.KeyCode == Keys.K)
                inputState.keysDown[Keys.K] = true;
            else if (e.KeyCode == Keys.L)
                inputState.keysDown[Keys.L] = true;
            else if (e.KeyCode == Keys.U)
                inputState.keysDown[Keys.U] = true;
            else if (e.KeyCode == Keys.O)
                inputState.keysDown[Keys.O] = true;
            else if (e.KeyCode == Keys.Space)
                inputState.keysDown[Keys.Space] = true;
            else if (e.KeyCode == Keys.Oemcomma)
                inputState.keysDown[Keys.Oemcomma] = true;
            else if (e.KeyCode == Keys.OemQuestion)
                inputState.keysDown[Keys.OemQuestion] = true;
            else if (e.KeyCode == Keys.LControlKey)
                inputState.keysDown[Keys.LControlKey] = true;
            else if (e.KeyCode == Keys.RControlKey)
                inputState.keysDown[Keys.RControlKey] = true;
            else if (e.KeyCode == Keys.ControlKey)
                inputState.keysDown[Keys.ControlKey] = true;
            else if (e.KeyCode == Keys.ShiftKey)
                inputState.keysDown[Keys.ShiftKey] = true;
            else if (e.KeyCode == Keys.LShiftKey)
                inputState.keysDown[Keys.LShiftKey] = true;
            else if (e.KeyCode == Keys.RShiftKey)
                inputState.keysDown[Keys.RShiftKey] = true;
            else if (e.KeyCode == Keys.Oemtilde)
                inputState.keysDown[Keys.Oemtilde] = true;
            else if (e.KeyCode == Keys.Alt)
            {
                inputState.keysDown[Keys.Alt] = true;
                inputState.keysDown[Keys.Alt] = true;
            }
            else if (e.KeyCode == Keys.D1)
                inputState.keysDown[Keys.D1] = true;
            else if (e.KeyCode == Keys.D2)
                inputState.keysDown[Keys.D2] = true;
            else if (e.KeyCode == Keys.D3)
                inputState.keysDown[Keys.D3] = true;
            else if (e.KeyCode == Keys.D4)
                inputState.keysDown[Keys.D4] = true;
            else if (e.KeyCode == Keys.D5)
                inputState.keysDown[Keys.D5] = true;
            else if (e.KeyCode == Keys.D6)
                inputState.keysDown[Keys.D6] = true;
            else if (e.KeyCode == Keys.D7)
                inputState.keysDown[Keys.D7] = true;
            else if (e.KeyCode == Keys.D8)
                inputState.keysDown[Keys.D8] = true;
            else if (e.KeyCode == Keys.D9)
                inputState.keysDown[Keys.D9] = true;
            else if (e.KeyCode == Keys.D0)
                inputState.keysDown[Keys.D0] = true;
            else if (e.KeyCode == Keys.OemMinus)
                inputState.keysDown[Keys.OemMinus] = true;
            else if (e.KeyCode == Keys.Oemplus)
                inputState.keysDown[Keys.Oemplus] = true;
            else if (e.KeyCode == Keys.Back)
                inputState.keysDown[Keys.Back] = true;
        }

        private void glControl_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                inputState.keysDown[Keys.W] = false;
            else if (e.KeyCode == Keys.A)
                inputState.keysDown[Keys.A] = false;
            else if (e.KeyCode == Keys.S)
                inputState.keysDown[Keys.S] = false;
            else if (e.KeyCode == Keys.D)
                inputState.keysDown[Keys.D] = false;
            else if (e.KeyCode == Keys.Q)
                inputState.keysDown[Keys.Q] = false;
            else if (e.KeyCode == Keys.E)
                inputState.keysDown[Keys.E] = false;
            else if (e.KeyCode == Keys.Z)
                inputState.keysDown[Keys.Z] = false;
            else if (e.KeyCode == Keys.X)
                inputState.keysDown[Keys.X] = false;
            else if (e.KeyCode == Keys.R)
                inputState.keysDown[Keys.R] = false;
            else if (e.KeyCode == Keys.F)
                inputState.keysDown[Keys.F] = false;
            else if (e.KeyCode == Keys.I)
                inputState.keysDown[Keys.I] = false;
            else if (e.KeyCode == Keys.J)
                inputState.keysDown[Keys.J] = false;
            else if (e.KeyCode == Keys.K)
                inputState.keysDown[Keys.K] = false;
            else if (e.KeyCode == Keys.L)
                inputState.keysDown[Keys.L] = false;
            else if (e.KeyCode == Keys.U)
                inputState.keysDown[Keys.U] = false;
            else if (e.KeyCode == Keys.O)
                inputState.keysDown[Keys.O] = false;
            else if (e.KeyCode == Keys.Space)
                inputState.keysDown[Keys.Space] = false;
            else if (e.KeyCode == Keys.Oemcomma)
                inputState.keysDown[Keys.Oemcomma] = false;
            else if (e.KeyCode == Keys.OemQuestion)
                inputState.keysDown[Keys.OemQuestion] = false;
            else if (e.KeyCode == Keys.LControlKey)
                inputState.keysDown[Keys.LControlKey] = false;
            else if (e.KeyCode == Keys.RControlKey)
                inputState.keysDown[Keys.RControlKey] = false;
            else if (e.KeyCode == Keys.ControlKey)
                inputState.keysDown[Keys.ControlKey] = false;
            else if (e.KeyCode == Keys.ShiftKey)
                inputState.keysDown[Keys.ShiftKey] = false;
            else if (e.KeyCode == Keys.LShiftKey)
                inputState.keysDown[Keys.LShiftKey] = false;
            else if (e.KeyCode == Keys.RShiftKey)
                inputState.keysDown[Keys.RShiftKey] = false;
            else if (e.KeyCode == Keys.Oemtilde)
                inputState.keysDown[Keys.Oemtilde] = false;
            else if (e.KeyCode == Keys.Alt)
            {
                inputState.keysDown[Keys.Alt] = false;
                inputState.keysDown[Keys.Alt] = false;
            }
            else if (e.KeyCode == Keys.D1)
                inputState.keysDown[Keys.D1] = false;
            else if (e.KeyCode == Keys.D2)
                inputState.keysDown[Keys.D2] = false;
            else if (e.KeyCode == Keys.D3)
                inputState.keysDown[Keys.D3] = false;
            else if (e.KeyCode == Keys.D4)
                inputState.keysDown[Keys.D4] = false;
            else if (e.KeyCode == Keys.D5)
                inputState.keysDown[Keys.D5] = false;
            else if (e.KeyCode == Keys.D6)
                inputState.keysDown[Keys.D6] = false;
            else if (e.KeyCode == Keys.D7)
                inputState.keysDown[Keys.D7] = false;
            else if (e.KeyCode == Keys.D8)
                inputState.keysDown[Keys.D8] = false;
            else if (e.KeyCode == Keys.D9)
                inputState.keysDown[Keys.D9] = false;
            else if (e.KeyCode == Keys.D0)
                inputState.keysDown[Keys.D0] = false;
            else if (e.KeyCode == Keys.OemMinus)
                inputState.keysDown[Keys.OemMinus] = false;
            else if (e.KeyCode == Keys.Oemplus)
                inputState.keysDown[Keys.Oemplus] = false;
            else if (e.KeyCode == Keys.Back)
                inputState.keysDown[Keys.Back] = false;

        }

        private void glControl_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                CurrentSettings.Projection = (Fractal.Projection)(((int)CurrentSettings.Projection + 1) % 3);
                CurrentCamera.ChangeMode(CurrentSettings.Projection);

                input_CameraPosition.Enabled = CurrentSettings.Projection == Fractal.Projection.Riemann_Sphere;
                input_CameraAngles.Enabled = CurrentSettings.Projection == Fractal.Projection.Riemann_Sphere;
                input_CameraRoll.Enabled = CurrentSettings.Projection == Fractal.Projection.Cartesian;
                input_RiemannAngles.Enabled = CurrentSettings.Projection == Fractal.Projection.Riemann_Flat;
            }
            if (e.KeyChar == '.')
                pauseTime = !pauseTime;
            if (e.KeyChar == ';')
                CurrentCamera.CurrentSettings.showTarget = !CurrentCamera.CurrentSettings.showTarget;
            if (e.KeyChar == '\'')
                CurrentCamera.CurrentSettings.showAxis = !CurrentCamera.CurrentSettings.showAxis;
            if (e.KeyChar == 'n')
            {
                CurrentCamera.Lock = !CurrentCamera.Lock;

                if (CurrentCamera.Lock)
                {
                    CurrentCamera.ArcBallYaw(0, true, 1);
                    CurrentCamera.ArcBallPitch(0, true, 1);
                }
            }
            if (e.KeyChar == 'm' && CurrentCamera.CurrentMode != Camera.Mode.Flat)
                CurrentCamera.ChangeMode(CurrentCamera.CurrentMode == Camera.Mode.FPS ? Camera.Mode.Free : Camera.Mode.FPS);
        }

        #endregion

        #region MenuStrip
        /// <summary>
        /// Callback for handling File->Exit
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Callback for handling Help->About
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
                "FractalLive is a simple fractal explorer that can be navigated and manipulated with mouse and keyboard controls. <github link>",
                "About FractalLive",
                MessageBoxButtons.OK);
        }
        #endregion

        #region General Controls
        private void button_Menu1_Click(object sender, EventArgs e)
        {
            panel_FormulaMenu.Show();
            panel_FormulaMenu.Enabled = true;
            panel_OrbitTrapMenu.Hide();
            panel_OrbitTrapMenu.Enabled = false;
            panel_ColorMenu.Hide();
            panel_ColorMenu.Enabled = false;
            panel_MiscMenu.Hide();
            panel_MiscMenu.Enabled = false;
        }
        private void button_Menu2_Click(object sender, EventArgs e)
        {
            panel_FormulaMenu.Hide();
            panel_FormulaMenu.Enabled = false;
            panel_OrbitTrapMenu.Show();
            panel_OrbitTrapMenu.Enabled = true;
            panel_ColorMenu.Hide();
            panel_ColorMenu.Enabled = false;
            panel_MiscMenu.Hide();
            panel_MiscMenu.Enabled = false;
        }
        private void button_Menu3_Click(object sender, EventArgs e)
        {
            panel_FormulaMenu.Hide();
            panel_FormulaMenu.Enabled = false;
            panel_OrbitTrapMenu.Hide();
            panel_OrbitTrapMenu.Enabled = false;
            panel_ColorMenu.Show();
            panel_ColorMenu.Enabled = true;
            panel_MiscMenu.Hide();
            panel_MiscMenu.Enabled = false;
        }
        private void button_Menu4_Click(object sender, EventArgs e)
        {
            panel_FormulaMenu.Hide();
            panel_FormulaMenu.Enabled = false;
            panel_OrbitTrapMenu.Hide();
            panel_OrbitTrapMenu.Enabled = false;
            panel_ColorMenu.Hide();
            panel_ColorMenu.Enabled = false;
            panel_MiscMenu.Show();
            panel_MiscMenu.Enabled = true;
        }

        private void input_Center_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse2DFloat(input_Center.Text))
                e.Cancel = true;
        }
        private void input_Center_Validated(object sender, EventArgs e)
        {
            CurrentSettings.Center.X = float.Parse(GetFrom2D(input_Center.Text, true));
            CurrentSettings.Center.Y = float.Parse(GetFrom2D(input_Center.Text, false));
            input_Center.Text = Make2D(CurrentSettings.Center.X, CurrentSettings.Center.Y);
        }

        private void input_Zoom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_Zoom.Text))
                e.Cancel = true;
        }
        private void input_Zoom_Validated(object sender, EventArgs e)
        {
            CurrentSettings.Zoom = float.Parse(input_Zoom.Text);
            input_Zoom.Text = CurrentSettings.Zoom.ToString(); // in case number gets restricted by bounds

            if (!checkBox_LockZoomFactor.Checked)
            {
                CurrentSettings.LockedZoom = CurrentSettings.Zoom;
                input_LockedZoom.Text = CurrentSettings.LockedZoom.ToString();
            }
        }

        private void checkBox_LockZoomFactor_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_LockZoomFactor.Checked)
            {
                CurrentSettings.LockedZoom = CurrentSettings.Zoom;
                input_LockedZoom.Text = CurrentSettings.LockedZoom.ToString();
            }
        }

        private void input_LockedZoom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_LockedZoom.Text))
                e.Cancel = true;
        }
        private void input_LockedZoom_Validated(object sender, EventArgs e)
        {
            CurrentSettings.LockedZoom = float.Parse(input_LockedZoom.Text);
            input_LockedZoom.Text = CurrentSettings.LockedZoom.ToString(); // in case number gets restricted by bounds

            checkBox_LockZoomFactor.Checked = true;
        }

        private void input_CameraPosition_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse3DFloat(input_CameraPosition.Text))
                e.Cancel = true;
        }
        private void input_CameraPosition_Validated(object sender, EventArgs e)
        {
            Vector3 tmp = new Vector3();
            tmp.X = float.Parse(GetFromND(input_CameraPosition.Text, 0));
            tmp.Y = float.Parse(GetFromND(input_CameraPosition.Text, 1));
            tmp.Z = float.Parse(GetFromND(input_CameraPosition.Text, 2));

            CurrentCamera.Position = tmp;
            input_CameraPosition.Text = Make3D(tmp.X, tmp.Y, tmp.Z);
        }

        private void input_CameraAngles_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse2DFloat(input_CameraAngles.Text))
                e.Cancel = true;
        }
        private void input_CameraAngles_Validated(object sender, EventArgs e)
        {
            CurrentCamera.Yaw = float.Parse(GetFrom2D(input_CameraAngles.Text, true));
            CurrentCamera.Pitch = float.Parse(GetFrom2D(input_CameraAngles.Text, false));
            input_CameraAngles.Text = Make2D(CurrentCamera.Yaw, CurrentCamera.Pitch);

            input_CameraPosition.Text = Make3D(CurrentCamera.Position.X, CurrentCamera.Position.Y, CurrentCamera.Position.Z);
        }

        private void input_CameraRoll_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_CameraRoll.Text))
                e.Cancel = true;
        }
        private void input_CameraRoll_Validated(object sender, EventArgs e)
        {
            CurrentCamera.Roll = float.Parse(GetFrom2D(input_CameraRoll.Text, true));
            input_CameraRoll.Text = CurrentCamera.Roll.ToString(); // in case number gets restricted by bounds
        }

        private void input_RiemannAngles_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse2DFloat(input_RiemannAngles.Text))
                e.Cancel = true;
        }
        private void input_RiemannAngles_Validated(object sender, EventArgs e)
        {
            CurrentSettings.RiemannAngles.X = MathHelper.DegreesToRadians(float.Parse(GetFrom2D(input_RiemannAngles.Text, true)));
            CurrentSettings.RiemannAngles.Y = MathHelper.DegreesToRadians(float.Parse(GetFrom2D(input_RiemannAngles.Text, false)));
            input_RiemannAngles.Text = Make2D(MathHelper.RadiansToDegrees(CurrentSettings.RiemannAngles.X), MathHelper.RadiansToDegrees(CurrentSettings.RiemannAngles.Y));
        }

        #endregion

        #region Menu 1 Controls

        private void input_FractalType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentFractalType = (Fractal.Type)input_FractalType.SelectedIndex;

            // Starting values
            input_CameraPosition.Enabled = CurrentSettings.Projection == Fractal.Projection.Riemann_Sphere;
            input_CameraAngles.Enabled = CurrentSettings.Projection == Fractal.Projection.Riemann_Sphere;
            input_CameraRoll.Enabled = CurrentSettings.Projection == Fractal.Projection.Cartesian;
            input_RiemannAngles.Enabled = CurrentSettings.Projection == Fractal.Projection.Riemann_Flat;

            input_FractalFormula.Enabled = currentFractalType != Fractal.Type.Julia_Mating;
            input_FractalFormula.SelectedIndex = (int)CurrentSettings.Formula;
            //label_JuliaPosition.Text = currentFractalType == Fractal.Type.Julia_Mating ? "Julia:" : "Julia*";
            input_JuliaX.Enabled = currentFractalType == Fractal.Type.Julia || currentFractalType == Fractal.Type.Julia_Mating;
            input_JuliaY.Enabled = currentFractalType == Fractal.Type.Julia || currentFractalType == Fractal.Type.Julia_Mating;
            input_JuliaX.Text = currentFractalType == Fractal.Type.Julia_Mating ? Make2D(CurrentSettings.JuliaMating1.X, CurrentSettings.JuliaMating1.Y) : CurrentSettings.Julia.X.ToString();
            input_JuliaY.Text = currentFractalType == Fractal.Type.Julia_Mating ? Make2D(CurrentSettings.JuliaMating2.X, CurrentSettings.JuliaMating2.Y) : CurrentSettings.Julia.Y.ToString();
            input_MatingSteps.Enabled = currentFractalType == Fractal.Type.Julia_Mating;
            input_MatingSteps.Text = Make2D(CurrentSettings.MatingIterations, CurrentSettings.IntermediateMatingSteps);
            input_CurrentMatingStep.Enabled = false;
            input_CurrentMatingStep.Value = 0;
            input_MaxIterations.Value = CurrentSettings.MaxIterations.Value;
            input_MinIterations.Value = CurrentSettings.MinIterations.Value;
            input_StartPositionX.Text = CurrentSettings.StartPosition.X.ToString();
            input_StartPositionY.Text = CurrentSettings.StartPosition.Y.ToString();
            input_Power.Text = Make2D(CurrentSettings.Power.X, CurrentSettings.Power.Y);
            input_CPower.Text = Make2D(CurrentSettings.C_Power.X, CurrentSettings.C_Power.Y);
            input_FoldCount.Text = CurrentSettings.FoldCount.ToString();
            input_FoldAngle.Text = CurrentSettings.FoldAngle.ToString();
            input_FoldOffsetX.Text = CurrentSettings.FoldOffset.X.ToString();
            input_FoldOffsetY.Text = CurrentSettings.FoldOffset.Y.ToString();
            checkBox_UseBuddhabrot.Checked = CurrentSettings.UseBuddhabrot;

            input_OrbitTrap.SelectedIndex = (int)CurrentSettings.OrbitTrap;
            input_OrbitTrapCalculation.SelectedIndex = (int)CurrentSettings.OrbitTrapCalculation;
            input_StartOrbit.Maximum = CurrentSettings.MaxIterations.Maximum;
            input_OrbitRange.Value = CurrentSettings.MaxIterations.Value;
            input_OrbitRange.Maximum = CurrentSettings.MaxIterations.Maximum;
            input_BailoutTexture.Text = CurrentSettings.BailoutTexture;
            input_OrbitTrap_SelectionChangeCommitted(null, null);


            input_EditingColor.SelectedIndex = (int)CurrentSettings.EditingColor;
            input_Coloring.SelectedIndex = (int)CurrentSettings.GetColoring();
            input_DomainCalculation.SelectedIndex = (int)CurrentSettings.GetDomainCalculation();
            input_SecondDomainValueFactor1.Enabled = CurrentSettings.GetUseSecondDomainValue();
            input_SecondDomainValueFactor2.Enabled = CurrentSettings.GetUseSecondDomainValue();
            input_Texture.Text = CurrentSettings.GetTexture();
            checkBox_UseCustomPalette_CheckedChanged(null, null);
            input_EditingColor_SelectionChangeCommitted(null, null);

            if (currentFractalType == Fractal.Type.Julia_Mating)
            {
                label_CurrentMatingStep.Text = "GENERATING:";

                if (juliaMating.CurrentStep == 0)
                    juliaMating.InitializeMating(CurrentSettings.JuliaMating1, CurrentSettings.JuliaMating2, CurrentSettings.MatingIterations, CurrentSettings.IntermediateMatingSteps);
            }
            else
                label_CurrentMatingStep.Text = "Current Step:*";

            input_EditingAnimation.SelectedIndex = (int)CurrentSettings.EditingAnimation;
            input_EditingAnimation_SelectionChangeCommitted(null, null);
        }

        private void input_FractalFormula_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentSettings.Formula = (Fractal.Formula)input_FractalFormula.SelectedIndex;
        }

        private void input_JuliaX_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !IsDecimalChar(e, currentFractalType == Fractal.Type.Julia_Mating);
        }
        private void input_JuliaX_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((currentFractalType == Fractal.Type.Julia && !TryParse1DFloat(input_JuliaX.Text)) || (currentFractalType == Fractal.Type.Julia_Mating && !TryParse2DFloat(input_JuliaX.Text)))
                e.Cancel = true;
        }
        private void input_JuliaX_Validated(object sender, EventArgs e)
        {
            if (currentFractalType == Fractal.Type.Julia)
            {
                CurrentSettings.Julia.X = float.Parse(input_JuliaX.Text);
                input_JuliaX.Text = CurrentSettings.Julia.X.ToString();
            }
            else if (currentFractalType == Fractal.Type.Julia_Mating)
            {
                CurrentSettings.JuliaMating1.X = float.Parse(GetFrom2D(input_JuliaX.Text, true));
                CurrentSettings.JuliaMating1.Y = float.Parse(GetFrom2D(input_JuliaX.Text, false));
                input_JuliaX.Text = Make2D(CurrentSettings.JuliaMating1.X, CurrentSettings.JuliaMating1.Y);

                juliaMating.InitializeMating(CurrentSettings.JuliaMating1, CurrentSettings.JuliaMating2);
                label_CurrentMatingStep.Text = "GENERATING: ";
                input_CurrentMatingStep.Enabled = false;
            }
        }

        private void input_JuliaY_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !IsDecimalChar(e, currentFractalType == Fractal.Type.Julia_Mating);
        }
        private void input_JuliaY_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((currentFractalType == Fractal.Type.Julia && !TryParse1DFloat(input_JuliaY.Text)) || (currentFractalType == Fractal.Type.Julia_Mating && !TryParse2DFloat(input_JuliaY.Text)))
                e.Cancel = true;
        }
        private void input_JuliaY_Validated(object sender, EventArgs e)
        {
            if (currentFractalType == Fractal.Type.Julia)
            {
                CurrentSettings.Julia.Y = float.Parse(input_JuliaY.Text);
                input_JuliaY.Text = CurrentSettings.Julia.Y.ToString();
            }
            else if (currentFractalType == Fractal.Type.Julia_Mating)
            {
                CurrentSettings.JuliaMating2.X = float.Parse(GetFrom2D(input_JuliaY.Text, true));
                CurrentSettings.JuliaMating2.Y = float.Parse(GetFrom2D(input_JuliaY.Text, false));
                input_JuliaY.Text = Make2D(CurrentSettings.JuliaMating2.X, CurrentSettings.JuliaMating2.Y);

                juliaMating.InitializeMating(CurrentSettings.JuliaMating1, CurrentSettings.JuliaMating2);
                label_CurrentMatingStep.Text = "GENERATING: ";
                input_CurrentMatingStep.Enabled = false;
            }
        }

        private void input_MatingSteps_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse2DFloat(input_MatingSteps.Text))
                e.Cancel = true;
            else
            {
                float test1 = float.Parse(GetFrom2D(input_MatingSteps.Text, true));
                float test2 = float.Parse(GetFrom2D(input_MatingSteps.Text, false));

                if (test1 > JuliaMating.MAX_MATING_ITER || test1 * test2 > JuliaMating.MAX_STEPS)
                //if (test1 * test2 > JuliaMating.MAX_STEPS)
                //if (test1 > JuliaMating.MAX_MATING_ITER)
                {
                    MessageBox.Show("Mating_Iterations must not exceed " + JuliaMating.MAX_MATING_ITER.ToString() + ", and Mating_Iterations * Intermediate_Steps must be smaller or equal to " + JuliaMating.MAX_STEPS.ToString() + ".", "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }
        private void input_MatingSteps_Validated(object sender, EventArgs e)
        {
            CurrentSettings.MatingIterations = int.Parse(GetFrom2D(input_MatingSteps.Text, true));
            CurrentSettings.IntermediateMatingSteps = int.Parse(GetFrom2D(input_MatingSteps.Text, false));
            input_MatingSteps.Text = Make2D(CurrentSettings.MatingIterations, CurrentSettings.IntermediateMatingSteps);

            juliaMating.InitializeMating(CurrentSettings.MatingIterations, CurrentSettings.IntermediateMatingSteps);
            label_CurrentMatingStep.Text = "GENERATING: ";
            input_CurrentMatingStep.Enabled = false;
        }

        private void input_CurrentMatingStep_ValueChanged(object sender, EventArgs e)
        {
            if (juliaMating.Completed)
            {
                CurrentSettings.CurrentMatingStep = Math.Clamp((int)input_CurrentMatingStep.Value, 0, CurrentSettings.MatingIterations * CurrentSettings.IntermediateMatingSteps - 1);
                input_CurrentMatingStep.Value = CurrentSettings.CurrentMatingStep;
                juliaMating.CurrentStep = CurrentSettings.CurrentMatingStep;
            }
        }

        private void input_MaxIterations_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentSettings.MaxIterations.Value == CurrentSettings.OrbitRange.Value && input_MaxIterations.Value != 0)
            {
                CurrentSettings.OrbitRange.Value = (int)input_MaxIterations.Value;
                input_OrbitRange.Value = CurrentSettings.OrbitRange.Value;
            }

            CurrentSettings.MaxIterations.SetValue((int)input_MaxIterations.Value);

            if (CurrentSettings.MaxIterations.Value < CurrentSettings.MinIterations.Value)
                input_MinIterations.Value = CurrentSettings.MaxIterations.Value;

            /*
            input_StartOrbit.Maximum = CurrentSettings.MaxIterations.Value;
            if (input_StartOrbit.Value > CurrentSettings.MaxIterations.Value)
                input_StartOrbit.Value = CurrentSettings.MaxIterations.Value;

            input_OrbitRange.Maximum = CurrentSettings.MaxIterations.Value;
            if (input_OrbitRange.Value > CurrentSettings.MaxIterations.Value)
                input_OrbitRange.Value = CurrentSettings.MaxIterations.Value;*/
        }

        private void input_MinIterations_ValueChanged(object sender, EventArgs e)
        {
            CurrentSettings.MinIterations.SetValue((int)input_MinIterations.Value);

            if (CurrentSettings.MinIterations.Value > CurrentSettings.MaxIterations.Value)
                input_MaxIterations.Value = CurrentSettings.MinIterations.Value;
        }

        private void checkBox_UseConjugate_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.UseConjugate = checkBox_UseConjugate.Checked;
        }

        private void input_StartPositionX_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_StartPositionX.Text))
                e.Cancel = true;
        }
        private void input_StartPositionX_Validated(object sender, EventArgs e)
        {
            CurrentSettings.StartPosition.X = float.Parse(input_StartPositionX.Text);
            input_StartPositionX.Text = CurrentSettings.StartPosition.X.ToString();
        }

        private void input_StartPositionY_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_StartPositionY.Text))
                e.Cancel = true;
        }
        private void input_StartPositionY_Validated(object sender, EventArgs e)
        {
            CurrentSettings.StartPosition.Y = float.Parse(input_StartPositionY.Text);
            input_StartPositionY.Text = CurrentSettings.StartPosition.Y.ToString();
        }

        private void input_Power_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse2DFloat(input_Power.Text))
                e.Cancel = true;
        }
        private void input_Power_Validated(object sender, EventArgs e)
        {
            CurrentSettings.Power.X = float.Parse(GetFrom2D(input_Power.Text, true));
            CurrentSettings.Power.Y = float.Parse(GetFrom2D(input_Power.Text, false));
            input_Power.Text = Make2D(CurrentSettings.Power.X, CurrentSettings.Power.Y);
        }

        private void input_CPower_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse2DFloat(input_CPower.Text))
                e.Cancel = true;
        }
        private void input_CPower_Validated(object sender, EventArgs e)
        {
            CurrentSettings.C_Power.X = float.Parse(GetFrom2D(input_CPower.Text, true));
            CurrentSettings.C_Power.Y = float.Parse(GetFrom2D(input_CPower.Text, false));
            input_CPower.Text = Make2D(CurrentSettings.C_Power.X, CurrentSettings.C_Power.Y);
        }

        private void input_FoldCount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_FoldCount.Text))
                e.Cancel = true;
        }
        private void input_FoldCount_Validated(object sender, EventArgs e)
        {
            CurrentSettings.FoldCount = float.Parse(input_FoldCount.Text);
            input_FoldCount.Text = CurrentSettings.FoldCount.ToString();
        }

        private void input_FoldAngle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_FoldAngle.Text))
                e.Cancel = true;
        }
        private void input_FoldAngle_Validated(object sender, EventArgs e)
        {
            CurrentSettings.FoldAngle = float.Parse(input_FoldAngle.Text);
            input_FoldAngle.Text = CurrentSettings.FoldAngle.ToString();
        }

        private void input_FoldOffsetX_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_FoldOffsetX.Text))
                e.Cancel = true;
        }
        private void input_FoldOffsetX_Validated(object sender, EventArgs e)
        {
            CurrentSettings.FoldOffset.X = float.Parse(input_FoldOffsetX.Text);
            input_FoldOffsetX.Text = CurrentSettings.FoldOffset.X.ToString();
        }

        private void input_FoldOffsetY_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_FoldOffsetY.Text))
                e.Cancel = true;
        }
        private void input_FoldOffsetY_Validated(object sender, EventArgs e)
        {
            CurrentSettings.FoldOffset.Y = float.Parse(input_FoldOffsetY.Text);
            input_FoldOffsetY.Text = CurrentSettings.FoldOffset.Y.ToString();
        }

        #endregion

        #region Menu 2 Controls
        private void input_OrbitTrap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentSettings.OrbitTrap = (Fractal.OrbitTrap)input_OrbitTrap.SelectedIndex;

            input_StartOrbit.Enabled = true;
            input_OrbitRange.Enabled = true;
            input_OrbitTrapBlendingFactor.Enabled = true;
            input_OrbitTrapThicknessFactor.Enabled = true;

            input_OrbitTrapCalculation.Enabled = true;
            input_Bailout.Enabled = true;
            checkBox_UseSecondValue.Enabled = true;
            input_SecondValueFactor1.Enabled = checkBox_UseSecondValue.Checked;
            input_SecondValueFactor2.Enabled = checkBox_UseSecondValue.Checked;
            input_StartDistance.Enabled = true;

            if (CurrentSettings.Is1DBailout)
            {
                input_BailoutX.Enabled = false;
                input_BailoutY.Enabled = false;

                button_AddBailoutTrap.Enabled = false;
                button_RemoveBailoutTrap.Enabled = false;
                input_EditingBailoutTrapList.Enabled = false;

                input_Bailout.Text = CurrentSettings.Bailout.ToString();
            }
            else if (CurrentSettings.Is2DBailout || CurrentSettings.Is3DBailout)
            {
                bool pointsOnly = CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points;

                input_BailoutX.Enabled = true;
                input_BailoutY.Enabled = true;

                button_AddBailoutTrap.Enabled = pointsOnly;
                button_RemoveBailoutTrap.Enabled = pointsOnly;
                input_EditingBailoutTrapList.Enabled = pointsOnly;

                if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Rectangle)
                {
                    input_BailoutX.Text = CurrentSettings.BailoutRectangle.X.ToString();
                    input_BailoutY.Text = CurrentSettings.BailoutRectangle.Y.ToString();
                }
                else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Spiral)
                {
                    input_EditingBailoutTrapList.Maximum = CurrentSettings.BailoutPointsCount;
                    input_EditingBailoutTrapList.Value = input_EditingBailoutTrapList.Maximum;
                    label_EditingOrbitBailout.Text = "Editing Spiral";

                    input_BailoutX.Text = Make2D(CurrentSettings.BailoutSpiral.X, CurrentSettings.BailoutSpiral.Y);
                    input_BailoutY.Text = Make2D(MathHelper.RadiansToDegrees(CurrentSettings.BailoutSpiral.Z), CurrentSettings.BailoutSpiral.W);
                }
                else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
                {
                    label_EditingOrbitBailout.Text = "Editing Point";

                    input_BailoutX.Text = CurrentSettings.BailoutPoints[CurrentSettings.BailoutPointsCount - 1].X.ToString();
                    input_BailoutY.Text = CurrentSettings.BailoutPoints[CurrentSettings.BailoutPointsCount - 1].Y.ToString();
                }
            }
            else // lines
            {
                input_BailoutX.Enabled = true;
                input_BailoutY.Enabled = true;

                button_AddBailoutTrap.Enabled = true;
                button_RemoveBailoutTrap.Enabled = true;
                input_EditingBailoutTrapList.Enabled = true;

                input_EditingBailoutTrapList.Maximum = CurrentSettings.BailoutLinesCount;
                input_EditingBailoutTrapList.Value = input_EditingBailoutTrapList.Maximum;
                label_EditingOrbitBailout.Text = "Editing Line";

                input_BailoutX.Text = Make2D(CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].X, CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].Y);
                input_BailoutY.Text = Make2D(CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].Z, CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].W);
            }
        }

        private void input_Bailout_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_Bailout.Text))
                e.Cancel = true;
        }
        private void input_Bailout_Validated(object sender, EventArgs e)
        {
            CurrentSettings.Bailout = float.Parse(input_Bailout.Text);
            input_Bailout.Text = CurrentSettings.Bailout.ToString(); // in case number gets restricted by bounds
        }

        private void button_AddBailoutTrap_Click(object sender, EventArgs e)
        {
            if (input_EditingBailoutTrapList.Maximum < 16)
            {
                input_EditingBailoutTrapList.Maximum++;

                if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
                {
                    CurrentSettings.AddPoint(Vector2.Zero);
                    input_EditingBailoutTrapList.Value = CurrentSettings.BailoutPointsCount;

                    input_BailoutX.Text = CurrentSettings.BailoutPoints[CurrentSettings.BailoutPointsCount - 1].X.ToString();
                    input_BailoutY.Text = CurrentSettings.BailoutPoints[CurrentSettings.BailoutPointsCount - 1].Y.ToString();
                }
                else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                {
                    CurrentSettings.AddLine(Vector4.UnitW);
                    input_EditingBailoutTrapList.Value = CurrentSettings.BailoutLinesCount;

                    input_BailoutX.Text = Make2D(CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].X, CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].Y);
                    input_BailoutY.Text = Make2D(CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].Z, CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].W);
                }
            }

        }
        private void button_RemoveBailoutTrap_Click(object sender, EventArgs e)
        {
            if (input_EditingBailoutTrapList.Maximum > 1)
            {
                if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
                {
                    CurrentSettings.RemovePoint((int)input_EditingBailoutTrapList.Value - 1);

                    int current = Math.Clamp((int)input_EditingBailoutTrapList.Value, 1, CurrentSettings.BailoutPointsCount);
                    input_EditingBailoutTrapList.Value = current--;

                    input_BailoutX.Text = CurrentSettings.BailoutPoints[current].X.ToString();
                    input_BailoutY.Text = CurrentSettings.BailoutPoints[current].Y.ToString();
                }
                else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                {
                    CurrentSettings.RemoveLine((int)input_EditingBailoutTrapList.Value - 1);

                    int current = Math.Clamp((int)input_EditingBailoutTrapList.Value, 1, CurrentSettings.BailoutLinesCount);
                    input_EditingBailoutTrapList.Value = current--;

                    input_BailoutX.Text = Make2D(CurrentSettings.BailoutLines[current].X, CurrentSettings.BailoutLines[current].Y);
                    input_BailoutY.Text = Make2D(CurrentSettings.BailoutLines[current].Z, CurrentSettings.BailoutLines[current].W);
                }

                input_EditingBailoutTrapList.Maximum--;
            }

        }

        private void input_EditingBailoutTrap_ValueChanged(object sender, EventArgs e)
        {
            int index = (int)input_EditingBailoutTrapList.Value - 1;

            if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
            {
                input_BailoutX.Text = CurrentSettings.BailoutPoints[index].X.ToString();
                input_BailoutY.Text = CurrentSettings.BailoutPoints[index].Y.ToString();
            }
            else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
            {
                input_BailoutX.Text = Make2D(CurrentSettings.BailoutLines[index].X, CurrentSettings.BailoutLines[index].Y);
                input_BailoutY.Text = Make2D(CurrentSettings.BailoutLines[index].Z, CurrentSettings.BailoutLines[index].W);
            }
        }

        private void input_BailoutX_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !IsDecimalChar(e, CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Spiral || CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines);
        }
        private void input_BailoutX_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((CurrentSettings.OrbitTrap != Fractal.OrbitTrap.Lines && CurrentSettings.OrbitTrap != Fractal.OrbitTrap.Spiral && !TryParse1DFloat(input_BailoutX.Text)) || ((CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Spiral || CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines) && !TryParse2DFloat(input_BailoutX.Text)))
                e.Cancel = true;
        }
        private void input_BailoutX_Validated(object sender, EventArgs e)
        {
            int editingBailoutTrap = (int)input_EditingBailoutTrapList.Value - 1;

            if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Rectangle)
            {
                CurrentSettings.BailoutRectangle.X = float.Parse(input_BailoutX.Text);
                input_BailoutX.Text = CurrentSettings.BailoutRectangle.X.ToString();
            }
            else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Spiral)
            {
                CurrentSettings.BailoutSpiral.X = float.Parse(GetFrom2D(input_BailoutX.Text, true));
                CurrentSettings.BailoutSpiral.Y = float.Parse(GetFrom2D(input_BailoutX.Text, false));
                input_BailoutX.Text = Make2D(CurrentSettings.BailoutSpiral.X, CurrentSettings.BailoutSpiral.Y);
            }
            else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
            {
                CurrentSettings.BailoutPoints[editingBailoutTrap].X = float.Parse(input_BailoutX.Text);
                input_BailoutX.Text = CurrentSettings.BailoutPoints[editingBailoutTrap].X.ToString();
            }
            else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
            {
                CurrentSettings.BailoutLines[editingBailoutTrap].X = float.Parse(GetFrom2D(input_BailoutX.Text, true));
                CurrentSettings.BailoutLines[editingBailoutTrap].Y = float.Parse(GetFrom2D(input_BailoutX.Text, false));
                input_BailoutX.Text = Make2D(CurrentSettings.BailoutLines[editingBailoutTrap].X, CurrentSettings.BailoutLines[editingBailoutTrap].Y);
            }
        }

        private void input_BailoutY_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !IsDecimalChar(e, CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Spiral || CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines);
        }
        private void input_BailoutY_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((CurrentSettings.OrbitTrap != Fractal.OrbitTrap.Lines && CurrentSettings.OrbitTrap != Fractal.OrbitTrap.Spiral && !TryParse1DFloat(input_BailoutY.Text)) || ((CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Spiral || CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines) && !TryParse2DFloat(input_BailoutY.Text)))
                e.Cancel = true;
        }
        private void input_BailoutY_Validated(object sender, EventArgs e)
        {
            int editingBailoutTrap = (int)input_EditingBailoutTrapList.Value - 1;

            if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Rectangle)
            {
                CurrentSettings.BailoutRectangle.Y = float.Parse(input_BailoutY.Text);
                input_BailoutY.Text = CurrentSettings.BailoutRectangle.Y.ToString();
            }
            else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Spiral)
            {
                CurrentSettings.BailoutSpiral.Z = MathHelper.DegreesToRadians(float.Parse(GetFrom2D(input_BailoutY.Text, true) + (float)(2*Math.PI)) % (float)(2*Math.PI));
                CurrentSettings.BailoutSpiral.W = float.Parse(GetFrom2D(input_BailoutY.Text, false));
                input_BailoutY.Text = Make2D(MathHelper.RadiansToDegrees(CurrentSettings.BailoutSpiral.Z), CurrentSettings.BailoutSpiral.W);
            }
            else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
            {
                CurrentSettings.BailoutPoints[editingBailoutTrap].Y = float.Parse(input_BailoutY.Text);
                input_BailoutY.Text = CurrentSettings.BailoutPoints[editingBailoutTrap].Y.ToString();
            }
            else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
            {
                CurrentSettings.BailoutLines[editingBailoutTrap].Z = float.Parse(GetFrom2D(input_BailoutY.Text, true));
                CurrentSettings.BailoutLines[editingBailoutTrap].W = float.Parse(GetFrom2D(input_BailoutY.Text, false));
                input_BailoutY.Text = Make2D(CurrentSettings.BailoutLines[editingBailoutTrap].Z, CurrentSettings.BailoutLines[editingBailoutTrap].W);
            }
        }

        private void input_StartDistance_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_StartDistance.Text))
                e.Cancel = true;
        }
        private void input_StartDistance_Validated(object sender, EventArgs e)
        {
            CurrentSettings.StartOrbitDistance.Value = float.Parse(input_StartDistance.Text);
            input_StartDistance.Text = CurrentSettings.StartOrbitDistance.Value.ToString(); // in case number gets restricted by bounds
        }

        private void input_OrbitTrapCalculation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentSettings.OrbitTrapCalculation = (Fractal.Calculation)input_OrbitTrapCalculation.SelectedIndex;
        }

        private void input_StartOrbit_ValueChanged(object sender, EventArgs e)
        {
            CurrentSettings.StartOrbit.Value = (int)input_StartOrbit.Value;
        }

        private void input_OrbitRange_ValueChanged(object sender, EventArgs e)
        {
            CurrentSettings.OrbitRange.Value = (int)input_OrbitRange.Value;
        }

        private void input_OrbitTrapFactor1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_OrbitTrapBlendingFactor.Text))
                e.Cancel = true;
        }
        private void input_OrbitTrapFactor1_Validated(object sender, EventArgs e)
        {
            CurrentSettings.BailoutFactor1 = float.Parse(input_OrbitTrapBlendingFactor.Text);
            input_OrbitTrapBlendingFactor.Text = CurrentSettings.BailoutFactor1.ToString();
        }

        private void input_OrbitTrapFactor2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_OrbitTrapThicknessFactor.Text))
                e.Cancel = true;
        }
        private void input_OrbitTrapFactor2_Validated(object sender, EventArgs e)
        {
            CurrentSettings.BailoutFactor2 = float.Parse(input_OrbitTrapThicknessFactor.Text);
            input_OrbitTrapThicknessFactor.Text = CurrentSettings.BailoutFactor2.ToString();
        }

        private void checkBox_UseSecondValue_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.UseSecondValue = checkBox_UseSecondValue.Checked;

            if (checkBox_UseSecondValue.Checked)
            {
                input_SecondValueFactor1.Enabled = true;
                input_SecondValueFactor2.Enabled = true;
            }
            else
            {
                input_SecondValueFactor1.Enabled = false;
                input_SecondValueFactor2.Enabled = false;
            }
        }

        private void input_SecondValueFactor1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_SecondValueFactor1.Text))
                e.Cancel = true;
        }
        private void input_SecondValueFactor1_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SecondValueFactor1 = float.Parse(input_SecondValueFactor1.Text);
            input_SecondValueFactor1.Text = CurrentSettings.SecondValueFactor1.ToString();
        }

        private void input_SecondValueFactor2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_SecondValueFactor2.Text))
                e.Cancel = true;
        }
        private void input_SecondValueFactor2_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SecondValueFactor2 = float.Parse(input_SecondValueFactor2.Text);
            input_SecondValueFactor2.Text = CurrentSettings.SecondValueFactor2.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input_BailoutTexture.Text = "";
        }

        private void input_BailoutTexture_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = input_BailoutTexture.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                input_BailoutTexture.Text = openFileDialog1.FileName;
        }
        private void input_BailoutTexture_TextChanged(object sender, EventArgs e)
        {
            CurrentSettings.BailoutTexture = input_BailoutTexture.Text;
            bool enabled = input_BailoutTexture.Text != "";

            if (enabled)
            {
                texture0 = Texture.LoadFromFile(input_BailoutTexture.Text);
                texture0.Use(OpenTK.Graphics.OpenGL4.TextureUnit.Texture0);
            }

            input_BailoutTextureBlend.Enabled = enabled;
            input_BailoutTextureScaleX.Enabled = enabled;
            input_TextureScaleY.Enabled = enabled;
            checkBox_BailoutUsePolarTextureCoordinates.Enabled = enabled;
        }

        private void input_BailoutTextureBlend_ValueChanged(object sender, EventArgs e)
        {
            CurrentSettings.BailoutTextureBlend = (float)input_BailoutTextureBlend.Value;
        }

        private void input_BailoutTextureScaleX_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_BailoutTextureScaleX.Text))
                e.Cancel = true;
        }
        private void input_BailoutTextureScaleX_Validated(object sender, EventArgs e)
        {
            CurrentSettings.BailoutTextureScaleX = float.Parse(input_BailoutTextureScaleX.Text);
            input_BailoutTextureScaleX.Text = CurrentSettings.BailoutTextureScaleX.ToString();
        }

        private void input_BailoutTextureScaleY_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_BailoutTextureScaleY.Text))
                e.Cancel = true;
        }
        private void input_BailoutTextureScaleY_Validated(object sender, EventArgs e)
        {
            CurrentSettings.BailoutTextureScaleY = float.Parse(input_BailoutTextureScaleY.Text);
            input_BailoutTextureScaleY.Text = CurrentSettings.BailoutTextureScaleY.ToString();
        }

        private void checkBox_BailoutUsePolarTextureCoordinates_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.BailoutUsePolarTextureCoordinates = checkBox_BailoutUsePolarTextureCoordinates.Checked;
        }

        #endregion

        #region Menu 3 Controls
        private void input_EditingColor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentSettings.EditingColor = (Fractal.Editing)input_EditingColor.SelectedIndex;
            input_Coloring.SelectedIndex = (int)CurrentSettings.GetColoring();
            checkBox_UseCustomPalette.Checked = CurrentSettings.GetUseCustomPalette();
            input_ColorCycles.Text = CurrentSettings.GetColorCycles().ToString();
            input_ColorFactor.Text = CurrentSettings.GetColorFactor().ToString();
            input_OrbitTrapFactor.Text = CurrentSettings.GetOrbitTrapFactor().ToString();
            input_StripeDensity.Text = CurrentSettings.GetStripeDensity().ToString();
            //checkBox_MatchOrbitTrap.Enabled = CurrentSettings.EditingColor != Fractal.Editing.Interior;
            checkBox_MatchOrbitTrap.Checked = CurrentSettings.GetMatchOrbitTrap();
            //input_DomainCalculation.Enabled = CurrentSettings.EditingColor != Fractal.Editing.Interior;
            input_DomainCalculation.SelectedIndex = (int)CurrentSettings.GetDomainCalculation();
            checkBox_UseDomainIteration.Checked = CurrentSettings.GetUseDomainIteration();
            checkBox_UseSecondDomainValue.Checked = CurrentSettings.GetUseSecondDomainValue();
            input_SecondDomainValueFactor1.Text = CurrentSettings.GetSecondDomainValueFactor1().ToString();
            input_SecondDomainValueFactor2.Text = CurrentSettings.GetSecondDomainValueFactor2().ToString();
            //checkBox_UseDistanceEstimation.Enabled = CurrentSettings.EditingColor != Fractal.Editing.Interior;
            checkBox_UseDistanceEstimation.Checked = CurrentSettings.GetUseDistanceEstimation();
            checkBox_UseNormals.Enabled = checkBox_UseDistanceEstimation.Checked;
            checkBox_UseNormals.Checked = CurrentSettings.GetUseNormals();
            input_MaxDistanceEstimation.Text = CurrentSettings.GetMaxDistanceEstimation().ToString();
            input_DistanceEstimationFactor1.Text = CurrentSettings.GetDistanceEstimationFactor1().ToString();
            input_Texture.Text = CurrentSettings.GetTexture();
            input_TextureBlend.Value = (decimal)CurrentSettings.GetTextureBlend();
            input_TextureScaleX.Text = CurrentSettings.GetTextureScaleX().ToString();
            input_TextureScaleY.Text = CurrentSettings.GetTextureScaleY().ToString();
            checkBox_UsePolarTextureCoordinates.Checked = CurrentSettings.GetUsePolarTextureCoordinates();
            checkBox_UseDistortedTexture.Checked = CurrentSettings.GetUseTextureDistortion();
            input_TextureDistortionFactor.Text = CurrentSettings.GetTextureDistortion().ToString();

            input_Coloring_SelectionChangeCommitted(null, null);
        }

        private void input_Coloring_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentSettings.SetColoring((Fractal.Coloring)input_Coloring.SelectedIndex);
            /*
            if (CurrentSettings.GetColoring() >= Fractal.Coloring.Domain_1)
                input_DomainCalculation.Enabled = true;
            else
                input_DomainCalculation.Enabled = false;*/

            bool usingDomain = (CurrentSettings.GetColoring() >= Fractal.Coloring.Stripes_1 && CurrentSettings.GetColoring() <= Fractal.Coloring.Stripes_2) || (CurrentSettings.GetColoring() >= Fractal.Coloring.Domain_1 && CurrentSettings.GetColoring() <= Fractal.Coloring.Domain_7);
            checkBox_MatchOrbitTrap.Enabled = usingDomain;
            input_StripeDensity.Enabled = CurrentSettings.GetColoring() >= Fractal.Coloring.Stripes_1 && CurrentSettings.GetColoring() <= Fractal.Coloring.Stripes_2;
            input_DomainCalculation.Enabled = usingDomain && !checkBox_MatchOrbitTrap.Checked;
            checkBox_UseDomainIteration.Enabled = usingDomain; 
            checkBox_UseSecondDomainValue.Enabled = usingDomain; 
            input_SecondDomainValueFactor1.Enabled = usingDomain && checkBox_UseSecondDomainValue.Checked; 
            input_SecondDomainValueFactor2.Enabled = usingDomain && checkBox_UseSecondDomainValue.Checked; 
        }

        private void checkBox_UseCustomPalette_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.SetUseCustomPalette(checkBox_UseCustomPalette.Checked);

            if (checkBox_UseCustomPalette.Checked)
            {
                button_Color1.Enabled = true;
                button_Color2.Enabled = true;
                button_Color3.Enabled = true;
                button_Color4.Enabled = true;
                button_Color5.Enabled = true;
                button_Color6.Enabled = true;

                button_Color1.BackColor = CurrentSettings.GetCustomPalette(0);
                button_Color2.BackColor = CurrentSettings.GetCustomPalette(1);
                button_Color3.BackColor = CurrentSettings.GetCustomPalette(2);
                button_Color4.BackColor = CurrentSettings.GetCustomPalette(3);
                button_Color5.BackColor = CurrentSettings.GetCustomPalette(4);
                button_Color6.BackColor = CurrentSettings.GetCustomPalette(5);
            }
            else
            {
                button_Color1.Enabled = false;
                button_Color2.Enabled = false;
                button_Color3.Enabled = false;
                button_Color4.Enabled = false;
                button_Color5.Enabled = false;
                button_Color6.Enabled = false;

                int scale = 2;
                button_Color1.BackColor = Color.FromArgb(255, button_Color1.BackColor.R / scale, button_Color1.BackColor.G / scale, button_Color1.BackColor.B / scale);
                button_Color2.BackColor = Color.FromArgb(255, button_Color2.BackColor.R / scale, button_Color2.BackColor.G / scale, button_Color2.BackColor.B / scale);
                button_Color3.BackColor = Color.FromArgb(255, button_Color3.BackColor.R / scale, button_Color3.BackColor.G / scale, button_Color3.BackColor.B / scale);
                button_Color4.BackColor = Color.FromArgb(255, button_Color4.BackColor.R / scale, button_Color4.BackColor.G / scale, button_Color4.BackColor.B / scale);
                button_Color5.BackColor = Color.FromArgb(255, button_Color5.BackColor.R / scale, button_Color5.BackColor.G / scale, button_Color5.BackColor.B / scale);
                button_Color6.BackColor = Color.FromArgb(255, button_Color6.BackColor.R / scale, button_Color6.BackColor.G / scale, button_Color6.BackColor.B / scale);
            }
        }

        private void button_Color1_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = button_Color1.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button_Color1.BackColor = colorDialog1.Color;
                CurrentSettings.SetCustomPalette(0, colorDialog1.Color);
            }
        }
        private void button_Color2_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = button_Color2.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button_Color2.BackColor = colorDialog1.Color;
                CurrentSettings.SetCustomPalette(1, colorDialog1.Color);
            }
        }
        private void button_Color3_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = button_Color3.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button_Color3.BackColor = colorDialog1.Color;
                CurrentSettings.SetCustomPalette(2, colorDialog1.Color);
            }
        }
        private void button_Color4_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = button_Color4.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button_Color4.BackColor = colorDialog1.Color;
                CurrentSettings.SetCustomPalette(3, colorDialog1.Color);
            }
        }
        private void button_Color5_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = button_Color5.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button_Color5.BackColor = colorDialog1.Color;
                CurrentSettings.SetCustomPalette(4, colorDialog1.Color);
            }
        }
        private void button_Color6_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = button_Color6.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button_Color6.BackColor = colorDialog1.Color;
                CurrentSettings.SetCustomPalette(5, colorDialog1.Color);
            }
        }

        private void input_ColorCycles_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_ColorCycles.Text))
                e.Cancel = true;
        }
        private void input_ColorCycles_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetColorCycles(float.Parse(input_ColorCycles.Text));
            input_ColorCycles.Text = CurrentSettings.GetColorCycles().ToString();
        }

        private void input_ColorFactor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_ColorFactor.Text))
                e.Cancel = true;
        }
        private void input_ColorFactor_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetColorFactor(float.Parse(input_ColorFactor.Text));
            input_ColorFactor.Text = CurrentSettings.GetColorFactor().ToString();
        }

        private void input_OrbitTrapFactor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_OrbitTrapFactor.Text))
                e.Cancel = true;
        }
        private void input_OrbitTrapFactor_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetOrbitTrapFactor(float.Parse(input_OrbitTrapFactor.Text));
            input_OrbitTrapFactor.Text = CurrentSettings.GetOrbitTrapFactor().ToString();
        }

        private void input_StripeDensity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_StripeDensity.Text))
                e.Cancel = true;
        }
        private void input_StripeDensity_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetStripeDensity(float.Parse(input_StripeDensity.Text));
            input_StripeDensity.Text = CurrentSettings.GetStripeDensity().ToString();
        }

        private void input_DomainCalculation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentSettings.SetDomainCalculation((Fractal.Calculation)input_DomainCalculation.SelectedIndex);
        }

        private void checkBox_UseDomainIteration_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.SetUseDomainIteration(checkBox_UseDomainIteration.Checked);
        }

        private void checkBox_UseSecondDomainValue_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.SetUseSecondDomainValue(checkBox_UseSecondDomainValue.Checked);

            input_SecondDomainValueFactor1.Enabled = checkBox_UseSecondDomainValue.Checked;
            input_SecondDomainValueFactor2.Enabled = checkBox_UseSecondDomainValue.Checked;
        }

        private void input_SecondDomainValueFactor1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_SecondDomainValueFactor1.Text))
                e.Cancel = true;
        }
        private void input_SecondDomainValueFactor1_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetSecondDomainValueFactor1(float.Parse(input_SecondDomainValueFactor1.Text));
            input_SecondDomainValueFactor1.Text = CurrentSettings.GetSecondDomainValueFactor1().ToString();
        }

        private void input_SecondDomainValueFactor2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_SecondDomainValueFactor2.Text))
                e.Cancel = true;
        }
        private void input_SecondDomainValueFactor2_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetSecondDomainValueFactor2(float.Parse(input_SecondDomainValueFactor2.Text));
            input_SecondDomainValueFactor2.Text = CurrentSettings.GetSecondDomainValueFactor2().ToString();
        }

        private void checkBox_MatchOrbitTrap_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.SetMatchOrbitTrap(checkBox_MatchOrbitTrap.Checked);

            input_DomainCalculation.Enabled = !checkBox_MatchOrbitTrap.Checked;
        }

        private void checkBox_UseDistanceEstimation_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.SetUseDistanceEstimation(checkBox_UseDistanceEstimation.Checked);

            input_MaxDistanceEstimation.Enabled = checkBox_UseDistanceEstimation.Checked;
            input_DistanceEstimationFactor1.Enabled = checkBox_UseDistanceEstimation.Checked;
            input_DistanceEstimationFactor2.Enabled = checkBox_UseDistanceEstimation.Checked;
            checkBox_UseNormals.Enabled = checkBox_UseDistanceEstimation.Checked;
        }

        private void input_MaxDistanceEstimation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_MaxDistanceEstimation.Text))
                e.Cancel = true;
        }
        private void input_MaxDistanceEstimation_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetMaxDistanceEstimation(float.Parse(input_MaxDistanceEstimation.Text));
            input_MaxDistanceEstimation.Text = CurrentSettings.GetMaxDistanceEstimation().ToString();
        }

        private void input_DistanceEstimationFactor1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_DistanceEstimationFactor1.Text))
                e.Cancel = true;
        }
        private void input_DistanceEstimationFactor1_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetDistanceEstimationFactor1(float.Parse(input_DistanceEstimationFactor1.Text));
            input_DistanceEstimationFactor1.Text = CurrentSettings.GetDistanceEstimationFactor1().ToString();
        }

        private void input_DistanceEstimationFactor2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_DistanceEstimationFactor2.Text))
                e.Cancel = true;
        }
        private void input_DistanceEstimationFactor2_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetDistanceEstimationFactor2(float.Parse(input_DistanceEstimationFactor2.Text));
            input_DistanceEstimationFactor2.Text = CurrentSettings.GetDistanceEstimationFactor2().ToString();
        }

        private void checkBox_UseNormals_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.SetUseNormals(checkBox_UseNormals.Checked);
        }

        private void button_ClearTexture_Click(object sender, EventArgs e)
        {
            input_Texture.Text = "";
        }

        private void input_Texture_TextChanged(object sender, EventArgs e)
        {
            CurrentSettings.SetTexture(input_Texture.Text);
            bool enabled = input_Texture.Text != "";

            if (enabled)
                if (CurrentSettings.EditingColor == Fractal.Editing.Interior)
                {
                    texture2 = Texture.LoadFromFile(input_Texture.Text);
                    texture2.Use(OpenTK.Graphics.OpenGL4.TextureUnit.Texture2);
                }
                else if (CurrentSettings.EditingColor == Fractal.Editing.Exterior)
                {
                    texture3 = Texture.LoadFromFile(input_Texture.Text);
                    texture3.Use(OpenTK.Graphics.OpenGL4.TextureUnit.Texture3);
                }
                else
                {
                    texture1 = Texture.LoadFromFile(input_Texture.Text);
                    texture1.Use(OpenTK.Graphics.OpenGL4.TextureUnit.Texture1);
                }

            input_TextureBlend.Enabled = enabled;
            input_TextureScaleX.Enabled = enabled;
            input_TextureScaleY.Enabled = enabled;
            checkBox_UsePolarTextureCoordinates.Enabled = enabled;
            checkBox_UseDistortedTexture.Enabled = enabled;
            input_TextureDistortionFactor.Enabled = enabled && checkBox_UseDistortedTexture.Checked;
        }
        private void input_Texture_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = input_Texture.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                input_Texture.Text = openFileDialog1.FileName;
        }

        private void input_TextureBlend_ValueChanged(object sender, EventArgs e)
        {
            CurrentSettings.SetTextureBlend((float)input_TextureBlend.Value);
        }

        private void input_TextureScaleX_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_TextureScaleX.Text))
                e.Cancel = true;
        }
        private void input_TextureScaleX_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetTextureScaleX(float.Parse(input_TextureScaleX.Text));
            input_TextureScaleX.Text = CurrentSettings.GetTextureScaleX().ToString();
        }

        private void input_TextureScaleY_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_TextureScaleY.Text))
                e.Cancel = true;
        }
        private void input_TextureScaleY_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetTextureScaleY(float.Parse(input_TextureScaleY.Text));
            input_TextureScaleY.Text = CurrentSettings.GetTextureScaleY().ToString();
        }

        private void checkBox_UsePolarTextureCoordinates_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.SetUsePolarTextureCoordinates(checkBox_UsePolarTextureCoordinates.Checked);
        }

        private void checkBox_UseDistortedTexture_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.SetUseTextureDistortion(checkBox_UseDistortedTexture.Checked);

            input_TextureDistortionFactor.Enabled = checkBox_UseDistortedTexture.Checked;
        }

        private void input_TextureDistortionFactor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_TextureDistortionFactor.Text))
                e.Cancel = true;
        }
        private void input_TextureDistortionFactor_Validated(object sender, EventArgs e)
        {
            CurrentSettings.SetTextureDistortion(float.Parse(input_TextureDistortionFactor.Text));
            input_TextureDistortionFactor.Text = CurrentSettings.GetTextureDistortion().ToString();
        }


        #endregion

        #region Menu 4 Controls

        private void input_EditingAnimation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentSettings.EditingAnimation = (Fractal.Animation)input_EditingAnimation.SelectedIndex;

            switch (CurrentSettings.EditingAnimation)
            {
                case Fractal.Animation.Julia:
                    checkBox_AnimationEnabled.Checked = juliaSettings.IsJuliaAnimationEnabled;
                    checkBox_UsePeriodicPoint.Checked = juliaSettings.UsePeriodicPoint;
                    input_JuliaAnimationPath.SelectedIndex = (int)CurrentSettings.JuliaAnimationPath;
                    input_JuliaAnimationRadius.Text = juliaSettings.JuliaAnimationRadius.ToString();
                    break;
                case Fractal.Animation.Julia_Mating:
                    checkBox_AnimationEnabled.Checked = juliaSettings.IsJuliaMatingAnimationEnabled;
                    input_JuliaAnimationPath.SelectedIndex = (int)CurrentSettings.JuliaMatingAnimationPath1;
                    input_JuliaAnimationRadius.Text = juliaSettings.JuliaMatingAnimationRadius1.ToString();
                    input_JuliaMatingAnimationPath.SelectedIndex = (int)CurrentSettings.JuliaMatingAnimationPath2;
                    input_JuliaMatingAnimationRadius.Text = juliaSettings.JuliaMatingAnimationRadius2.ToString();
                    input_JuliaMatingAnimationOffset.Value = (decimal)juliaSettings.JuliaMatingAnimationOffset.Value;
                    checkBox_UseJuliaMatingAnimationReverse.Checked = juliaSettings.UseJuliaMatingAnimationReverse;
                    break;
                case Fractal.Animation.OrbitTrap:
                    checkBox_AnimationEnabled.Checked = juliaSettings.IsOrbitTrapAnimationEnabled;
                    break;
                case Fractal.Animation.Normals:
                    checkBox_AnimationEnabled.Checked = juliaSettings.IsNormalAnimationEnabled;
                    break;
                case Fractal.Animation.Texture:
                    checkBox_AnimationEnabled.Checked = juliaSettings.IsTextureAnimationEnabled;
                    break;
                case Fractal.Animation.Custom:
                    checkBox_AnimationEnabled.Checked = juliaSettings.IsCustomAnimationEnabled;
                    break;
            }

            checkBox_AnimationEnabled_CheckedChanged(null, null);
        }

        private void checkBox_AnimationEnabled_CheckedChanged(object sender, EventArgs e)
        {
            input_AnimationSpeed.Text = juliaSettings.AnimationSpeed.ToString();

            checkBox_UsePeriodicPoint.Enabled = false;
            input_JuliaAnimationPath.Enabled = false;
            input_JuliaAnimationRadius.Enabled = false;
            input_JuliaMatingAnimationPath.Enabled = false;
            input_JuliaMatingAnimationRadius.Enabled = false;
            input_JuliaMatingAnimationOffset.Enabled = false;
            checkBox_UseJuliaMatingAnimationReverse.Enabled = false;

            switch (CurrentSettings.EditingAnimation)
            {
                case Fractal.Animation.Julia:
                    juliaSettings.IsJuliaAnimationEnabled = checkBox_AnimationEnabled.Checked;

                    input_AnimationSpeed.Enabled = juliaSettings.IsJuliaAnimationEnabled;
                    checkBox_UsePeriodicPoint.Enabled = juliaSettings.IsJuliaAnimationEnabled;
                    input_JuliaAnimationPath.Enabled = juliaSettings.IsJuliaAnimationEnabled;
                    input_JuliaAnimationRadius.Enabled = juliaSettings.IsJuliaAnimationEnabled;

                    input_JuliaMatingAnimationPath.Enabled = false;
                    input_JuliaMatingAnimationRadius.Enabled = false;
                    input_JuliaMatingAnimationOffset.Enabled = false;
                    checkBox_UseJuliaMatingAnimationReverse.Enabled = false;

                    break;
                case Fractal.Animation.Julia_Mating:
                    juliaMatingSettings.IsJuliaMatingAnimationEnabled = checkBox_AnimationEnabled.Checked;

                    checkBox_UsePeriodicPoint.Enabled = false;

                    input_AnimationSpeed.Enabled = juliaMatingSettings.IsJuliaMatingAnimationEnabled;
                    input_JuliaAnimationPath.Enabled = juliaMatingSettings.IsJuliaMatingAnimationEnabled;
                    input_JuliaAnimationRadius.Enabled = juliaMatingSettings.IsJuliaMatingAnimationEnabled;
                    input_JuliaMatingAnimationPath.Enabled = juliaMatingSettings.IsJuliaMatingAnimationEnabled;
                    input_JuliaMatingAnimationRadius.Enabled = juliaMatingSettings.IsJuliaMatingAnimationEnabled;
                    input_JuliaMatingAnimationOffset.Enabled = juliaMatingSettings.IsJuliaMatingAnimationEnabled;
                    checkBox_UseJuliaMatingAnimationReverse.Enabled = juliaMatingSettings.IsJuliaMatingAnimationEnabled;

                    break;
                case Fractal.Animation.OrbitTrap:
                    juliaSettings.IsOrbitTrapAnimationEnabled = checkBox_AnimationEnabled.Checked;
                    input_AnimationSpeed.Enabled = juliaMatingSettings.IsOrbitTrapAnimationEnabled;
                    break;
                case Fractal.Animation.Normals:
                    juliaSettings.IsNormalAnimationEnabled = checkBox_AnimationEnabled.Checked;
                    input_AnimationSpeed.Enabled = juliaMatingSettings.IsNormalAnimationEnabled;
                    break;
                case Fractal.Animation.Texture:
                    juliaSettings.IsTextureAnimationEnabled = checkBox_AnimationEnabled.Checked;
                    input_AnimationSpeed.Enabled = juliaMatingSettings.IsTextureAnimationEnabled;
                    break;
                case Fractal.Animation.Custom:
                    juliaSettings.IsCustomAnimationEnabled = checkBox_AnimationEnabled.Checked;
                    input_AnimationSpeed.Enabled = juliaMatingSettings.IsCustomAnimationEnabled;
                    break;
            }
        }

        private void input_AnimationSpeed_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_AnimationSpeed.Text))
                e.Cancel = true;
        }
        private void input_AnimationSpeed_Validated(object sender, EventArgs e)
        {
            CurrentSettings.AnimationSpeed = float.Parse(input_AnimationSpeed.Text);
            input_AnimationSpeed.Text = CurrentSettings.AnimationSpeed.ToString();
        }

        private void checkBox_UsePeriodicPoint_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.UsePeriodicPoint = checkBox_UsePeriodicPoint.Checked;
        }

        private void input_JuliaAnimationPath_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CurrentSettings.EditingAnimation == Fractal.Animation.Julia)
                CurrentSettings.JuliaAnimationPath = (Fractal.JuliaAnimationPath)input_JuliaAnimationPath.SelectedIndex;
            else if (CurrentSettings.EditingAnimation == Fractal.Animation.Julia_Mating)
                CurrentSettings.JuliaMatingAnimationPath1 = (Fractal.JuliaAnimationPath)input_JuliaAnimationPath.SelectedIndex;
        }

        private void input_JuliaAnimationRadius_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_JuliaAnimationRadius.Text))
                e.Cancel = true;
        }
        private void input_JuliaAnimationRadius_Validated(object sender, EventArgs e)
        {
            if (CurrentSettings.EditingAnimation == Fractal.Animation.Julia)
            {
                juliaSettings.JuliaAnimationRadius = float.Parse(input_JuliaAnimationRadius.Text);
                input_JuliaAnimationRadius.Text = juliaSettings.JuliaAnimationRadius.ToString();
            }
            else if (CurrentSettings.EditingAnimation == Fractal.Animation.Julia_Mating)
            {
                juliaSettings.JuliaMatingAnimationRadius1 = float.Parse(input_JuliaAnimationRadius.Text);
                input_JuliaAnimationRadius.Text = juliaSettings.JuliaMatingAnimationRadius1.ToString();
            }
        }

        private void input_JuliaMatingAnimationPath_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentSettings.JuliaMatingAnimationPath2 = (Fractal.JuliaAnimationPath)input_JuliaMatingAnimationPath.SelectedIndex;
        }

        private void input_JuliaMatingAnimationRadius_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_JuliaMatingAnimationRadius.Text))
                e.Cancel = true;
        }
        private void input_JuliaMatingAnimationRadius_Validated(object sender, EventArgs e)
        {
            juliaSettings.JuliaMatingAnimationRadius2 = float.Parse(input_JuliaMatingAnimationRadius.Text);
            input_JuliaMatingAnimationRadius.Text = juliaSettings.JuliaMatingAnimationRadius2.ToString();
        }

        private void input_JuliaMatingAnimationOffset_ValueChanged(object sender, EventArgs e)
        {
            CurrentSettings.JuliaMatingAnimationOffset.SetValue((float)input_JuliaMatingAnimationOffset.Value);
        }

        private void checkBox_UseJuliaMatingAnimationReverse_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.UseJuliaMatingAnimationReverse = checkBox_UseJuliaMatingAnimationReverse.Checked;
        }

        #endregion

        #region Properties
        private ref Camera CurrentCamera
        {
            get
            {
                switch (currentFractalType)
                {
                    case Fractal.Type.Mandelbrot:
                        return ref mandelbrotCamera;
                    case Fractal.Type.Julia:
                        return ref juliaCamera;
                    case Fractal.Type.Julia_Mating:
                        return ref juliaMatingCamera;
                    case Fractal.Type.Mandelbulb:
                        return ref mandelbulbCamera;
                    default:
                        return ref customCamera;
                }
            }
        }
        private ref Fractal.Settings CurrentSettings
        {
            get
            {
                switch (currentFractalType)
                {
                    case Fractal.Type.Mandelbrot:
                        return ref mandelbrotSettings;
                    case Fractal.Type.Julia:
                        return ref juliaSettings;
                    case Fractal.Type.Julia_Mating:
                        return ref juliaMatingSettings;
                    case Fractal.Type.Mandelbulb:
                        return ref mandelbulbSettings;
                    default:
                        return ref customSettings;
                }
            }
        }
        private ref Shader CurrentShader
        {
            get
            {
                switch (currentFractalType)
                {
                    case Fractal.Type.Mandelbrot:
                        return ref mandelbrotShader;
                    case Fractal.Type.Julia:
                        return ref juliaJulia;
                    case Fractal.Type.Julia_Mating:
                        return ref juliaMatingShader;
                    case Fractal.Type.Mandelbulb:
                        return ref mandelbulbShader;
                    default:
                        return ref custom;
                }
            }
        }
        #endregion

        #region Fields
        private OpenTK.WinForms.INativeInput _nativeInput;
        internal static Stopwatch? applicationTime;
        float fractalTime;
        float animationTime;
        bool pauseTime = false;
        private Timer _timer = null!;
        private int fps = 60;
        private InputState inputState;

        private const int minGLWidth = 500;
        private const int minGLHeight = 309;

        float deltaTime = 0;
        float lastFrame = 0;

        private Fractal.Type currentFractalType;

        private Fractal.Settings mandelbrotSettings;
        private Shader mandelbrotShader;
        private Camera mandelbrotCamera;

        private Fractal.Settings juliaSettings;
        private Shader juliaJulia;
        private Camera juliaCamera;

        private Fractal.Settings juliaMatingSettings;
        private Shader juliaMatingShader;
        private Camera juliaMatingCamera;
        private JuliaMating juliaMating = new JuliaMating();

        private Fractal.Settings mandelbulbSettings;
        private Shader mandelbulbShader;
        private Camera mandelbulbCamera;

        private Fractal.Settings customSettings;
        private Shader custom;
        private Camera customCamera;

        private int sboCompute;

        private int vboPlane, vaoPlane;
        private int vboSphere, vaoSphere;
        TexturedVertex[] sphereVertices = new IcoSphere().Create(5, 1, true);

        Texture texture0, texture1, texture2, texture3;

        #endregion

        #region Utils
        internal bool TryParse1DFloat(string text)
        {
            return float.TryParse(text, out _);
        }
        internal bool TryParse2DFloat(string text)
        {
            string[] values = text.Replace(" ", "").Split(',');
            return values.Length == 2 && TryParse1DFloat(values[0]) && TryParse1DFloat(values[1]);
        }
        internal bool TryParse3DFloat(string text)
        {
            string[] values = text.Replace(" ", "").Split(',');
            return values.Length == 3 && TryParse1DFloat(values[0]) && TryParse1DFloat(values[1]) && TryParse1DFloat(values[2]);
        }
        internal bool TryParse4DFloat(string text)
        {
            string[] values = text.Replace(" ", "").Split(',');
            return values.Length == 4 && TryParse1DFloat(values[0]) && TryParse1DFloat(values[1]) && TryParse1DFloat(values[2]) && TryParse1DFloat(values[3]);
        }

        internal float[] Parse2DFloat(string text)
        {
            string[] values = text.Replace(" ", "").Split(',');
            float[] ret = new float[2];

            for (int i = 0; i < 2; i++)
                ret[i] = float.Parse(values[i]);

            return ret;
        }
        internal float[] Parse3DFloat(string text)
        {
            string[] values = text.Replace(" ", "").Split(',');
            float[] ret = new float[3];

            for (int i = 0; i < 3; i++)
                ret[i] = float.Parse(values[i]);

            return ret;
        }
        internal float[] Parse4DFloat(string text)
        {
            string[] values = text.Replace(" ", "").Split(',');
            float[] ret = new float[4];

            for (int i = 0; i < 4; i++)
                ret[i] = float.Parse(values[i]);

            return ret;
        }

        internal string Make2D(float x, float y)
        {
            return x.ToString() + ", " + y.ToString();
        }
        internal string Make3D(float x, float y, float z)
        {
            return x.ToString() + ", " + y.ToString() + ", " + z.ToString();
        }
        internal string Make3D(Vector3 v)
        {
            return v.X.ToString() + ", " + v.Y.ToString() + ", " + v.Z.ToString();
        }
        internal string Make4D(Vector4 v)
        {
            return v.X.ToString() + ", " + v.Y.ToString() + ", " + v.Z.ToString() + ", " + v.W.ToString();
        }

        internal string GetFrom2D(string input, bool getFirst)
        {
            return input.Replace(" ", "").Split(',')[getFirst ? 0 : 1];
        }
        internal string GetFromND(string input, int index)
        {
            return input.Replace(" ", "").Split(',')[index];
        }

        internal string Replace2D(string input, string original, bool replaceFirst)
        {
            string[] values = original.Replace(" ", "").Split(',');
            values[replaceFirst ? 0 : 1] = input;
            return values[0] + ", " + values[1];
        }

        internal bool IsUintChar(KeyPressEventArgs e, bool allowComma = false)
        {
            // only allow numbers, backspace, enter, and comma (if allowed)
            return char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 13 || (allowComma && e.KeyChar == ',');
        }
        internal bool IsDecimalChar(KeyPressEventArgs e, bool allowComma = false)
        {
            // only allow numbers, period, negative symbol, backspace, enter, and comma (if allowed)
            return char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == 8 || e.KeyChar == 13 || (allowComma && e.KeyChar == ',');
        }

        private void control_FocusOnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                glControl.Focus(); // force leave
        }

        private void control_ValidateUintChar(object sender, KeyPressEventArgs e)
        {
            e.Handled = !IsUintChar(e);
        }
        private void control_ValidateMultipleUintChar(object sender, KeyPressEventArgs e)
        {
            e.Handled = !IsUintChar(e, true);
        }

        private void control_ValidateDecimalChar(object sender, KeyPressEventArgs e)
        {
            e.Handled = !IsDecimalChar(e);
        }
        private void control_ValidateMultipleDecimalChar(object sender, KeyPressEventArgs e)
        {
            e.Handled = !IsDecimalChar(e, true);
        }


        #endregion
    }
}
