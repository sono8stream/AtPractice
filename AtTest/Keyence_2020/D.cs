using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Keyence_2020
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
            int n = ReadInt();
            int[] arrayA = ReadInts();
            int[] arrayB = ReadInts();

            int all = 1 << n;
            int res = int.MaxValue;
            for(int i = 0; i < all; i++)
            {
                bool[] useBlue = new bool[n];
                int[][] vals = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    if (((1 << j) & i) > 0)
                    {
                        useBlue[j] = true;
                    }
                    vals[j] = new int[2] { 0, j };
                    vals[j][0] = useBlue[j] ? arrayB[j] : arrayA[j];
                }
                vals = vals.OrderBy(a => a[0]).ToArray();
                Queue<int[]> que = new Queue<int[]>();
                for (int j = 0; j < n; j++) que.Enqueue(vals[j]);
                bool ok = true;
                int tmp = 0;
                int[][] inValues = new int[n][];
                for(int j = 0; j < n; j++)
                {
                    Queue<int[]> next = new Queue<int[]>();
                    while (que.Count > 0)
                    {
                        int[] val = que.Dequeue();
                        int index = val[1];
                        if (useBlue[index])
                        {
                            if (j % 2 == index % 2)
                            {
                                next.Enqueue(val);
                                continue;
                            }
                        }
                        else
                        {
                            if (j % 2 != index % 2)
                            {
                                next.Enqueue(val);
                                continue;
                            }
                        }
                        inValues[j] = val;
                        for (int k = 0; k < j; k++)
                        {
                            if (inValues[k][1] > index) tmp++;
                        }
                        break;
                    }
                    if (inValues[j] == null
                        || (next.Count > 0 && next.Peek()[0] < inValues[j][0]))
                    {
                        ok = false;
                        break;
                    }
                    if (next.Count > 0)
                    {
                        while (que.Count > 0)
                        {
                            next.Enqueue(que.Dequeue());
                        }
                        que = next;
                    }
                }
                if (ok)
                {
                    res = Min(res, tmp);
                }
            }
            if (res == int.MaxValue) WriteLine(-1);
            else WriteLine(res);
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
