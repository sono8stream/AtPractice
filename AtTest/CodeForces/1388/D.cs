using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1388
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
            int n = ReadInt();
            long[] array = ReadLongs();
            int[] childs = ReadInts();
            List<int>[] parents = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                parents[i] = new List<int>();
            }
            for(int i = 0; i < n; i++)
            {
                if (childs[i] == -1)
                {
                    continue;
                }
                parents[childs[i] - 1].Add(i);
            }

            var que = new Queue<int[]>();
            for(int i = 0; i < n; i++)
            {
                if (childs[i] == -1)
                {
                    que.Enqueue(new int[2] { i, -1 });
                }
            }
            var stk = new Stack<int>();
            while (que.Count > 0)
            {
                int[] val = que.Dequeue();
                int now = val[0];
                int par = val[1];

                stk.Push(now);
                for(int i = 0; i < parents[now].Count; i++)
                {
                    int to = parents[now][i];
                    if (to == par)
                    {
                        continue;
                    }
                    que.Enqueue(new int[2] { to, now });
                }
            }

            HashSet<int>[] lefts = new HashSet<int>[n];
            HashSet<int>[] rights = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
            {
                lefts[i] = new HashSet<int>();
                rights[i] = new HashSet<int>();
            }

            long res = 0;
            long[] vals = new long[n];
            while (stk.Count > 0)
            {
                int now = stk.Pop();

                long tmp = array[now];
                for(int i = 0; i < parents[now].Count; i++)
                {
                    int to = parents[now][i];
                    if (vals[to] > 0)
                    {
                        tmp += vals[to];
                        rights[to].Add(now);
                        lefts[now].Add(to);
                    }
                    else
                    {
                        rights[now].Add(to);
                        lefts[to].Add(now);
                    }
                }
                vals[now] = tmp;
                res += tmp;
            }

            WriteLine(res);

            var sortQue = new Queue<int>();
            for(int i = 0; i < n; i++)
            {
                if (lefts[i].Count == 0)
                {
                    sortQue.Enqueue(i);
                }
            }
            int cnt = 0;
            while (sortQue.Count > 0)
            {
                int now = sortQue.Dequeue();
                Write(now + 1);
                cnt++;
                if (cnt < n)
                {
                    Write(" ");
                }
                foreach(int to in rights[now])
                {
                    lefts[to].Remove(now);
                    if (lefts[to].Count == 0)
                    {
                        sortQue.Enqueue(to);
                    }
                }
            }
            WriteLine();
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
