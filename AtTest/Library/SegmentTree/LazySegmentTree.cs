using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.SegmentTree
{
    class ABC179_F
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
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            /*
            var hors = new LazySegmentTree<int>(n, Min, n - 2, int.MaxValue / 2);
            var vers = new LazySegmentTree<int>(n, Min, n - 2, int.MaxValue / 2);

            long res = (long)(n - 2) * (n - 2);
            for (int i = 0; i < q; i++)
            {
                int[] query = ReadInts();
                int l = query[0];
                int r = query[1];

                if (l == 1)
                {
                    int len = vers.Look(r - 2);
                    if (len > 0)
                    {
                        hors.Update(0, len - 1, r - 2);
                        res -= len;
                    }
                }
                if (l == 2)
                {
                    int len = hors.Look(r - 2);
                    if (len > 0)
                    {
                        vers.Update(0, len - 1, r - 2);
                        res -= len;
                    }
                }
            }

            WriteLine(res);
            */
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

        /// <summary>
        /// 位置を特定可能なノードを用いる遅延セグメント木
        /// </summary>
        /// <typeparam name="ValueType">保持する値の型</typeparam>
        /// <typeparam name="LazyValueType">遅延評価で反映させる値の型</typeparam>
        class LazySegmentTree3<ValueType, LazyValueType>
        {
            int totalLength;
            Node[] valTree;
            LazyValueType[] lazyTree;
            bool[] haveLazy;

            // 遅延評価値を伝播させる処理
            Func<LazyValueType, LazyValueType, LazyValueType> evaluate;
            // 遅延評価値を保持する値に反映させる処理
            Func<Node, LazyValueType, ValueType> project;
            // 保持する値の畳み込み処理
            Func<Node, Node, ValueType> integrate;

            // 範囲外の値
            ValueType exValue;

            public struct Node
            {
                public ValueType val;
                // 同じdepthFromTopでの左からの位置（0-indexed）
                public int indexFromLeft;
                // 畳みこんでいる要素サイズ
                public int length;

                public Node(ValueType val, int indexFromLeft, int length)
                {
                    this.val = val;
                    this.indexFromLeft = indexFromLeft;
                    this.length = length;
                }
            }

            /// <summary>
            /// 要素数lengthの遅延セグ木
            /// </summary>
            /// <param name="length"></param>
            /// <param name="evaluate">遅延評価値を伝播させる処理</param>
            /// <param name="project">遅延評価値を保持する値に反映させる処理</param>
            /// <param name="integrate">保持する値の畳み込み処理</param>
            /// <param name="initialValue">初期値を生成するための遅延評価値</param>
            /// <param name="exValue">保持する値の例外値</param>
            public LazySegmentTree3(int length, 
                Func<LazyValueType, LazyValueType, LazyValueType> evaluate,
                Func<Node, LazyValueType, ValueType> project,
                Func<Node, Node, ValueType> integrate, LazyValueType initValue, ValueType exValue)
            {
                totalLength = 1;
                while (totalLength < length)
                {
                    totalLength *= 2;
                }

                this.evaluate = evaluate;
                this.project = project;
                this.integrate = integrate;

                lazyTree = new LazyValueType[totalLength * 2 - 1];
                haveLazy = new bool[totalLength * 2 - 1];
                valTree = new Node[totalLength * 2 - 1];

                int nodeLength = totalLength;
                int remainLength = length;
                for (int i = 0; i < length; i++)
                {
                    int currentIndexFromLeft = length - remainLength;
                    int currentNodeLength;
                    // ノードに畳みこまれている要素数を計算
                    if (remainLength < nodeLength)
                    {
                        currentNodeLength = remainLength;
                        remainLength = length;
                        nodeLength /= 2;
                    }
                    else
                    {
                        currentNodeLength = nodeLength;
                        remainLength -= nodeLength;
                    }

                    valTree[i + totalLength - 1] = new Node(exValue, currentIndexFromLeft, currentNodeLength);
                    valTree[i + totalLength - 1].val = project(valTree[i + totalLength - 1], initValue);
                }

                for (int i = totalLength - 2; i >= 0; i--)
                {
                    valTree[i].val = integrate(valTree[i * 2 + 1], valTree[i * 2 + 2]);
                }

                this.exValue = exValue;
            }

            /// <summary>
            /// [left, right]をvalで更新
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <param name="val"></param>
            public void Update(int left, int right, LazyValueType val)
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
            void UpdateQuery(int left, int right, int i, int top, int last, LazyValueType val)
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

            public ValueType Scan(int left, int right)
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

                    if (right <= half)
                    {
                        return ScanQuery(left, right, i * 2 + 1, top, half);
                    }
                    if (left > half)
                    {
                        return ScanQuery(left, right, i * 2 + 2, half + 1, last);
                    }

                    Node leftNode = ScanQuery(left, half, i * 2 + 1, top, half);
                    Node rightNode = ScanQuery(half + 1, right, i * 2 + 2, half + 1, last);
                    ValueType value = integrate(leftNode,rightNode);

                    return new Node(value, leftNode.indexFromLeft, leftNode.length + rightNode.length);
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

        // ノードを含まないもの
        class LazySegmentTree2<T, U>
        {
            int totalLength;
            T[] valTree;
            U[] lazyTree;
            bool[] haveLazy;

            // lazyの更新
            Func<U, U, U> evaluate;
            // lazyからvalへの投影
            Func<T, U, T> project;
            // valの結合
            Func<T, T, T> integrate;

            T exValue;

            /// <summary>
            /// 要素数lengthの遅延セグ木
            /// </summary>
            /// <param name="length"></param>
            /// <param name="evaluate">比較関数</param>
            /// <param name="project">投影関数</param>
            /// <param name="integrate">結合関数</param>
            /// <param name="initialValue">初期値</param>
            /// <param name="exValue">例外値</param>
            public LazySegmentTree2(int length, Func<U, U, U> evaluate, Func<T, U, T> project,
                Func<T, T, T> integrate, U initValue, T exValue)
            {
                totalLength = 1;
                while (totalLength < length)
                {
                    totalLength *= 2;
                }

                this.evaluate = evaluate;
                this.project = project;
                this.integrate = integrate;

                valTree = new T[totalLength * 2 - 1];
                lazyTree = new U[totalLength * 2 - 1];
                haveLazy = new bool[totalLength * 2 - 1];

                for (int i = 0; i < length; i++)
                {
                    valTree[i + totalLength - 1] = project(valTree[i + totalLength - 1], initValue);
                }

                for (int i = totalLength - 2; i >= 0; i--)
                {
                    valTree[i] = integrate(valTree[i * 2 + 1], valTree[i * 2 + 2]);
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
                    valTree[i] = project(valTree[i], lazyTree[i]);
                    while (i > 0)
                    {
                        i = (i - 1) / 2;
                        valTree[i] = integrate(valTree[i * 2 + 1], valTree[i * 2 + 2]);
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

                return ScanQuery(left, right, 0, 0, totalLength - 1);
            }

            T ScanQuery(int left, int right, int i, int top, int last)
            {
                if (left == top && right == last)
                {
                    return valTree[i];
                }
                else
                {
                    EvaluateLazy(i);

                    int half = (top + last) / 2;
                    T leftVal = exValue;
                    T rightVal = exValue;

                    if (right <= half)
                    {
                        return ScanQuery(left, right, i * 2 + 1, top, half);
                    }
                    if (left > half)
                    {
                        return ScanQuery(left, right, i * 2 + 2, half + 1, last);
                    }

                    return integrate(ScanQuery(left, half, i * 2 + 1, top, half),
                        ScanQuery(half + 1, right, i * 2 + 2, half + 1, last));
                }
            }

            void EvaluateLazy(int i)
            {
                if (i * 2 + 2 < lazyTree.Length && haveLazy[i])
                {
                    haveLazy[i * 2 + 1] = true;
                    lazyTree[i * 2 + 1] = evaluate(lazyTree[i * 2 + 1], lazyTree[i]);
                    valTree[i * 2 + 1] = project(valTree[i * 2 + 1], lazyTree[i * 2 + 1]);

                    haveLazy[i * 2 + 2] = true;
                    lazyTree[i * 2 + 2] = evaluate(lazyTree[i * 2 + 2], lazyTree[i]);
                    valTree[i * 2 + 2] = project(valTree[i * 2 + 2], lazyTree[i * 2 + 2]);

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