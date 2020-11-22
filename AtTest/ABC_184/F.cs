using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_184
{
    class F
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
            int[] nt = ReadInts();
            int n = nt[0];
            int t = nt[1];

            int[] array = ReadInts();
            if (n == 1)
            {
                WriteLine(array[0] <= t ? array[0] : 0);
                return;
            }

            int max = 0;
            HashSet<int> left = new HashSet<int>();
            left.Add(0);
            for(int i = 0; i < n / 2; i++)
            {
                HashSet<int> next = new HashSet<int>();
                foreach(int val in left)
                {
                    next.Add(val);
                    if (val + array[i] <= t)
                    {
                        next.Add(val + array[i]);
                        max = Max(max, val + array[i]);
                    }
                }
                left = next;
            }

            HashSet<int> right = new HashSet<int>();
            right.Add(0);
            for (int i = n/2; i < n; i++)
            {
                HashSet<int> next = new HashSet<int>();
                foreach (int val in right)
                {
                    next.Add(val);
                    if (val + array[i] <= t)
                    {
                        next.Add(val + array[i]);
                        max = Max(max, val + array[i]);
                    }
                }
                right = next;
            }

            int[] rights = new int[right.Count];
            int idx = 0;
            foreach (int val in right)
            {
                rights[idx] = val;
                idx++;
            }
            Array.Sort(rights);

            foreach(int val in left)
            {
                if (val + rights[0] > t)
                {
                    continue;
                }

                int bottom = 0;
                int top = right.Count;
                while (bottom + 1 < top)
                {
                    int mid = (bottom + top) / 2;
                    if (val + rights[mid] <= t)
                    {
                        bottom = mid;
                    }
                    else
                    {
                        top = mid;
                    }
                }

                max = Max(max, val + rights[bottom]);
            }

            WriteLine(max);
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
