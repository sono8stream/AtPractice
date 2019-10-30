using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_C
{
    class _033
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
            SegTree<int> segTree = new SegTree<int>(200010, 0, (a, b) => a + b, 0);
            List<int> reses = new List<int>();
            for(int i = 0; i < q; i++)
            {
                int[] tx = ReadInts();
                int t = tx[0];
                int x = tx[1];
                if (t == 1)
                {
                    segTree.Update(x, segTree[x] + 1);
                }
                else
                {
                    int bottom = 0;
                    int top = 200001;
                    while (bottom + 1 < top)
                    {
                        int mid = (bottom + top) / 2;
                        if (segTree.Scan(1, mid + 1) < x) bottom = mid;
                        else top = mid;
                    }
                    reses.Add(top);
                    segTree.Update(top, segTree[top] - 1);
                }
            }
            for(int i = 0; i < reses.Count; i++)
            {
                WriteLine(reses[i]);
            }
        }

        class SegTree<T>
        {
            int totalLength;
            T[] tree;
            Func<T, T, T> integrate;
            T exValue;

            public T this[int i]
            {
                get
                {
                    int now = i + totalLength - 1;
                    return tree[now];
                }
            }

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
