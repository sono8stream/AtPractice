using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.SegmentTree
{
    class LazySegmentTree
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
        }

        class LazySegtree<T, U>
        {
            int n;
            T[] data;
            U[] lazy;
            bool[] isLazy;
            Func<T, T, T> calc;
            Func<T, U, int, T> apply;
            Func<U, U, U> merge;
            T exValue;

            /// <summary>
            /// 遅延セグメントツリーの構築
            /// </summary>
            /// <param name="m">要素数</param>
            /// <param name="calc">要素のマージ</param>
            /// <param name="apply">要素に作用素を作用</param>
            /// <param name="merge">作用素のマージ</param>
            /// <param name="exValue">単位元</param>
            public LazySegtree(int m, Func<T, T, T> calc, Func<T, U, int, T> apply, Func<U, U, U> merge, T exValue)
            {
                this.calc = calc;
                this.apply = apply;
                this.merge = merge;
                this.exValue = exValue;
                n = 1;
                while (n < m) n <<= 1;
                data = new T[n * 2 - 1];
                lazy = new U[n * 2 - 1];
                isLazy = new bool[n * 2 - 1];
                for (int i = 0; i < data.Length; i++) data[i] = exValue;
            }

            public LazySegtree(int m, Func<T, T, T> calc, Func<T, U, int, T> apply,
                Func<U, U, U> merge, T exData, T initialValue) 
                : this(m, calc, apply, merge, exData)
            {
                for (int i = 0; i < m; i++) data[i + n - 1] = initialValue;
                for (int i = n - 2; i >= 0; i--)
                {
                    data[i] = calc(data[i * 2 + 1], data[i * 2 + 2]);
                }
            }

            public LazySegtree(int m, Func<T, T, T> calc, Func<T, U, int, T> apply,
                Func<U, U, U> merge, T exData,
                IList<T> initialValue)
                : this(m, calc, apply, merge, exData)
            {
                for (int i = 0; i < m; i++) data[i + n - 1] = initialValue[i];
                for (int i = n - 2; i >= 0; i--)
                {
                    data[i] = calc(data[i * 2 + 1], data[i * 2 + 2]);
                }
            }

            void AssignLazy(int k, U x)
            {
                if (k >= lazy.Length) return;
                if (isLazy[k]) lazy[k] = merge(lazy[k], x);
                else
                {
                    isLazy[k] = true;
                    lazy[k] = x;
                }
            }

            void Eval(int k, int len)
            {
                if (!isLazy[k]) return;
                AssignLazy(k * 2 + 1, lazy[k]);
                AssignLazy(k * 2 + 2, lazy[k]);
                data[k] = apply(data[k], lazy[k], len);
                isLazy[k] = false;
            }

            T Update(int s, int t, U x, int k, int l, int r)
            {
                Eval(k, r - l);
                if (r <= s || t <= l) return data[k];
                if (s <= l && r <= t)
                {
                    AssignLazy(k, x);
                    return apply(data[k], lazy[k], r - l);
                }
                return data[k] = calc(Update(s, t, x, k * 2 + 1, l, (l + r) / 2),
                                      Update(s, t, x, k * 2 + 2, (l + r) / 2, r));
            }

            T Run(int s, int t, int k, int l, int r)
            {
                Eval(k, r - l);
                if (r <= s || t <= l) return exValue;
                if (s <= l && r <= t) return data[k];
                return calc(Run(s, t, k * 2 + 1, l, (l + r) / 2),
                            Run(s, t, k * 2 + 2, (l + r) / 2, r));
            }

            /// <summary>update [s, t]</summary>
            public void Update(int s, int t, U x) { t++; Update(s, t, x, 0, 0, n); }
            /// <summary>return node[s, t]</summary>
            public T this[int s, int t] => Run(s, t);
            T Run(int s, int t) { t++; return Run(s, t, 0, 0, n); }
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
