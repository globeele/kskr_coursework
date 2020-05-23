using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CourseProject
{
    public partial class Form1 : Form
    {
        float dR = 15, delta = 0.3f, thickness;
        float force1 = 33.3f, force2;
        float dopStress = 1, maxStress;
        float widthDetails= 1500,  lengthDetails = 1500, prevwidthDetails , prevlengthDetails;
        float elasticModulus, poissonsRatio;
        bool edit = false;
        List<Node> nodes;
        List<Element> elements;
        int[] indexNodes1 = new int[] { 77, 78, 79, 80, 81, 82 };
        int[] indexNodes2 = new int[] { 5, 6 };
        float[,] globalK;
        Graphics gr;
        SolidBrush c1, c2, c3, c4, c5, c6, c7, c8, c9;
        public Form1()
        {
            InitializeComponent();
            gr = panel.CreateGraphics();
            c1 = new SolidBrush(Color.Blue);
            c2 = new SolidBrush(Color.DarkTurquoise);
            c3 = new SolidBrush(Color.LightSkyBlue);
            c4 = new SolidBrush(Color.Aqua);
            c5 = new SolidBrush(Color.LimeGreen);
            c6 = new SolidBrush(Color.GreenYellow);
            c7 = new SolidBrush(Color.Yellow);
            c8 = new SolidBrush(Color.Orange);
            c9 = new SolidBrush(Color.Red);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nodes = FileHelper.ReadFileNodes();
            elements = FileHelper.ReadFileElements(nodes);
        }

        private void buttonGrid_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].X = nodes[i].X / dR;
                nodes[i].Y = nodes[i].Y / dR;
            }
           // detailsRadius = Convert.ToSingle(textBoxLength.Text);
            thickness = Convert.ToSingle(textBoxThickness.Text);

            //widthDetails = detailsRadius * 2;
            //lengthDetails = widthDetails * 2;

            //dR = lengthDetails / defaultR;
            //dR = detailsRadius / defaultR;
           // dR = 10000;
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].X = nodes[i].X * dR;
                nodes[i].Y = nodes[i].Y * dR;
            }

            if (edit)
                gr.TranslateTransform(-(panel.Width - prevlengthDetails * delta) / 2, -(440 - (panel.Height - prevwidthDetails * delta) / 2));
            edit = true;
            gr.TranslateTransform((panel.Width - lengthDetails * delta) / 2, (440 - (panel.Height - widthDetails * delta) / 2));
            prevlengthDetails = lengthDetails;
            prevwidthDetails = widthDetails;

            gr.Clear(Color.Linen);
            Meshing(Color.Green);
            DrawingFixation();
            DrawingForce();
            groupBoxResult.Visible = false;
            comboBox.Visible = false;
            buttonSolve.Enabled = true;
        }

        //Метод отрисовки сетки
        void Meshing(Color color)
        {
            Pen p = new Pen(color, 1);
            for (int i = 0; i < elements.Count; i++)
            {
                gr.DrawLine(p, elements[i].N1.X * delta, -elements[i].N1.Y * delta, elements[i].N2.X * delta, -elements[i].N2.Y * delta);
                gr.DrawLine(p, elements[i].N2.X * delta, -elements[i].N2.Y * delta, elements[i].N3.X * delta, -elements[i].N3.Y * delta);
                gr.DrawLine(p, elements[i].N3.X * delta, -elements[i].N3.Y * delta, elements[i].N1.X * delta, -elements[i].N1.Y * delta);
            }
        }

        //Метод отрисовки закрепления
        void DrawingFixation()
        {
            Pen p = new Pen(Color.Blue, 3);
            gr.DrawLine(p, nodes[indexNodes1[1]].X * delta - 140, -nodes[indexNodes1[1]].Y * delta -210, nodes[indexNodes1[4]].X * delta -180, -nodes[indexNodes1[4]].Y * delta-210);
            gr.DrawLine(p, nodes[indexNodes1[1]].X * delta - 140, -nodes[indexNodes1[1]].Y * delta -210, nodes[indexNodes1[4]].X * delta -193, -nodes[indexNodes1[4]].Y * delta-195);
            gr.DrawLine(p, nodes[indexNodes1[1]].X * delta - 140, -nodes[indexNodes1[1]].Y * delta +75, nodes[indexNodes1[4]].X * delta -193, -nodes[indexNodes1[4]].Y * delta+90);
            gr.DrawLine(p, nodes[indexNodes1[1]].X * delta - 125, -nodes[indexNodes1[1]].Y * delta +90, nodes[indexNodes1[4]].X * delta -193, -nodes[indexNodes1[4]].Y * delta+90);
        }

        //Метод отрисовки сил
        void DrawingForce()
        {
            Pen p = new Pen(Color.Red, 4);

            p.EndCap = LineCap.ArrowAnchor;

            for (int i = 0; i < indexNodes1.Length-1; i = i + 1)
                gr.DrawLine(p, nodes[indexNodes1[i]].X * delta -10, -nodes[indexNodes1[i]].Y * delta -100, nodes[indexNodes1[i]].X * delta -10, -nodes[indexNodes1[i]].Y * delta);
            }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.Linen);
            elasticModulus = Convert.ToSingle(textBoxElasticModulus.Text);
            poissonsRatio = Convert.ToSingle(textBoxPoissonsRatio.Text);
            force2 = Convert.ToSingle(textBoxForce.Text);
            force1 = force1 + force2;

            for (int i = 0; i < elements.Count; i++)
                elements[i].CreateMatrix(thickness, elasticModulus, poissonsRatio);
            globalK = new float[nodes.Count * 2, nodes.Count * 2 + 1];

            int[] listIndex = new int[3];
            for (int i = 0; i < elements.Count; i++)
            {
                listIndex[0] = elements[i].N1.Index;
                listIndex[1] = elements[i].N2.Index;
                listIndex[2] = elements[i].N3.Index;

                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                    {
                        globalK[2 * listIndex[j], 2 * listIndex[k]] = globalK[2 * listIndex[j], 2 * listIndex[k]] + elements[i].K[j * 2, k * 2];
                        globalK[2 * listIndex[j] + 1, 2 * listIndex[k]] = globalK[2 * listIndex[j] + 1, 2 * listIndex[k]] + elements[i].K[j * 2 + 1, k * 2];
                        globalK[2 * listIndex[j], 2 * listIndex[k] + 1] = globalK[2 * listIndex[j], 2 * listIndex[k] + 1] + elements[i].K[j * 2, k * 2 + 1];
                        globalK[2 * listIndex[j] + 1, 2 * listIndex[k] + 1] = globalK[2 * listIndex[j] + 1, 2 * listIndex[k] + 1] + elements[i].K[j * 2 + 1, k * 2 + 1];
                    }
            }

            for (int i = 0; i < indexNodes1.Length; i++)
                globalK[indexNodes1[i] * 2, nodes.Count * 2] = force1;
            for (int i = 0; i < indexNodes2.Length; i++)
                globalK[indexNodes2[i] * 2 + 1, nodes.Count * 2] = force2;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Fixation)
                {
                    for (int j = 0; j < nodes.Count * 2; j++)
                    {
                        globalK[2 * i, j] = 0;
                        globalK[2 * i + 1, j] = 0;
                        globalK[j, 2 * i] = 0;
                        globalK[j, 2 * i + 1] = 0;
                    }
                    globalK[2 * i, 2 * i] = 1;
                    globalK[2 * i + 1, 2 * i + 1] = 1;
                }
            }

            globalK = MatrixHelper.Gaus(nodes, globalK);

            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Sig[0, 0] = globalK[2 * elements[i].N1.Index, 2 * nodes.Count];
                elements[i].Sig[1, 0] = globalK[2 * elements[i].N1.Index + 1, 2 * nodes.Count];
                elements[i].Sig[2, 0] = globalK[2 * elements[i].N2.Index, 2 * nodes.Count];
                elements[i].Sig[3, 0] = globalK[2 * elements[i].N2.Index + 1, 2 * nodes.Count];
                elements[i].Sig[4, 0] = globalK[2 * elements[i].N3.Index, 2 * nodes.Count];
                elements[i].Sig[5, 0] = globalK[2 * elements[i].N3.Index + 1, 2 * nodes.Count];
            }

            for (int i = 0; i < elements.Count; i++)
                elements[i].SolveStress();

            MaxDeformationXAndY();
            if (maxStress > dopStress)
                labelStresOk.Text = "нет";
            else
                labelStresOk.Text = "да";
        }

        //Определение максимальных смещений и напряжения
        void MaxDeformationXAndY()
        {
            float maxX = globalK[0, 2 * nodes.Count];
            float maxY = globalK[1, 2 * nodes.Count];

            for (int i = 0; i < nodes.Count; i++)
            {
                if (globalK[i * 2, 2 * nodes.Count] > maxX)
                {
                    maxX = globalK[i * 2, 2 * nodes.Count];
                }
                if (globalK[i * 2 + 1, 2 * nodes.Count] > maxY)
                {
                    maxY = globalK[i * 2 + 1, 2 * nodes.Count];
                }
            }

            maxStress = elements[0].S;
            for (int i = 0; i < elements.Count; i++)
                if (elements[i].S > maxStress)
                    maxStress = elements[i].S;

            labelMaxDeformationX.Text = maxX.ToString();
            labelMaxDeformationY.Text = maxY.ToString();
            labelStress.Text = maxStress.ToString();
            groupBoxResult.Visible = true;
            comboBox.Visible = true;
            gr.Clear(Color.Linen);
            Meshing(Color.Green);
        }

        //Отрисовка цветов
        private void DrawingDeformation()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                Point[] points = new Point[3];
                points[0] = new Point(Convert.ToInt32((elements[i].N1.X + elements[i].Sig[0, 0] * 400f) * delta), -Convert.ToInt32((elements[i].N1.Y + elements[i].Sig[1, 0] * 400f) * delta));
                points[1] = new Point(Convert.ToInt32((elements[i].N2.X + elements[i].Sig[2, 0] * 400f) * delta), -Convert.ToInt32((elements[i].N2.Y + elements[i].Sig[3, 0] * 400f) * delta));
                points[2] = new Point(Convert.ToInt32((elements[i].N3.X + elements[i].Sig[4, 0] * 400f) * delta), -Convert.ToInt32((elements[i].N3.Y + elements[i].Sig[5, 0] * 400f) * delta));
                gr.FillPolygon(elements[i].ColorElement, points);

                Pen p = new Pen(Color.Black, 1);
                gr.DrawLine(p, (elements[i].N1.X + elements[i].Sig[0, 0] * 400f) * delta, -(elements[i].N1.Y + elements[i].Sig[1, 0] * 400f) * delta, (elements[i].N2.X + elements[i].Sig[2, 0] * 400f) * delta, -(elements[i].N2.Y + elements[i].Sig[3, 0] * 400f) * delta);
                gr.DrawLine(p, (elements[i].N2.X + elements[i].Sig[2, 0] * 400f) * delta, -(elements[i].N2.Y + elements[i].Sig[3, 0] * 400f) * delta, (elements[i].N3.X + elements[i].Sig[4, 0] * 400f) * delta, -(elements[i].N3.Y + elements[i].Sig[5, 0] * 400f) * delta);
                gr.DrawLine(p, (elements[i].N3.X + elements[i].Sig[4, 0] * 400f) * delta, -(elements[i].N3.Y + elements[i].Sig[5, 0] * 400f) * delta, (elements[i].N1.X + elements[i].Sig[0, 0] * 400f) * delta, -(elements[i].N1.Y + elements[i].Sig[1, 0] * 400f) * delta);
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
                Deformation();
            else if (comboBox.SelectedIndex == 1)
                DeformationX();
            else if (comboBox.SelectedIndex == 2)
                DeformationY();
            else if (comboBox.SelectedIndex == 3)
                Stress();
        }

        //Отрисовка деформированной детали
        void Deformation()
        {
            gr.Clear(Color.Linen);
            Pen p = new Pen(Color.Blue, 1);
            for (int i = 0; i < elements.Count; i++)
            {
                gr.DrawLine(p, (elements[i].N1.X + elements[i].Sig[0, 0] * 400f) * delta, -(elements[i].N1.Y + elements[i].Sig[1, 0] * 400f) * delta, (elements[i].N2.X + elements[i].Sig[2, 0] * 400f) * delta, -(elements[i].N2.Y + elements[i].Sig[3, 0] * 400f) * delta);
                gr.DrawLine(p, (elements[i].N2.X + elements[i].Sig[2, 0] * 400f) * delta, -(elements[i].N2.Y + elements[i].Sig[3, 0] * 400f) * delta, (elements[i].N3.X + elements[i].Sig[4, 0] * 400f) * delta, -(elements[i].N3.Y + elements[i].Sig[5, 0] * 400f) * delta);
                gr.DrawLine(p, (elements[i].N3.X + elements[i].Sig[4, 0] * 400f) * delta, -(elements[i].N3.Y + elements[i].Sig[5, 0] * 400f) * delta, (elements[i].N1.X + elements[i].Sig[0, 0] * 400f) * delta, -(elements[i].N1.Y + elements[i].Sig[1, 0] * 400f) * delta);
            }
        }

        //Отрисовка смещения по оси Х
        void DeformationX()
        {
            gr.Clear(Color.Linen);
            float[] maxmin = new float[elements.Count];
            for (int i = 0; i < elements.Count; i++)
                maxmin[i] = Math.Abs(globalK[2 * elements[i].N1.Index, 2 * nodes.Count]) + Math.Abs(globalK[2 * elements[i].N2.Index, 2 * nodes.Count]) + Math.Abs(globalK[2 * elements[i].N3.Index, 2 * nodes.Count]);

            float maxX = maxmin[0];
            float minX = maxmin[0];

            for (int i = 0; i < maxmin.Length; i++)
            {
                if (maxmin[i] > maxX)
                    maxX = maxmin[i];

                if (maxmin[i] < minX)
                    minX = maxmin[i];
            }

            float dX = (maxX - minX) / 9;

            for (int i = 0; i < elements.Count; i++)
            {
                float sumX = Math.Abs(globalK[2 * elements[i].N1.Index, 2 * nodes.Count]) + Math.Abs(globalK[2 * elements[i].N2.Index, 2 * nodes.Count]) + Math.Abs(globalK[2 * elements[i].N3.Index, 2 * nodes.Count]);
                if (sumX >= minX && sumX < minX + dX)
                    elements[i].ColorElement = c1;
                else if (sumX >= minX + dX && sumX < minX + 2 * dX)
                    elements[i].ColorElement = c2;
                else if (sumX >= minX + 2 * dX && sumX < minX + 3 * dX)
                    elements[i].ColorElement = c3;
                else if (sumX >= minX + 3 * dX && sumX < minX + 4 * dX)
                    elements[i].ColorElement = c4;
                else if (sumX >= minX + 4 * dX && sumX < minX + 5 * dX)
                    elements[i].ColorElement = c5;
                else if (sumX >= minX + 5 * dX && sumX < minX + 6 * dX)
                    elements[i].ColorElement = c6;
                else if (sumX >= minX + 6 * dX && sumX < minX + 7 * dX)
                    elements[i].ColorElement = c7;
                else if (sumX >= minX + 7 * dX && sumX < minX + 8 * dX)
                    elements[i].ColorElement = c8;
                else if (sumX >= minX + 8 * dX && sumX <= maxX)
                    elements[i].ColorElement = c9;
            }

            DrawingDeformation();
        }

        //Отрисовка смещения по оси Y
        void DeformationY()
        {
            gr.Clear(Color.Linen);
            float[] maxmin = new float[elements.Count];
            for (int i = 0; i < elements.Count; i++)
                maxmin[i] = Math.Abs(globalK[2 * elements[i].N1.Index + 1, 2 * nodes.Count]) + Math.Abs(globalK[2 * elements[i].N2.Index + 1, 2 * nodes.Count]) + Math.Abs(globalK[2 * elements[i].N3.Index + 1, 2 * nodes.Count]);

            float maxY = maxmin[0];
            float minY = maxmin[0];

            for (int i = 0; i < maxmin.Length; i++)
            {
                if (maxmin[i] > maxY)
                    maxY = maxmin[i];

                if (maxmin[i] < minY)
                    minY = maxmin[i];
            }

            float dX = (maxY - minY) / 9;

            for (int i = 0; i < elements.Count; i++)
            {
                float sumX = Math.Abs(globalK[2 * elements[i].N1.Index + 1, 2 * nodes.Count]) + Math.Abs(globalK[2 * elements[i].N2.Index + 1, 2 * nodes.Count]) + Math.Abs(globalK[2 * elements[i].N3.Index + 1, 2 * nodes.Count]);
                if (sumX >= minY && sumX < minY + dX)
                    elements[i].ColorElement = c1;
                else if (sumX >= minY + dX && sumX < minY + 2 * dX)
                    elements[i].ColorElement = c2;
                else if (sumX >= minY + 2 * dX && sumX < minY + 3 * dX)
                    elements[i].ColorElement = c3;
                else if (sumX >= minY + 3 * dX && sumX < minY + 4 * dX)
                    elements[i].ColorElement = c4;
                else if (sumX >= minY + 4 * dX && sumX < minY + 5 * dX)
                    elements[i].ColorElement = c5;
                else if (sumX >= minY + 5 * dX && sumX < minY + 6 * dX)
                    elements[i].ColorElement = c6;
                else if (sumX >= minY + 6 * dX && sumX < minY + 7 * dX)
                    elements[i].ColorElement = c7;
                else if (sumX >= minY + 7 * dX && sumX < minY + 8 * dX)
                    elements[i].ColorElement = c8;
                else if (sumX >= minY + 8 * dX && sumX <= maxY)
                    elements[i].ColorElement = c9;
            }

            DrawingDeformation();
        }

        //Отрисовка напряжения
        void Stress()
        {
            gr.Clear(Color.Linen);
            float[] maxmin = new float[elements.Count];
            for (int i = 0; i < elements.Count; i++)
                maxmin[i] = elements[i].S;

            float maxS = maxmin[0];
            float minS = maxmin[0];

            for (int i = 0; i < maxmin.Length; i++)
            {
                if (maxmin[i] > maxS)
                    maxS = maxmin[i];

                if (maxmin[i] < minS)
                    minS = maxmin[i];
            }

            float dX = (maxS - minS) / 9;

            for (int i = 0; i < elements.Count; i++)
            {
                float sumX = elements[i].S;
                if (sumX >= minS && sumX < minS + dX)
                    elements[i].ColorElement = c1;
                else if (sumX >= minS + dX && sumX < minS + 2 * dX)
                    elements[i].ColorElement = c2;
                else if (sumX >= minS + 2 * dX && sumX < minS + 3 * dX)
                    elements[i].ColorElement = c3;
                else if (sumX >= minS + 3 * dX && sumX < minS + 4 * dX)
                    elements[i].ColorElement = c4;
                else if (sumX >= minS + 4 * dX && sumX < minS + 5 * dX)
                    elements[i].ColorElement = c5;
                else if (sumX >= minS + 5 * dX && sumX < minS + 6 * dX)
                    elements[i].ColorElement = c6;
                else if (sumX >= minS + 6 * dX && sumX < minS + 7 * dX)
                    elements[i].ColorElement = c7;
                else if (sumX >= minS + 7 * dX && sumX < minS + 8 * dX)
                    elements[i].ColorElement = c8;
                else if (sumX >= minS + 8 * dX && sumX <= maxS)
                    elements[i].ColorElement = c9;
            }
            DrawingDeformation();
        }
    }
}
