using System;
using System.Collections.Generic;
using System.Linq;

namespace AtTest.D_Challenge
{
    class ABC_062
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[] array = ReadLongs();
            var headSums = new long[n+1];
            headSums[0] = 0;
            var sDictH = new PriorityQueueNum<bool>();
            for(int i = 0; i < n; i++)
            {
                headSums[0] += array[i];
                sDictH.Add(array[i], true);
            }
            for(int i = 1; i <= n; i++)
            {
                headSums[i] = headSums[i - 1] + array[n + i - 1];
                sDictH.Add(array[n + i - 1],true);
                headSums[i] -= sDictH.Dequeue().Key;
            }
            var tailSums = new long[n + 1];
            tailSums[0] = 0;
            var sDictT = new PriorityQueueNum<bool>(true);
            for (int i = 0; i < n; i++)
            {
                tailSums[0] += array[3 * n - i - 1];
                sDictT.Add(array[3 * n - i - 1], true);
            }
            for (int i = 1; i <= n; i++)
            {
                tailSums[i] = tailSums[i - 1] + array[2 * n - i];
                sDictT.Add(array[2 * n - i], true);
                tailSums[i] -= sDictT.Dequeue().Key;
            }

            long res = long.MinValue;
            for(int i = 0; i <= n; i++)
            {
                res = Math.Max(res, headSums[i] - tailSums[n - i]);
            }
            Console.WriteLine(res);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles()
        {
            return Array.ConvertAll(Read().Split(), double.Parse);
        }

        public class PriorityQueueNum<TValue>
        {
            SortedDictionary<long, Queue<TValue>> dict
                = new SortedDictionary<long, Queue<TValue>>();

            public int Count { get; private set; } = 0;
            bool reverse = false;

            public PriorityQueueNum(bool reverse = false)
            {
                this.reverse = reverse;
            }

            public void Add(long key, TValue value)
            {
                if (reverse) key = -key;
                if (!dict.ContainsKey(key))
                {
                    dict[key] = new Queue<TValue>();
                }
                dict[key].Enqueue(value);
                Count++;
            }

            public KeyValuePair<long, TValue> Dequeue()
            {
                KeyValuePair<long, Queue<TValue>> queue = dict.First();
                if (queue.Value.Count <= 1)
                {
                    dict.Remove(queue.Key);
                }
                Count--;
                long key = queue.Key;
                if (reverse) key = -key;
                return new KeyValuePair<long, TValue>(
                    key, queue.Value.Dequeue());
            }
        }
    }
}
