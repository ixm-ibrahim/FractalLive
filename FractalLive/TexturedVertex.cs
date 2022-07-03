﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FractalLive
{

    [StructLayout(LayoutKind.Explicit, Size = 8*sizeof(float))]
    struct TexturedVertex
    {
        #region Enumerations

        #endregion

        #region Structures

        #endregion

        #region Constructors
        public TexturedVertex(float position_x, float position_y, float position_z, float normal_x, float normal_y, float normal_z, float texture_x, float texture_y)
        {
            this.position_x = position_x;
            this.position_y = position_y;
            this.position_z = position_z;
            this.normal_x = normal_x;
            this.normal_y = normal_y;
            this.normal_z = normal_z;
            this.texture_x = texture_x;
            this.texture_y = texture_y;
        }
        #endregion

        #region Methods
        #endregion

        #region Properties
        public static int Size => (3 + 3 + 2) * sizeof(float);
        #endregion

        #region Fields
        [FieldOffset(0 * sizeof(float))]
        public float position_x;
        [FieldOffset(1 * sizeof(float))]
        public float position_y;
        [FieldOffset(2 * sizeof(float))]
        public float position_z;
        [FieldOffset(3 * sizeof(float))]
        public float normal_x;
        [FieldOffset(4 * sizeof(float))]
        public float normal_y;
        [FieldOffset(5 * sizeof(float))]
        public float normal_z;
        [FieldOffset(6 * sizeof(float))]
        public float texture_x;
        [FieldOffset(7 * sizeof(float))]
        public float texture_y;
        #endregion

        #region Variables

        #endregion
    }
}
