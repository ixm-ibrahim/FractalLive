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
                keysDown[Keys.D2] = false;          // bailout
                keysDown[Keys.Oemcomma] = false;    // bailout (y value)
                keysDown[Keys.OemPeriod] = false;   // bailout (second x value)
                keysDown[Keys.OemQuestion] = false; // bailout (second y value)
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

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 8*sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 8*sizeof(float),  6*sizeof(float));
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
            shader.SetDouble("zoom", Math.Pow(2, fractalSettings.Zoom.Value));
            shader.SetFloat("initialRadius", fractalSettings.InitialDisplayRadius.Value);
            shader.SetFloat("normalizedCoordsWidth", (float)glControl.Width / Math.Max(minGLWidth, minGLHeight));
            shader.SetFloat("normalizedCoordsHeight", (float)glControl.Height / Math.Max(minGLWidth, minGLHeight));

            shader.SetVector2d("center", fractalSettings.Center);
            shader.SetFloat("rollAngle", camera.Roll);
            shader.SetInt("maxIterations", fractalSettings.MaxIterations.Value);
            shader.SetInt("orbitTrap", (int)fractalSettings.OrbitTrap);
            shader.SetFloat("bailout", fractalSettings.Bailout.Value);
            
            if (currentFractal == Fractal.Type.MANDELBROT)
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
            currentFractal = Fractal.Type.MANDELBROT;

            mandelbrotSettings = new Fractal.Settings(Fractal.Type.MANDELBROT);
            mandelbrotCamera = new Camera();

            // Default values
            NativeInputRadioButton.Checked = false;
            input_MaxIterations.Value = CurrentSettings.MaxIterations.Value;
            input_OrbitTrap.SelectedIndex = (int)CurrentSettings.OrbitTrap;
            input_BailoutX.Text = CurrentSettings.Bailout.Value.ToString();

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
            _timer.Interval = 1000/fps;   // 1000 ms per sec / 16.67 ms per frame = 60 FPS
            _timer.Start();

            // Start window
            // Ensure that the viewport and projection matrix are set correctly initially.
            glControl_Resize(glControl, EventArgs.Empty);

            GL.Enable(EnableCap.DepthTest);
            //GL.Enable(EnableCap.CullFace);
            //GL.CullFace(CullFaceMode.Back);
            //GL.FrontFace(FrontFaceDirection.Cw);

            glControl.Focus();
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
            //Matrix4 perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 1, 64);
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadMatrix(ref perpective);

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
                modifier *= 10;
            if (inputState.ControlDown)
                modifier /= 10;

            if (inputState.keysDown[Keys.D1])
            {
                CurrentSettings.MaxIterations += (int)(modifier * 10);
                input_MaxIterations.Value = CurrentSettings.MaxIterations.Value;
            }
            if (inputState.keysDown[Keys.D2])
            {
                CurrentSettings.Bailout += modifier / 5;
                input_BailoutX.Text = CurrentSettings.Bailout.Value.ToString();
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
                    float factor = CurrentCamera.CurrentPanSpeed / (float)Math.Pow(2,CurrentSettings.Zoom.Value);

                    CurrentSettings.Center += new Vector2((float)Math.Cos(rad), (float)Math.Sin(rad)) * (float)deltaX * factor;
                    CurrentSettings.Center -= new Vector2((float)Math.Cos(rad90), (float)Math.Sin(rad90)) * (float)deltaY * factor;
                }
                
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

            Vector2 normalizedMousePos = new Vector2((float)inputState.GLMousePositionX / glControl.Width, (float)inputState.GLMousePositionY / glControl.Height) * 2 - new Vector2(1,1);
            Vector2 aspectRatio = new Vector2(glControl.Width, -glControl.Height) / Math.Max(minGLWidth, minGLHeight);
            Vector2 offset = normalizedMousePos * CurrentSettings.InitialDisplayRadius.Value * aspectRatio;
            
            Vector2 mousePos = CurrentSettings.Center + (xRoll * offset.X + yRoll * offset.Y) / (float)Math.Pow(2, CurrentSettings.Zoom.Value);
            CurrentSettings.Zoom += scrollOffset * CurrentCamera.CurrentZoomSpeed;
            CurrentSettings.Center = mousePos - (xRoll * offset.X + yRoll * offset.Y) / (float)Math.Pow(2, CurrentSettings.Zoom.Value);
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

            //Log("Key down: " + e.KeyCode.ToString());
            //Log("\tinputState.keysDown[Keys.D1]: " + inputState.keysDown[Keys.D1].ToString());
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

            //Log("Key up: " + e.KeyCode.ToString());
            //Log("\tinputState.keysDown[Keys.D1]: " + inputState.keysDown[Keys.D1].ToString());
        }

        private void glControl_KeyPress(object? sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        #region Controls
        private void input_MaxIterations_ValueChanged(object sender, EventArgs e)
        {
            CurrentSettings.MaxIterations.SetValue((int)input_MaxIterations.Value);
        }
        
        private void input_OrbitTrap_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentSettings.OrbitTrap = (Fractal.OrbitTrap)input_OrbitTrap.SelectedIndex;
        }

        private void input_BailoutX_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow numbers and backspace
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar==8);
        }
        private void input_BailoutX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                glControl.Focus(); // force leave
        }
        private void input_BailoutX_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!float.TryParse(input_BailoutX.Text, out _))
                e.Cancel = true;
        }

        private void input_BailoutX_Validated(object sender, EventArgs e)
        {
            CurrentSettings.Bailout.SetValue(float.Parse(input_BailoutX.Text));
            input_BailoutX.Text = CurrentSettings.Bailout.Value.ToString(); // in case number gets restricted by bounds
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
                    case Fractal.Type.MANDELBROT:
                        return ref mandelbrotCamera;
                    case Fractal.Type.JULIA:
                        return ref juliaCamera;
                    case Fractal.Type.JULIA_MATING:
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
                    case Fractal.Type.MANDELBROT:
                        return ref mandelbrotSettings;
                    case Fractal.Type.JULIA:
                        return ref juliaSettings;
                    case Fractal.Type.JULIA_MATING:
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
                    case Fractal.Type.MANDELBROT:
                        return ref mandelbrot;
                    case Fractal.Type.JULIA:
                        return ref julia;
                    case Fractal.Type.JULIA_MATING:
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

    }
}
