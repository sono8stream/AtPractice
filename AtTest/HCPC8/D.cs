using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC8
{
    class D
    {
        static void Main(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            bool[] res = new bool[t];
            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                int[][] edges = new int[n * n][];
                int[,] dists = new int[n, n];
                for(int j = 0; j < n; j++)
                {
                    int[] distTemp = ReadInts();
                    for(int k = 0; k < n; k++)
                    {
                        if (distTemp[k] == -1) distTemp[k] = int.MaxValue;
                        edges[j * n + k] = new int[3] { j, k, distTemp[k] };
                        dists[j, k] = int.MaxValue;
                    }
                }
                Array.Sort(edges, (a, b) => a[2] - b[2]);
                bool ok = true;
                for (int j = 0; j < n * n; j++)
                {
                    int from = edges[j][0];
                    int to = edges[j][1];
                    if (from == to)
                    {
                        if (edges[j][2] != 0)
                        {
                            ok = false;
                            break;
                        }
                        dists[from, to] = 0;
                        continue;
                    }

                    for (int k = 0; k < n; k++)
                    {
                        if (dists[from, k] == int.MaxValue 
                            || dists[k, to] == int.MaxValue)
                        {
                            continue;
                        }

                        long nowDist = dists[from, k] + dists[k, to];
                        if (nowDist < edges[j][2])
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (!ok) break;
                    dists[from, to] = edges[j][2];
                }
                res[i] = ok;
            }
            for(int i = 0; i < t; i++)
            {
                WriteLine(res[i] ? "YES" : "NO");
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
