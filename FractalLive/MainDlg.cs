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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor for MainDlg
        /// </summary>
        public MainDlg()
        {
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
            glControl.MakeCurrent();

            GL.ClearColor(Color4.MidnightBlue);
            //GL.Enable(EnableCap.DepthTest);

            mandelbrot.Use();
            GL.BindVertexArray(vaoPlane);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 6);

            mandelbrotCamera.Render();

            /*
            Matrix4 lookat = Matrix4.LookAt(0, 5, 5, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Rotate(_angle, 0.0f, 1.0f, 0.0f);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Begin(PrimitiveType.Quads);

            GL.Color4(Color4.Silver);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.Color4(Color4.Honeydew);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            GL.Color4(Color4.Moccasin);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            GL.Color4(Color4.IndianRed);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            GL.Color4(Color4.PaleVioletRed);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);

            GL.Color4(Color4.ForestGreen);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);

            GL.End();
            */
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
            mandelbrotCamera = new Camera();

            NativeInputRadioButton.Checked = true;

            // Make sure that when the GLControl is resized or needs to be painted,
            // we update our projection matrix or re-render its contents, respectively.
            glControl.Resize += glControl_Resize;
            glControl.Paint += glControl_Paint;

            // Log any focus changes.
            glControl.GotFocus += (sender, e) =>
                Log("Focus in");
            glControl.LostFocus += (sender, e) =>
                Log("Focus out");

            // Log WinForms keyboard/mouse events.
            glControl.MouseDown += (sender, e) =>
            {
                glControl.Focus();
                Log($"WinForms Mouse down: ({e.X},{e.Y})");
            };
            glControl.MouseUp += (sender, e) =>
                Log($"WinForms Mouse up: ({e.X},{e.Y})");
            glControl.MouseMove += (sender, e) =>
                Log($"WinForms Mouse move: ({e.X},{e.Y})");
            glControl.KeyDown += (sender, e) =>
                Log($"WinForms Key down: {e.KeyCode}");
            glControl.KeyUp += (sender, e) =>
                Log($"WinForms Key up: {e.KeyCode}");
            glControl.KeyPress += (sender, e) =>
                Log($"WinForms Key press: {e.KeyChar}");


            // Redraw the screen every 1/60 of a second.
            _timer = new Timer();
            _timer.Tick += (sender, e) =>
            {
                _angle += 0.5f;
                Render();
            };
            _timer.Interval = 1000/60;   // 1000 ms per sec / 16.67 ms per frame = 60 FPS
            _timer.Start();

            // Ensure that the viewport and projection matrix are set correctly initially.
            glControl_Resize(glControl, EventArgs.Empty);

            applicationTime.Start();
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
            Matrix4 perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);
        }

        /// <summary>
        /// Callback upon window update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            //glControl.MakeCurrent();

            //GL.ClearColor(Color4.MidnightBlue);
            //GL.Clear(ClearBufferMask.ColorBufferBit);

            //glControl.SwapBuffers();

            Render();
        }

        #endregion

        #region Buttons

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

                _nativeInput.MouseDown += (e) =>
                {
                    glControl.Focus();
                    Log("Native Mouse down");
                };
                _nativeInput.MouseUp += (e) =>
                    Log("Native Mouse up");
                _nativeInput.MouseMove += (e) =>
                    Log($"Native mouse position: {e.Position.X}, {e.Position.Y}\n\tDelta: {e.DeltaX},{e.DeltaY}");
                _nativeInput.KeyDown += (e) =>
                    Log($"Native Key down: {e.Key}");
                _nativeInput.KeyUp += (e) =>
                    Log($"Native Key up: {e.Key}");
                _nativeInput.TextInput += (e) =>
                    Log($"Native Text input: {e.AsString}");
                _nativeInput.JoystickConnected += (e) =>
                    Log($"Native Joystick connected: {e.JoystickId}");
            }
        }

        #endregion

        #region Properties

        #endregion

        #region Fields
        internal static Stopwatch? applicationTime;

        private OpenTK.WinForms.INativeInput _nativeInput;
        private Timer _timer = null!;
        private float _angle = 0.0f;

        private Shader mandelbrot;

        private Camera mandelbrotCamera;
        private Camera juliaCamera;
        private Camera juliaMatingCamera;

        private int vboPlane, vaoPlane;

        #endregion

        #region Constants

        #endregion
    }
}
