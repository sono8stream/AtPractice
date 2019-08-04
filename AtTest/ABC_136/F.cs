using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_136
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
            int n = ReadInt();
            int[][] xys = new int[n][];
            for(int i = 0; i < n; i++)
            {
                xys[i] = ReadInts();
            }
            Array.Sort(xys, (a, b) => a[1] - b[1]);
            for (int i = 0; i < n; i++) xys[i][1] = i;
            Array.Sort(xys, (a, b) => a[0] - b[0]);

            long[] belows = new long[n];
            SegTree<int> segTree = new SegTree<int>(n, 0, (a, b) => a + b, 0);
            for(int i = 0; i < n; i++)
            {
                belows[i] = segTree.Scan(0, xys[i][1]);
                segTree.Update(xys[i][1], 1);
            }

            long mask = 998244353;
            long[] pows = new long[n + 1];
            pows[0] = 1;
            for(int i = 1; i <= n; i++)
            {
                pows[i] = pows[i - 1] * 2;
                pows[i] %= mask;
            }

            long res = (pows[n - 1] * n) % mask;
            for(int i = 0; i < n; i++)
            {
                long tmp = pows[n - 1] - 1;
                if(i>=0) tmp -= pows[i] - 1;
                if(xys[i][1]>=0) tmp -= pows[xys[i][1]] - 1;
                if(n-i-1>=0) tmp -= pows[n - i-1] - 1;
                if(n-xys[i][1]-1>=0)tmp -= pows[n - xys[i][1]-1] - 1;

                while (tmp < 0) tmp += mask;

                tmp += pows[belows[i]] - 1;
                tmp += pows[i -belows[i]] - 1;
                long afterBelows = segTree.Scan(0, xys[i][1]) - belows[i];
                tmp += pows[afterBelows] - 1;
                tmp += pows[n - i - 1 - afterBelows] - 1;
                tmp %= mask;

                res += tmp;
                res %= mask;
            }
            WriteLine(res);
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
