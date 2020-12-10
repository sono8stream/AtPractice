using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1395
{
    class C
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] array = ReadInts();
            int[] bArray = ReadInts();

            var vals = new HashSet<int>();
            vals.Add(0);
            for(int i = 0; i < n; i++)
            {
                var next = new HashSet<int>();
                for(int j = 0; j < m; j++)
                {
                    int val = (array[i] & bArray[j]);
                    foreach(int prev in vals)
                    {
                        next.Add(prev | val);
                    }
                }
                vals = next;
            }

            int res = int.MaxValue;
            foreach(int val in vals)
            {
                res = Min(res, val);
            }

            WriteLine(res);
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
