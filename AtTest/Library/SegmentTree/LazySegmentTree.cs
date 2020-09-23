using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.SegmentTree
{
    class ABC179_F
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
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];

            var hors = new LazySegmentTree<int>(n, Min, n - 2, int.MaxValue / 2);
            var vers = new LazySegmentTree<int>(n, Min, n - 2, int.MaxValue / 2);

            long res = (long)(n - 2) * (n - 2);
            for (int i = 0; i < q; i++)
            {
                int[] query = ReadInts();
                int l = query[0];
                int r = query[1];

                if (l == 1)
                {
                    int len = vers.Look(r - 2);
                    if (len > 0)
                    {
                        hors.Update(0, len - 1, r - 2);
                        res -= len;
                    }
                }
                if (l == 2)
                {
                    int len = hors.Look(r - 2);
                    if (len > 0)
                    {
                        vers.Update(0, len - 1, r - 2);
                        res -= len;
                    }
                }
            }

            WriteLine(res);
        }

        class LazySegmentTree<T>
        {
            int totalLength;
            T[] tree;
            Func<T, T, T> evaluate;

            /// <summary>
            /// 要素数lengthの遅延セグ木
            /// </summary>
            /// <param name="length"></param>
            /// <param name="evaluate">比較関数</param>
            /// <param name="initialValue">初期値</param>
            /// <param name="exValue">例外値</param>
            public LazySegmentTree(int length, Func<T, T, T> evaluate, T initialValue, T exValue)
            {
                totalLength = 1;
                while (totalLength < length)
                {
                    totalLength *= 2;
                }

                this.evaluate = evaluate;

                tree = new T[totalLength * 2 - 1];
                for (int i = 0; i < tree.Length; i++)
                {
                    tree[i] = exValue;
                }
                for (int i = 0; i < length; i++)
                {
                    tree[i + totalLength - 1] = initialValue;
                }
            }

            /// <summary>
            /// [left, right]をvalで更新
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <param name="val"></param>
            public void Update(int left, int right, T val)
            {
                if (left >= totalLength || right < 0 || right < left)
                {
                    return;
                }

                Query(left, right, 0, 0, totalLength - 1, val);
            }

            /// <summary>
            /// [left, right]が[top,last]と一致していればvalで更新，そうでなければ分割して評価
            /// 再帰処理
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <param name="i"></param>
            /// <param name="top"></param>
            /// <param name="last"></param>
            /// <param name="val"></param>
            void Query(int left, int right, int i, int top, int last, T val)
            {
                if (left == top && right == last)
                {
                    tree[i] = evaluate(tree[i], val);
                }
                else
                {
                    int half = (top + last) / 2;
                    if (left <= half)
                    {
                        Query(left, Min(right, half), i * 2 + 1, top, half, val);
                    }
                    if (right >= half + 1)
                    {
                        Query(Max(left, half + 1), right, i * 2 + 2, half + 1, last, val);
                    }
                }
            }

            public T Look(int i)
            {
                int now = i + totalLength - 1;
                T val = tree[now];

                while (now > 0)
                {
                    now = (now - 1) / 2;
                    val = evaluate(val, tree[now]);
                }

                return val;
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