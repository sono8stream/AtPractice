using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_170
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
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            int[][] abs = new int[n][];
            var sets = new HashSet<int>[250000];
            var ques = new PriorityQueue<int>[250000];
            for (int i = 0; i < 250000; i++)
            {
                sets[i] = new HashSet<int>();
                ques[i] = new PriorityQueue<int>();
            }

            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadInts();
                int a = abs[i][0];
                int b = abs[i][1];
                sets[b].Add(i);
                ques[b].Enqueue(-a, i);
            }

            var maxQue = new PriorityQueue<int>();
            for (int i = 0; i < 250000; i++)
            {
                if (ques[i].Count > 0)
                {
                    maxQue.Enqueue(-ques[i].Top().Key, i);
                }
            }

            for (int i = 0; i < q; i++)
            {
                int[] cd = ReadInts();
                int c = cd[0] - 1;
                int d = cd[1];
                int from = abs[c][1];

                sets[from].Remove(c);
                while(ques[from].Count>0
                    && !sets[from].Contains(ques[from].Top().Value))
                {
                    ques[abs[c][1]].Dequeue();
                }
                if (ques[from].Count > 0)
                {
                    maxQue.Enqueue(-ques[from].Top().Key, from);
                }

                sets[d].Add(c);
                ques[d].Enqueue(-abs[c][0], c);
                maxQue.Enqueue(-ques[d].Top().Key, d);
                abs[c][1] = d;

                while(maxQue.Count>0
                    &&(ques[ maxQue.Top().Value].Count==0
                    || -ques[maxQue.Top().Value].Top().Key != maxQue.Top().Key))
                {
                    maxQue.Dequeue();
                }

                WriteLine(maxQue.Top().Key);
            }
        }

        class PriorityQueue<T>
        {
            private readonly List<KeyValuePair<long, T>> list;

            public int Count { get; private set; }

            public PriorityQueue()
            {
                list = new List<KeyValuePair<long, T>>();
                Count = 0;
            }

            private void Add(KeyValuePair<long, T> pair)
            {
                if (Count == list.Count)
                {
                    list.Add(pair);
                }
                else
                {
                    list[Count] = pair;
                }
                Count++;
            }

            private void Swap(int a, int b)
            {
                KeyValuePair<long, T> tmp = list[a];
                list[a] = list[b];
                list[b] = tmp;
            }

            public void Enqueue(long key, T value)
            {
                Add(new KeyValuePair<long, T>(key, value));
                int c = Count - 1;
                while (c > 0)
                {
                    int p = (c - 1) / 2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    c = p;
                }
            }

            public KeyValuePair<long, T> Top()
            {
                return list[0];
            }

            public KeyValuePair<long, T> Dequeue()
            {
                KeyValuePair<long, T> pair = list[0];
                Count--;
                if (Count == 0) return pair;

                list[0] = list[Count];
                int p = 0;
                while (true)
                {
                    int c1 = p * 2 + 1;
                    int c2 = p * 2 + 2;
                    if (c1 >= Count) break;

                    int c = (c2 >= Count || list[c1].Key < list[c2].Key)
                        ? c1 : c2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    p = c;
                }
                return pair;
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
