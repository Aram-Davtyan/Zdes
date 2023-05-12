using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] mX = new double[3];        //x1,x2,x3
            double[,] mmD = new double[3, 3];   //койфиц. иксов
            double[] mS = new double[3];        //свободные члены
            double[] mP = new double[3];        //приближения
            double[] mPp = new double[3];       //пред. приближение 
            double[] mPog = new double[3];      //прогрешность 
            double Xf;                          //мин погрешность 
            bool flag = true;


            StreamReader fin = File.OpenText(@"D:\data.txt");


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                        mmD[i, j] = (int)fin.Read();

                }
            }


            for (int j = 0; j < 3; j++)
                {
                     mS[j]  = (int)fin.Read();
                }



            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("mP = " + mS[i] );
               
            }


      
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i != j)
                        mmD[i, j] *= -1;

                }
            }

            for (int i = 0; i < 3; i++)
            {
                mP[i] = mS[i] / mmD[i, i];
                mPp[i] = mP[i];
                Console.WriteLine("mP = " + mP[i]);
                Console.WriteLine("mPp = " + mPp[i]);
            }
            Console.WriteLine("");

            while (flag)
            {

                mP[0] = (mS[0] + (mPp[1] * mmD[0, 1]) + (mPp[2] * mmD[0, 2])) / mmD[0, 0];
                mP[1] = (mS[1] + (mP[0] * mmD[1, 0]) + (mPp[2] * mmD[1, 2])) / mmD[1, 1];
                mP[2] = (mS[2] + (mP[0] * mmD[2, 0]) + (mP[1] * mmD[2, 1])) / mmD[2, 2];


                for (int i = 0; i < 3; i++)           //считаю погрешность 
                {
                    mPog[i] = Math.Abs(mP[i] - mPp[i]) / Math.Abs(mP[i]);
                }

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("mPooog = " + mPog[i]);
                }

                for (int i = 0; i < 3; i++)
                {
                    mPp[i] = mP[i];
                }


                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("mP = " + mP[i]);
                    Console.WriteLine("mPp = " + mPp[i]);
                }

                if (mPog[0] < Xf && mPog[1] < Xf && mPog[2] < Xf)
                    flag = false;


                Console.WriteLine();
            }
        }
    }
}
