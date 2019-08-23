using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_107
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long n = ReadLong();
            int[] array = ReadInts();
            int[] sorted = new int[n];
            for (int i = 0; i < n; i++) sorted[i] = array[i];
            Array.Sort(sorted);
            Dictionary<int, int> pos = new Dictionary<int, int>();
            for(int i = 0; i < n; i++)
            {
                if (pos.ContainsKey(sorted[i])) continue;

                pos.Add(sorted[i], i);
            }

            int bottom = 0;
            int top = (int)n;
            while (bottom + 1 < top)
            {
                int mid = (bottom + top) / 2;
                int val = sorted[mid];
                int[] sums = new int[n];
                for (int i = 0; i < n; i++)
                {
                    if (val <= array[i])
                    {
                        sums[i] = 1;
                    }
                    else sums[i] = -1;

                    if (i > 0) sums[i] += sums[i - 1];
                }

                long cnt = 0;
                SegTree<int> tree = new SegTree<int>(2*100000+5, 0, (a, b) => a + b, 0);
                for(int i = (int)n - 1; i >= 0; i--)
                {
                    tree.Update(sums[i] + 100000, tree.Look(sums[i] + 100000) + 1);
                    if (val <= array[i])
                    {
                        cnt += tree.Scan(sums[i] - 1 + 100000, 2 * 100000 + 10);
                    }
                    else
                    {
                        cnt += tree.Scan(sums[i] + 1 + 100000, 2 * 100000 + 10);
                    }
                }

                long thres = n * (n + 1) / 4;
                if ((n * (n + 1) / 2) % 2 > 0) thres++;
                if (cnt >= thres) bottom = mid;
                else top = mid;
            }

            Console.WriteLine(sorted[bottom]);
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

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
