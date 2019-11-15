using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Nikkei2019_2_qual
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[][] lrcs = new int[m][];
            for(int i = 0; i < m; i++)
            {
                lrcs[i] = ReadInts();
            }
            Array.Sort(lrcs, (a, b) =>
            {
                if (a[0] != b[0]) return a[0] - b[0];
                else
                {
                    if (a[2] != b[2]) return a[2] - b[2];
                    else return a[1] - b[1];
                }
            });
            LazySegtree<long, long> lazySegtree = new LazySegtree<long, long>(
                    n, Min, (x, y, len) => Min(x, y), Min, long.MaxValue);
            lazySegtree.Update(0, 0, 0);
            for(int i = 0; i < m; i++)
            {
                long dist = lazySegtree[lrcs[i][0] - 1, lrcs[i][1] - 1];
                if (dist == long.MaxValue) break;
                dist += lrcs[i][2];
                lazySegtree.Update(lrcs[i][0] - 1, lrcs[i][1] - 1, dist);
            }
            if (lazySegtree[n - 1, n - 1] == long.MaxValue)
            {
                WriteLine(-1);
            }
            else
            {
                WriteLine(lazySegtree[n - 1, n - 1]);
            }
        }


        class SegTree<T>
        {
            int totalLength;
            T[] tree;
            Func<T, T, T> integrate;
            T exValue;

            public SegTree(int length, Func<T, T, T> integrate, T exValue)
            {
                this.integrate = integrate;
                this.exValue = exValue;
                totalLength = 1;
                while (totalLength < length) totalLength *= 2;

                tree = new T[2 * totalLength - 1];
                for (int i = 0; i < tree.Length; i++) tree[i] = exValue;
            }

            public SegTree(int length, T initialValue,
                Func<T, T, T> integrate, T exValue)
                : this(length, integrate, exValue)
            {
                for (int i = 0; i < length; i++)
                {
                    tree[i + totalLength - 1] = initialValue;
                }
                UpdateAll();
            }

            public void AssignWithoutUpdate(int i, T value)
            {
                tree[i + totalLength - 1] = value;
            }

            public void Update(int i, T value)
            {
                int now = i + totalLength - 1;
                tree[now] = value;
                while (now > 0)
                {
                    now = (now - 1) / 2;
                    tree[now] = integrate(
                        tree[now * 2 + 1], tree[now * 2 + 2]);
                }
            }

            public void UpdateAll()
            {
                for (int i = totalLength - 2; i >= 0; i--)
                {
                    tree[i] = integrate(tree[i * 2 + 1], tree[i * 2 + 2]);
                }
            }

            public T Look(int i) { return tree[i + totalLength - 1]; }

            //[top,last)
            public T Scan(int top, int last)
            {
                return Query(top, last, 0, 0, totalLength);
            }

            T Query(int top, int last, int i, int left, int right)
            {
                if (right <= top || last <= left) return exValue;
                if (top <= left && right <= last) return tree[i];

                T leftValue = Query(top, last, i * 2 + 1,
                    left, (left + right) / 2);
                T rightValue = Query(top, last, (i + 1) * 2,
                    (left + right) / 2, right);

                return integrate(leftValue, rightValue);
            }
        }

        /// <OriginalAuthor>riantkb</OriginalAuthor>
        class LazySegtree<T, U>
        {
            readonly int n;
            T[] data;
            U[] lazy;
            readonly bool[] is_lazy;
            readonly Func<T, T, T> calc;
            readonly Func<T, U, int, T> apply;
            readonly Func<U, U, U> merge;
            readonly T ex_data;

            /// <summary>
            /// 遅延セグメントツリーの構築
            /// </summary>
            /// <param name="m">要素数</param>
            /// <param name="calc">要素のマージ</param>
            /// <param name="apply">要素に作用素を作用</param>
            /// <param name="merge">作用素のマージ</param>
            /// <param name="ex_data">単位元</param>
            public LazySegtree(int m, Func<T, T, T> calc, Func<T, U, int, T> apply, Func<U, U, U> merge, T ex_data)
            {
                this.calc = calc;
                this.apply = apply;
                this.merge = merge;
                this.ex_data = ex_data;
                n = 1;
                while (n < m) n <<= 1;
                data = new T[n * 2 - 1];
                lazy = new U[n * 2 - 1];
                is_lazy = new bool[n * 2 - 1];
                for (int i = 0; i < data.Length; i++) data[i] = ex_data;
            }
            public LazySegtree(int m, Func<T, T, T> calc, Func<T, U, int, T> apply, Func<U, U, U> merge, T ex_data, T ini) : this(m, calc, apply, merge, ex_data)
            {
                for (int i = 0; i < m; i++) data[i + n - 1] = ini;
                for (int i = n - 2; i >= 0; i--) data[i] = calc(data[i * 2 + 1], data[i * 2 + 2]);
            }
            public LazySegtree(int m, Func<T, T, T> calc, Func<T, U, int, T> apply, Func<U, U, U> merge, T ex_data, IList<T> ini) : this(m, calc, apply, merge, ex_data)
            {
                for (int i = 0; i < m; i++) data[i + n - 1] = ini[i];
                for (int i = n - 2; i >= 0; i--) data[i] = calc(data[i * 2 + 1], data[i * 2 + 2]);
            }
            void assign_lazy(int k, U x)
            {
                if (k >= lazy.Length) return;
                if (is_lazy[k]) lazy[k] = merge(lazy[k], x);
                else
                {
                    is_lazy[k] = true;
                    lazy[k] = x;
                }
            }
            void eval(int k, int len)
            {
                if (!is_lazy[k]) return;
                assign_lazy(k * 2 + 1, lazy[k]);
                assign_lazy(k * 2 + 2, lazy[k]);
                data[k] = apply(data[k], lazy[k], len);
                is_lazy[k] = false;
            }
            T update(int s, int t, U x, int k, int l, int r)
            {
                eval(k, r - l);
                if (r <= s || t <= l) return data[k];
                if (s <= l && r <= t)
                {
                    assign_lazy(k, x);
                    return apply(data[k], lazy[k], r - l);
                }
                return data[k] = calc(update(s, t, x, k * 2 + 1, l, (l + r) / 2),
                                      update(s, t, x, k * 2 + 2, (l + r) / 2, r));
            }
            T run(int s, int t, int k, int l, int r)
            {
                eval(k, r - l);
                if (r <= s || t <= l) return ex_data;
                if (s <= l && r <= t) return data[k];
                return calc(run(s, t, k * 2 + 1, l, (l + r) / 2),
                            run(s, t, k * 2 + 2, (l + r) / 2, r));
            }

            /// <summary>update [s, t]</summary>
            public void Update(int s, int t, U x) { t++; update(s, t, x, 0, 0, n); }
            /// <summary>return node[s, t]</summary>
            public T this[int s, int t] => Run(s, t);
            T Run(int s, int t) { t++; return run(s, t, 0, 0, n); }
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
