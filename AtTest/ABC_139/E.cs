using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_139
{
    class E
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
            int[][] others = new int[n][];
            for (int i = 0; i < n; i++) others[i] = ReadInts();
            int[] nows = new int[n];
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue((i + 1) * 10000 + others[i][0]);
            }
            var hashs = new HashSet<int>();
            int day = 0;
            while (queue.Count > 0)
            {
                day++;
                Queue<int> next = new Queue<int>();
                while (queue.Count > 0)
                {
                    int val = queue.Dequeue();
                    int me = val / 10000;
                    int other = val % 10000;
                    if (hashs.Contains(other * 10000 + me))
                    {
                        nows[me - 1]++;
                        nows[other - 1]++;
                        if (nows[me - 1] < n - 1)
                        {
                            next.Enqueue(
                                me * 10000 + others[me - 1][nows[me - 1]]);
                        }
                        if (nows[other - 1] < n - 1)
                        {
                            next.Enqueue(
                                other * 10000 + others[other - 1][nows[other - 1]]);
                        }
                        hashs.Remove(other * 10000 + me);
                    }
                    else
                    {
                        hashs.Add(val);
                    }
                }
                queue = next;
            }

            for(int i = 0; i < n; i++)
            {
                if (nows[i] < n-1)
                {
                    WriteLine(-1);
                    return;
                }
            }
            WriteLine(day);
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
