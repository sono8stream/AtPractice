﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC200420
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

        static void Method(string[] args)
        {
            int[] nl = ReadInts();
            int n = nl[0];
            int l = nl[1];
            int[] lengthes = new int[n];
            for(int i = 0; i < n; i++)
            {
                lengthes[i] = ReadInt();
            }

            long res = 0;
            PriorityQueue<int> que = new PriorityQueue<int>();
            for (int i = 0; i < n; i++)
            {
                if ((i == 0 && lengthes[i] > lengthes[i + 1]) ||
                    (i == n - 1 && lengthes[i] > lengthes[i - 1]) ||
                    (i > 0 && i < n - 1 && lengthes[i] > lengthes[i - 1] &&
                    lengthes[i] > lengthes[i + 1]))
                {
                    que.Enqueue(l - lengthes[i], i);
                }
            }

            while (que.Count > 0)
            {
                var pair = que.Dequeue();
                long time = pair.Key;
                int index = pair.Value;
                if (lengthes[index] == 0)
                {
                    continue;
                }
                lengthes[index] = 0;
                res = time;
                if (index > 0 && lengthes[index - 1] > 0)
                {
                    if (index - 1 == 0 ||
                        lengthes[index - 1] > lengthes[index - 2])
                    {
                        que.Enqueue(res + l - lengthes[index - 1], index - 1);
                    }
                }
                if (index < n - 1 && lengthes[index + 1] > 0)
                {
                    if(index+1==n-1||
                        lengthes[index + 1] > lengthes[index + 2])
                    {
                        que.Enqueue(res + l - lengthes[index + 1], index + 1);
                    }
                }
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
