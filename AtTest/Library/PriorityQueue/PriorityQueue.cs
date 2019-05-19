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
            var pQueue = new PriorityQueue<int>();
            pQueue.Enqueue(120, 11);
            pQueue.Enqueue(15, 1);
            pQueue.Enqueue(6, 14);
            while (pQueue.Count > 0)
            {
                var queue = pQueue.Dequeue();
                Console.WriteLine(queue.Key + ": " + queue.Value);
            }
        }

        public class PriorityQueueRough<TKey, TValue>
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

        public class PriorityQueueRough2<TKey, TValue>
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

        class PriorityQueue<T>
        {
            private readonly List<KeyValuePair<long,T>> list;

            public int Count { get; private set; }

            public PriorityQueue()
            {
                list = new List<KeyValuePair<long, T>>();
                Count = 0;
            }

            private void Add(KeyValuePair<long,T> pair)
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
                KeyValuePair<long,T> tmp = list[a];
                list[a] = list[b];
                list[b] = tmp;
            }

            public void Enqueue(long key,T value)
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

            public KeyValuePair<long,T> Dequeue()
            {
                KeyValuePair<long,T> pair = list[0];
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
    }
}