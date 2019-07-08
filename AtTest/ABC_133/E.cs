using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_133
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            long n = nk[0];
            long k = nk[1];

            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new List<int>();
            for(int i = 0; i < n-1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0]-1;
                int b = ab[1]-1;
                graph[a].Add(b);
                graph[b].Add(a);
            }

            long mask = 1000000000 + 7;
            Queue<long[]> que = new Queue<long[]>();
            que.Enqueue(new long[2] { 0, -1 });
            long[] vals = new long[n];
            for (int i = 0; i < n; i++) vals[i] = 0;
            vals[0] = k;
            while (que.Count > 0)
            {
                long[] val = que.Dequeue();
                long index = val[0];
                long parent = val[1];
                long cnt = parent >= 0 ? k - 2 : k - 1;
                for(int i = 0; i < graph[index].Count; i++)
                {
                    if (parent == graph[index][i]) continue;

                    vals[graph[index][i]] = cnt;
                    cnt--;
                    que.Enqueue(new long[2] { graph[index][i], index });
                }
            }

            long res = 1;
            for(int i = 0; i < n; i++)
            {
                res *= vals[i];
                res %= mask;
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
