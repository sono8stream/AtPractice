using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_036
{
    class B
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
            long[] nk = ReadLongs();
            int n = (int)nk[0];
            long k = nk[1];
            int[] array = ReadInts();
            Dictionary<int, int> firstPos = new Dictionary<int, int>();
            Dictionary<int, int> nextPos = new Dictionary<int, int>();
            int[] nextSameIndexes = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                if (firstPos.ContainsKey(array[i]))
                {
                    firstPos[array[i]] = i;
                    nextSameIndexes[i] = nextPos[array[i]];
                    nextPos[array[i]] = i;
                }
                else
                {
                    firstPos.Add(array[i], i);
                    nextPos.Add(array[i], i);
                    nextSameIndexes[i] = i;
                }
            }
            for(int i = n - 1; i >= 0; i--)
            {
                if(nextSameIndexes[i]==i
                    && firstPos[array[i]] != i)
                {
                    nextSameIndexes[i] = firstPos[array[i]];
                }
            }


            int now = -1;
            for (int i = 0; i < n; i++)
            {
                if (nextSameIndexes[i] > i)
                {
                    i = nextSameIndexes[i];
                    continue;
                }
                now = i;
                break;
            }

            if (now == -1)
            {
                return;
            }

            List<int> firstIndexes = new List<int>();
            HashSet<int> usedIndexes = new HashSet<int>();
            while (now < n && !usedIndexes.Contains(now))
            {
                firstIndexes.Add(now);
                usedIndexes.Add(now);

                if (nextSameIndexes[now] != now)
                {
                    now = nextSameIndexes[now];
                }
                now++;
                while (now < n && nextSameIndexes[now] > now)
                {
                    now = nextSameIndexes[now];
                    now++;
                }
            }

            long period = firstIndexes.Count + 1;

            long no = (k - 1) % period;
            if (no == period - 1)
            {
                return;
            }

            List<int> res = new List<int>();
            for(int i = firstIndexes[(int)no]; i < n; i++)
            {
                if (nextSameIndexes[i] > i)
                {
                    i = nextSameIndexes[i];
                    continue;
                }
                res.Add(array[i]);
            }

            for(int i = 0; i < res.Count; i++)
            {
                Write(res[i]);
                if (i < res.Count - 1) Write(" ");
            }
        }

        class Range
        {
            public int l, r;
            public Range(int l,int r)
            {
                this.l = l;
                this.r = r;
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
