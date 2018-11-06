using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_113
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] ta = ReadInts();
            int tP = ta[0] * 1000;
            int aP = ta[1] * 1000;
            int[] hs = ReadInts();
            int resIndex = 0;
            int deltaMin = int.MaxValue;
            for(int i =0; i < n; i++)
            {
                int tTemp = tP - 6*hs[i];
                int deltaTemp = Math.Abs(aP - tTemp);
                if (deltaMin > deltaTemp)
                {
                    deltaMin = deltaTemp;
                    resIndex = i;
                }
            }
            Console.WriteLine(resIndex + 1);
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
