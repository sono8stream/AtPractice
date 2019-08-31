using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TTPC2019
{
    class B
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
            string[] ss = new string[n];
            for(int i = 0; i < n; i++)
            {
                ss[i] = Read();
            }
            for(int i = 0; i < n; i++)
            {
                int okyo = 100;
                int ech = -1;
                for(int j = 0; j < ss[i].Length; j++)
                {
                    if (j <= ss[i].Length - 4 && ss[i].Substring(j, 4) == "okyo")
                    {
                        okyo = Min(okyo, j);
                    }
                    if (j <= ss[i].Length - 3 && ss[i].Substring(j, 3) == "ech")
                    {
                        ech = Max(ech, j);
                    }
                }
                if (okyo<ech)
                {
                    WriteLine("Yes");
                }
                else
                {
                    WriteLine("No");
                }
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
