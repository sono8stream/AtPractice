using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_110
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
            int n = ReadInt();
            int[] array = ReadInts();

            int[] poses = new int[n];
            for (int i = 0; i < n; i++)
            {
                poses[array[i] - 1] = i;
            }

            int now = 0;
            List<int> res = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int pos = poses[i];
                if (pos == i)
                {
                    continue;
                }

                if (i >= now)
                {
                    for (int j = pos; j > i; j--)
                    {
                        res.Add(j);
                        int other = array[j - 1];
                        array[j] = other;
                        poses[other - 1]++;
                    }
                    array[i] = i + 1;
                    poses[i] = i;
                    now = pos;
                }
                else
                {
                    WriteLine(-1);
                    return;
                }
            }

            if (res.Count == n - 1)
            {
                for (int i = 0; i < res.Count; i++)
                {
                    WriteLine(res[i]);
                }
            }
            else
            {
                WriteLine(-1);
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
