using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractalLive
{
    class JuliaMating
    {
        public JuliaMating()
        {
            IsInitialized = false;
        }

        public void InitializeMating(int matingIterations, int intermediateSteps, bool complete = false)
        {
            IsInitialized = false;

            MatingIterations = matingIterations;
            IntermediateSteps = intermediateSteps;

            if (complete)
                CompleteMating();
            else
                InitializeMating();
        }
        public void InitializeMating(Vector2 p, Vector2 q, bool complete = false)
        {
            P = new BigComplex(p.X, p.Y);
            Q = new BigComplex(q.X, q.Y);

            if (complete)
                CompleteMating();
            else
                InitializeMating();
        }
        public void InitializeMating(Vector2 p, Vector2 q, int matingIterations, int intermediateSteps, bool complete = false)
        {
            // Bascilica vs. Rabbit
            //P = new BigComplex(-1, 0);
            //Q = new BigComplex(-.123f, .745f);
            P = new BigComplex(p.X, p.Y);
            Q = new BigComplex(q.X, q.Y);
            MatingIterations = matingIterations;
            IntermediateSteps = intermediateSteps;

            if (complete)
                CompleteMating();
            else
                InitializeMating();
        }
        void InitializeMating()
        {
            Completed = false;
            currentStep = -1;

            T = new double[IntermediateSteps];
            R = new double[IntermediateSteps];

            X = new BigComplex[MatingIterations * IntermediateSteps];
            Y = new BigComplex[MatingIterations * IntermediateSteps];

            Ma = new Vector2d[MatingIterations * IntermediateSteps];
            Mb = new Vector2d[MatingIterations * IntermediateSteps];
            Mc = new Vector2d[MatingIterations * IntermediateSteps];
            Md = new Vector2d[MatingIterations * IntermediateSteps];

            for (int s = 0; s < IntermediateSteps; s++)
            {
                T[s] = (s + .5) / IntermediateSteps;
                R[s] = Math.Exp(Math.Pow(2, 1 - T[s]) * Math.Log(R1));
            }

            var p_i = BigComplex.Zero;
            var q_i = BigComplex.Zero;

            for (int i = 0; i < MatingIterations * IntermediateSteps; i++)
            {
                int s = i % IntermediateSteps;

                X[i] = p_i / R[s];
                Y[i] = R[s] / q_i;

                int n = (i - s) / IntermediateSteps;

                if (s == IntermediateSteps - 1)
                {
                    p_i = (p_i ^ 2) + P;
                    q_i = (q_i ^ 2) + Q;
                }
            }

            IsInitialized = true;
        }

        void SetStepValues()
        {
            int s = (int)currentStep % IntermediateSteps;
            int n = ((int)currentStep - s) / IntermediateSteps;
                
            if (n == MatingIterations - 1)
            {
                n = MatingIterations - 2;
                s = IntermediateSteps - 1;
            }

            R_t = R[s];

            Ma_Step = new Vector2d[n + 1];
            Mb_Step = new Vector2d[n + 1];
            Mc_Step = new Vector2d[n + 1];
            Md_Step = new Vector2d[n + 1];

            for (int k = 0; k <= n; k++)
            {
                Ma_Step[k] = Ma[IntermediateSteps * k + s];
                Mb_Step[k] = Mb[IntermediateSteps * k + s];
                Mc_Step[k] = Mc[IntermediateSteps * k + s];
                Md_Step[k] = Md[IntermediateSteps * k + s];
            }
        }

        public void UpdateMating()
        {
            if (!Completed)
                currentStep++;
            else
                if (currentStep < 0)
                    currentStep = 0;
                else if (currentStep >= MatingIterations * IntermediateSteps)
                    currentStep = MatingIterations * IntermediateSteps - 1;

            if (currentStep >= MatingIterations * IntermediateSteps)
                currentStep = MatingIterations * IntermediateSteps - 1;

            // frame = intermediate_steps * n + s
            // for each n
            //      for each s
            int s = (int)currentStep % IntermediateSteps;
            int n = ((int)currentStep - s) / IntermediateSteps;

            //if (n > 18)
            //zoom *= 1.005f;

            if (!Completed)
            {
                if (currentStep == MatingIterations * IntermediateSteps - 1)
                    Completed = true;

                int first = IntermediateSteps + s;

                if (n > 0)
                {
                    var z_x = new BigComplex[MatingIterations - n];
                    var z_y = new BigComplex[MatingIterations - n];

                    var tmp = (1 - Y[first]) / (1 - X[first]);

                    for (int k = 0; k < MatingIterations - n; k++)
                    {
                        int k_next = k + 1;
                        int next = IntermediateSteps * k_next + s;
                        int prev = IntermediateSteps * k + ((s + IntermediateSteps - 1) % IntermediateSteps);

                        z_x[k] = BigComplex.Sqrt(BigComplex.Proj(tmp * (X[next] - X[first]) / (X[next] - Y[first])));
                        z_y[k] = BigComplex.Sqrt(BigComplex.Proj(tmp * (1 - (X[first] / Y[next])) / (1 - (Y[first] / Y[next]))));

                        if ((-z_x[k] - X[prev]).RadiusSquared < (z_x[k] - X[prev]).RadiusSquared)
                            z_x[k] = -z_x[k];
                        if ((-z_y[k] - Y[prev]).RadiusSquared < (z_y[k] - Y[prev]).RadiusSquared)
                            z_y[k] = -z_y[k];
                    }

                    for (int k = 0; k < MatingIterations - n; k++)
                    {
                        X[IntermediateSteps * k + s] = z_x[k];
                        Y[IntermediateSteps * k + s] = z_y[k];
                    }
                }

                var d = Y[first] - 1;
                var c = 1 - X[first];
                var b = X[first] * d;
                var a = Y[first] * c;

                Ma[(int)currentStep] = new Vector2d(a.R.ToDouble(), a.I.ToDouble());
                Mb[(int)currentStep] = new Vector2d(b.R.ToDouble(), b.I.ToDouble());
                Mc[(int)currentStep] = new Vector2d(c.R.ToDouble(), c.I.ToDouble());
                Md[(int)currentStep] = new Vector2d(d.R.ToDouble(), d.I.ToDouble());

                SetStepValues();
            }
        }
        public void CompleteMating()
        {
            InitializeMating();

            for (currentStep = 0; currentStep < MatingIterations*IntermediateSteps; currentStep++)
            {
                int s = (int)currentStep % IntermediateSteps;
                int n = ((int)currentStep - s) / IntermediateSteps;

                int first = IntermediateSteps + s;

                if (n > 0)
                {
                    var z_x = new BigComplex[MatingIterations - n];
                    var z_y = new BigComplex[MatingIterations - n];

                    var tmp = (1 - Y[first]) / (1 - X[first]);

                    for (int k = 0; k < MatingIterations - n; k++)
                    {
                        int k_next = k + 1;
                        int next = IntermediateSteps * k_next + s;
                        int prev = IntermediateSteps * k + ((s + IntermediateSteps - 1) % IntermediateSteps);

                        z_x[k] = BigComplex.Sqrt(BigComplex.Proj(tmp * (X[next] - X[first]) / (X[next] - Y[first])));
                        z_y[k] = BigComplex.Sqrt(BigComplex.Proj(tmp * (1 - (X[first] / Y[next])) / (1 - (Y[first] / Y[next]))));

                        if ((-z_x[k] - X[prev]).RadiusSquared < (z_x[k] - X[prev]).RadiusSquared)
                            z_x[k] = -z_x[k];
                        if ((-z_y[k] - Y[prev]).RadiusSquared < (z_y[k] - Y[prev]).RadiusSquared)
                            z_y[k] = -z_y[k];
                    }

                    for (int k = 0; k < MatingIterations - n; k++)
                    {
                        X[IntermediateSteps * k + s] = z_x[k];
                        Y[IntermediateSteps * k + s] = z_y[k];
                    }
                }

                var d = Y[first] - 1;
                var c = 1 - X[first];
                var b = X[first] * d;
                var a = Y[first] * c;

                Ma[(int)currentStep] = new Vector2d(a.R.ToDouble(), a.I.ToDouble());
                Mb[(int)currentStep] = new Vector2d(b.R.ToDouble(), b.I.ToDouble());
                Mc[(int)currentStep] = new Vector2d(c.R.ToDouble(), c.I.ToDouble());
                Md[(int)currentStep] = new Vector2d(d.R.ToDouble(), d.I.ToDouble());
            }

            Completed = true;
            currentStep--;
            currentStep--; //@ because of bug in final iteration
            SetStepValues();
        }

        public bool IsInitialized { get; set; }
        public bool Completed { get; private set; }
        public int CurrentStep
        {
            get => currentStep;
            
            set
            {
                currentStep = value;
                SetStepValues();
            }
        }

        public BigComplex P { get; private set; }
        public BigComplex Q { get; private set; }

        public int MatingIterations { get; set; }
        public int IntermediateSteps { get; set; }

        public BigComplex[] X { get; private set; }
        public BigComplex[] Y { get; private set; }
        public double[] T { get; private set; }
        public double[] R { get; private set; }
        public Vector2d[] Ma { get; private set; }
        public Vector2d[] Mb { get; private set; }
        public Vector2d[] Mc { get; private set; }
        public Vector2d[] Md { get; private set; }
        public double R_t { get; private set; }
        public Vector2d[] Ma_Step { get; private set; }
        public Vector2d[] Mb_Step { get; private set; }
        public Vector2d[] Mc_Step { get; private set; }
        public Vector2d[] Md_Step { get; private set; }

        const double R1 = 1e10;
        public const int MAX_MATING_ITER = 200;
        public const int MAX_STEPS = 5000;

        private int currentStep;
    }
}
