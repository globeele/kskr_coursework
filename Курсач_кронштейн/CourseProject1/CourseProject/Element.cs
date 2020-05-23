using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CourseProject
{
    class Element
    {
        Node n1;
        Node n2;
        Node n3;
        SolidBrush colorElement;
        int index;
        float[,] a;
        float[,] a_1;
        float[,] q;
        float[,] k;
        float[,] b;
        float[,] d;
        float[,] sig;
        float[,] e;
        float[,] stress;
        float s;

        public Element(int _index, Node _n1, Node _n2, Node _n3)
        {
            index = _index;
            n1 = _n1;
            n2 = _n2;
            n3 = _n3;
            sig = new float[6, 1];
        }

        public void CreateMatrix(float t, float elasticModulus, float poissonsRatio)
        {
            CreateA();
            CreateQ();
            CreateD(elasticModulus, poissonsRatio);
            CreateB();
            CreateK(t);
        }

        void CreateA()
        {
            a = new float[6, 6];
            a_1 = new float[6, 6];

            a[0, 0] = 1;
            a[0, 1] = n1.X;
            a[0, 2] = n1.Y;

            a[1, 3] = 1;
            a[1, 4] = n1.X;
            a[1, 5] = n1.Y;

            a[2, 0] = 1;
            a[2, 1] = n2.X;
            a[2, 2] = n2.Y;

            a[3, 3] = 1;
            a[3, 4] = n2.X;
            a[3, 5] = n2.Y;

            a[4, 0] = 1;
            a[4, 1] = n3.X;
            a[4, 2] = n3.Y;

            a[5, 3] = 1;
            a[5, 4] = n3.X;
            a[5, 5] = n3.Y;

            a_1 = MatrixHelper.FindingTheInverseMatrix(a);
        }

        void CreateQ()
        {
            q = new float[3, 6];

            q[0, 1] = 1;
            q[1, 5] = 1;
            q[2, 2] = 1;
            q[2, 4] = 1;
        }

        void CreateD(float elasticModulus, float poissonsRatio)
        {
            d = new float[3, 3];
            float koeff = elasticModulus / (1 - poissonsRatio * poissonsRatio);
            d[0, 0] = 1;
            d[0, 1] = poissonsRatio;
            d[0, 2] = 0;
            d[1, 0] = poissonsRatio;
            d[1, 1] = 1;
            d[1, 2] = 0;
            d[2, 0] = 0;
            d[2, 1] = 0;
            d[2, 2] = (1 - poissonsRatio) / 2;
            d = MatrixHelper.MultiplicationMatrixAndNumber(d, koeff);
        }

        void CreateB()
        {
            b = new float[3, 6];
            b = MatrixHelper.MatrixMultiplication(q, a_1);
        }

        void CreateK(float t)
        {
            k = new float[6, 6];
            float[,] transpB = MatrixHelper.Transpose(b);
            k = MatrixHelper.MatrixMultiplication(transpB, d);
            k = MatrixHelper.MatrixMultiplication(k, b);
            k = MatrixHelper.MultiplicationMatrixAndNumber(k, t);
            float ds = triangleArea(n1.X, n1.Y, n2.X, n2.Y, n3.X, n3.Y);
            k = MatrixHelper.MultiplicationMatrixAndNumber(k, ds);
        }

        public void SolveStress()
        {
            float[,] bb = MatrixHelper.MatrixMultiplication(q, a_1);
            e = MatrixHelper.MatrixMultiplication(bb, sig);
            stress = MatrixHelper.MatrixMultiplication(d, e);
            s = (float)Math.Sqrt(Math.Pow(stress[0, 0], 2) + Math.Pow(stress[1, 0], 2) - stress[0, 0] * stress[1, 0] + 3 * (Math.Pow(stress[2, 0], 2)));
        }

        float triangleArea(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            float a, b, c, p;
            c = (float)Math.Sqrt(Math.Pow(y1 - y2, 2) + Math.Pow(x1 - x2, 2));
            a = (float)Math.Sqrt(Math.Pow(y2 - y3, 2) + Math.Pow(x2 - x3, 2));
            b = (float)Math.Sqrt(Math.Pow(y1 - y3, 2) + Math.Pow(x1 - x3, 2));

            p = (a + b + c) / 2;
            return ((float)Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
        }

        public SolidBrush ColorElement
        {
            get { return (colorElement); }
            set { colorElement = value; }
        }

        public Node N1
        {
            get { return (n1); }
            set { n1 = value; }
        }

        public Node N2
        {
            get { return (n2); }
            set { n2 = value; }
        }

        public Node N3
        {
            get { return (n3); }
            set { n3 = value; }
        }

        public int Index
        {
            get { return (index); }
            set { index = value; }
        }

        public float S
        {
            get { return (s); }
            set { s = value; }
        }

        public float[,] A
        {
            get { return (a); }
            set { a = value; }
        }

        public float[,] Q
        {
            get { return (q); }
            set { q = value; }
        }

        public float[,] K
        {
            get { return (k); }
            set { k = value; }
        }

        public float[,] B
        {
            get { return (b); }
            set { b = value; }
        }

        public float[,] D
        {
            get { return (d); }
            set { d = value; }
        }

        public float[,] Sig
        {
            get { return (sig); }
            set { sig = value; }
        }

        public float[,] Stress
        {
            get { return (stress); }
            set { stress = value; }
        }
    }
}
