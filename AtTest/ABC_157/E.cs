using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_157
{
    class E
    {
        static void Main(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            char[] s = Read().ToCharArray();
            int q = ReadInt();
            SegTree<Used> segTree = new SegTree<Used>(n, new Used(0), (a, b) =>
               {
                   Used res = new Used(0);
                   if (a.used != null && b.used != null)
                   {
                       for (int i = 0; i < a.used.Length; i++)
                       {
                           res[i] = a[i] | b[i];
                       }
                   }
                   return res;
               }, new Used(0));
            for(int i = 0; i < n; i++)
            {
                Used tmp = segTree.Look(i);
                tmp[s[i] - 'a'] = true;
                segTree.Update(i, tmp);
            }
            for(int i = 0; i < q; i++)
            {
                string[] query = Read().Split();
                int type=int.Parse(query[0]);
                if (type == 1)
                {
                    int index = int.Parse(query[1]) - 1;
                    Used tmp = segTree.Look(index);
                    tmp[s[index] - 'a'] = false;
                    tmp[query[2][0] - 'a'] = true;
                    s[index] = (char)(query[2][0] - 'a');
                    segTree.Update(index, tmp);
                }
                else
                {
                    int l = int.Parse(query[1]) - 1;
                    int r = int.Parse(query[2]);
                    Used tmp = segTree.Scan(l, r);
                    int kinds = 0;
                    tmp.used.Select(a =>
                    {
                        if (a)
                        {
                            kinds++;
                        }
                        return a;
                    });
                    WriteLine(kinds);
                }
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

        struct Used
        {
            public bool[] used;

            public bool this[int i]
            {
                set { if (used != null) { used[i] = value; } }
                get { if (used == null){ return false; } else { return used[i]; } }
            }

            public Used(int val)
            {
                used = new bool[26];
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
