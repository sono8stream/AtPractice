using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC_047_C
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];

            var tree = new SegmentTree<int>(n + 1, (a, b) => a + b, 1, 0);

            long remain = 1;
            bool[] used = new bool[n + 1];
            for(int i = 0; i <= n-k; i++)
            {
                long now = 0;
                if (i < n-k)
                {
                    remain *= n - i;
                    if (remain % k == 0)
                    {
                        now = remain / k;
                        remain = k;
                    }
                    else
                    {
                        now = remain / k + 1;
                        remain %= k;
                    }
                }
                if (i == n - k)
                {
                    now = remain;
                }

                int bottom = 0;
                int top = n;
                while (bottom + 1 < top)
                {
                    int mid = (bottom + top) / 2;
                    int val = tree.Scan(1, mid);
                    if (val >= now)
                    {
                        top = mid;
                    }
                    else
                    {
                        bottom = mid;
                    }
                }
                used[top] = true;
                WriteLine(top);
                tree.Update(top, 0);
            }

            int last = n;
            for(int i = n - k + 1; i < n; i++)
            {
                while (used[last])
                {
                    last--;
                }
                WriteLine(last);
                used[last] = true;
            }
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
