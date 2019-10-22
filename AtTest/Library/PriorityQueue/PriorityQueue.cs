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

            public KeyValuePair<long, T> Top()
            {
                return list[0];
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
    }
}