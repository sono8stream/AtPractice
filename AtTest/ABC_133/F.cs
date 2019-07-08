using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_133
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            List<Edge>[] graph = new List<Edge>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<Edge>();
            }
            for(int i = 0; i < n - 1; i++)
            {
                int[] abcd = ReadInts();
                int a = abcd[0] - 1;
                int b = abcd[1] - 1;
                int c = abcd[2];
                int d = abcd[3];
                graph[a].Add(new Edge(b, c, d));
                graph[b].Add(new Edge(a, c, d));
            }


        }

        struct Edge
        {
            public int to;
            public int color;
            public long length;
            public Edge(int t,int c, long l)
            {
                to = t;
                color = c;
                length = l;
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
