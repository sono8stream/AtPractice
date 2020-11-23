using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1422
{
    class D
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
            long n = nm[0];

            int[] sf = ReadInts();
            long sx = sf[0];
            long sy = sf[1];
            long fx = sf[2];
            long fy = sf[3];

            int m = nm[1];
            if (m == 0)
            {
                WriteLine(Abs(sx - fx) + Abs(sy - fy));
                return;
            }

            int[][] warps = new int[m][];
            for(int i = 0; i < m; i++)
            {
                warps[i] = ReadInts();
            }
            int[][] xs = new int[m+1][];
            int[][] ys = new int[m+1][];
            for(int i = 0; i < m; i++)
            {
                xs[i] = new int[2] { warps[i][0], i };
                ys[i] = new int[2] { warps[i][1], i };
            }
            xs[m] = new int[2] { (int)sx, -1 };
            ys[m] = new int[2] { (int)sy, -1 };
            Array.Sort(xs, (a, b) => a[0] - b[0]);
            Array.Sort(ys, (a, b) => a[0] - b[0]);

            List<int> pressedX = new List<int>();
            List<int> pressedY = new List<int>();
            int[] xIs = new int[m];
            int[] yIs = new int[m];
            int startXI = -1;
            int startYI = -1;

            for(int i = 0; i < m+1; i++)
            {
                if (pressedX.Count == 0 || pressedX[pressedX.Count - 1] < xs[i][0])
                {
                    pressedX.Add(xs[i][0]);
                }
                if(pressedY.Count == 0 || pressedY[pressedY.Count - 1] < ys[i][0])
                {
                    pressedY.Add(ys[i][0]);
                }
                if (xs[i][1] >= 0)
                {
                    xIs[xs[i][1]] = pressedX.Count - 1;
                }
                else
                {
                    startXI = pressedX.Count - 1;
                }
                if (ys[i][1] >= 0)
                {
                    yIs[ys[i][1]] = pressedY.Count - 1;
                }
                else
                {
                    startYI = pressedY.Count - 1;
                }
            }

            List<int>[] xGraph = new List<int>[pressedX.Count];
            List<int>[] yGraph = new List<int>[pressedY.Count];
            for(int i = 0; i < pressedX.Count; i++)
            {
                xGraph[i] = new List<int>();
            }
            for(int i = 0; i < pressedY.Count; i++)
            {
                yGraph[i] = new List<int>();
            }

            for(int i = 0; i < m; i++)
            {
                int xI = xIs[i];
                int yI = yIs[i];
                xGraph[xI].Add(yI);
                yGraph[yI].Add(xI);
            }

            long[] xDists = new long[pressedX.Count];
            long[] yDists = new long[pressedY.Count];
            for (int i = 0; i < pressedX.Count; i++)
            {
                xDists[i] = long.MaxValue;
            }
            for (int i = 0; i < pressedY.Count; i++)
            {
                yDists[i] = long.MaxValue;
            }

            var que = new PriorityQueue<int[]>();
            // x : 0, y : 1
            que.Enqueue(0, new int[2] { 0, startXI });
            que.Enqueue(0, new int[2] { 1, startYI });
            while (que.Count > 0)
            {
                var pair = que.Dequeue();
                long dist = pair.Key;
                int state = pair.Value[0];
                int now = pair.Value[1];
                if (state == 0)
                {
                    if (xDists[now] <= dist)
                    {
                        continue;
                    }

                    xDists[now] = dist;
                    if (now > 0)
                    {
                        long nextDist = dist + pressedX[now] - pressedX[now - 1];
                        if (nextDist < xDists[now - 1])
                        {
                            que.Enqueue(nextDist, new int[2] { 0, now - 1 });
                        }
                    }
                    if (now + 1 < pressedX.Count)
                    {
                        long nextDist = dist + pressedX[now + 1] - pressedX[now];
                        if (nextDist < xDists[now + 1])
                        {
                            que.Enqueue(nextDist, new int[2] { 0, now + 1 });
                        }
                    }
                    for (int i = 0; i < xGraph[now].Count; i++)
                    {
                        int to = xGraph[now][i];
                        if (dist < yDists[to])
                        {
                            que.Enqueue(dist, new int[2] { 1, to });
                        }
                    }
                }
                else
                {
                    if (yDists[now] <= dist)
                    {
                        continue;
                    }

                    yDists[now] = dist;
                    if (now > 0)
                    {
                        long nextDist = dist + pressedY[now] - pressedY[now - 1];
                        if (nextDist < yDists[now - 1])
                        {
                            que.Enqueue(nextDist, new int[2] { 1, now - 1 });
                        }
                    }
                    if (now + 1 < pressedY.Count)
                    {
                        long nextDist = dist + pressedY[now + 1] - pressedY[now];
                        if (nextDist < yDists[now + 1])
                        {
                            que.Enqueue(nextDist, new int[2] { 1, now + 1 });
                        }
                    }
                    for (int i = 0; i < yGraph[now].Count; i++)
                    {
                        int to = yGraph[now][i];
                        if (dist < xDists[to])
                        {
                            que.Enqueue(dist, new int[2] { 0, to });
                        }
                    }
                }
            }

            long res = Abs(sx - fx) + Abs(sy - fy);
            for (int i = 0; i < m; i++)
            {
                long tmp = xDists[xIs[i]] + Abs(warps[i][0] - fx) + Abs(warps[i][1] - fy);
                res = Min(res, tmp);
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
