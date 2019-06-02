using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_128
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            var array = new Event[2 * n];
            for (int i = 0; i < n; i++)
            {
                int[] stxs = ReadInts();
                stxs[0] -= stxs[2];
                stxs[1] -= stxs[2];
                array[i * 2] = new Event(stxs[0], 1, stxs[2]);
                array[i * 2 + 1] = new Event(stxs[1], 0, stxs[2]);
            }
            Array.Sort(array);

            var qs = new int[q][];
            for (int i = 0; i < q; i++)
            {
                qs[i] = new int[2] { ReadInt(), i };
            }

            int[] res = new int[q];
            var dict = new SortedDictionary<int, bool>();
            int now = 0;
            for (int i = 0; i < q; i++)
            {
                while (now < 2 * n
                    && array[now].time <= qs[i][0])
                {
                    switch (array[now].no)
                    {
                        case 1:
                            dict.Add(array[now].pos, true);
                            break;
                        case 0:
                            dict.Remove(array[now].pos);
                            break;
                    }
                    now++;
                }
                if (dict.Count > 0) res[qs[i][1]] = dict.Keys.First();
                else res[qs[i][1]] = -1;
            }

            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            for (int i = 0; i < q; i++) WriteLine(res[i]);
            Out.Flush();
        }

        struct Event : IComparable<Event>
        {
            public int time;
            public int no;
            public int pos;

            public Event(int time, int no, int pos)
            {
                this.time = time;
                this.no = no;
                this.pos = pos;
            }

            public int CompareTo(Event other)
            {
                if (time < other.time) return -1;
                if (time == other.time)
                {
                    if (no < other.no) return -1;
                    if (no == other.no) return 0;
                    else return 1;
                }
                else return 1;
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
