using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_186
{
    class F
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
            int[] hwm = ReadInts();
            int h = hwm[0];
            int w = hwm[1];
            int m = hwm[2];

            int[][] xys = new int[m][];
            for(int i = 0; i < m; i++)
            {
                xys[i] = ReadInts();
            }
            Array.Sort(xys, (a, b) => a[0] - b[0]);

            long[] vers = new long[w];
            List<int>[] hs = new List<int>[h];
            for(int i = 0; i < w; i++)
            {
                vers[i] = h - 1;
            }
            for(int i = 0; i < h; i++)
            {
                hs[i] = new List<int>();
            }
            for (int i = 0; i < m; i++)
            {
                int x = xys[i][0] - 1;
                int y = xys[i][1] - 1;
                if (vers[y] == h - 1)
                {
                    vers[y] = x - 1;
                }
                hs[x].Add(y);
            }

            long res = 0;
            int verRight = w - 1;
            for(int i = 0; i < w; i++)
            {
                if (vers[i] == -1)
                {
                    verRight = i - 1;
                    break;
                }

                res += vers[i] + 1;
            }

            var tree = new SegmentTree<int>(w, (a, b) => a + b, 1, 0);
            for(int i = 0; i <= vers[0]; i++)
            {
                int right = w-1;
                for(int j = 0; j < hs[i].Count; j++)
                {
                    right = Min(right, hs[i][j] - 1);
                    tree.Update(hs[i][j], 0);
                }
                if (i == 0)
                {
                    continue;
                }

                int cnt = tree.Scan(0, Min(verRight,right));
                res += right + 1 - cnt;
            }

            WriteLine(res);
        }

        class SegmentTree<T>
        {
            int totalLength;
            T[] tree;
            Func<T, T, T> integrate;
            T exValue;

            public SegmentTree(int length, Func<T, T, T> integrate, T initialValue, T exValue)
            {
                totalLength = 1;
                while (totalLength < length)
                {
                    totalLength *= 2;
                }

                this.integrate = integrate;

                tree = new T[totalLength * 2 - 1];
                for (int i = 0; i < tree.Length; i++)
                {
                    tree[i] = exValue;
                }
                for (int i = 0; i < length; i++)
                {
                    tree[i + totalLength - 1] = initialValue;
                }
                this.exValue = exValue;

                UpdateAll();
            }

            void UpdateAll()
            {
                for (int i = totalLength - 2; i >= 0; i--)
                {
                    tree[i] = integrate(tree[i * 2 + 1], tree[i * 2 + 2]);
                }
            }

            public void Update(int i, T value)
            {
                int now = i + totalLength - 1;
                tree[now] = value;
                while (now > 0)
                {
                    now = (now - 1) / 2;
                    tree[now] = integrate(tree[now * 2 + 1], tree[now * 2 + 2]);
                }
            }


            /// <summary>
            /// [left, right]を取得
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            public T Scan(int left, int right)
            {
                if (left >= totalLength || right < 0 || right < left)
                {
                    return exValue;
                }

                return Query(left, right, 0, 0, totalLength - 1);
            }

            /// <summary>
            /// [left, right]が[top,last]と一致していればその値を，そうでなければ統合して返す
            /// 再帰処理
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <param name="i"></param>
            /// <param name="top"></param>
            /// <param name="last"></param>
            T Query(int left, int right, int i, int top, int last)
            {
                if (left == top && right == last)
                {
                    return tree[i];
                }
                else
                {
                    int half = (top + last) / 2;
                    T val = exValue;
                    if (left <= half)
                    {
                        val = integrate(val, Query(left, Min(right, half), i * 2 + 1, top, half));
                    }
                    if (right >= half + 1)
                    {
                        val = integrate(val, Query(Max(left, half + 1), right, i * 2 + 2, half + 1, last));
                    }
                    return val;
                }
            }

            public T Look(int i)
            {
                return tree[i + totalLength - 1];
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
