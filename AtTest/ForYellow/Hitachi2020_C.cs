using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Hitachi2020_C
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
            List<int>[] graph = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            for(int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }

            int[] colors = new int[n];
            int reds = 0;
            int blues = 0;
            Queue<int[]> que = new Queue<int[]>();
            que.Enqueue(new int[3] { 0, 1, -1 });
            while (que.Count > 0)
            {
                int[] val = que.Dequeue();
                int idx = val[0];
                int color = val[1];
                int par = val[2];

                colors[idx] = color;
                if (color == 1)
                {
                    reds++;
                }
                else
                {
                    blues++;
                }

                for (int i = 0; i < graph[idx].Count; i++){
                    int to = graph[idx][i];
                    if (to == par)
                    {
                        continue;
                    }

                    que.Enqueue(new int[3] { to, color == 1 ? 2 : 1, idx });
                }
            }

            int[] res = new int[n];
            int[] numbers = new int[3] { 3, 1, 2 };
            if (reds <= n / 3)
            {
                for (int i = 0; i < n; i++)
                {
                    if (colors[i] == 1)
                    {
                        res[i] = numbers[0];
                        numbers[0] += 3;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (colors[i] == 2)
                    {
                        if (numbers[0] <= n)
                        {
                            res[i] = numbers[0];
                            numbers[0] += 3;
                        }
                        else if (numbers[1] <= n)
                        {
                            res[i] = numbers[1];
                            numbers[1] += 3;
                        }
                        else
                        {
                            res[i] = numbers[2];
                            numbers[2] += 3;
                        }
                    }
                }
            }
            else if (blues <= n / 3)
            {
                for (int i = 0; i < n; i++)
                {
                    if (colors[i] == 2)
                    {
                        res[i] = numbers[0];
                        numbers[0] += 3;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (colors[i] == 1)
                    {
                        if (numbers[0] <= n)
                        {
                            res[i] = numbers[0];
                            numbers[0] += 3;
                        }
                        else if (numbers[1] <= n)
                        {
                            res[i] = numbers[1];
                            numbers[1] += 3;
                        }
                        else
                        {
                            res[i] = numbers[2];
                            numbers[2] += 3;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (numbers[colors[i]] <= n)
                    {
                        res[i] = numbers[colors[i]];
                        numbers[colors[i]] += 3;
                    }
                    else
                    {
                        res[i] = numbers[0];
                        numbers[0] += 3;
                    }
                }
            }

            WriteLine(string.Join(" ", res));
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
