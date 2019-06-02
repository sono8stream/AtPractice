using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Msolutions2019
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            HashSet<int>[] graph = new HashSet<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new HashSet<int>();
            for(int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                graph[ab[0] - 1].Add(ab[1] - 1);
                graph[ab[1] - 1].Add(ab[0] - 1);
            }
            long[] cs = ReadLongs();
            Array.Sort(cs);
            int now = 0;
            long score = 0;
            Queue<int> queue = new Queue<int>();
            for(int i = 0; i < n; i++)
            {
                if (graph[i].Count == 1) queue.Enqueue(i);
            }
            long[] point = new long[n];
            for (int i = 0; i < n; i++) point[i] = -1;
            while (queue.Count > 0)
            {
                int val = queue.Dequeue();
                if (point[val]>=0) continue;

                if(now<n-1) score += cs[now];
                point[val] = cs[now];
                now++;
                if (now == n) break;

                foreach(int i in graph[val])
                {
                    graph[i].Remove(val);
                    if (graph[i].Count == 1) queue.Enqueue(i);
                }
            }
            WriteLine(score);
            for(int i = 0; i < n; i++)
            {
                Write(point[i]);
                if (i < n - 1) Write(" ");
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
