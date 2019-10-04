using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_29
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
            List<int[]> vals = new List<int[]>();
            for(int i = 1; i <= 150;i++)
            {
                for(int j = i+1; j <= 150;j++)
                {
                    int val = i * i + j * j;
                    vals.Add(new int[3] { val, i, j });
                }
            }
            vals = vals.OrderBy(a => a[1]).ToList();
            vals = vals.OrderBy(a => a[0]).ToList();
            while (true)
            {
                int[] hw = ReadInts();
                int h = hw[0];
                int w = hw[1];
                if (h == 0) break;
                int tar = h * h + w * w;
                for(int i = 0; i < vals.Count; i++)
                {
                    if ((tar == vals[i][0] && h < vals[i][1])
                        || tar < vals[i][0])
                    {
                        WriteLine(vals[i][1] + " " + vals[i][2]);
                        break;
                    }
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
