using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AtTest.C_Challenge
{
    class ABC_074
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] vals = ReadInts();
            float density = 0;
            int grams = vals[0] * 100, sugars = 0;
            for (int i = 1; i <= vals[5]/100; i++)
            {
                int xTemp = -1, yTemp = -1;
                //Ax+By=iになるか判定
                for (int j = 0; j * vals[0] <= i; j++)
                {
                    if ((i - j * vals[0]) % vals[1] == 0)
                    {
                        xTemp = j;
                        yTemp = (i - j * vals[0]) / vals[1];
                        break;
                    }
                }
                if (xTemp == -1) continue;

                //最大の砂糖の量を計算
                int limit = i * vals[4];
                if (limit > vals[5] - i * 100)
                {
                    limit = vals[5] - i * 100;
                }
                int maxSugars = 0;
                int pTemp = 0, qTemp =0;
                for(int j = 0; j * vals[2] <= limit; j++)
                {
                    int sugarsTemp
                        = vals[2] * j
                        + (limit - j * vals[2]) / vals[3] * vals[3];
                    if (sugarsTemp > maxSugars)
                    {
                        pTemp = j;
                        qTemp = (limit - j * vals[2]) / vals[3];
                        maxSugars = sugarsTemp;
                    }
                }

                int gramsTemp = (vals[0] * xTemp + vals[1] * yTemp) * 100
                    + maxSugars;
                float densityTemp = 100.0f
                    * maxSugars / gramsTemp;
                if (densityTemp > density)
                {
                    sugars = maxSugars;
                    grams = gramsTemp;
                    density = densityTemp;
                }
            }
            /*Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(p);
            Console.WriteLine(q);
            Console.WriteLine(density);*/
            Console.Write(grams);
            Console.Write(" ");
            Console.Write(sugars);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
