using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1437
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
            int[] ab = ReadInts();
            int a = ab[0];
            int b = ab[1];
            long[] array = ReadLongs();
            int[] bArray = new int[0];
            if (b > 0)
            {
                bArray = ReadInts();
                for(int i = 0; i < b; i++)
                {
                    bArray[i]--;
                }
            }

            // 不可能判定
            for (int i = 0; i + 1 < b; i++)
            {
                long left = array[bArray[i]];
                long right = array[bArray[i + 1]];
                int delta = bArray[i + 1] - bArray[i];
                if (right - left < delta)
                {
                    WriteLine(-1);
                    return;
                }
            }

            // b[i]を下回るような最長増加部分列を区間ごとに求める
            // 位置によって満たすべき値が異なる？
            long[] deltas = new long[a];
            long bottom = -10000000000;
            int now = 0;
            for (int i = 0; i < b; i++)
            {
                while (now <= bArray[i])
                {
                    bottom++;
                    deltas[now] = array[now] - bottom;
                    now++;
                }
                bottom = array[bArray[i]];
            }
            while (now < a)
            {
                bottom++;
                deltas[now] = array[now] - bottom;
                now++;
            }

            int res = 0;
            int li = 0;
            for(int i = 0; i < b; i++)
            {
                if (li< bArray[i])
                {
                    res += bArray[i] - li- GetLIS(deltas, li, bArray[i] - 1, deltas[bArray[i]]);
                }
                li = bArray[i] + 1;
            }
            if (li < a)
            {
                res += a - li - GetLIS(deltas, li, a - 1, long.MaxValue);
            }

            WriteLine(res);
        }

        static int GetLIS(long[] array, int left, int right, long max)
        {
            var list = new List<long>();
            for(int i = left; i <= right; i++)
            {
                if (array[i] < 0 || array[i] > max)
                {
                    continue;
                }

                if (list.Count == 0 || list[list.Count - 1] <= array[i])
                {
                    list.Add(array[i]);
                }
                else
                {
                    int bottom = -1;
                    int top = list.Count - 1;
                    while (bottom + 1 < top)
                    {
                        int mid = (bottom + top) / 2;
                        if (list[mid] > array[i])
                        {
                            top = mid;
                        }
                        else
                        {
                            bottom = mid;
                        }
                    }

                    list[top] = array[i];
                }
            }

            return list.Count;
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
