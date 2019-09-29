using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_142
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            List<int>[] graph = new List<int>[n];
            List<int>[] reverse = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
                reverse[i] = new List<int>();
            }
            for(int i = 0; i < m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0]-1;
                int b = ab[1]-1;
                graph[a].Add(b);
                reverse[b].Add(a);
            }

            List<int> poses = new List<int>();
            for(int i = 0; i < n; i++)
            {
                PriorityQueue<int> queue = new PriorityQueue<int>();
                queue.Enqueue(0, i);
                long[] distances = new long[n];
                for (int j = 0; j < n; j++) distances[j] = long.MaxValue / 4;
                while (queue.Count > 0)
                {
                    var pair = queue.Dequeue();
                    long distance = pair.Key;
                    int index = pair.Value;
                    if (distances[index] <= distance)
                    {
                        if (index == i)
                        {
                            List<int> tempPoses = new List<int>();
                            do
                            {
                                tempPoses.Add(index);
                                for (int j = 0; j<reverse[index].Count; j++)
                                {
                                    int next = reverse[index][j];
                                    if (distances[next] != distance - 1) continue;
                                    index = next;
                                    distance--;
                                    break;
                                }
                            } while (index != i);
                            if (poses.Count == 0 || tempPoses.Count < poses.Count)
                            {
                                poses = tempPoses;
                            }
                            break;
                        }
                        continue;
                    }
                    distances[index] = distance;

                    for(int j = 0; j < graph[index].Count; j++)
                    {
                        int next = graph[index][j];
                        long nextDistance = distance + 1;

                        queue.Enqueue(nextDistance, next);
                    }
                }
            }
            if(poses.Count==0)            WriteLine(-1);
            else
            {
                WriteLine(poses.Count);
                for(int i = 0; i < poses.Count; i++)
                {
                    WriteLine(poses[i]+1);
                }
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
