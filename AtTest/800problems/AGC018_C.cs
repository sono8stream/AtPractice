using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._800problems
{
    class AGC018_C
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
            int[] xyz = ReadInts();
            int x = xyz[0];
            int y = xyz[1];
            int z = xyz[2];
            long[][] abcs = new long[x + y + z][];
            for(int i = 0; i < x + y + z; i++)
            {
                abcs[i] = ReadLongs();
            }
            abcs = abcs.OrderBy(a => a[0] - a[1]).ToArray();

            PriorityQueue<int> silverQueue = new PriorityQueue<int>();
            PriorityQueue<int> goldQueue = new PriorityQueue<int>();
            long[] silverSums = new long[x + y + z];
            long[] brondSumsL = new long[x + y + z];
            long[] brondSumsR = new long[x + y + z];
            long[] goldSums = new long[x + y + z];

            for(int i = 0; i < y; i++)
            {
                silverQueue.Enqueue(abcs[i][1] - abcs[i][2], i);
                silverSums[i] = abcs[i][1];
                if (i > 0) silverSums[i] += silverSums[i - 1];
            }
            for(int i = y; i < y + z; i++)
            {
                silverQueue.Enqueue(abcs[i][1] - abcs[i][2], i);
                silverSums[i] = silverSums[i - 1] + abcs[i][1];
                var pair = silverQueue.Dequeue();
                silverSums[i] -= abcs[pair.Value][1];
                brondSumsL[i] = brondSumsL[i - 1] + abcs[pair.Value][2];
            }
            for(int i = x + y + z - 1; i >= y+z; i--)
            {
                goldQueue.Enqueue(abcs[i][0] - abcs[i][2], i);
                goldSums[i] = abcs[i][0];
                if (i + 1 < x + y + z) goldSums[i] += goldSums[i + 1];
            }
            for(int i = y + z - 1; i >= y; i--)
            {
                goldQueue.Enqueue(abcs[i][0] - abcs[i][2], i);
                goldSums[i] = goldSums[i + 1] + abcs[i][0];
                var pair = goldQueue.Dequeue();
                goldSums[i] -= abcs[pair.Value][0];
                brondSumsR[i] = brondSumsR[i + 1] + abcs[pair.Value][2];
            }

            long res = silverSums[y - 1] + goldSums[y]
                + brondSumsL[y - 1] + brondSumsR[y];

            for(int i = y; i < y + z; i++)
            {
                res = Max(res, silverSums[i] + goldSums[i + 1]
                    + brondSumsL[i] + brondSumsR[i + 1]);
            }

            WriteLine(res);
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
