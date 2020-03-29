using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Discovery2016Qual_B
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
            int[][] ordered = new int[n][];
            for(int i = 0; i < n; i++)
            {
                ordered[i] = new int[2] { array[i], i };
            }
            ordered = ordered.OrderBy(a => a[0]).ToArray();

            Queue<int[]> que = new Queue<int[]>();
            for(int i = 0; i < n; i++)
            {
                que.Enqueue(ordered[i]);
            }

            int res = 0;
            int now = n;
            while (que.Count > 0)
            {
                int tmp = que.Peek()[0];
                int next = que.Dequeue()[1];
                if (next < now)
                {
                    res++;
                }

                if (next < now)
                {
                    while (que.Count > 0 &&
                    tmp == que.Peek()[0] &&
                    now > que.Peek()[1])
                    {
                        next = que.Dequeue()[1];
                    }

                    while (que.Count > 0 &&
                        tmp == que.Peek()[0])
                    {
                        que.Dequeue();
                    }
                }
                else
                {
                    while(que.Count>0 &&
                        tmp == que.Peek()[0])
                    {
                        next = que.Dequeue()[1];
                    }
                }

                now = next;
            }

            if (now == 0)
            {
                WriteLine(res - 1);
            }
            else
            {
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
