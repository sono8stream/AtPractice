using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1136
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
            int[] kArray = ReadInts();

            long[] deltas = new long[n];
            long[] deltaSums = new long[n];
            for (int i = 1; i < n; i++)
            {
                deltas[i] = kArray[i - 1];
                deltaSums[i] = deltaSums[i - 1] + deltas[i];
            }

            // val, left
            var tree = new LazySegmentTree2<long, long[]>(n, (a, b) => b,
                (a, b, l, r) =>
                {
                    long baseVal = b[0] + deltaSums[l] - deltaSums[b[1]];
                    long res = baseVal * (r - l + 1) + deltaSums[r];
                    if (l > b[1])
                    {
                        res -= deltaSums[l - 1];
                    }
                    else
                    {
                        res -= deltaSums[l];
                    }
                    return res;
                }, (a, b) => a + b, new long[2] { 0, 0 }, 0);
            for (int i = 0; i < n; i++)
            {
                tree.Update(i, i, new long[2] { array[i], i });
            }

            int q = ReadInt();
            for(int i = 0; i < q; i++)
            {
                string[] line = Read().Split();
                if (line[0][0] == 's')
                {
                    int l = int.Parse(line[1]) - 1;
                    int r = int.Parse(line[2]) - 1;
                    WriteLine(tree.Scan(l, r));
                }
                else
                {
                    int ii = int.Parse(line[1]) - 1;
                    int x = int.Parse(line[2]);
                    long now = tree.Scan(ii, ii) + x;
                    int bottom = ii;
                    int top = n;
                    while (bottom + 1 < top)
                    {
                        int mid = (bottom + top) / 2;
                        long val = tree.Scan(mid, mid);
                        long target = now + deltaSums[mid] - deltaSums[ii];
                        if (val <= target)
                        {
                            bottom = mid;
                        }
                        else
                        {
                            top = mid;
                        }
                    }

                    tree.Update(ii, bottom, new long[2] { now, ii });
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

        class LazySegmentTree2<T, U>
        {
            int totalLength;
            T[] valTree;
            U[] lazyTree;
            bool[] haveLazy;

            // lazyの更新
            Func<U, U, U> evaluate;
            // lazyからvalへの投影
            Func<T, U, int, int, T> project;
            // valの結合
            Func<T, T, T> integrate;

            T exValue;

            /// <summary>
            /// 要素数lengthの遅延セグ木
            /// </summary>
            /// <param name="length"></param>
            /// <param name="evaluate">比較関数</param>
            /// <param name="project">投影関数</param>
            /// <param name="integrate">結合関数</param>
            /// <param name="initialValue">初期値</param>
            /// <param name="exValue">例外値</param>
            public LazySegmentTree2(int length, Func<U, U, U> evaluate, Func<T, U, int, int, T> project,
                Func<T, T, T> integrate, U initValue, T exValue)
            {
                totalLength = 1;
                while (totalLength < length)
                {
                    totalLength *= 2;
                }

                this.evaluate = evaluate;
                this.project = project;
                this.integrate = integrate;

                valTree = new T[totalLength * 2 - 1];
                lazyTree = new U[totalLength * 2 - 1];
                haveLazy = new bool[totalLength * 2 - 1];

                for (int i = 0; i < length; i++)
                {
                    valTree[i + totalLength - 1] = project(valTree[i + totalLength - 1], initValue, i, i);
                }

                for (int i = totalLength - 2; i >= 0; i--)
                {
                    valTree[i] = integrate(valTree[i * 2 + 1], valTree[i * 2 + 2]);
                }

                this.exValue = exValue;
            }

            /// <summary>
            /// [left, right]をvalで更新
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <param name="val"></param>
            public void Update(int left, int right, U val)
            {
                if (left < 0 || right >= totalLength || right < left)
                {
                    return;
                }

                UpdateQuery(left, right, 0, 0, totalLength - 1, val);
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
            void UpdateQuery(int left, int right, int i, int top, int last, U val)
            {
                if (left == top && right == last)
                {
                    haveLazy[i] = true;
                    lazyTree[i] = evaluate(lazyTree[i], val);
                    valTree[i] = project(valTree[i], lazyTree[i], left, right);
                    while (i > 0)
                    {
                        i = (i - 1) / 2;
                        valTree[i] = integrate(valTree[i * 2 + 1], valTree[i * 2 + 2]);
                    }
                }
                else
                {
                    EvaluateLazy(i, left, right);

                    int half = (top + last) / 2;
                    if (left <= half)
                    {
                        UpdateQuery(left, Min(right, half), i * 2 + 1, top, half, val);
                    }
                    if (right >= half + 1)
                    {
                        UpdateQuery(Max(left, half + 1), right, i * 2 + 2, half + 1, last, val);
                    }
                }
            }

            public T Scan(int left, int right)
            {
                if (left < 0 || right >= totalLength || right < left)
                {
                    return exValue;
                }

                return ScanQuery(left, right, 0, 0, totalLength - 1);
            }

            T ScanQuery(int left, int right, int i, int top, int last)
            {
                if (left == top && right == last)
                {
                    return valTree[i];
                }
                else
                {
                    EvaluateLazy(i, left, right);

                    int half = (top + last) / 2;
                    T leftVal = exValue;
                    T rightVal = exValue;

                    if (right <= half)
                    {
                        return ScanQuery(left, right, i * 2 + 1, top, half);
                    }
                    if (left > half)
                    {
                        return ScanQuery(left, right, i * 2 + 2, half + 1, last);
                    }

                    return integrate(ScanQuery(left, half, i * 2 + 1, top, half),
                        ScanQuery(half + 1, right, i * 2 + 2, half + 1, last));
                }
            }

            void EvaluateLazy(int i, int left, int right)
            {
                if (i * 2 + 2 < lazyTree.Length && haveLazy[i])
                {
                    haveLazy[i * 2 + 1] = true;
                    lazyTree[i * 2 + 1] = evaluate(lazyTree[i * 2 + 1], lazyTree[i]);
                    valTree[i * 2 + 1] = project(valTree[i * 2 + 1], lazyTree[i * 2 + 1], left, right);

                    haveLazy[i * 2 + 2] = true;
                    lazyTree[i * 2 + 2] = evaluate(lazyTree[i * 2 + 2], lazyTree[i]);
                    valTree[i * 2 + 2] = project(valTree[i * 2 + 2], lazyTree[i * 2 + 2], left, right);

                    haveLazy[i] = false;
                }
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
