using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.SegmentTree
{
    class ARC033_C
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
            int q = ReadInt();
            SegmentTree<int> segTree = new SegmentTree<int>(200010, (a, b) => a + b, 0, 0);
            for (int i = 0; i < q; i++)
            {
                int[] tx = ReadInts();
                int t = tx[0];
                int x = tx[1];
                if (t == 1)
                {
                    segTree.Update(x, 1);
                }
                else
                {
                    int bottom = 0;
                    int top = 200010;
                    while (bottom + 1 < top)
                    {
                        int mid = (bottom + top) / 2;
                        if (segTree.Scan(1, mid) < x)
                        {
                            bottom = mid;
                        }
                        else
                        {
                            top = mid;
                        }
                    }
                    WriteLine(top);
                    segTree.Update(top, 0);
                }
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

            /// <summary>
            /// iにある値をvalueに書き換える
            /// </summary>
            /// <param name="i"></param>
            /// <param name="value"></param>
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
            /// 右左の違いを気にする
            /// </summary>
            /// <param name="left">配列中のScanしたい左端インデックス</param>
            /// <param name="right">配列中のScanしたい右端インデックス</param>
            /// <param name="i">現在見ているツリー中の要素のインデックス</param>
            /// <param name="top">現在見ているツリー中の要素がカバーする配列中の左端インデックス</param>
            /// <param name="last">現在見ているツリー中の要素がカバーする配列中の右端インデックス</param>
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

                    if (right <= half)
                    {
                        return Query(left, right, i * 2 + 1, top, half);
                    }
                    if (left > half)
                    {
                        return Query(left, right, i * 2 + 2, half + 1, last);
                    }

                    T leftNode = Query(left, half, i * 2 + 1, top, half);
                    T rightNode = Query(half + 1, right, i * 2 + 2, half + 1, last);
                    return integrate(leftNode, rightNode);
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