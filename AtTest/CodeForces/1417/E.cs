using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1417
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
            int[] array = ReadInts();

            long[] inverseDeltas = new long[35];
            long firstInverse = 0;
            // Create trie tree
            List<int[]> graph = new List<int[]>();
            List<int> childs = new List<int>();
            graph.Add(new int[2] { -1, -1 });
            childs.Add(0);
            for(int i = n - 1; i >= 0; i--)
            {
                int div = 1 << 30;
                int dig = 30;
                int now = 0;
                childs[now]++;
                while (dig >= 0)
                {
                    if ((div & array[i]) > 0)
                    {
                        if (graph[now][1] == -1)
                        {
                            graph[now][1] = graph.Count;
                            graph.Add(new int[2] { -1, -1 });
                            childs.Add(0);
                        }
                        childs[graph[now][1]]++;
                        inverseDeltas[dig] += childs[now] - childs[graph[now][1]];
                        firstInverse += childs[now] - childs[graph[now][1]];
                        now = graph[now][1];
                    }
                    else
                    {
                        if (graph[now][0] == -1)
                        {
                            graph[now][0] = graph.Count;
                            graph.Add(new int[2] { -1, -1 });
                            childs.Add(0);
                        }
                        childs[graph[now][0]]++;
                        inverseDeltas[dig] -= childs[now] - childs[graph[now][0]];
                        now = graph[now][0];
                    }

                    div >>= 1;
                    dig--;
                }
            }

            int val = 0;
            long cnt = firstInverse;
            int nowDiv = 1;
            for(int i = 0; i <= 30; i++)
            {
                if (inverseDeltas[i] > 0)
                {
                    cnt -= inverseDeltas[i];
                    val += nowDiv;
                }
                nowDiv *= 2;
            }

            WriteLine(cnt + " " + val);
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
