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
            public float fov;
            public bool showTarget;
            public bool showAxis;
            public float moveSpeed;
            public float turnSpeed;
            public float zoomSpeed;
            public float mouseSensitivity;
            public float nearClipping;
            public float farClipping;

            public Settings(Mode mode, float fov = 67.5f, Projection projection = Projection.CARTESIAN, bool showTarget = false, bool showAxis = false, float moveSpeed = .5f, float turnSpeed = .2f, float zoomSpeed = .1f, float mouseSensitivity = .2f, float nearClipping = 0.1f, float farClipping = 100f)
            {
                this.mode = Mode.FLAT;
                this.projection = Projection.CARTESIAN;
                this.fov = MathHelper.DegreesToRadians(fov);
                this.showTarget = showTarget;
                this.showAxis = showAxis;
                this.moveSpeed = moveSpeed;
                this.turnSpeed = turnSpeed;
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
            flatSettings = new Settings(Mode.FLAT, 45.0f);
            freeSettings = new Settings(Mode.FREE, 67.5f);
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

        void UpdateTarget()
        {
            target = MoveAlongAxis(position, direction, targetDistance);
        }


        // Gets the view matrix
        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(position, direction + position, up);
            //return Matrix4.LookAt(Position, direction, up);
        }

        // Gets the projection matrix @DOES NOT WORK AS INTENDED
        public Matrix4 GetOrthographicMatrix(int Width, int Height)
        {
            return Matrix4.CreateOrthographic(Width, Height, currentSettings.nearClipping, currentSettings.farClipping);
            //return Matrix4.LookAt(Position, Direction + direction, Up);
        }

        // Gets the projection matrix
        public Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(currentSettings.fov, AspectRatio, currentSettings.nearClipping, currentSettings.farClipping);
            //return Matrix4.CreatePerspectiveFieldOfView(fov, AspectRatio, 0.0001f, targetDistance * 10);
        }


        public void MoveAlongAxis(Vector3 axis, bool updateTarget = true)
        {
            MoveAlongAxis(axis, 1, updateTarget);
        }
        public void MoveAlongAxis(Vector3 axis, float distance, bool updateTarget = true)
        {
            UpdateTargetDistance();
            position += axis * distance * currentSettings.moveSpeed;

            if (updateTarget)
                UpdateTarget();
        }
        public static Vector3 MoveAlongAxis(Vector3 position, Vector3 axis, float distance)
        {
            return position + (axis * distance);
        }

        public void Zoom(float distance = 1)
        {
            //MoveAlongAxis(direction, currentSettings.zoomSpeed * distance * targetDistance, false);
            MoveAlongAxis(direction, currentSettings.zoomSpeed * distance * (position - position.Normalized()).Length, false);
        }

        public void ZoomAlongAxis(Vector3 axis, float distance)
        {
            MoveAlongAxis(axis, currentSettings.zoomSpeed * distance * targetDistance, false);
        }

        public void ZoomTarget(Vector3 target, float distance, bool updateTarget = true)
        {
            UpdateTargetDistance();
            MoveAlongAxis((target - position).Normalized(), currentSettings.zoomSpeed * distance * targetDistance, false);

            if (updateTarget)
                UpdateTarget();
        }

        public void RotateX(float angle, bool updateTarget = true)
        {
            UpdateTargetDistance();
            ArcBall(Vector3.UnitX, angle);

            if (updateTarget)
                UpdateTarget();
        }

        public void RotateY(float angle, bool updateTarget = true)
        {
            UpdateTargetDistance();
            ArcBall(Vector3.UnitY, angle);

            if (updateTarget)
                UpdateTarget();
        }

        public void RotateZ(float angle, bool updateTarget = true)
        {
            UpdateTargetDistance();
            ArcBall(Vector3.UnitZ, angle);

            if (updateTarget)
                UpdateTarget();
        }

        //@OpenTK.Quaternion error has to do something with FromAxisAngle()
        public void RotateYaw(float angle, Mode mode, bool updateTarget = true)
        {
            UpdateTargetDistance();

            if (mode == Mode.FPS)
                Yaw += angle * currentSettings.turnSpeed;
            else
                //RotateVectors(Quaternion.FromAxisAngle(MathHelper.DegreesToRadians(angle * currentSettings.turnSpeed), new Vector3D(up)));
                RotateVectors(Quaternion.FromAxisAngle(up, MathHelper.DegreesToRadians(angle * currentSettings.turnSpeed)));

            if (updateTarget)
                UpdateTarget();
        }

        public void RotatePitch(float angle, Mode mode, bool updateTarget = true)
        {
            UpdateTargetDistance();

            if (mode == Mode.FPS)
                Pitch += angle * currentSettings.turnSpeed;
            else
                //RotateVectors(Quaternion.FromAxisAngle(MathHelper.DegreesToRadians(angle * turnSpeed), new Vector3D(right)));
                RotateVectors(Quaternion.FromAxisAngle(right, MathHelper.DegreesToRadians(angle * currentSettings.turnSpeed)));

            if (updateTarget)
                UpdateTarget();
        }

        public void RotateRoll(float angle, bool updateTarget = true)
        {
            UpdateTargetDistance();

            //RotateVectors(Quaternion.FromAxisAngle(MathHelper.DegreesToRadians(angle * turnSpeed), new Vector3D(direction)));
            RotateVectors(Quaternion.FromAxisAngle(direction, MathHelper.DegreesToRadians(angle * currentSettings.turnSpeed)));

            if (updateTarget)
                UpdateTarget();
        }

        public static Vector3 Rotate(Vector3 position, Vector3 axis, float angle)
        {
            Quaternion localRotation = Quaternion.FromAxisAngle(axis, MathHelper.DegreesToRadians(angle));

			return localRotation.Inverted() * (localRotation * position);
            /*Quaternion localRotation = Quaternion.FromAxisAngle(angle * Math.PI / 360, new Vector3D(axis));

            Vector3D v = localRotation.Inverse() * (localRotation * new Vector3D(position));

            position.X = (float)v.X;
            position.Y = (float)v.Y;
            position.Z = (float)v.Z;

            return position;*/
        }

        public void ArcBallYaw(float angle, Mode mode, bool aroundOrigin = false)
        {
            position -= (aroundOrigin ? Vector3.Zero : target);

            if (mode == Mode.FPS)
                Yaw += angle * currentSettings.turnSpeed;
            else
                RotateVectors(Quaternion.FromAxisAngle(up, MathHelper.DegreesToRadians(currentSettings.turnSpeed * angle)));

            position = (direction * -position.Length) + (aroundOrigin ? Vector3.Zero : target);

            if (aroundOrigin)
                UpdateTarget();
        }

        public void ArcBallPitch(float angle, Mode mode, bool aroundOrigin = false)
        {
            position -= (aroundOrigin ? Vector3.Zero : target);

            if (mode == Mode.FPS)
                Pitch += angle * currentSettings.turnSpeed;
            else
                RotateVectors(Quaternion.FromAxisAngle(right, MathHelper.DegreesToRadians(currentSettings.turnSpeed * angle)));

            position = (direction * -position.Length) + (aroundOrigin ? Vector3.Zero : target);

            if (aroundOrigin)
                UpdateTarget();
        }

        public void ArcBall(Vector3 axis, float angle, bool aroundOrigin = true)
        {
            //RotateVectors(Quaternion.FromAxisAngle(turnSpeed * MathHelper.DegreesToRadians(angle), new Vector3D(axis)));
            RotateVectors(Quaternion.FromAxisAngle(axis, currentSettings.turnSpeed * MathHelper.DegreesToRadians(angle)));

            position = (Vector3.UnitZ * -position.Length) + (aroundOrigin ? Vector3.Zero : target);

            if (aroundOrigin)
                UpdateTarget();
        }

        // Updates direction vertices based on yaw and pitch
        void RotateVectors()
        {
            // First the direction matrix is calculated using some basic trigonometry
            direction.X = (float)Math.Cos(pitch) * (float)Math.Cos(yaw);
            direction.Y = (float)Math.Sin(pitch);
            direction.Z = (float)Math.Cos(pitch) * (float)Math.Sin(yaw);

            // We need to make sure the vectors are all normalized, as otherwise we would get some funky results
            direction = Vector3.Normalize(direction);

            // Calculate both the right and the up vector using cross product
            //		Note that we are calculating the right from the global up, this behaviour might
            //		not be what you need for all cameras so keep this in mind if you do not want a FPS camera
            right = Vector3.Normalize(Vector3.Cross(direction, Vector3.UnitY));
            up = Vector3.Normalize(Vector3.Cross(right, direction));
        }
        // Updates direction vertices based on quaternion
        void RotateVectors(Quaternion localRotation)
        {
			
			ApplyRotationToVector(localRotation, ref right);
			ApplyRotationToVector(localRotation, ref up);
			ApplyRotationToVector(localRotation, ref direction);
			/*
            var hAxis = new Vector3D(right);
            var vAxis = new Vector3D(up);
            var dir = new Vector3D(direction);

            ApplyRotationToVector(localRotation, ref hAxis);
            ApplyRotationToVector(localRotation, ref vAxis);
            ApplyRotationToVector(localRotation, ref dir);

            right.X = (float)hAxis.X;
            right.Y = (float)hAxis.Y;
            right.Z = (float)hAxis.Z;

            up.X = (float)vAxis.X;
            up.Y = (float)vAxis.Y;
            up.Z = (float)vAxis.Z;

            direction.X = (float)dir.X;
            direction.Y = (float)dir.Y;
            direction.Z = (float)dir.Z;
            */
            yaw = (float)Math.Atan2(direction.X, -direction.Z) - MathHelper.PiOver2;
            pitch = (float)Math.Asin(direction.Y);
        }

        //void ApplyRotationToVector(Quaternion rotation, ref Vector3D v)
        void ApplyRotationToVector(Quaternion rotation, ref Vector3 v)
        {
            //v = tmp * (rotation * v);
            //v = rotation.Inverted() * (rotation * v); // GLM overrides this
            v = rotation * v;
        }

        public bool Is3D()
        {
            return CurrentMode != Mode.FLAT;
        }

        #endregion

        #region Properties
        public float AspectRatio { get; set; }
        public Settings CurrentSettings => currentSettings;
        public bool FullScreen { get; set; }
        public bool Lock { get; set; }
        public Mode CurrentMode => CurrentSettings.mode;

        // Changing this can simulate a zoom
        public float FOV
        {
            get => MathHelper.RadiansToDegrees(currentSettings.fov);

            set => currentSettings.fov = MathHelper.DegreesToRadians(MathHelper.Clamp(value, 1f, 45f));
        }

        public float Pitch
        {
            get => MathHelper.RadiansToDegrees(pitch);

            set
            {
                // We clamp the pitch value between -89 and 89 to prevent the camera from going upside down, and
                // to avoid gimbal lock
                pitch = MathHelper.DegreesToRadians(MathHelper.Clamp(value, -89f, 89f));

                RotateVectors();
            }
        }

        public float Yaw
        {
            get => MathHelper.RadiansToDegrees(yaw);

            set
            {
                yaw = MathHelper.DegreesToRadians(value);

                RotateVectors();
            }
        }

        public float Roll { get; set; }

        #endregion

        #region Fields
        private Vector3 position;
        private Vector3 right;
        private Vector3 up;
        private Vector3 direction;
        private Vector3 target;
        private float targetDistance;

        private Vector3 orientation;
        float yaw = -MathHelper.PiOver2;
        float pitch = 0;
        float roll = 0;

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
