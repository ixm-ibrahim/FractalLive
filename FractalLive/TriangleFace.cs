using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalLive
{

    public class TriangleFace
    {
        public Vector3[] verticies;
        public Vector3 normal;
        public Vector3 center;
        public Vector3 adjacent_01;
        public Vector3 adjacent_12;
        public Vector3 adjacent_20;

        public bool reversed = false;

        public int subdivision = 0;

        public TriangleFace(Vector3 a, Vector3 b, Vector3 c, bool reversed = false, int subdivision = 0)
        {
            verticies = new Vector3[3];

            verticies[0] = a;
            verticies[1] = b;
            verticies[2] = c;

            normal = GetNormal();
            center = GetCenter();

            this.reversed = reversed;
            this.subdivision = subdivision;
        }

        public TriangleFace(Vector3 a, Vector3 b, Vector3 c, Vector3 norm)
        {
            verticies = new Vector3[3];

            verticies[0] = a;
            verticies[1] = b;
            verticies[2] = c;

            normal = norm;
            center = GetCenter();
        }

        public Vector3 this[int index]
        {
            get { return verticies[index]; }

            set
            {
                verticies[index] = value;

                normal = GetNormal();
                center = GetCenter();
            }
        }

        public static bool operator ==(TriangleFace a, TriangleFace b)
        {
            return a.verticies.All(b.verticies.Contains) && a.normal == b.normal;
        }
        public static bool operator !=(TriangleFace a, TriangleFace b)
        {
            return !(a == b);
        }

        Vector3 GetNormal()
        {
            return Vector3.Cross(verticies[1] - verticies[0], verticies[2] - verticies[0]).Normalized();
        }

        Vector3 GetCenter()
        {
            return ((verticies[0] + verticies[1] + verticies[2]) / 3).Normalized();
        }
    }

}
