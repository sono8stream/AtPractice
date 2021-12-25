using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_223
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[][] abs = new int[m][];
            for (int i = 0; i < m; i++)
            {
                abs[i] = ReadInts();
            }

            List<int>[] forwardGraph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                forwardGraph[i] = new List<int>();
            }

            int[] remainParents = new int[n];
            for (int i = 0; i < m; i++)
            {
                forwardGraph[abs[i][0] - 1].Add(abs[i][1] - 1);
                remainParents[abs[i][1] - 1]++;
            }

            GeneralPriorityQueue<int> que = new GeneralPriorityQueue<int>();
            for (int i = 0; i < n; i++)
            {
                if (remainParents[i] == 0)
                {
                    que.Enqueue(i);
                }
            }

            List<int> resList = new List<int>();
            while (que.Count > 0)
            {
                int now = que.Dequeue();
                resList.Add(now + 1);

                foreach (int child in forwardGraph[now])
                {
                    remainParents[child]--;
                    if (remainParents[child] == 0)
                    {
                        que.Enqueue(child);
                    }
                }
            }

            if (resList.Count == n)
            {
                WriteLine(string.Join(" ", resList));
            }
            else
            {
                WriteLine("-1");
            }
        }

        class GeneralPriorityQueue<T> where T : IComparable<T>
        {
            private readonly List<T> list;

            public int Count { get; private set; }

            public T Top { get { return list[0]; } }

            public GeneralPriorityQueue()
            {
                list = new List<T>();
                Count = 0;
            }

            private void Add(T value)
            {
                if (Count == list.Count)
                {
                    list.Add(value);
                }
                else
                {
                    list[Count] = value;
                }
                Count++;
            }

            private void Swap(int a, int b)
            {
                T tmp = list[a];
                list[a] = list[b];
                list[b] = tmp;
            }

            public void Enqueue(T value)
            {
                Add(value);
                int current = Count - 1;
                while (current > 0)
                {
                    int parent = (current - 1) / 2;
                    if (list[current].CompareTo(list[parent]) >= 0)
                    {
                        break;
                    }

                    Swap(parent, current);
                    current = parent;
                }
            }

            public T Dequeue()
            {
                T value = list[0];
                Count--;
                if (Count == 0) return value;

                list[0] = list[Count];
                int parent = 0;
                while (true)
                {
                    int currentLeft = parent * 2 + 1;
                    int currentRight = parent * 2 + 2;
                    if (currentLeft >= Count)
                    {
                        break;
                    }

                    int current = (currentRight >= Count || list[currentLeft].CompareTo(list[currentRight]) == -1)
                        ? currentLeft : currentRight;
                    if (list[current].CompareTo(list[parent]) >= 0)
                    {
                        break;
                    }

                    Swap(parent, current);
                    parent = current;
                }
                return value;
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
