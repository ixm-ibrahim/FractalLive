using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace FractalLive
{
    public partial class MainDlg : Form
    {
        #region Enumerations

        #endregion

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
                // fractal settings
                keysDown[Keys.D1] = false;          // max iterations
                keysDown[Keys.D2] = false;          // bailout (general)
                keysDown[Keys.D3] = false;          // max distance
                keysDown[Keys.D4] = false;          // distance fineness
                keysDown[Keys.D5] = false;          // power
                keysDown[Keys.D6] = false;          // c power
                keysDown[Keys.D7] = false;          // fold count
                keysDown[Keys.D8] = false;          // fold angle
                keysDown[Keys.D9] = false;          // fold offset x
                keysDown[Keys.D0] = false;          // fold offset y
                keysDown[Keys.OemMinus] = false;    // toggle conjugate
                keysDown[Keys.Oemplus] = false;     // toggle distance estimation
                keysDown[Keys.Oemtilde] = false;    // screenshot
            }

            public bool IsKeyDown(Keys key)
            {
                return keysDown.GetValueOrDefault(key);
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
                new TexturedVertex(-1,-1,0,0,0,0,0,0),  //  1,-1 +----+ 1,1
                new TexturedVertex(-1, 1,0,0,0,0,0,1),  //       |   /|
                new TexturedVertex( 1, 1,0,0,0,0,1,1),  //       |  / |
                new TexturedVertex( 1,-1,0,0,0,0,1,0),  //       | /  |
                new TexturedVertex(-1,-1,0,0,0,0,0,0),  //       |/   |
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
        }

        private void InitShaders()
        {


            mandelbrot = new Shader("Shaders/geometry.vert", "Shaders/mandelbrot.frag");
            mandelbrot.Use();
        }

        private void Log(string message)
        {
            LogTextBox.AppendText(message + "\r\n");
        }

        private void Render()
        {
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            ref Fractal.Settings fractalSettings = ref CurrentSettings;
            ref Shader shader = ref CurrentShader;
            ref Camera camera = ref CurrentCamera;



            shader.SetMatrix4("projection", camera.GetProjectionMatrix());
            shader.SetMatrix4("view", camera.GetViewMatrix());
            shader.SetMatrix4("model", Matrix4.Identity);

            shader.SetBool("is3D", camera.Is3D());
            shader.SetDouble("zoom", fractalSettings.Zoom.Value);
            shader.SetFloat("initialRadius", fractalSettings.InitialDisplayRadius.Value);
            shader.SetFloat("normalizedCoordsWidth", (float)glControl.Width / Math.Max(minGLWidth, minGLHeight));
            shader.SetFloat("normalizedCoordsHeight", (float)glControl.Height / Math.Max(minGLWidth, minGLHeight));

            shader.SetVector2d("center", fractalSettings.Center);
            shader.SetFloat("rollAngle", camera.Roll);

            // Menu 1
            shader.SetInt("maxIterations", fractalSettings.MaxIterations.Value);

            // Menu 2
            shader.SetInt("orbitTrap", (int)fractalSettings.OrbitTrap);
            // min/avg/max/etc.
            shader.SetFloat("bailout", fractalSettings.Bailout);
            shader.SetFloat("bailoutFactor1", fractalSettings.BailoutFactor1);
            shader.SetFloat("bailoutFactor2", fractalSettings.BailoutFactor2);
            shader.SetInt("startOrbit", fractalSettings.StartOrbit);
            shader.SetInt("orbitRange", fractalSettings.OrbitRange);
            shader.SetVector2("bailoutRectangle", fractalSettings.BailoutRectangle);
            shader.SetVector2Array("bailoutPoints", fractalSettings.BailoutPoints);
            shader.SetInt("bailoutPointsCount", fractalSettings.BailoutPointsCount);
            shader.SetVector4Array("bailoutLines", fractalSettings.BailoutLines);
            shader.SetInt("bailoutLinesCount", fractalSettings.BailoutLinesCount);
            
            if (currentFractal == Fractal.Type.Mandelbrot)
            {
                mandelbrot.Use();
                GL.BindVertexArray(vaoPlane);
                GL.DrawArrays(PrimitiveType.Triangles, 0, 6);

                mandelbrotCamera.Render();
            }

            glControl.SwapBuffers();
        }
        #endregion

        #region Callbacks

        /// <summary>
        /// Callback when form is loaded
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitObjects();
            InitShaders();

            applicationTime = new Stopwatch();
            currentFractal = Fractal.Type.Mandelbrot;

            mandelbrotSettings = new Fractal.Settings(Fractal.Type.Mandelbrot);
            mandelbrotCamera = new Camera();

            // Default values
            NativeInputRadioButton.Checked = false;
            input_FractalType.SelectedIndex = (int)CurrentSettings.Type;
            input_FractalFormula.SelectedIndex = (int)CurrentSettings.Formula;
            input_MaxIterations.Value = CurrentSettings.MaxIterations.Value;
            input_OrbitTrap.SelectedIndex = 0;
            input_StartOrbit.Maximum = CurrentSettings.MaxIterations.Value;
            input_OrbitRange.Value = CurrentSettings.MaxIterations.Value;
            input_OrbitRange.Maximum = input_OrbitRange.Value;
            input_OrbitTrap_SelectionChangeCommitted(null, null);

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
            //GL.Enable(EnableCap.CullFace);
            //GL.CullFace(CullFaceMode.Back);
            //GL.FrontFace(FrontFaceDirection.Cw);

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

            GL.DeleteProgram(mandelbrot.Handle);
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

            //juliaCamera.AspectRatio = aspect_ratio;
            mandelbrotCamera.AspectRatio = aspect_ratio;
            //juliaMatingCamera.AspectRatio = aspect_ratio;
        }

        /// <summary>
        /// Callback upon window update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControl_Update(object sender, PaintEventArgs e)
        {
            glControl.MakeCurrent();

            float currentFrame = applicationTime.ElapsedMilliseconds;
            deltaTime = (currentFrame - lastFrame) / 1000;
            lastFrame = currentFrame;

            // input
            float modifier = inputState.keysDown[Keys.Oemtilde] ? -1 : 1;
            if (inputState.ShiftDown)
                modifier *= 5;
            if (inputState.ControlDown)
                modifier /= 5;


            if (panel_FormulaMenu.Enabled)
            {
                if (inputState.keysDown[Keys.D1])
                {
                    CurrentSettings.MaxIterations += (int)(modifier * 2);
                    input_MaxIterations.Value = CurrentSettings.MaxIterations.Value;
                }
                if (inputState.keysDown[Keys.D2])
                {
                    CurrentSettings.Power += (int)(modifier * 2);
                    input_Power.Text = CurrentSettings.Power.ToString();
                }
                if (inputState.keysDown[Keys.D3])
                {
                    CurrentSettings.C_Power += (int)(modifier * 2);
                    input_CPower.Text = CurrentSettings.C_Power.ToString();
                }
            }
            else if (panel_OrbitTrapMenu.Enabled)
            {
                int editingBailoutTrapIndex = (int)input_EditingBailoutTrap.Value - 1;

                if (inputState.keysDown[Keys.D1])
                {
                    CurrentSettings.Bailout += modifier / 5;
                    input_Bailout.Text = CurrentSettings.Bailout.ToString();
                }
                if (inputState.keysDown[Keys.D2])
                {
                    if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Rectangle)
                    {
                        CurrentSettings.BailoutRectangle.X += modifier / 5;
                        input_BailoutX.Text = CurrentSettings.BailoutRectangle.X.ToString();
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
                    {
                        CurrentSettings.BailoutPoints[editingBailoutTrapIndex].X += modifier / 5;
                        input_BailoutX.Text = CurrentSettings.BailoutPoints[editingBailoutTrapIndex].X.ToString();
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                    {
                        CurrentSettings.BailoutLines[editingBailoutTrapIndex].X += modifier / 5;
                        input_BailoutX.Text = Replace2D(CurrentSettings.BailoutLines[editingBailoutTrapIndex].X.ToString(), input_BailoutX.Text, true);
                    }
                }
                if (inputState.keysDown[Keys.D3])
                {
                    if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Rectangle)
                    {
                        CurrentSettings.BailoutRectangle.Y += modifier / 5;
                        input_BailoutY.Text = CurrentSettings.BailoutRectangle.Y.ToString();
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
                    {
                        CurrentSettings.BailoutPoints[editingBailoutTrapIndex].Y += modifier / 5;
                        input_BailoutY.Text = CurrentSettings.BailoutPoints[editingBailoutTrapIndex].Y.ToString();
                    }
                    else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                    {
                        CurrentSettings.BailoutLines[editingBailoutTrapIndex].Y += modifier / 5;
                        input_BailoutX.Text = Replace2D(CurrentSettings.BailoutLines[editingBailoutTrapIndex].Y.ToString(), input_BailoutX.Text, false);
                    }
                }
                if (inputState.keysDown[Keys.D4])
                {
                    if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                    {
                        CurrentSettings.BailoutLines[editingBailoutTrapIndex].Z += modifier / 5;
                        input_BailoutY.Text = Replace2D(CurrentSettings.BailoutLines[editingBailoutTrapIndex].Z.ToString(), input_BailoutY.Text, true);
                    }
                }
                if (inputState.keysDown[Keys.D5])
                {
                    if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                    {
                        CurrentSettings.BailoutLines[editingBailoutTrapIndex].W += modifier / 5;
                        input_BailoutY.Text = Replace2D(CurrentSettings.BailoutLines[editingBailoutTrapIndex].W.ToString(), input_BailoutY.Text, true);
                    }
                }
                if (inputState.keysDown[Keys.D6] && input_OrbitTrapFactor1.Enabled)
                {
                    CurrentSettings.BailoutFactor1 += modifier / 100;
                    input_OrbitTrapFactor1.Text = CurrentSettings.BailoutFactor1.ToString();
                }
                if (inputState.keysDown[Keys.D7] && input_OrbitTrapFactor2.Enabled)
                {
                    CurrentSettings.BailoutFactor2 += modifier / 10;
                    input_OrbitTrapFactor2.Text = CurrentSettings.BailoutFactor2.ToString();
                }
            }

            // update controls

            // update fractal
            Render();
        }

        #endregion

        #region Input

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

        private void glControl_MouseMove(object? sender, MouseEventArgs e)
        {
            inputState.GLMousePositionX = e.X;
            inputState.GLMousePositionY = e.Y;

            int deltaX = inputState.PreviousMouseX - MousePosition.X;
            int deltaY = inputState.PreviousMouseY - MousePosition.Y;

            if (inputState.MouseRightDown)
            {
                Cursor.Position = new System.Drawing.Point(inputState.PreviousMouseX, inputState.PreviousMouseY);

                if (CurrentCamera.CurrentMode == Camera.Mode.FLAT)
                {
                    float rad = MathHelper.DegreesToRadians(CurrentCamera.Roll);
                    float rad90 = rad + MathHelper.Pi / 2;
                    float factor = CurrentCamera.CurrentPanSpeed / (float)Math.Pow(2, CurrentSettings.Zoom.Value);

                    CurrentSettings.Center += new Vector2((float)Math.Cos(rad), (float)Math.Sin(rad)) * (float)deltaX * factor;
                    CurrentSettings.Center -= new Vector2((float)Math.Cos(rad90), (float)Math.Sin(rad90)) * (float)deltaY * factor;
                }

                input_Center.Text = Make2D(CurrentSettings.Center.X, CurrentSettings.Center.Y);
            }

            inputState.PreviousMouseX = MousePosition.X;
            inputState.PreviousMouseY = MousePosition.Y;
        }

        private void glControl_MouseWheel(object? sender, MouseEventArgs e)
        {
            int scrollOffset = e.Delta > 0 ? 1 : (e.Delta < 1 ? -1 : 0);

            float rad = MathHelper.DegreesToRadians(CurrentCamera.Roll);
            float rad90 = rad + MathHelper.Pi / 2;

            Vector2 xRoll = new Vector2((float)Math.Cos(rad), (float)Math.Sin(rad));
            Vector2 yRoll = new Vector2((float)Math.Cos(rad90), (float)Math.Sin(rad90));

            Vector2 normalizedMousePos = new Vector2((float)inputState.GLMousePositionX / glControl.Width, (float)inputState.GLMousePositionY / glControl.Height) * 2 - new Vector2(1, 1);
            Vector2 aspectRatio = new Vector2(glControl.Width, -glControl.Height) / Math.Max(minGLWidth, minGLHeight);
            Vector2 offset = normalizedMousePos * CurrentSettings.InitialDisplayRadius.Value * aspectRatio;

            Vector2 mousePos = CurrentSettings.Center + (xRoll * offset.X + yRoll * offset.Y) / (float)Math.Pow(2, CurrentSettings.Zoom.Value);
            CurrentSettings.Zoom += scrollOffset * CurrentCamera.CurrentZoomSpeed;
            CurrentSettings.Center = mousePos - (xRoll * offset.X + yRoll * offset.Y) / (float)Math.Pow(2, CurrentSettings.Zoom.Value);

            input_Center.Text = Make2D(CurrentSettings.Center.X, CurrentSettings.Center.Y);
            input_Zoom.Text = CurrentSettings.Zoom.Value.ToString();
        }

        private void glControl_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LControlKey)
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
        }

        private void glControl_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LControlKey)
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

        }

        private void glControl_KeyPress(object? sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        #region Controls

        private void button_Menu1_Click(object sender, EventArgs e)
        {
            panel_FormulaMenu.Show();
            panel_FormulaMenu.Enabled = true;
            panel_OrbitTrapMenu.Hide();
            panel_OrbitTrapMenu.Enabled = false;


        }
        private void button_Menu2_Click(object sender, EventArgs e)
        {
            panel_FormulaMenu.Hide();
            panel_FormulaMenu.Enabled = false;
            panel_OrbitTrapMenu.Show();
            panel_OrbitTrapMenu.Enabled = true;


        }
        private void button_Menu3_Click(object sender, EventArgs e)
        {
            panel_FormulaMenu.Hide();
            panel_FormulaMenu.Enabled = false;
            panel_OrbitTrapMenu.Hide();
            panel_OrbitTrapMenu.Enabled = false;


        }
        private void button_Menu4_Click(object sender, EventArgs e)
        {
            panel_FormulaMenu.Hide();
            panel_FormulaMenu.Enabled = false;
            panel_OrbitTrapMenu.Hide();
            panel_OrbitTrapMenu.Enabled = false;


        }

        private void input_MaxIterations_ValueChanged(object sender, EventArgs e)
        {
            CurrentSettings.MaxIterations.SetValue((int)input_MaxIterations.Value);

            input_StartOrbit.Maximum = CurrentSettings.MaxIterations.Value;
            if (input_StartOrbit.Value > CurrentSettings.MaxIterations.Value)
                input_StartOrbit.Value = CurrentSettings.MaxIterations.Value;

            input_OrbitRange.Maximum = CurrentSettings.MaxIterations.Value;
            if (input_OrbitRange.Value > CurrentSettings.MaxIterations.Value)
                input_OrbitRange.Value = CurrentSettings.MaxIterations.Value;
        }

        private void input_StartOrbit_ValueChanged(object sender, EventArgs e)
        {
            CurrentSettings.StartOrbit = (int)input_StartOrbit.Value;
        }

        private void input_OrbitRange_ValueChanged(object sender, EventArgs e)
        {
            CurrentSettings.OrbitRange = (int)input_OrbitRange.Value;
        }
        
        private void input_OrbitTrap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentSettings.OrbitTrap = (Fractal.OrbitTrap)input_OrbitTrap.SelectedIndex;

            if (CurrentSettings.Is1DBailout)
            {
                input_Bailout.Enabled = true;
                input_BailoutX.Enabled = false;
                input_BailoutY.Enabled = false;

                button_AddBailoutTrap.Enabled = false;
                button_RemoveBailoutTrap.Enabled = false;
                input_EditingBailoutTrap.Enabled = false;

                input_StartOrbit.Enabled = false;
                input_OrbitRange.Enabled = false;
                input_OrbitTrapFactor1.Enabled = false;
                input_OrbitTrapFactor2.Enabled = false;

                input_Bailout.Text = CurrentSettings.Bailout.ToString();
            }
            else if (CurrentSettings.Is2DBailout)
            {
                bool isPoints = (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points);

                input_Bailout.Enabled = isPoints;
                input_BailoutX.Enabled = true;
                input_BailoutY.Enabled = true;

                button_AddBailoutTrap.Enabled = isPoints;
                button_RemoveBailoutTrap.Enabled = isPoints;
                input_EditingBailoutTrap.Enabled = isPoints;

                input_StartOrbit.Enabled = isPoints;
                input_OrbitRange.Enabled = isPoints;
                input_OrbitTrapFactor1.Enabled = isPoints;
                input_OrbitTrapFactor2.Enabled = isPoints;

                if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Rectangle)
                {
                    input_BailoutX.Text = CurrentSettings.BailoutRectangle.X.ToString();
                    input_BailoutY.Text = CurrentSettings.BailoutRectangle.Y.ToString();
                }
                else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
                {
                    input_EditingBailoutTrap.Maximum = CurrentSettings.BailoutPointsCount;
                    input_EditingBailoutTrap.Value = input_EditingBailoutTrap.Maximum;
                    label_EditingOrbitBailout.Text = "Editing Point";

                    input_BailoutX.Text = CurrentSettings.BailoutPoints[CurrentSettings.BailoutPointsCount - 1].X.ToString();
                    input_BailoutY.Text = CurrentSettings.BailoutPoints[CurrentSettings.BailoutPointsCount - 1].Y.ToString();
                }
            }
            else // lines
            {
                input_Bailout.Enabled = true;
                input_BailoutX.Enabled = true;
                input_BailoutY.Enabled = true;

                button_AddBailoutTrap.Enabled = true;
                button_RemoveBailoutTrap.Enabled = true;
                input_EditingBailoutTrap.Enabled = true;

                input_StartOrbit.Enabled = true;
                input_OrbitRange.Enabled = true;
                input_OrbitTrapFactor1.Enabled = true;
                input_OrbitTrapFactor2.Enabled = true;

                input_EditingBailoutTrap.Maximum = CurrentSettings.BailoutLinesCount;
                input_EditingBailoutTrap.Value = input_EditingBailoutTrap.Maximum;
                label_EditingOrbitBailout.Text = "Editing Line";

                input_BailoutX.Text = Make2D(CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].X, CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].Y);
                input_BailoutY.Text = Make2D(CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].Z, CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].W);
            }

        }

        private void button_AddBailoutTrap_Click(object sender, EventArgs e)
        {
            if (input_EditingBailoutTrap.Maximum < 16)
            {
                input_EditingBailoutTrap.Maximum++;

                if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
                {
                    CurrentSettings.AddPoint(Vector2.Zero);
                    input_EditingBailoutTrap.Value = CurrentSettings.BailoutPointsCount;

                    input_BailoutX.Text = CurrentSettings.BailoutPoints[CurrentSettings.BailoutPointsCount - 1].X.ToString();
                    input_BailoutY.Text = CurrentSettings.BailoutPoints[CurrentSettings.BailoutPointsCount - 1].Y.ToString();
                }
                else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                {
                    CurrentSettings.AddLine(Vector4.UnitW);
                    input_EditingBailoutTrap.Value = CurrentSettings.BailoutLinesCount;

                    input_BailoutX.Text = Make2D(CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].X, CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].Y);
                    input_BailoutY.Text = Make2D(CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].Z, CurrentSettings.BailoutLines[CurrentSettings.BailoutLinesCount - 1].W);
                }
            }

        }
        private void button_RemoveBailoutTrap_Click(object sender, EventArgs e)
        {
            if (input_EditingBailoutTrap.Maximum > 1)
            {
                if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Points)
                {
                    CurrentSettings.RemovePoint((int)input_EditingBailoutTrap.Value - 1);

                    int current = Math.Clamp((int)input_EditingBailoutTrap.Value, 1, CurrentSettings.BailoutPointsCount);
                    input_EditingBailoutTrap.Value = current--;

                    input_BailoutX.Text = CurrentSettings.BailoutPoints[current].X.ToString();
                    input_BailoutY.Text = CurrentSettings.BailoutPoints[current].Y.ToString();
                }
                else if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines)
                {
                    CurrentSettings.RemoveLine((int)input_EditingBailoutTrap.Value - 1);

                    int current = Math.Clamp((int)input_EditingBailoutTrap.Value, 1, CurrentSettings.BailoutLinesCount);
                    input_EditingBailoutTrap.Value = current--;

                    input_BailoutX.Text = Make2D(CurrentSettings.BailoutLines[current].X, CurrentSettings.BailoutLines[current].Y);
                    input_BailoutY.Text = Make2D(CurrentSettings.BailoutLines[current].Z, CurrentSettings.BailoutLines[current].W);
                }

                input_EditingBailoutTrap.Maximum--;
            }

        }

        private void input_EditingBailoutTrap_ValueChanged(object sender, EventArgs e)
        {
            int index = (int)input_EditingBailoutTrap.Value - 1;

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

        private void input_Center_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow numbers, period, negative symbol, backspace, and comma
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == 8 || e.KeyChar == 44);
        }
        private void input_Center_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                glControl.Focus(); // force leave
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

        private void input_Zoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow numbers, period, negative symbol, and backspace
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == 8);
        }
        private void input_Zoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                glControl.Focus(); // force leave
        }
        private void input_Zoom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_Zoom.Text))
                e.Cancel = true;
        }
        private void input_Zoom_Validated(object sender, EventArgs e)
        {
            CurrentSettings.Zoom.Value = float.Parse(input_Zoom.Text);
            input_Zoom.Text = CurrentSettings.Zoom.Value.ToString(); // in case number gets restricted by bounds
        }

        private void input_Bailout_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow numbers, period, negative symbol, and backspace
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == 8);
        }
        private void input_Bailout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                glControl.Focus(); // force leave
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

        private void input_BailoutX_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow numbers, period, negative symbol, and backspace (and comma, if cross orbit trap)
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == 8 || (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines && e.KeyChar == 44));
        }
        private void input_BailoutX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                glControl.Focus(); // force leave
        }
        private void input_BailoutX_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((CurrentSettings.OrbitTrap != Fractal.OrbitTrap.Lines && !TryParse1DFloat(input_BailoutX.Text)) || (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines && !TryParse2DFloat(input_BailoutX.Text)))
                e.Cancel = true;
        }
        private void input_BailoutX_Validated(object sender, EventArgs e)
        {
            int editingBailoutTrap = (int)input_EditingBailoutTrap.Value - 1;

            if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Rectangle)
            {
                CurrentSettings.BailoutRectangle.X = float.Parse(input_BailoutX.Text);
                input_BailoutX.Text = CurrentSettings.BailoutRectangle.X.ToString();
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
            // only allow numbers, period, negative symbol, and backspace (and comma, if cross orbit trap)
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == 8 || (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines && e.KeyChar == 44));
        }
        private void input_BailoutY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                glControl.Focus(); // force leave
        }
        private void input_BailoutY_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((CurrentSettings.OrbitTrap != Fractal.OrbitTrap.Lines && !TryParse1DFloat(input_BailoutY.Text)) || (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Lines && !TryParse2DFloat(input_BailoutY.Text)))
                e.Cancel = true;
        }
        private void input_BailoutY_Validated(object sender, EventArgs e)
        {
            int editingBailoutTrap = (int)input_EditingBailoutTrap.Value - 1;

            if (CurrentSettings.OrbitTrap == Fractal.OrbitTrap.Rectangle)
            {
                CurrentSettings.BailoutRectangle.Y = float.Parse(input_BailoutY.Text);
                input_BailoutY.Text = CurrentSettings.BailoutRectangle.Y.ToString();
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

        private void input_OrbitTrapFactor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow numbers, period, negative symbol, and backspace
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == 8);
        }
        private void input_OrbitTrapFactor1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                glControl.Focus(); // force leave
        }
        private void input_OrbitTrapFactor1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_OrbitTrapFactor1.Text))
                e.Cancel = true;
        }
        private void input_OrbitTrapFactor1_Validated(object sender, EventArgs e)
        {
            CurrentSettings.BailoutFactor1 = float.Parse(input_OrbitTrapFactor1.Text);
            input_OrbitTrapFactor1.Text = CurrentSettings.BailoutFactor1.ToString();
        }

        private void input_OrbitTrapFactor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow numbers, period, negative symbol, and backspace
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == 8);
        }
        private void input_OrbitTrapFactor2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                glControl.Focus(); // force leave
        }
        private void input_OrbitTrapFactor2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TryParse1DFloat(input_OrbitTrapFactor2.Text))
                e.Cancel = true;
        }
        private void input_OrbitTrapFactor2_Validated(object sender, EventArgs e)
        {
            CurrentSettings.BailoutFactor2 = float.Parse(input_OrbitTrapFactor2.Text);
            input_OrbitTrapFactor2.Text = CurrentSettings.BailoutFactor2.ToString();
        }

        private void WinFormsInputRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            glControl.DisableNativeInput();
        }

        private void NativeInputRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            OpenTK.WinForms.INativeInput nativeInput = glControl.EnableNativeInput();

            if (_nativeInput == null)
            {
                _nativeInput = nativeInput;

                _nativeInput.KeyDown += (e) =>
                    Log($"Native Key down: {e.Key}");
                _nativeInput.KeyUp += (e) =>
                    Log($"Native Key up: {e.Key}");
                _nativeInput.MouseWheel += (e) =>
                    Log($"Native Key up: {e.Offset}");
            }
        }
        #endregion

        #region Properties
        private ref Camera CurrentCamera
        {
            get
            {
                switch (currentFractal)
                {
                    case Fractal.Type.Mandelbrot:
                        return ref mandelbrotCamera;
                    case Fractal.Type.Julia:
                        return ref juliaCamera;
                    case Fractal.Type.Julia_Mating:
                        return ref juliaMatingCamera;
                    default:
                        return ref customCamera;
                }
            }
        }
        private ref Fractal.Settings CurrentSettings
        {
            get
            {
                switch (currentFractal)
                {
                    case Fractal.Type.Mandelbrot:
                        return ref mandelbrotSettings;
                    case Fractal.Type.Julia:
                        return ref juliaSettings;
                    case Fractal.Type.Julia_Mating:
                        return ref juliaMatingSettings;
                    default:
                        return ref customSettings;
                }
            }
        }
        private ref Shader CurrentShader
        {
            get
            {
                switch (currentFractal)
                {
                    case Fractal.Type.Mandelbrot:
                        return ref mandelbrot;
                    case Fractal.Type.Julia:
                        return ref julia;
                    case Fractal.Type.Julia_Mating:
                        return ref juliaMating;
                    default:
                        return ref custom;
                }
            }
        }
        #endregion

        #region Fields
        private OpenTK.WinForms.INativeInput _nativeInput;
        internal static Stopwatch? applicationTime;
        private Timer _timer = null!;
        private int fps = 60;
        private InputState inputState;

        private const int minGLWidth = 500;
        private const int minGLHeight = 309;

        float deltaTime = 0;
        float lastFrame = 0;

        private Fractal.Type currentFractal;

        private Fractal.Settings mandelbrotSettings;
        private Shader mandelbrot;
        private Camera mandelbrotCamera;

        private Fractal.Settings juliaSettings;
        private Shader julia;
        private Camera juliaCamera;

        private Fractal.Settings juliaMatingSettings;
        private Shader juliaMating;
        private Camera juliaMatingCamera;

        private Fractal.Settings customSettings;
        private Shader custom;
        private Camera customCamera;

        private int vboPlane, vaoPlane;

        #endregion

        #region Constants

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

        internal float[] Parse2DFloat(string text)
        {
            string[] values = text.Replace(" ", "").Split(',');
            float[] ret = new float[2];

            for (int i = 0; i < 2; i++)
                ret[i] = float.Parse(values[i]);

            return ret;
        }

        internal string Make2D(float x, float y)
        {
            return x.ToString() + ", " + y.ToString();
        }

        internal string GetFrom2D(string input, bool getFirst)
        {
            return input.Replace(" ", "").Split(',')[getFirst ? 0 : 1];
        }

        internal string Replace2D(string input, string original, bool replaceFirst)
        {
            string[] values = original.Replace(" ", "").Split(',');
            values[replaceFirst ? 0 : 1] = input;
            return values[0] + ", " + values[1];
        }
        #endregion
    }
}
