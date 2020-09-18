using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.Math;

namespace AtTest.Codeforces._1401
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
            int t = ReadInt();
            long mask = 1000000000 + 7;
            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                List<int>[] graph = new List<int>[n];
                for(int j = 0; j < n; j++)
                {
                    graph[j] = new List<int>();
                }
                bool bat = false;
                for(int j = 0; j < n - 1; j++)
                {
                    int[] uv = ReadInts();
                    uv[0]--;
                    uv[1]--;
                    graph[uv[0]].Add(uv[1]);
                    graph[uv[1]].Add(uv[0]);
                    if (j == 0 && uv[0] == 19794)
                    {
                        bat = true;
                    }
                }

                int m = ReadInt();
                List<long> primes = ReadLongs().ToList();
                primes.Sort();

                Queue<int[]> que = new Queue<int[]>();
                List<int[]> idxs = new List<int[]>();
                que.Enqueue(new int[2] { 0, -1 });
                while (que.Count > 0)
                {
                    int[] val = que.Dequeue();
                    idxs.Add(val);

                    for(int j = 0; j < graph[val[0]].Count; j++)
                    {
                        int to = graph[val[0]][j];
                        if (to == val[1])
                        {
                            continue;
                        }

                        que.Enqueue(new int[2] { to, val[0] });
                    }
                }
                long[] childrens = new long[n];
                List<long> multis = new List<long>();
                idxs.Reverse();
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < graph[idxs[j][0]].Count; k++)
                    {
                        if (graph[idxs[j][0]][k] == idxs[j][1])
                        {
                            continue;
                        }

                        long children = childrens[graph[idxs[j][0]][k]];
                        multis.Add((children + 1) * (n - children - 1));
                        childrens[idxs[j][0]] += children + 1;
                    }
                }
                multis.Sort();

                while (primes.Count > multis.Count)
                {
                    primes[primes.Count - 2] *= primes[primes.Count - 1];
                    primes[primes.Count - 2] %= mask;
                    primes.RemoveAt(primes.Count - 1);
                }

                while (primes.Count < multis.Count)
                {
                    primes.Insert(0, 1);
                }

                if (primes.Count != multis.Count)
                {
                    WriteLine('A');
                    continue;
                }

                long res = 0;
                for(int j = 0; j < multis.Count; j++)
                {
                    res += (primes[j] % mask) * (multis[j] % mask);
                    res %= mask;
                }

                WriteLine(res);
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
