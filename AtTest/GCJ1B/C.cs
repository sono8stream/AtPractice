﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ1C
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
            for (int i = 0; i < t; i++)
            {
                Write("Case #" + (i + 1) + ": ");
                res[i]();
            }
        }

        static Action Solve()
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[] cs = ReadInts();
            int[] ds = ReadInts();
            SegTree<int> segTreeC = new SegTree<int>(n, Max, 0);
            SegTree<int> segTreeD = new SegTree<int>(n, Max, 0);
            for(int i = 0; i < n; i++)
            {
                segTreeC.Update(i, cs[i]);
                segTreeD.Update(i, ds[i]);
            }

            long cnt = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = i+1; j <= n; j++)
                {
                    int delta = Abs(segTreeC.Scan(i, j) - segTreeD.Scan(i, j));
                    if (delta <= k) cnt++;
                }
            }

            return () => WriteLine(cnt);
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
