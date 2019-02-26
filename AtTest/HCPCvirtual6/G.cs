using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPCvirtual6
{
    class G
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[] array = new long[n - 1];
            long[] sumsL = new long[n - 1];
            for (int i = 0; i < n - 1; i++)
            {
                array[i] += ReadLong();
                sumsL[i] = array[i];
                if (i > 0)
                {
                    sumsL[i] += sumsL[i - 1];
                }
                if (sumsL[i] <= 0) sumsL[i] = 0;
            }
            long[] sumsR = new long[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                sumsR[i] = array[i];
                if (i < n - 2)
                {
                    sumsR[i] += sumsR[i + 1];
                }
                if (sumsR[i] <= 0) sumsR[i] = 0;
            }
            for(int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    WriteLine(sumsR[i]);
                }
                else if (i == n - 1)
                {
                    WriteLine(sumsL[i-1]);
                }
                else
                {
                    WriteLine(Max(sumsL[i - 1], sumsR[i]));
                }
            }
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
