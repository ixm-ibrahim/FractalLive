using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics; 

namespace FractalLive
{
    public class Camera
    {
        #region Enumerations
        public enum Mode
        {
            FLAT, FPS, FREE
        }

        public enum Projection
        {
            CARTESIAN, RIEMANN
        }
        #endregion

        #region Structures
        public struct Settings
        {
            public Mode mode;
            public Projection projection;
            public double fov;
            public bool showTarget;
            public bool showAxis;
            public double moveSpeed;
            public double zoomSpeed;
            public double mouseSensitivity;
            public double nearClipping;
            public double farClipping;

            public Settings(Mode mode, double fov = 67.5, Projection projection = Projection.CARTESIAN, bool showTarget = false, bool showAxis = false, double moveSpeed = .5, double zoomSpeed = .1, double mouseSensitivity = .2, double nearClipping = 0.1, double farClipping = 100)
            {
                this.mode = Mode.FLAT;
                this.projection = Projection.CARTESIAN;
                this.fov = fov;
                this.showTarget = showTarget;
                this.showAxis = showAxis;
                this.moveSpeed = moveSpeed;
                this.zoomSpeed = zoomSpeed;
                this.mouseSensitivity = mouseSensitivity;
                this.nearClipping = nearClipping;
                this.farClipping = farClipping;
            }
        }
        #endregion

        #region Constructors
        public Camera(int aspectRatio = 1)
        {
            flatSettings = new Settings(Mode.FLAT, 45.0);
            freeSettings = new Settings(Mode.FREE, 67.5);
            currentSettings = flatSettings;
            
            FullScreen = false;
            AspectRatio = aspectRatio;
            Lock = false;
            
            position = new Vector3(0,0,3);
            target = Vector3.Zero;
            right = Vector3.UnitX;
            up = Vector3.UnitY;
            direction = -Vector3.UnitZ;
            UpdateTargetDistance();


            InitObjects();
        }
        ~Camera()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            // Delete all the resources.
            GL.DeleteVertexArray(vaoAxis);
            GL.DeleteBuffer(vboAxis);
            GL.DeleteVertexArray(vaoTarget);
            GL.DeleteBuffer(vboTarget);

            GL.DeleteProgram(shader.Handle);
        }
        #endregion

        #region Methods
        private void InitObjects()
        {
            shader = new Shader("Shaders/axis.vert", "Shaders/axis.frag");

            float[] vertices_target =
            {
		        // Position			   Color
		        -0.1f,  0.0f,  0.0f,   1.0f, 1.0f, 1.0f,
                 0.1f,  0.0f,  0.0f,   1.0f, 1.0f, 1.0f,
                 0.0f, -0.1f,  0.0f,   1.0f, 1.0f, 1.0f,
                 0.0f,  0.1f,  0.0f,   1.0f, 1.0f, 1.0f,
                 0.0f,  0.0f, -0.1f,   1.0f, 1.0f, 1.0f,
                 0.0f,  0.0f,  0.1f,   1.0f, 1.0f, 1.0f,
            };
            float[] vertices_axis =
            {
		        // Position			   Color
		        -1.0f,  0.0f,  0.0f,   0.6f, 0.0f, 0.0f,
                 1.0f,  0.0f,  0.0f,   0.6f, 0.0f, 0.0f,
                 0.0f, -1.0f,  0.0f,   0.0f, 0.6f, 0.0f,
                 0.0f,  1.0f,  0.0f,   0.0f, 0.6f, 0.0f,
                 0.0f,  0.0f, -1.0f,   0.0f, 0.0f, 0.6f,
                 0.0f,  0.0f,  1.0f,   0.0f, 0.0f, 0.6f,
            };

            vboTarget = GL.GenBuffer();
            vaoTarget = GL.GenVertexArray();

            GL.BindVertexArray(vaoTarget);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboTarget);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices_target.Length * sizeof(float), vertices_target, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);


            vboAxis = GL.GenBuffer();
            vaoAxis = GL.GenVertexArray();

            GL.BindVertexArray(vaoAxis);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboAxis);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices_axis.Length * sizeof(float), vertices_axis, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);
        }

        public void Render(int aspectRatio = 0)
        {
            if (aspectRatio != 0)
                AspectRatio = aspectRatio;

            if (currentSettings.showTarget || currentSettings.showAxis)
            {
                shader.Use();

                shader.SetMatrix4("projection", Matrix4.Identity);
                shader.SetMatrix4("view", Matrix4.Identity);

                GL.LineWidth(3);

                if (currentSettings.showAxis)
                {
                    GL.BindVertexArray(vaoAxis);

                    shader.SetMatrix4("model", Matrix4.Identity);

                    GL.DrawArrays(PrimitiveType.Lines, 0, 6);
                }

                if (currentSettings.showTarget)
                {
                    GL.BindVertexArray(vaoTarget);

                    Matrix4 model = Matrix4.Identity;
                    model *= Matrix4.CreateRotationX((float) MainDlg.applicationTime.Elapsed.TotalSeconds);
                    model *= Matrix4.CreateRotationY((float) MainDlg.applicationTime.Elapsed.TotalSeconds / 2);
                    model *= Matrix4.CreateRotationZ((float) MainDlg.applicationTime.Elapsed.TotalSeconds / 3);
                    model *= Matrix4.CreateScale(new Vector3(targetDistance / 3));
                    shader.SetMatrix4("model", model);

                    GL.DrawArrays(PrimitiveType.Lines, 0, 6);
                }
            }
        }

        public void ChangeMode(Mode newMode)
        {
            if (currentSettings.mode != newMode)
                if (currentSettings.mode == Mode.FLAT)
                {
                    flatSettings = currentSettings;
                    currentSettings = freeSettings;
                }
                else
                {
                    freeSettings = currentSettings;
                    currentSettings = flatSettings;
                }
        }

        public void UpdateTargetDistance()
        {
            targetDistance = (target - position).Length;
        }
        #endregion

        #region Properties
        public double AspectRatio { get; set; }
        public Settings CurrentSettings => currentSettings;
        public bool FullScreen { get; set; }
        public bool Lock { get; set; }

        #endregion

        #region Fields
        private Vector3 position;
        private Vector3 right;
        private Vector3 up;
        private Vector3 direction;
        private Vector3 orientation;
        private Vector3 target;
        private float targetDistance;

        private Settings currentSettings;
        private Settings flatSettings;
        private Settings freeSettings;

        private Shader shader;

        private int vaoTarget, vboTarget;
        private int vaoAxis, vboAxis;
        #endregion

        #region Constants


        #endregion
    }
}
