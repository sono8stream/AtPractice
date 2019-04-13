using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC7
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nh = ReadInts();
            int n = nh[0];
            int h = nh[1];
            int[] hs = new int[n];
            for (int i = 0; i < n; i++) hs[i] = ReadInt();
            WriteLine(DFS(hs, h));
        }

        static long DFS(int[] remain, int h)
        {
            if (remain.Length == 1) return 1;
            int sum = 0;
            long val = 0;
            for (int i = 0; i < remain.Length; i++)
            {
                sum += remain[i];
                if (sum > h) break;

                int[] next = new int[remain.Length - 1];
                for (int j = 0; j < remain.Length; j++)
                {
                    if (j < i) next[j] = remain[j];
                    if (j == i) continue;
                    if (j > i) next[j - 1] = remain[j];
                }
                val += DFS(next, h);
            }
            return val;
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
