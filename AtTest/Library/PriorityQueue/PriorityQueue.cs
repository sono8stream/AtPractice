using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    public class PriorityQueueTest
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            var pQueue = new PriorityQueue<long, int>();
            pQueue.Add(15, 1);
            pQueue.Add(120, 11);
            pQueue.Add(6, 14);
            pQueue.RemoveKeyValue(6, 15);
            while (pQueue.Count > 0)
            {
                var queue = pQueue.Dequeue(true);
                Console.WriteLine(queue.Key + ": " + queue.Value);
            }
        }

        public class PriorityQueue<TKey, TValue>
        {
            SortedDictionary<TKey, Dictionary<TValue, bool>> dict
                = new SortedDictionary<TKey, Dictionary<TValue, bool>>();

            public int Count { get; private set; } = 0;

            public void Add(TKey key, TValue value)
            {
                if (!dict.ContainsKey(key))
                {
                    dict[key] = new Dictionary<TValue, bool>();
                }

                dict[key].Add(value, true);
                Count++;
            }

            public KeyValuePair<TKey, TValue> Dequeue(bool reverse = false)
            {
                KeyValuePair<TKey, Dictionary<TValue, bool>> queue;
                if (reverse)
                {
                    queue = dict.Last();
                }
                else
                {
                    queue = dict.First();
                }
                if (queue.Value.Count <= 1)
                {
                    dict.Remove(queue.Key);
                }
                Count--;
                TValue val = queue.Value.First().Key;
                queue.Value.Remove(val);
                return new KeyValuePair<TKey, TValue>(
                    queue.Key, val);
            }

            public void RemoveKeyValue(TKey key, TValue val)
            {
                if (!dict.ContainsKey(key)) return;
                if (!dict[key].ContainsKey(val)) return;

                var valDict = dict[key];
                if (valDict.Count <= 1)
                {
                    dict.Remove(key);
                }
                else
                {
                    valDict.Remove(val);
                }
                Count--;
            }
        }

        public class PriorityQueue2<TKey, TValue>
        {
            SortedDictionary<TKey, Queue<TValue>> dict
                = new SortedDictionary<TKey, Queue<TValue>>();

            public int Count { get; private set; } = 0;

            public void Add(TKey key, TValue value)
            {
                if (!dict.ContainsKey(key))
                {
                    dict[key] = new Queue<TValue>();
                }

                dict[key].Enqueue(value);
                Count++;
            }

            public KeyValuePair<TKey, TValue> Dequeue(bool reverse = false)
            {
                KeyValuePair<TKey, Queue<TValue>> queue;
                if (reverse)
                {
                    queue = dict.Last();
                }
                else
                {
                    queue = dict.First();
                }
                if (queue.Value.Count <= 1)
                {
                    dict.Remove(queue.Key);
                }
                Count--;
                return new KeyValuePair<TKey, TValue>(
                    queue.Key, queue.Value.Dequeue());
            }
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