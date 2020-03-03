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
            char[] s = Read().ToCharArray();
            int q = ReadInt();
            SegTree segTree = new SegTree(n, (a, b) =>
               {
                   bool[] res = new bool[26];
                   for (int i = 0; i < a.Length; i++)
                   {
                       res[i] = a[i] | b[i];
                   }
                   return res;
               });
            for(int i = 0; i < n; i++)
            {
                bool[] tmp = segTree.Look(i);
                tmp[s[i] - 'a'] = true;
                segTree.Update(i);
            }
            for(int i = 0; i < q; i++)
            {
                string[] query = Read().Split();
                int type=int.Parse(query[0]);
                if (type == 1)
                {
                    int index = int.Parse(query[1]) - 1;
                    bool[] tmp = segTree.Look(index);
                    tmp[s[index] - 'a'] = false;
                    tmp[query[2][0] - 'a'] = true;
                    s[index] = query[2][0];
                    segTree.Update(index);
                }
                else
                {
                    int l = int.Parse(query[1]) - 1;
                    int r = int.Parse(query[2]);
                    bool[] tmp = segTree.Scan(l, r);
                    int kinds = 0;
                    for(int j = 0; j < 26; j++)
                    {
                        if (tmp[j])
                        {
                            kinds++;
                        }
                    }
                    WriteLine(kinds);
                }
            }
        }

        class SegTree
        {
            int totalLength;
            bool[][] tree;
            Func<bool[], bool[], bool[]> integrate;

            public SegTree(int length, Func<bool[],bool[],bool[]> integrate)
            {
                this.integrate = integrate;
                totalLength = 1;
                while (totalLength < length) totalLength *= 2;

                tree = new bool[2 * totalLength - 1][];
                for (int i = 0; i < tree.Length; i++)
                {
                    tree[i] = new bool[26];
                }
            }

            public void Update(int i)
            {
                int now = i + totalLength - 1;
                while (now > 0)
                {
                    now = (now - 1) / 2;
                    tree[now] = integrate(
                        tree[now * 2 + 1], tree[now * 2 + 2]);
                }
            }

            public bool[] Look(int i) { return tree[i + totalLength - 1]; }

            //[top,last)
            public bool[] Scan(int top, int last)
            {
                return Query(top, last, 0, 0, totalLength);
            }

            bool[] Query(int top, int last, int i, int left, int right)
            {
                if (right <= top || last <= left) return new bool[26];
                if (top <= left && right <= last) return tree[i];

                bool[] leftValue = Query(top, last, i * 2 + 1,
                    left, (left + right) / 2);
                bool[] rightValue = Query(top, last, (i + 1) * 2,
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
