using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_1
{
    class K
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
            int[] array = ReadInts();
            for(int i =0; i < n; i++)
            {
                array[i] = Min(array[i], i + 1);
            }

            int res = 0;
            int tmpNow = 0;
            GeneralPriorityQueue<int> queue = new GeneralPriorityQueue<int>();
            for(int i = n - 1; i >= 0; i--)
            {
                queue.Enqueue(-array[i]);
                if (tmpNow < n - i)
                {
                    res++;
                    tmpNow += -queue.Dequeue();
                }
            }

            WriteLine(res);
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
                int c = Count - 1;
                while (c > 0)
                {
                    int p = (c - 1) / 2;
                    if (list[c].CompareTo(list[p]) >= 0) break;

                    Swap(p, c);
                    c = p;
                }
            }

            public T Dequeue()
            {
                T value = list[0];
                Count--;
                if (Count == 0) return value;

                list[0] = list[Count];
                int p = 0;
                while (true)
                {
                    int c1 = p * 2 + 1;
                    int c2 = p * 2 + 2;
                    if (c1 >= Count) break;

                    int c = (c2 >= Count || list[c1].CompareTo(list[c2]) == -1)
                        ? c1 : c2;
                    if (list[c].CompareTo(list[p]) >= 0) break;

                    Swap(p, c);
                    p = c;
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
