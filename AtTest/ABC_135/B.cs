using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_135
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
            int[] ps = ReadInts();
            int[] sorted = new int[n];
            for (int i = 0; i < n; i++) sorted[i] = ps[i];
            Array.Sort(sorted);
            for(int i = 0; i < n; i++)
            {
                for(int j = i; j < n; j++)
                {
                    int tmp = ps[i];
                    ps[i] = ps[j];
                    ps[j] = tmp;
                    int cnt = 0;
                    for(int k = 0; k < n; k++)
                    {
                        if (ps[k] == sorted[k]) cnt++;
                    }
                    if (cnt == n)
                    {
                        WriteLine("YES");
                        return;
                    }
                    ps[j] = ps[i];
                    ps[i] = tmp;
                }
            }

            WriteLine("NO");
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
