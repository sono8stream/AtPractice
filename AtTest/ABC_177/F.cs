using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_177
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
            int[] hw = ReadInts();
            int h = hw[0];
            int w = hw[1];
            int[][] abs = new int[h][];
            for (int i = 0; i < h; i++)
            {
                abs[i] = ReadInts();
                abs[i][0]--;
                abs[i][1]--;
            }

            // 始点を管理していく
            bool[] isHoles = new bool[w + 1];
            var tree = new LazySegmentTree2<int, int>(
                w + 1, (a, b) => b, (a, b) => b, (a, b) => Max(a, b), 0, 0);
            for (int i = 0; i <= w; i++)
            {
                tree.Update(i, i, i);
            }
            var que = new PriorityQueue<int>();
            for (int i = 0; i < w; i++)
            {
                que.Enqueue(0, i);
            }

            for (int i = 0; i < h; i++)
            {
                int max = tree.Scan(abs[i][0], abs[i][1] + 1);
                tree.Update(abs[i][1] + 1, abs[i][1] + 1, max);
                tree.Update(abs[i][0], abs[i][1], -1);
                if (max < w && max >= 0)
                {
                    que.Enqueue(abs[i][1] + 1 - max, max);
                }

                while (que.Count > 0)
                {
                    var pair = que.Top();
                    int now = (int)pair.Key + pair.Value;
                    if (tree.Scan(now, now) == pair.Value)
                    {
                        break;
                    }
                    que.Dequeue();
                }

                if (que.Count == 0)
                {
                    WriteLine(-1);
                }
                else
                {
                    WriteLine(que.Top().Key + i + 1);
                }
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
            Func<T, U, T> project;
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
            public LazySegmentTree2(int length, Func<U, U, U> evaluate, Func<T, U, T> project,
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
                    valTree[i + totalLength - 1] = project(valTree[i + totalLength - 1], initValue);
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
                    valTree[i] = project(valTree[i], lazyTree[i]);
                    while (i > 0)
                    {
                        i = (i - 1) / 2;
                        valTree[i] = integrate(valTree[i * 2 + 1], valTree[i * 2 + 2]);
                    }
                }
                else
                {
                    EvaluateLazy(i);

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
                    EvaluateLazy(i);

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

            void EvaluateLazy(int i)
            {
                if (i * 2 + 2 < lazyTree.Length && haveLazy[i])
                {
                    haveLazy[i * 2 + 1] = true;
                    lazyTree[i * 2 + 1] = evaluate(lazyTree[i * 2 + 1], lazyTree[i]);
                    valTree[i * 2 + 1] = project(valTree[i * 2 + 1], lazyTree[i * 2 + 1]);

                    haveLazy[i * 2 + 2] = true;
                    lazyTree[i * 2 + 2] = evaluate(lazyTree[i * 2 + 2], lazyTree[i]);
                    valTree[i * 2 + 2] = project(valTree[i * 2 + 2], lazyTree[i * 2 + 2]);

                    haveLazy[i] = false;
                }
            }
        }

        class PriorityQueue<T>
        {
            private readonly List<KeyValuePair<long, T>> list;

            public int Count { get; private set; }

            public PriorityQueue()
            {
                list = new List<KeyValuePair<long, T>>();
                Count = 0;
            }

            private void Add(KeyValuePair<long, T> pair)
            {
                if (Count == list.Count)
                {
                    list.Add(pair);
                }
                else
                {
                    list[Count] = pair;
                }
                Count++;
            }

            private void Swap(int a, int b)
            {
                KeyValuePair<long, T> tmp = list[a];
                list[a] = list[b];
                list[b] = tmp;
            }

            public void Enqueue(long key, T value)
            {
                Add(new KeyValuePair<long, T>(key, value));
                int c = Count - 1;
                while (c > 0)
                {
                    int p = (c - 1) / 2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    c = p;
                }
            }

            public KeyValuePair<long, T> Top()
            {
                return list[0];
            }

            public KeyValuePair<long, T> Dequeue()
            {
                KeyValuePair<long, T> pair = list[0];
                Count--;
                if (Count == 0) return pair;

                list[0] = list[Count];
                int p = 0;
                while (true)
                {
                    int c1 = p * 2 + 1;
                    int c2 = p * 2 + 2;
                    if (c1 >= Count) break;

                    int c = (c2 >= Count || list[c1].Key < list[c2].Key)
                        ? c1 : c2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    p = c;
                }
                return pair;
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
