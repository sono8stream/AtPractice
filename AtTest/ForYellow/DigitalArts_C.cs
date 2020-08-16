using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class DigitalArts_C
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
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];

            HashSet<int>[] graph = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new HashSet<int>();
            }
            int[] res = new int[n];
            int[] charged = new int[n];

            for(int i = 0; i < m; i++)
            {
                string[] row = Read().Split();
                if (row[0][0] == 't')
                {
                    int idx = int.Parse(row[1]) - 1;
                    charged[idx]++;
                }
                if (row[0][0] == 'f')
                {
                    int a = int.Parse(row[1]) - 1;
                    int b = int.Parse(row[2]) - 1;
                    graph[a].Add(b);
                    graph[b].Add(a);
                    res[a] -= charged[b];
                    res[b] -= charged[a];
                }
                if (row[0][0] == 'u')
                {
                    int a = int.Parse(row[1]) - 1;
                    int b = int.Parse(row[2]) - 1;
                    graph[a].Remove(b);
                    graph[b].Remove(a);
                    res[a] += charged[b];
                    res[b] += charged[a];
                }
            }

            for(int i = 0; i < n; i++)
            {
                res[i] += charged[i];
                foreach(int to in graph[i])
                {
                    res[i] += charged[to];
                }
            }

            Array.Sort(res);
            Array.Reverse(res);
            WriteLine(res[k - 1]);
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
