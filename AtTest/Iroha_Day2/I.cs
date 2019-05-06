using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Iroha_Day2
{
    class I
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] hwx = ReadInts();
            int h = hwx[0];
            int w = hwx[1];
            int x = hwx[2];
            int[] start = ReadInts();
            start[0]--;
            start[1]--;

            int[] goal = ReadInts();
            goal[0]--;
            goal[1]--;

            int[,] grid = new int[h, w];
            for (int i = 0; i < h; i++)
            {
                int[] row = ReadInts();
                for (int j = 0; j < w; j++)
                {
                    grid[i, j] = row[j];
                }
            }

            List<long> cs = new List<long>();
            cs.Add(0);
            cs.AddRange(ReadLongs());

            int[,] numbers = new int[h, w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    numbers[i, j] = -1;
                }
            }

            int no = 0;
            List<List<int[]>> extPoses = new List<List<int[]>>();
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (numbers[i, j] >= 0) continue;

                    extPoses.Add(new List<int[]>());
                    Queue<int[]> queue = new Queue<int[]>();
                    queue.Enqueue(new int[3] { i, j, no });
                    while (queue.Count > 0)
                    {
                        int[] val = queue.Dequeue();
                        if (numbers[val[0], val[1]] >= 0) continue;

                        numbers[val[0], val[1]] = val[2];

                        if (val[0] - 1 >= 0)
                        {
                            if (grid[i, j] == grid[val[0] - 1, val[1]])
                            {
                                queue.Enqueue(new int[3]
                                { val[0] - 1, val[1], val[2] });
                            }
                            else
                            {
                                extPoses[no].Add(new int[2]
                                { val[0]-1,val[1]});
                            }
                        }
                        if (val[1] - 1 >= 0)
                        {
                            if (grid[i, j] == grid[val[0], val[1] - 1])
                            {
                                queue.Enqueue(new int[3]
                                { val[0], val[1]-1, val[2] });
                            }
                            else
                            {
                                extPoses[no].Add(new int[2]
                                { val[0],val[1]-1});
                            }
                        }
                        if (val[0] + 1 < h)
                        {
                            if (grid[i, j] == grid[val[0] + 1, val[1]])
                            {
                                queue.Enqueue(new int[3]
                                { val[0] + 1, val[1], val[2] });
                            }
                            else
                            {
                                extPoses[no].Add(new int[2]
                                { val[0]+1,val[1]});
                            }
                        }
                        if (val[1] + 1 < w)
                        {
                            if (grid[i, j] == grid[val[0], val[1] + 1])
                            {
                                queue.Enqueue(new int[3]
                                { val[0], val[1]+1, val[2] });
                            }
                            else
                            {
                                extPoses[no].Add(new int[2]
                                { val[0],val[1]+1});
                            }
                        }
                    }
                    no++;
                }
            }

            var graph = new List<Edge>[no];
            for (int i = 0; i < no; i++) graph[i] = new List<Edge>();
            for(int i = 0; i < no; i++)
            {
                var dict = new Dictionary<int, bool>();
                for(int j = 0; j < extPoses[i].Count; j++)
                {
                    int number = numbers[
                        extPoses[i][j][0], extPoses[i][j][1]];
                    if (dict.ContainsKey(number)) continue;

                    dict.Add(number, true);
                    graph[i].Add(new Edge(number, cs[grid[
                        extPoses[i][j][0], extPoses[i][j][1]]]));
                }
            }

            int startNode = numbers[start[0], start[1]];
            int goalNode = numbers[goal[0], goal[1]];

            long maxDist = 0;
            long[] dists = Dijkstra(startNode, graph, out maxDist);
            WriteLine(dists[goalNode]);
        }

        static long[] Dijkstra(int startIndex,
            List<Edge>[] graph, out long maxDistance)
        {
            var pQueue = new PriorityQueue<int>();
            var visitFlags = new bool[graph.Length];
            var distances = new long[graph.Length];
            maxDistance = 0;

            //Initialize nodes
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = long.MaxValue;
                visitFlags[i] = false;
            }
            pQueue.Enqueue(0, startIndex);
            distances[startIndex] = 0;

            while (pQueue.Exist())
            {
                KeyValuePair<long, int> pair = pQueue.Dequeue();
                long distance = pair.Key;
                int index = pair.Value;

                if (visitFlags[index]) continue;

                //Confirm distances
                visitFlags[index] = true;
                maxDistance = Math.Max(maxDistance, distance);

                //Update priority queue
                for (int i = 0; i < graph[index].Count; i++)
                {
                    int nextIndex = graph[index][i].toIndex;
                    if (visitFlags[nextIndex]) continue;

                    long nextDistance = distance + graph[index][i].distance;
                    if (nextDistance < distances[nextIndex])
                    {
                        distances[nextIndex] = nextDistance;
                        pQueue.Enqueue(nextDistance, nextIndex);
                    }
                }
            }
            return distances;
        }

        class Edge
        {
            public int toIndex;
            public long distance;

            public Edge(int toIndex, long distance)
            {
                this.toIndex = toIndex;
                this.distance = distance;
            }
        }

        class PriorityQueue<T>
        {
            private readonly List<KeyValuePair<long, T>> list;
            private int count;

            public PriorityQueue()
            {
                list = new List<KeyValuePair<long, T>>();
                count = 0;
            }

            private void Add(KeyValuePair<long, T> pair)
            {
                if (count == list.Count)
                {
                    list.Add(pair);
                }
                else
                {
                    list[count] = pair;
                }
                count++;
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
                int c = count - 1;
                while (c > 0)
                {
                    int p = (c - 1) / 2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    c = p;
                }
            }

            public KeyValuePair<long, T> Dequeue()
            {
                KeyValuePair<long, T> pair = list[0];
                count--;
                if (count == 0) return pair;

                list[0] = list[count];
                int p = 0;
                while (true)
                {
                    int c1 = p * 2 + 1;
                    int c2 = p * 2 + 2;
                    if (c1 >= count) break;

                    int c = (c2 >= count || list[c1].Key < list[c2].Key)
                        ? c1 : c2;
                    if (list[c].Key >= list[p].Key) break;

                    Swap(p, c);
                    p = c;
                }
                return pair;
            }

            public bool Exist() { return count > 0; }
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
