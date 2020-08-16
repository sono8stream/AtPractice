using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC017_D
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
            long[] array = ReadLongs();
            var sumTree = new SegTree<long>(n, 0, (a, b) => a + b, 0);
            var gcdTree = new SegTree<long>(n, 0, (a, b) => GCD(a, b), 0);
            for (int i = 0; i < n; i++)
            {
                long delta = array[i];
                if (i > 0)
                {
                    delta -= array[i - 1];
                }
                sumTree.Update(i, delta);
                gcdTree.Update(i, Abs(delta));
            }

            int m = ReadInt();
            for (int i = 0; i < m; i++)
            {
                int[] tlr = ReadInts();
                int t = tlr[0];
                int l = tlr[1];
                int r = tlr[2];

                if (t == 0)
                {
                    long top = sumTree.Scan(0, l);
                    long gcd = gcdTree.Scan(l, r);
                    WriteLine(GCD(top, gcd));
                }
                else
                {
                    sumTree.Update(l - 1, sumTree.Look(l - 1) + t);
                    gcdTree.Update(l - 1, Abs(sumTree.Look(l - 1)));
                    if (r < n)
                    {
                        sumTree.Update(r, sumTree.Look(r) - t);
                        gcdTree.Update(r, Abs(sumTree.Look(r)));
                    }
                }
            }
        }

        static long GCD(long a, long b)
        {
            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }

            if (b > a)
            {
                long temp = b;
                b = a;
                a = temp;
            }
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
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
