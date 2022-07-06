using System;
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
                Focus = false;
                MouseRightDown = false;
                MouseLeftDown = false;
                ControlDown = false;
                ShiftDown = false;
                AltDown = false;
                PreviousMouseX = MousePosition.X;
                PreviousMouseY = MousePosition.Y;
                GLMousePositionX = 0;
                GLMousePositionY = 0;
            }

            public bool Focus { get; set; }
            public bool MouseRightDown { get; set; }
            public bool MouseLeftDown { get; set; }
            public bool ControlDown { get; set; }
            public bool ShiftDown { get; set; }
            public bool AltDown { get; set; }
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
            shader.SetDouble("zoom", Math.Pow(2, fractalSettings.Zoom));
            shader.SetFloat("initialRadius", fractalSettings.InitialDisplayRadius);
            shader.SetFloat("normalizedCoordsWidth", (float)glControl.Width / Math.Max(minGLWidth, minGLHeight));
            shader.SetFloat("normalizedCoordsHeight", (float)glControl.Height / Math.Max(minGLWidth, minGLHeight));

            shader.SetVector2d("center", fractalSettings.Center);
            shader.SetFloat("rollAngle", camera.Roll);
            shader.SetInt("maxIterations", fractalSettings.MaxIterations);
            
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
            input_MaxIterations.Value = CurrentSettings.MaxIterations;
            NativeInputRadioButton.Checked = false;

            // Callbacks
            glControl.Resize += glControl_Resize;
            glControl.Paint += glControl_Update;

            glControl.GotFocus += (sender, e) => inputState.Focus = true;
            glControl.LostFocus += (sender, e) => inputState.Focus = false;

            // Log WinForms keyboard/mouse events.
            /*
            glControl.KeyDown += (sender, e) =>
                Log($"WinForms Key down: {e.KeyCode}");
            glControl.KeyUp += (sender, e) =>
                Log($"WinForms Key up: {e.KeyCode}");
            glControl.KeyPress += (sender, e) =>
                Log($"WinForms Key press: {e.KeyChar}");
            */
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

            // update fractal
            CurrentCamera.Roll += 1f;
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
                    float factor = CurrentCamera.CurrentMoveSpeed / (float)Math.Pow(2,CurrentSettings.Zoom);

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
            Vector2 offset = normalizedMousePos * CurrentSettings.InitialDisplayRadius * aspectRatio;
            
            Vector2 mousePos = CurrentSettings.Center + (xRoll * offset.X + yRoll * offset.Y) / (float)Math.Pow(2, CurrentSettings.Zoom);
            CurrentSettings.Zoom += scrollOffset * CurrentCamera.CurrentZoomSpeed;
            CurrentSettings.Center = mousePos - (xRoll * offset.X + yRoll * offset.Y) / (float)Math.Pow(2, CurrentSettings.Zoom);
        }

        private void input_MaxIterations_ValueChanged(object sender, EventArgs e)
        {
            CurrentSettings.MaxIterations = (int)input_MaxIterations.Value;
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
