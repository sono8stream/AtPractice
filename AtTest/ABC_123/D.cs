using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_123
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] xyzk = ReadInts();
            int x = xyzk[0];
            int y = xyzk[1];
            int z = xyzk[2];
            int k = xyzk[3];
            long[] aArray = ReadLongs();
            long[] bArray = ReadLongs();
            long[] cArray = ReadLongs();
            Array.Sort(aArray);
            Array.Reverse(aArray);
            Array.Sort(bArray);
            Array.Reverse(bArray);
            Array.Sort(cArray);
            Array.Reverse(cArray);
            long[] res = new long[k];
            var queue = new PriorityQueue<int[]>();
            queue.Enqueue(-(aArray[0] + bArray[0] + cArray[0]),
                new int[3] { 0, 0, 0 });
            bool[,,] used = new bool[x, y, z];
            int cnt = 0;
            while(cnt<k)
            {
                var pair = queue.Dequeue();
                long key = pair.Key;
                int[] val = pair.Value;
                if (used[val[0], val[1], val[2]]) continue;

                used[val[0], val[1], val[2]] = true;
                WriteLine(-key);
                cnt++;
                if (val[0] + 1 < x)
                {
                    long next = aArray[val[0] + 1]
                        + bArray[val[1]] + cArray[val[2]];
                    queue.Enqueue(-next,
                        new int[3] { val[0] + 1, val[1], val[2] });
                }
                if (val[1] + 1 < y)
                {
                    long next = aArray[val[0]]
                        + bArray[val[1]+1] + cArray[val[2]];
                    queue.Enqueue(-next,
                        new int[3] { val[0], val[1] + 1, val[2] });
                }
                if (val[2] + 1 < z)
                {
                    long next = aArray[val[0]]
                        + bArray[val[1]] + cArray[val[2]+1];
                    queue.Enqueue(-next,
                        new int[3] { val[0], val[1], val[2]+1 });
                }
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
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
