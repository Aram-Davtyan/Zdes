using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] a1 = {
                {7,-1,1,0,1,3},
                {14,1,1,1,1,2},
                {8,1,5,-1,1,-4}
                };

            double[,] a = new double[3, 9];
            double[] baz = { 6, 7, 8 };
            double[] CB = { 0, 5, 5, 4, 2, 0, -1, -1, -1 };
            double[] CBB = { 0, -1, -3, -2, 0, 2 };
            double[] Cb = { -1, -1, -1 };
            double[] Dj = new double[9];
            double[] Djj = new double[9];

            double OpEl;



            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    a[i, j] = a1[i, j];
                }
            }


            int f;
            for (int i = 0; i < 3; i++)
            {
                f = 0;
                for (int j = 6; j < 9; j++)
                {
                    if (i == f)
                        a[i, j] = 1;
                    else
                        a[i, j] = 0;


                    if (i == f)
                        a[i, j] = 1;
                    else
                        a[i, j] = 0;


                    if (i == f)
                        a[i, j] = 1;
                    else
                        a[i, j] = 0;

                    f++;
                }
            }


            Console.WriteLine(" ");

            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");



            for (int i = 0; i < 9; i++)
            {
                double sum1 = 0;
                double sum2 = 0;

                if (baz[0] == 6 || baz[0] == 7 || baz[0] == 8)
                {
                    sum2 += Cb[0] * a[0, i];
                }
                else
                {
                    sum1 += Cb[0] * a[0, i];
                }


                if (baz[1] == 6 || baz[1] == 7 || baz[1] == 8)
                {
                    sum2 += Cb[1] * a[1, i];
                }
                else
                {
                    sum1 += Cb[1] * a[1, i];
                }


                if (baz[2] == 6 || baz[2] == 7 || baz[2] == 8)
                {
                    sum2 += Cb[2] * a[2, i];
                }
                else
                {
                    sum1 += Cb[2] * a[2, i];
                }

                if (i >= 6)
                    sum2 -= CB[i];
                else
                    sum1 -= CB[i];

                Dj[i] = sum1;
                Djj[i] = sum2;

            }




            for (int j = 0; j < 9; j++)
            {
                Console.Write(Dj[j] + " ");
            }

            Console.WriteLine(" ");

            for (int j = 0; j < 9; j++)
            {
                Console.Write(Djj[j] + " ");
            }
            Console.WriteLine(" ");


            bool flag = true;
            while (flag)
            {
                double[] q = new double[3];
                double minDjj;
                int minJ, minI;

                minDjj = Djj[1];
                minJ = 1;
                for (int i = 1; i < 9; i++)
                {
                    if (Djj[i] < minDjj)
                    {
                        minDjj = Djj[i];
                        minJ = i;
                    }
                }
                Console.WriteLine(" ");
                Console.WriteLine(minDjj + " ");
                Console.WriteLine(minJ + " ");



                for (int i = 0; i < 3; i++)
                {
                    q[i] = a[i, 0] / a[i, minJ];
                }

                double minStolb;
                minStolb = 999999999999;
                minI = -1;
                for (int i = 0; i < 3; i++)
                {
                    if (q[i] < minStolb && a[i, minJ] > 0)
                    {
                        minStolb = q[i];
                        minI = i;
                    }

                }


                Console.WriteLine(" ");
                Console.WriteLine(minStolb + " ");
                Console.WriteLine(minI + " ");




                OpEl = a[minI, minJ];


                Console.WriteLine(" ");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(baz[i] + " ");
                }
                Console.WriteLine(" ");



                for (int i = 0; i < 9; i++)
                {
                    a[minI, i] /= OpEl;
                }

                Console.WriteLine(" ");
                Console.WriteLine(" ");



                double[,] ax = new double[3, 9];
                for (int i = 0; i < 3; i++)
                {

                    for (int j = 0; j < 9; j++)
                    {

                        ax[i, j] = a[i, j];
                    }
                }


                for (int i = 0; i < 3; i++)
                {

                    for (int j = 0; j < 9; j++)
                    {
                        if (i == minI)
                            continue;

                        a[i, j] = ax[i, j] - ax[minI, j] * ax[i, minJ];
                    }
                }

                baz[minI] = minJ;
                Cb[minI] = CB[minJ];

                for (int i = 0; i < 3; i++)
                {
                    Console.Write(baz[i] + " ");
                }
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(Cb[i] + " ");
                }

                Console.WriteLine(" ");

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write(a[i, j] + "                ");
                    }
                    Console.WriteLine(" ");
                }
                Console.WriteLine(" ");




                for (int i = 0; i < 9; i++)
                {
                    double sum1 = 0;
                    double sum2 = 0;

                    if (baz[0] == 6 || baz[0] == 7 || baz[0] == 8)
                    {
                        sum2 += Cb[0] * a[0, i];
                    }
                    else
                    {
                        sum1 += Cb[0] * a[0, i];
                    }


                    if (baz[1] == 6 || baz[1] == 7 || baz[1] == 8)
                    {
                        sum2 += Cb[1] * a[1, i];
                    }
                    else
                    {
                        sum1 += Cb[1] * a[1, i];
                    }


                    if (baz[2] == 6 || baz[2] == 7 || baz[2] == 8)
                    {
                        sum2 += Cb[2] * a[2, i];
                    }
                    else
                    {
                        sum1 += Cb[2] * a[2, i];
                    }

                    if (i >= 6)
                        sum2 -= CB[i];
                    else
                        sum1 -= CB[i];

                    Dj[i] = sum1;
                    Djj[i] = sum2;

                }



                for (int j = 0; j < 9; j++)
                {
                    Console.Write(Dj[j] + " ");
                }

                Console.WriteLine(" ");

                for (int j = 0; j < 9; j++)
                {
                    Console.Write(Djj[j] + " ");
                }
                Console.WriteLine(" ");
                Console.WriteLine(" ");

                double sum = 0;
                for (int i = 0; i < 3; i++)
                {
                    sum += baz[i];
                }
                if (sum <= 12)
                    flag = false;

            }
        }
        }
    }
