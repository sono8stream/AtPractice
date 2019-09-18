using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class AGC014_C
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
            int[] hwk = ReadInts();
            int h = hwk[0];
            int w = hwk[1];
            int k = hwk[2];
            bool[,] map = new bool[h, w];
            int sX = 0, sY = 0;
            for(int i = 0; i < h; i++)
            {
                string s = Read();
                for(int j = 0; j < w; j++)
                {
                    if (s[j] == '#') continue;
                    if (s[j] == 'S')
                    {
                        sX = j;
                        sY = i;
                    }
                    map[i, j] = true;
                }
            }
            long[,] distances = new long[h, w];
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    distances[i, j] = long.MaxValue / 4;
                }
            }
            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };
            PriorityQueue<int[]> queue = new PriorityQueue<int[]>();
            queue.Enqueue(0,new int[2] { sX, sY });
            while (queue.Count > 0)
            {
                var pair = queue.Dequeue();
                long distance = pair.Key;
                int x = pair.Value[0];
                int y = pair.Value[1];
                if (distances[y, x] <= distance) continue;

                distances[y, x] = distance;
                for(int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];
                    if (nx < 0 || w <= nx || ny < 0 || h <= ny)
                    {
                        continue;
                    }

                    long newDistance = 0;
                    if (map[ny, nx])
                    {
                        if (distance % (2 * k) >= k)
                        {
                            newDistance = distance - distance % k + k + 1;
                        }
                        newDistance = distance + 1;
                    }
                    else
                    {
                        if (distance % (2 * k) >= k)
                        {
                            newDistance++;
                        }
                        else
                        {
                            newDistance = distance - distance % k + k + 1;
                        }
                    }
                    if (newDistance < distances[ny, nx])
                    {
                        queue.Enqueue(newDistance, new int[2] { nx, ny });
                    }
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
