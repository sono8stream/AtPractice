using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._1370
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
            string s = Read();
            string t = Read();
            int sOnes = 0;
            int tOnes = 0;
            for(int i = 0; i < n; i++)
            {
                if (s[i] == '1')
                {
                    sOnes++;
                }
                if (t[i] == '1')
                {
                    tOnes++;
                }
            }
            if (sOnes != tOnes)
            {
                WriteLine(-1);
                return;
            }

            List<int> nums = new List<int>();
            for(int i = 0; i < n; i++)
            {
                if (s[i] != t[i])
                {
                    nums.Add(s[i] - '0');
                }
            }

            List<int> blocks = new List<int>();
            blocks.Add(1);
            for(int i = 1; i < nums.Count; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    blocks[blocks.Count - 1]++;
                }
                else
                {
                    blocks.Add(1);
                }
            }

            var oneQue = new PriorityQueue<bool>();
            var zeroQue = new PriorityQueue<bool>();
            for(int i = 0; i < blocks.Count; i++)
            {
                if (i % 2 == 0)
                {
                    oneQue.Enqueue(-blocks[i], true);
                }
                else
                {
                    zeroQue.Enqueue(-blocks[i], true);
                }
            }

            long res = 0;
            while (oneQue.Count > 0)
            {
                int cnt = Min(oneQue.Count, zeroQue.Count);
                List<long> remainOne = new List<long>();
                List<long> remainZero = new List<long>();
                long delta = 0;
                for(int i = 0; i < cnt; i++)
                {
                    remainOne.Add(oneQue.Dequeue().Key);
                    remainZero.Add(zeroQue.Dequeue().Key);
                    if (i == cnt - 1)
                    {
                        delta = Min(-remainOne[remainOne.Count - 1], -remainZero[remainZero.Count - 1]);
                    }
                }
                for(int i = 0; i < cnt; i++)
                {
                    if (remainOne[i]+delta < 0)
                    {
                        oneQue.Enqueue(remainOne[i]+delta, true);
                    }
                    if (remainZero[i]+delta < 0)
                    {
                        zeroQue.Enqueue(remainZero[i]+delta, true);
                    }
                }
                res += delta;
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
