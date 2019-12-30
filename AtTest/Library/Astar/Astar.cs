using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.Astar
{
    class Astar
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
            bool[,] grid = new bool[5, 5];
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    grid[i, j] = true;
                }
            }
            grid[1, 2] = false;
            grid[2, 2] = false;
            grid[3, 1] = false;
            grid[3, 2] = false;
            List<int[]> path = AstarSearch(grid, 1, 2, 4, 4);
            for(int i = 0; i < path.Count; i++)
            {
                WriteLine(path[i][0] + "," + path[i][1]);
            }
        }

        static List<int[]> AstarSearch(bool[,] grid,int sX,int sY,int gX,int gY)
        {
            var opens = new GeneralPriorityQueue<NodeInfo>();
            opens.Enqueue(new NodeInfo(sX, sY, null, 0, Abs(gX - sX) + Abs(gY - sY)));
            var closed = new List<NodeInfo>();
            int[] dx = new int[4] { 1, 0, -1, 0 };
            int[] dy = new int[4] { 0, 1, 0, -1 };
            int h = grid.GetLength(0);
            int w = grid.GetLength(1);
            bool[,] visited = new bool[h, w];
            while (opens.Count > 0)
            {
                NodeInfo now = opens.Dequeue();
                if (visited[now.y, now.x]) continue;

                visited[now.y, now.x] = true;
                closed.Add(now);
                if (now.x == gX && now.y == gY) break;

                for(int i = 0; i < 4; i++)
                {
                    int toX = now.x + dx[i];
                    int toY = now.y + dy[i];
                    if (toX < 0 || toX >= w || toY < 0 || toY >= h) continue;
                    if (visited[toY, toX]) continue;
                    if (!grid[toY, toX]) continue;

                    int nextH = Abs(toX - gX) + Abs(toY - gY);
                    opens.Enqueue(new NodeInfo(toX, toY, now, now.c + 1, nextH));
                }
            }
            List<int[]> path = new List<int[]>();
            NodeInfo current = closed[closed.Count - 1];
            if (!(current.x == gX && current.y == gY)) return path;
            path.Add(new int[2] { current.x, current.y });
            while (current.parent != null)
            {
                current = current.parent;
                path.Add(new int[2] { current.x, current.y });
            }
            path.Reverse();
            return path;
        }

        class NodeInfo:IComparable<NodeInfo>
        {
            public int x;
            public int y;
            public NodeInfo parent;
            public int c;
            public int h;
            public int s;
            public NodeInfo(int x, int y, NodeInfo parent, int c, int h)
            {
                this.x = x;
                this.y = y;
                this.parent = parent;
                this.c = c;
                this.h = h;
                this.s = c + h;
            }

            public int CompareTo(NodeInfo other)
            {
                if (s == other.s)
                {
                    return c.CompareTo(other.c);
                }
                return s.CompareTo(other.s);
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
