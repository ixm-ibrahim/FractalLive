using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalLive
{
    // http://sol.gfxile.net/sphere/index.html
    public class IcoSphere
    {
        float maxR;
        float maxI;
        float minR;
        float minI;

        public TexturedVertex[] Create(int subdivisions, float radius, bool riemannTexturing = false)
        {
            var s = 1;
            var t = (float)((1.0 + Math.Sqrt(5.0)) / 2.0);

            var a = radius * new Vector3(s, t, 0).Normalized();     // 1
            var b = radius * new Vector3(-s, t, 0).Normalized();    // 2
            var c = radius * new Vector3(-s, -t, 0).Normalized();   // 3
            var d = radius * new Vector3(s, -t, 0).Normalized();    // 4

            var e = radius * new Vector3(0, s, t).Normalized();     // 5
            var f = radius * new Vector3(0, -s, t).Normalized();    // 6
            var g = radius * new Vector3(0, -s, -t).Normalized();   // 7
            var h = radius * new Vector3(0, s, -t).Normalized();    // 8

            var m = radius * new Vector3(t, 0, s).Normalized();     // 9
            var j = radius * new Vector3(t, 0, -s).Normalized();    // 10
            var k = radius * new Vector3(-t, 0, -s).Normalized();   // 11
            var l = radius * new Vector3(-t, 0, s).Normalized();    // 12

            // All arranged counter-clockwise (except when reversed)
            var faces = new List<TriangleFace>
            {
                // "top" - 5 faces around point a
                new TriangleFace(b, e, a),
                new TriangleFace(e, m, a),
                new TriangleFace(m, j, a),
                new TriangleFace(j, h, a),
                new TriangleFace(h, b, a),

                // "middle" - 5 adjacent faces to "top"
                new TriangleFace(e, b, l, true),
                new TriangleFace(m, e, f, true),
                new TriangleFace(j, m, d, true),
                new TriangleFace(h, j, g, true),
                new TriangleFace(b, h, k, true),
                
                // "middle" - 5 adjacent faces to "bottom"
                new TriangleFace(l, f, e, true),
                new TriangleFace(f, d, m, true),
                new TriangleFace(d, g, j, true),
                new TriangleFace(g, k, h, true),
                new TriangleFace(k, l, b, true),

                // 5 adjacent faces 
                new TriangleFace(f, l, c),
                new TriangleFace(d, f, c),
                new TriangleFace(g, d, c),
                new TriangleFace(k, g, c),
                new TriangleFace(l, k, c)
            };

            // subdivide triangles
            for (int i = 0; i < subdivisions; i++)
            {
                var faces2 = new List<TriangleFace>();

                foreach (var tri in faces)
                {
                    // replace triangle by 4 triangles
                    a = radius * ((tri[0] + tri[1]) / 2).Normalized();   // bottom midpoint
                    b = radius * ((tri[1] + tri[2]) / 2).Normalized();   // right midpoint
                    c = radius * ((tri[2] + tri[0]) / 2).Normalized();   // left midpoint

                    faces2.Add(new TriangleFace(tri[0], a, c)); // bottom-left
                    faces2.Add(new TriangleFace(tri[1], b, a)); // bottom-right
                    faces2.Add(new TriangleFace(tri[2], c, b)); // top
                    faces2.Add(new TriangleFace(a, b, c));      // middle
                }

                faces = faces2;
            }
            Console.WriteLine(faces.Count);
            // done, now add triangles to mesh
            var vertices = new List<TexturedVertex>();

            foreach (var tri in faces)
            {
                foreach (var v in tri.verticies)
                {
                    var scale = v.Z == 1 ? float.MaxValue : (1 + (v.Z + 1) / (1 - v.Z)) / 2f;
                    var r = v.X * scale;
                    var i = v.Y * scale;

                    maxR = Math.Max(r, maxR);
                    minR = Math.Min(r, minR);
                    maxI = Math.Max(i, maxI);
                    minI = Math.Min(i, minI);
                }
            }

            for (int i = faces.Count - 1; faces.Count > 0; i--)
            {
                Vector2 uvA;
                Vector2 uvB;
                Vector2 uvC;

                // Get texture coordinates
                if (riemannTexturing)
                {
                    /*
                    uvA = GetReimannCoord(faces[i][0]);
                    uvB = GetReimannCoord(faces[i][1]);
                    uvC = GetReimannCoord(faces[i][2]);
                    uvD = GetReimannCoord(faces[i][3]);
                    */
                    uvA = GetSphereCoord2(faces[i][0]);
                    uvB = GetSphereCoord2(faces[i][1]);
                    uvC = GetSphereCoord2(faces[i][2]);
                }
                else
                {
                    uvA = GetSphereCoord(faces[i][0]);
                    uvB = GetSphereCoord(faces[i][1]);
                    uvC = GetSphereCoord(faces[i][2]);
                }

                /*
                vertices.Add(new TexturedVertex(tri[0], tri.normal, uv1));
                vertices.Add(new TexturedVertex(tri[1], tri.normal, uv2));
                vertices.Add(new TexturedVertex(tri[2], tri.normal, uv3));
                */
                vertices.Add(new TexturedVertex(faces[i][0], faces[i][0].Normalized(), uvA));
                vertices.Add(new TexturedVertex(faces[i][1], faces[i][1].Normalized(), uvB));
                vertices.Add(new TexturedVertex(faces[i][2], faces[i][2].Normalized(), uvC));

                faces.RemoveAt(i);
            }

            return vertices.ToArray();
        }

        // https://dreamstatecoding.blogspot.com/search?q=texturedvertex
        public static Vector2 GetSphereCoord(Vector3 v)
        {
            Vector2 uv;
            var len = v.Length;

            uv.Y = (float)(Math.Acos(v.Y / len) / Math.PI);
            uv.X = -(float)((Math.Atan2(v.Z, v.X) / Math.PI + 1.0f) * 0.5f);

            return uv;
        }

        public static Vector2 GetSphereCoord2(Vector3 v)
        {
            Vector2 uv;
            var r = v.Length;

            var theta = Math.Atan2(v.Z, v.X);
            var phi = Math.Acos(-v.Y / r);

            phi /= Math.Abs(Math.Cos(theta % Math.PI / 4));

            uv.X = (float)(phi * Math.Cos(theta));
            uv.Y = (float)(phi * Math.Sin(theta));

            uv.X = (float)((uv.X - -Math.PI) / (Math.PI - -Math.PI) * (1 - 0) + 0);
            uv.Y = (float)((uv.Y - -Math.PI) / (Math.PI - -Math.PI) * (1 - 0) + 0);

            return uv;
        }

        private Vector2 GetReimannCoord(Vector3 v)
        {

            if (v.Y > .99f)
                v.Y = .99f;
            /**/
            var tmp = (1 + (v.Y + 1) / (1 - v.Y)) / 2f;
            var r = v.X * tmp;
            var i = v.Z * tmp;

            //r = (r - minR) / (maxR - minR) * (1 - 0) + 0;
            //i = (i - minI) / (maxI - minI) * (1 - 0) + 0;

            //r = (float)(1 / (1 + Math.Exp(-r * Math.Log(.001) / maxR)));
            //i = (float)(1 / (1 + Math.Exp(-i * Math.Log(.001) / maxI)));

            //r = (float)(Math.Sin(.5 * r * Math.PI / maxR) * (1 - .5) + .5);
            //i = (float)(Math.Sin(.5 * i * Math.PI / maxI) * (1 - .5) + .5);
            /*
            if (r >= 0)
                r = (float)(Math.Sqrt(maxR*maxR - (r - maxR)*(r - maxR)) / (2 * maxR) + .5);
            else
                r = (float)(-Math.Sqrt(maxR * maxR - (-r - maxR) * (-r - maxR)) / (2 * maxR) + .5);

            if (i >= 0)
                i = (float)(Math.Sqrt(maxI * maxI - (i - maxI) * (i - maxI)) / (2 * maxI) + .5);
            else
                i = (float)(-Math.Sqrt(maxI * maxI - (-i - maxI) * (-i - maxI)) / (2 * maxI) + .5);
            */
            /*
            var er = .5 * (Math.Sqrt(maxR * maxR + 8) - maxR);
            var ei = .5 * (Math.Sqrt(maxI * maxI + 8) - maxI);
            if (r >= 0)
                r = (float)(1 - 1 / (maxR * (r + er)) + 1 / (maxR * (maxR + er)));
            else
                r = (float)(1 / (maxR * (-r + er)) - 1 / (maxR * (maxR + er)));

            if (i >= 0)
                i = (float)(1 - 1 / (maxI * (i + ei)) + 1 / (maxI * (maxI + ei)));
            else
                i = (float)(1 / (maxI * (-i + ei)) - 1 / (maxI * (maxI + ei)));
            */
            /*
            var a = .5;
            var br = .5 * (Math.Sqrt(maxR * (maxR + 8 * a)) - 3 * maxR);
            var bi = .5 * (Math.Sqrt(maxI * (maxI + 8 * a)) - 3 * maxI);
            if (r >= 0)
                r = (float)(1 - a / (maxR + r + br) + a / (2 * maxR + br));
            else
                r = (float)(a / (maxR - r + br) - a / (2 * maxR + br));

            if (i >= 0)
                i = (float)(1 - a / (maxI + i + bi) + a / (2 * maxI + bi));
            else
                i = (float)(a / (maxI - i + bi) - a / (2 * maxI + bi));
                */
            /*
            if (r >= 0)
                r = -(r-maxR)*(r-maxR)/(2*maxR*maxR) + 1;
            else
                r = (-r - maxR) * (-r - maxR) / (2 * maxR * maxR);

            if (i >= 0)
                i = -(i - maxI) * (i - maxI) / (2 * maxI * maxI) + 1;
            else
                i = (-i - maxI) * (-i - maxI) / (2 * maxI * maxI);
                */
            /**/
            float a = 1;
            if (r >= 0)
                r = (float)(Math.Log(1 + a * r - 0) / Math.Log(1 + a * maxR - 0) * (1 - .5) + .5);
            else
                r = (float)(-Math.Log(1 + -a * r - 0) / Math.Log(1 + a * maxR - 0) * (1 - .5) + .5);

            if (i >= 0)
                i = (float)(Math.Log(1 + a * i - 0) / Math.Log(1 + a * maxI - 0) * (1 - .5) + .5);
            else
                i = (float)(-Math.Log(1 + -a * i - 0) / Math.Log(1 + a * maxI - 0) * (1 - .5) + .5);



            return new Vector2(r, i);
        }
    }
}
