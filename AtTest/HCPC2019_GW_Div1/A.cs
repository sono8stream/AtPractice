using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_GW_Div1
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            List<int> res = new List<int>();
            while (true)
            {
                int n = ReadInt();
                if (n == 0) break;

                int[] array= ReadInts();
                Array.Sort(array);
                int delta = int.MaxValue;
                for (int i = 0; i < n - 1; i++)
                {
                    delta = Min(delta, array[i + 1] - array[i]);
                }
                res.Add(delta);
            }

            for (int i = 0; i < res.Count; i++) WriteLine(res[i]);
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
