using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            public bool toggleTarget;
            public bool toggleAxis;
            public double moveSpeed;
            public double zoomSpeed;
            public double mouseSensitivity;
            public double nearClipping;
            public double farClipping;

            public Settings(Mode mode, double fov = 67.5, Projection projection = Projection.CARTESIAN, bool toggleTarget = false, bool toggleAxis = false, double moveSpeed = .5, double zoomSpeed = .1, double mouseSensitivity = .2, double nearClipping = 0.1, double farClipping = 100)
            {
                this.mode = Mode.FLAT;
                this.projection = Projection.CARTESIAN;
                this.fov = fov;
                this.toggleTarget = toggleTarget;
                this.toggleAxis = toggleAxis;
                this.moveSpeed = moveSpeed;
                this.zoomSpeed = zoomSpeed;
                this.mouseSensitivity = mouseSensitivity;
                this.nearClipping = nearClipping;
                this.farClipping = farClipping;
            }
        }
        #endregion

        #region Constructors
        public Camera()
        {
            flatSettings = new Settings(Mode.FLAT, 45.0);
            freeSettings = new Settings(Mode.FREE, 67.5);
            
            position = new Vector3(0,0,3);
            right = new Vector3(1,0,0);
            up = new Vector3(0,1,0);
            direction = new Vector3(0,0,-1);

            FullScreen = false;
            AspectRatio = 1;
            Lock = false;
        }

        #endregion

        #region Methods

        #endregion

        #region Properties
        public bool FullScreen { get; set; }
        public double AspectRatio { get; set; }
        public bool Lock { get; set; }
        #endregion

        #region Fields
        public Vector3 position;
        public Vector3 right;
        public Vector3 up;
        public Vector3 direction;
        public Vector3 orientation;
        public Vector3 target;

        Settings flatSettings;
        Settings freeSettings;
        #endregion

        #region Variables


        #endregion
    }
}
