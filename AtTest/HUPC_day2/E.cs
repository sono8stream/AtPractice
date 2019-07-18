using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HUPC_day2
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nmk = ReadInts();
            int n = nmk[0];
            int m = nmk[1];
            int k = nmk[2];
            long[] ps = ReadLongs();
            int[] cs = ReadInts();
            long[] js = ReadLongs();

            List<Edge>[] graph = new List<Edge>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < m; i++)
            {
                int[] uvt = ReadInts();
                int u = uvt[0] - 1;
                int v = uvt[1] - 1;
                long t = uvt[2];
                graph[u].Add(new Edge(v, t));
                graph[v].Add(new Edge(u, t));
            }

            long[,] distances = new long[n, 2];
            for (int i = 0; i < n; i++)
            {
                distances[i, 0] = long.MaxValue;
                distances[i, 1] = long.MaxValue;
            }

            PriorityQueue<Pos> queue = new PriorityQueue<Pos>();
            queue.Enqueue(new Pos(1000000000, 0, 0));
            while (queue.Count() > 0)
            {
                Pos posData = queue.Dequeue();
                long distance = posData.distance;
                int index = posData.index;
                int state = posData.state;
                if (distances[index, state] <= distance) continue;

                distances[index, state] = distance;
                if (state == 0)
                {
                    long nextDistance = distance - ps[index];
                    if (distances[index, 1] > nextDistance)
                    {
                        queue.Enqueue(new Pos(nextDistance, index, 1));
                    }
                }
                for (int i = 0; i < graph[index].Count; i++)
                {
                    int to = graph[index][i].to;
                    long nextDistance = distance + graph[index][i].distance;
                    if (distances[to, state] <= nextDistance) continue;

                    queue.Enqueue(new Pos(nextDistance, to, state));
                }
            }

            long[] results = new long[k];
            for (int i = 0; i < k; i++) results[i] = long.MinValue;

            for (int i = 0; i < n; i++)
            {
                int c = cs[i] - 1;
                long val = -distances[i, 0] + 1000000000
                    - distances[i, 1] + 1000000000;
                val += js[i];
                results[c] = Max(results[c], val);
            }


            var sw = new System.IO.StreamWriter(OpenStandardOutput())
            { AutoFlush = false };
            SetOut(sw);

            for (int i = 0; i < k; i++)
            {
                WriteLine(results[i]);
            }

            Out.Flush();
        }

        struct Edge
        {
            public int to;
            public long distance;

            public Edge(int to,long distance)
            {
                this.to = to;
                this.distance = distance;
            }
        }

        struct Pos :IComparable<Pos>
        {
            public long distance;
            public int index;
            public int state;

            public Pos(long distance,int index,int state)
            {
                this.distance = distance;
                this.index = index;
                this.state = state;
            }

            public int CompareTo(Pos other)
            {
                return distance.CompareTo(other.distance);
            }
        }

        public class PriorityQueue<T> where T : IComparable<T>
        {
            private List<T> data;

            public PriorityQueue()
            {
                this.data = new List<T>();
            }

            public void Enqueue(T item)
            {
                data.Add(item);
                int ci = data.Count - 1; // child index; start at end
                while (ci > 0)
                {
                    int pi = (ci - 1) / 2; // parent index
                    if (data[ci].CompareTo(data[pi]) >= 0)
                        break; // child item is larger than (or equal) parent so we're done
                    T tmp = data[ci];
                    data[ci] = data[pi];
                    data[pi] = tmp;
                    ci = pi;
                }
            }

            public T Dequeue()
            {
                // assumes pq is not empty; up to calling code
                int li = data.Count - 1; // last index (before removal)
                T frontItem = data[0];   // fetch the front
                data[0] = data[li];
                data.RemoveAt(li);

                --li; // last index (after removal)
                int pi = 0; // parent index. start at front of pq
                while (true)
                {
                    int ci = pi * 2 + 1; // left child index of parent
                    if (ci > li)
                        break;  // no children so done
                    int rc = ci + 1;     // right child
                    if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                        ci = rc;
                    if (data[pi].CompareTo(data[ci]) <= 0)
                        break; // parent is smaller than (or equal to) smallest child so done
                    T tmp = data[pi];
                    data[pi] = data[ci];
                    data[ci] = tmp; // swap parent and child
                    pi = ci;
                }
                return frontItem;
            }

            public T Peek()
            {
                T frontItem = data[0];
                return frontItem;
            }

            public int Count()
            {
                return data.Count;
            }

            public override string ToString()
            {
                string s = "";
                for (int i = 0; i < data.Count; ++i)
                    s += data[i].ToString() + " ";
                s += "count = " + data.Count;
                return s;
            }

            public bool IsConsistent()
            {
                // is the heap property true for all data?
                if (data.Count == 0)
                    return true;
                int li = data.Count - 1; // last index
                for (int pi = 0; pi < data.Count; ++pi)
                { // each parent index
                    int lci = 2 * pi + 1; // left child index
                    int rci = 2 * pi + 2; // right child index

                    if (lci <= li && data[pi].CompareTo(data[lci]) > 0)
                        return false; // if lc exists and it's greater than parent then bad.
                    if (rci <= li && data[pi].CompareTo(data[rci]) > 0)
                        return false; // check the right child too.
                }
                return true; // passed all checks
            }
            // IsConsistent
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
