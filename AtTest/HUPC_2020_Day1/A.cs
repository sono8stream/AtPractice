using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HUPC_2020_Day1
{
    class A
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[][] vals = new int[n][];
            for(int i = 0; i < n; i++)
            {
                vals[i] = ReadInts();
            }

            int original = vals[0][0];
            if (vals[0][1] == 0)
            {
                original += vals[0][0] / 10;
            }

            bool yes = false;
            for(int i = 1; i < n; i++)
            {
                int target = vals[i][0];
                if (vals[i][1] == 0)
                {
                    target += vals[i][0] / 10;
                }

                if (target < original)
                {
                    if (!yes)
                    {
                        WriteLine("Yes");
                        yes = true;
                    }

                    WriteLine(i + 1);
                }
            }
            if (!yes)
            {
                WriteLine("No");
            }
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
