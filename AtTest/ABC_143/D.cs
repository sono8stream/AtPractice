using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_143
{
    class D
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
            int[] ls = ReadInts();
            Dictionary<int, long> sames = new Dictionary<int, long>();
            long[] cnts = new long[2000 + 1];
            for (int i = 0; i < n; i++)
            {
                cnts[ls[i]]++;
                if (!sames.ContainsKey(ls[i]))
                {
                    sames.Add(ls[i], 0);
                }
                sames[ls[i]]++;
            }
            for(int i = 1; i <= 2000; i++)
            {
                cnts[i] += cnts[i - 1];
            }
            Array.Sort(ls);
            long res = 0;
            for (int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    res += cnts[ls[i] + ls[j] - 1] - cnts[ls[j]];

                }
            }
            foreach (int key in sames.Keys)
            {
                if (sames[key] >= 2)
                {
                    res += sames[key] * (sames[key] - 1) / 2 * cnts[key - 1];
                }
                if (sames[key] >= 3)
                {
                    res += sames[key] * (sames[key] - 1) * (sames[key] - 2) / 6;
                }
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
