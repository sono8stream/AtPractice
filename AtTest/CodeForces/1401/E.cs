using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Codeforces._1401
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int max = 1000000;

            long res = 1;

            int[][] ylrs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                ylrs[i] = ReadInts();
                if (ylrs[i][1] == 0 && ylrs[i][2] == max)
                {
                    res++;
                }
            }
            Array.Sort(ylrs, (a, b) => a[0] - b[0]);

            int[][] xyAdds = new int[m][];
            int[][] xyRems = new int[m][];
            for (int i = 0; i < m; i++)
            {
                int[] xlr = ReadInts();
                xyAdds[i] = new int[2] { xlr[0], xlr[1] };
                xyRems[i] = new int[2] { xlr[0], xlr[2] };
                if (xlr[1] == 0 && xlr[2] == max)
                {
                    res++;
                }
            }
            Array.Sort(xyAdds, (a, b) => a[1] - b[1]);
            Array.Sort(xyRems, (a, b) => a[1] - b[1]);

            SegTree<long> segTree = new SegTree<long>(max + 10, 0, (a, b) => a + b, 0);
            int idxAdd = 0;
            int idxRem = 0;
            for(int i = 0; i < n; i++)
            {
                while (idxAdd < m && xyAdds[idxAdd][1] <= ylrs[i][0])
                {
                    segTree.Update(xyAdds[idxAdd][0], segTree.Look(xyAdds[idxAdd][0]) + 1);
                    idxAdd++;
                }
                while (idxRem < m && xyRems[idxRem][1] < ylrs[i][0])
                {
                    segTree.Update(xyRems[idxRem][0], segTree.Look(xyRems[idxRem][0]) - 1);
                    idxRem++;
                }

                res += segTree.Scan(ylrs[i][1], ylrs[i][2] + 1);
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
