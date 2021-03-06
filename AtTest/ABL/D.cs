﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABL
{
    class D
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];

            int[] array = new int[n];
            for(int i = 0; i < n; i++)
            {
                array[i] = ReadInt();
            }

            var tree = new LazySegmentTree<int, int>(610000, Max, (node, next) => Max(node.val, next),
                (nodeA, nodeB) => Max(nodeA.val, nodeB.val), 0, 0);

            int res = 0;
            for(int i = 0; i < n; i++)
            {
                int left = Max(0, array[i] - k);
                int right = array[i] + k;
                int val = tree.Scan(left, right) + 1;
                res = Max(res, val);
                tree.Update(array[i], array[i], val);
            }

            WriteLine(res);
        }

        class LazySegmentTree<T, U>
        {
            int totalLength;
            Node[] valTree;
            U[] lazyTree;
            bool[] haveLazy;

            // lazyの更新
            Func<U, U, U> evaluate;
            // lazyからvalへの投影
            Func<Node, U, T> project;
            // valの結合
            Func<Node, Node, T> integrate;

            T exValue;

            public struct Node
            {
                public T val;
                public int dig;
                public int len;

                public Node(T val, int dig, int len)
                {
                    this.val = val;
                    this.dig = dig;
                    this.len = len;
                }
            }

            /// <summary>
            /// 要素数lengthの遅延セグ木
            /// </summary>
            /// <param name="length"></param>
            /// <param name="evaluate">比較関数</param>
            /// <param name="project">投影関数</param>
            /// <param name="integrate">結合関数</param>
            /// <param name="initialValue">初期値</param>
            /// <param name="exValue">例外値</param>
            public LazySegmentTree(int length, Func<U, U, U> evaluate, Func<Node, U, T> project,
                Func<Node, Node, T> integrate, U initValue, T exValue)
            {
                totalLength = 1;
                while (totalLength < length)
                {
                    totalLength *= 2;
                }

                this.evaluate = evaluate;
                this.project = project;
                this.integrate = integrate;

                lazyTree = new U[totalLength * 2 - 1];
                haveLazy = new bool[totalLength * 2 - 1];
                valTree = new Node[totalLength * 2 - 1];

                for (int i = 0; i < length; i++)
                {
                    valTree[i + totalLength - 1] = new Node(exValue, length - i - 1, 1);
                    valTree[i + totalLength - 1].val = project(valTree[i + totalLength - 1], initValue);
                }

                for (int i = totalLength - 2; i >= 0; i--)
                {
                    valTree[i].val = integrate(valTree[i * 2 + 1], valTree[i * 2 + 2]);
                    valTree[i].len = valTree[i * 2 + 1].len * 2;
                    valTree[i].dig = valTree[i * 2 + 2].dig;
                }

                this.exValue = exValue;
            }

            /// <summary>
            /// [left, right]をvalで更新
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <param name="val"></param>
            public void Update(int left, int right, U val)
            {
                if (left < 0 || right >= totalLength || right < left)
                {
                    return;
                }

                UpdateQuery(left, right, 0, 0, totalLength - 1, val);
            }

            /// <summary>
            /// [left, right]が[top,last]と一致していればvalで更新，そうでなければ分割して評価
            /// 再帰処理
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <param name="i"></param>
            /// <param name="top"></param>
            /// <param name="last"></param>
            /// <param name="val"></param>
            void UpdateQuery(int left, int right, int i, int top, int last, U val)
            {
                if (left == top && right == last)
                {
                    haveLazy[i] = true;
                    lazyTree[i] = evaluate(lazyTree[i], val);
                    valTree[i].val = project(valTree[i], lazyTree[i]);
                    while (i > 0)
                    {
                        i = (i - 1) / 2;
                        valTree[i].val = integrate(valTree[i * 2 + 1], valTree[i * 2 + 2]);
                    }
                }
                else
                {
                    EvaluateLazy(i);

                    int half = (top + last) / 2;
                    if (left <= half)
                    {
                        UpdateQuery(left, Min(right, half), i * 2 + 1, top, half, val);
                    }
                    if (right >= half + 1)
                    {
                        UpdateQuery(Max(left, half + 1), right, i * 2 + 2, half + 1, last, val);
                    }
                }
            }

            public T Scan(int left, int right)
            {
                if (left < 0 || right >= totalLength || right < left)
                {
                    return exValue;
                }

                return ScanQuery(left, right, 0, 0, totalLength - 1).val;
            }

            Node ScanQuery(int left, int right, int i, int top, int last)
            {
                if (left == top && right == last)
                {
                    return valTree[i];
                }
                else
                {
                    EvaluateLazy(i);

                    int half = (top + last) / 2;
                    var leftNode = new Node(exValue, -1, -1);
                    var rightNode = new Node(exValue, -1, -1);
                    if (left <= half)
                    {
                        leftNode = ScanQuery(left, Min(right, half), i * 2 + 1, top, half);
                    }
                    if (right >= half + 1)
                    {
                        rightNode = ScanQuery(Max(left, half + 1), right, i * 2 + 2, half + 1, last);
                    }

                    if (leftNode.len == -1)
                    {
                        return rightNode;
                    }
                    if (rightNode.len == -1)
                    {
                        return leftNode;
                    }

                    return new Node(integrate(leftNode, rightNode), rightNode.dig, leftNode.len * 2);
                }
            }

            void EvaluateLazy(int i)
            {
                if (i * 2 + 2 < lazyTree.Length && haveLazy[i])
                {
                    haveLazy[i * 2 + 1] = true;
                    lazyTree[i * 2 + 1] = evaluate(lazyTree[i * 2 + 1], lazyTree[i]);
                    valTree[i * 2 + 1].val = project(valTree[i * 2 + 1], lazyTree[i * 2 + 1]);

                    haveLazy[i * 2 + 2] = true;
                    lazyTree[i * 2 + 2] = evaluate(lazyTree[i * 2 + 2], lazyTree[i]);
                    valTree[i * 2 + 2].val = project(valTree[i * 2 + 2], lazyTree[i * 2 + 2]);

                    haveLazy[i] = false;
                }
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
