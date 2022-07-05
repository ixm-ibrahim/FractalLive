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
            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            ref Fractal.Settings fractalSettings = ref CurrentSettings;
            ref Shader shader = ref CurrentShader;
            ref Camera camera = ref CurrentCamera;



            shader.SetMatrix4("projection", camera.GetProjectionMatrix());
            shader.SetMatrix4("view", camera.GetViewMatrix());
            shader.SetMatrix4("model", Matrix4.Identity);

            shader.SetBool("is3D", camera.Is3D());
            camera.Roll += .1f;
            shader.SetFloat("rollAngle", camera.Roll);
            shader.SetDouble("zoom", Math.Pow(2, fractalSettings.Zoom));
            shader.SetFloat("aspectRatio", camera.AspectRatio);
            Log(camera.Roll.ToString());
            shader.SetVector2d("center", fractalSettings.Center);

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
                //Render();
                glControl_Paint(null, null);
            };
            _timer.Interval = 1000/fps;   // 1000 ms per sec / 16.67 ms per frame = 60 FPS
            _timer.Start();

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
        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            glControl.MakeCurrent();

            float currentFrame = applicationTime.ElapsedMilliseconds;
            deltaTime = (currentFrame - lastFrame) / 1000;
            lastFrame = currentFrame;
            
            // input

            // update fractal

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
        internal static Stopwatch? applicationTime;
        private int fps = 60;
        private OpenTK.WinForms.INativeInput _nativeInput;
        private Timer _timer = null!;
        private float _angle = 0.0f;

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
