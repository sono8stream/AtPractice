using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_Challenge
{
    class _008_D
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
            int[] xs = ReadInts();
            int[][] xIndexes = new int[n][];
            for(int i = 0; i < n; i++)
            {
                xIndexes[i] = new int[2] { xs[i] - 1, i + 1 };
            }
            Array.Sort(xIndexes, (a, b) => a[0] - b[0]);
            Queue<int> que = new Queue<int>();
            for(int i = 0; i < n; i++)
            {
                for(int j = 1; j < xIndexes[i][1]; j++)
                {
                    que.Enqueue(xIndexes[i][1]);
                }
            }
            int[] res = new int[n * n];
            int now = 0;
            int[] cnts = new int[n];
            for(int i = 0; i < n * n; i++)
            {
                if (now < n && i == xIndexes[now][0])
                {
                    if (cnts[xIndexes[now][1] - 1] == xIndexes[now][1] - 1)
                    {
                        res[i] = xIndexes[now][1];
                        cnts[xIndexes[now][1] - 1]++;
                        for (int j = xIndexes[now][1]; j < n; j++)
                        {
                            que.Enqueue(xIndexes[now][1]);
                        }
                        now++;
                    }
                    else
                    {
                        WriteLine("No");
                        return;
                    }
                }
                else
                {
                    if (que.Count > 0)
                    {
                        res[i] = que.Peek();
                        cnts[que.Dequeue() - 1]++;
                    }
                    else
                    {
                        WriteLine("No");
                        return;
                    }
                }
            }

            WriteLine("Yes");
            for(int i = 0; i < n*n; i++)
            {
                Write(res[i]+" ");
            }
            WriteLine();
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
