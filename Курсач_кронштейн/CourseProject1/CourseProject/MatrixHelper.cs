using System.Collections.Generic;

namespace CourseProject
{
    static class MatrixHelper
    {
        //Произведение матриц
        static public float[,] MatrixMultiplication(float[,] a, float[,] b)
        {
            float[,] c = new float[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        c[i, j] = c[i, j] + a[i, k] * b[k, j];
                    }
                }
            }
            return (c);
        }

        //Транспонирование матрицы
        static public float[,] Transpose(float[,] a)
        {
            float[,] b = new float[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    b[j, i] = a[i, j];
            return (b);
        }

        //Произвадение матрицы на число
        static public float[,] MultiplicationMatrixAndNumber(float[,] a, float b)
        {
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = a[i, j] * b;
            return (a);
        }

        //Нахождение обратной матрицы с помощью метода Гаусса
        static public float[,] FindingTheInverseMatrix(float[,] a)
        {
            float[,] a_1 = new float[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < 6; i++)
                a_1[i, i] = 1;

            float variable;

            for (int i = 0; i < 6; i++)
            {
                if (a[i, i] == 0)
                {
                    int index = i + 1;
                    while (index < 6)
                    {
                        if (a[index, i] != 0)
                            break;
                        index++;
                    }

                    if (index != 6)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            a[i, j] = a[i, j] + a[index, j];
                            a[index, j] = a[i, j] - a[index, j];
                            a[i, j] = a[i, j] - a[index, j];


                            a_1[i, j] = a_1[i, j] + a_1[index, j];
                            a_1[index, j] = a_1[i, j] - a_1[index, j];
                            a_1[i, j] = a_1[i, j] - a_1[index, j];
                        }
                    }
                }

                variable = a[i, i];
                for (int j = 0; j < 6; j++)
                {
                    a[i, j] = a[i, j] / variable;
                    a_1[i, j] = a_1[i, j] / variable;
                }

                for (int j = 0; j < 6; j++)
                {
                    if (j != i)
                    {
                        variable = a[j, i];
                        if (variable != 0)
                            for (int k = 0; k < 6; k++)
                            {
                                a[j, k] = a[j, k] - variable * a[i, k];
                                a_1[j, k] = a_1[j, k] - variable * a_1[i, k];
                            }
                    }
                }
            }
            return (a_1);
        }

        //Решение СЛАУ методом Гаусса
        static public float[,] Gaus(List<Node> nodes, float[,] globalK)
        {
            float variable;
            for (int i = 0; i < nodes.Count * 2; i++)
            {
                if (globalK[i, i] == 0)
                {
                    int index = i + 1;
                    while (index < nodes.Count * 2)
                    {
                        if (globalK[index, i] != 0)
                            break;
                        index++;
                    }

                    if (index != nodes.Count * 2)
                    {
                        for (int j = i; j < nodes.Count * 2 + 1; j++)
                        {
                            globalK[i, j] = globalK[i, j] + globalK[index, j];
                            globalK[index, j] = globalK[i, j] - globalK[index, j];
                            globalK[i, j] = globalK[i, j] - globalK[index, j];
                        }
                    }
                }

                variable = globalK[i, i];
                for (int j = nodes.Count * 2; j >= i; j--)
                {
                    globalK[i, j] = globalK[i, j] / variable;
                }
                for (int j = i + 1; j < nodes.Count * 2; j++)
                {
                    variable = globalK[j, i];
                    if (variable != 0)
                        for (int k = nodes.Count * 2; k >= i; k--)
                            globalK[j, k] = globalK[j, k] - variable * globalK[i, k];
                }

            }

            for (int i = nodes.Count * 2 - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    globalK[j, nodes.Count * 2] -= globalK[j, i] * globalK[i, nodes.Count * 2];
                    globalK[j, i] = 0;
                }
            }

            return (globalK);
        }
    }
}
