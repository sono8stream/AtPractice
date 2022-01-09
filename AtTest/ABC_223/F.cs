using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_223
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

        class Node
        {
            public int leftOpenNum;
            public int rightOpenNum;

            public Node(int leftOpenNum, int rightOpenNum)
            {
                this.leftOpenNum = leftOpenNum;
                this.rightOpenNum = rightOpenNum;
            }
        }

        static void Method(string[] args)
        {
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            char[] s = Read().ToCharArray();

            SegmentTree<Node> tree = new SegmentTree<Node>(n,
                (a, b) =>
                {
                    int resolvedOpenNum = Math.Min(a.rightOpenNum, b.leftOpenNum);
                    int leftOpenNum = a.leftOpenNum + (b.leftOpenNum - resolvedOpenNum);
                    int rightOpenNum = b.rightOpenNum + (a.rightOpenNum - resolvedOpenNum);
                    return new Node(leftOpenNum, rightOpenNum);
                },
                new Node(0, 0), new Node(0, 0));

            for (int i = 0; i < n; i++)
            {
                bool can = s[i] == '(';
                if (s[i] == '(')
                {
                    tree.Update(i, new Node(0, 1));
                }
                else
                {
                    tree.Update(i, new Node(1, 0));
                }
            }

            for(int i = 0; i < q; i++)
            {
                int[] query = ReadInts();
                int mode = query[0];
                int left = query[1] - 1;
                int right = query[2] - 1;

                if (mode == 1)
                {

                    if (s[left] == s[right])
                    {
                        continue;
                    }
                    else
                    {
                        if (s[left] == '(')
                        {
                            tree.Update(left, new Node(1, 0));
                            tree.Update(right, new Node(0, 1));
                            s[left] = ')';
                            s[right] = '(';
                        }
                        else
                        {
                            tree.Update(left, new Node(0, 1));
                            tree.Update(right, new Node(1, 0));
                            s[left] = '(';
                            s[right] = ')';
                        }
                    }
                }
                else
                {
                    Node node = tree.Scan(left, right);
                    WriteLine(node.leftOpenNum == 0 && node.rightOpenNum == 0 ? "Yes" : "No");
                }
            }
        }

        class SegmentTree<T>
        {
            int totalLength;
            T[] tree;
            Func<T, T, T> integrate;
            T exValue;

            public SegmentTree(int length, Func<T, T, T> integrate, T initialValue, T exValue)
            {
                totalLength = 1;
                while (totalLength < length)
                {
                    totalLength *= 2;
                }

                this.integrate = integrate;

                tree = new T[totalLength * 2 - 1];
                for (int i = 0; i < tree.Length; i++)
                {
                    tree[i] = exValue;
                }
                for (int i = 0; i < length; i++)
                {
                    tree[i + totalLength - 1] = initialValue;
                }
                this.exValue = exValue;

                UpdateAll();
            }

            void UpdateAll()
            {
                for (int i = totalLength - 2; i >= 0; i--)
                {
                    tree[i] = integrate(tree[i * 2 + 1], tree[i * 2 + 2]);
                }
            }

            public void Update(int i, T value)
            {
                int now = i + totalLength - 1;
                tree[now] = value;
                while (now > 0)
                {
                    now = (now - 1) / 2;
                    tree[now] = integrate(tree[now * 2 + 1], tree[now * 2 + 2]);
                }
            }


            /// <summary>
            /// [left, right]を取得
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            public T Scan(int left, int right)
            {
                if (left >= totalLength || right < 0 || right < left)
                {
                    return exValue;
                }

                return Query(left, right, 0, 0, totalLength - 1);
            }

            /// <summary>
            /// [left, right]が[top,last]と一致していればその値を，そうでなければ統合して返す
            /// 再帰処理
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <param name="i"></param>
            /// <param name="top"></param>
            /// <param name="last"></param>
            T Query(int left, int right, int i, int top, int last)
            {
                if (left == top && right == last)
                {
                    return tree[i];
                }
                else
                {
                    int half = (top + last) / 2;
                    T val = exValue;

                    if (right <= half)
                    {
                        return Query(left, right, i * 2 + 1, top, half);
                    }
                    if (left > half)
                    {
                        return Query(left, right, i * 2 + 2, half + 1, last);
                    }

                    T leftNode = Query(left, half, i * 2 + 1, top, half);
                    T rightNode = Query(half + 1, right, i * 2 + 2, half + 1, last);
                    return integrate(leftNode, rightNode);
                }
            }

            public T Look(int i)
            {
                return tree[i + totalLength - 1];
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
