using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Otemae_2019
{
    class G
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
            int[] pqrs = ReadInts();
            int p = pqrs[0];
            int q = pqrs[1];
            int r = pqrs[2];
            int s = pqrs[3];
            int[][] tabcds = new int[m][];
            for(int i = 0; i < m; i++)
            {
                tabcds[i] = ReadInts();
            }

            List<int> xs = new List<int>();
            List<int> ys = new List<int>();
            for(int i = 0; i < m; i++)
            {
                ys.Add(tabcds[i][1]);
                ys.Add(tabcds[i][2]);
                xs.Add(tabcds[i][3]);
                xs.Add(tabcds[i][4]);
            }
            ys.Add(p);
            xs.Add(q);
            ys.Add(r);
            xs.Add(s);
            ys.Sort();
            xs.Sort();
            var xDict = new Dictionary<int, int>();
            var yDict = new Dictionary<int, int>();
            List<int> plainXs = new List<int>();
            List<int> plainYs = new List<int>();
            for(int i = 0; i < xs.Count; i++)
            {
                if (!xDict.ContainsKey(xs[i]))
                {
                    xDict.Add(xs[i], xDict.Count);
                    plainXs.Add(xs[i]);
                }
                if (!yDict.ContainsKey(ys[i]))
                {
                    yDict.Add(ys[i], yDict.Count);
                    plainYs.Add(ys[i]);
                }
            }
            int[,] yGrid = new int[yDict.Count, xDict.Count];
            int[,] xGrid = new int[yDict.Count, xDict.Count];
            for (int i = 0; i < m; i++)
            {
                int aI = yDict[tabcds[i][1]];
                int bI = yDict[tabcds[i][2]];
                int cI = xDict[tabcds[i][3]];
                int dI = xDict[tabcds[i][4]];
                if (tabcds[i][0] == 1)
                {
                    yGrid[aI, cI]++;
                    yGrid[aI, dI]++;
                    if (bI+1 < yDict.Count)
                    {
                        yGrid[bI+1, cI]--;
                        yGrid[bI+1, dI]--;
                    }
                }
                else
                {
                    xGrid[aI, cI]++;
                    xGrid[bI, cI]++;
                    if (dI + 1 < xDict.Count)
                    {
                        xGrid[aI, dI + 1]--;
                        xGrid[bI, dI + 1]--;
                    }
                }
            }
            int[,] grid =new int[yDict.Count, xDict.Count];
            for(int i = 0; i < yDict.Count; i++)
            {
                for(int j = 0; j < xDict.Count; j++)
                {
                    if (i > 0)
                    {
                        yGrid[i, j] += yGrid[i - 1, j];
                        xGrid[i, j] += xGrid[i - 1, j];
                    }
                    if (j > 0)
                    {
                        yGrid[i, j] += yGrid[i, j - 1];
                        xGrid[i, j] += xGrid[i, j - 1];
                    }
                    grid[i, j] = Min(yGrid[i, j], 1) + Min(xGrid[i, j], 1);
                }
            }

            long[,] distances = new long[yDict.Count, xDict.Count];
            for(int i = 0; i < yDict.Count; i++)
            {
                for(int j = 0; j < xDict.Count; j++)
                {
                    distances[i, j] = long.MaxValue / 2;
                }
            }
            PriorityQueue<int[]> queue = new PriorityQueue<int[]>();
            queue.Enqueue(0, new int[2] { yDict[q], xDict[p] });
            while (queue.Count > 0)
            {
                var pair = queue.Dequeue();
                long distance = pair.Key;
                int[] pos = pair.Value;
                if (distances[pos[0], pos[1]] <= distance) continue;

                distances[pos[0], pos[1]] = distance;
                if (pos[0] > 0)
                {
                    long next = distance;
                    //if()
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
