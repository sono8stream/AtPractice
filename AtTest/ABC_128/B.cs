using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_128
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var dict = new SortedDictionary<string, SortedDictionary<int, int>>();
            for(int i = 0; i < n; i++)
            {
                string[] sp = Read().Split();
                string s = sp[0];
                int p = int.Parse(sp[1]);
                if (!dict.ContainsKey(s))
                {
                    dict.Add(s, new SortedDictionary<int, int>());
                }
                dict[s].Add(-p, i+1);
            }

            foreach(string s in dict.Keys)
            {
                foreach(int p in dict[s].Keys)
                {
                    WriteLine(dict[s][p]);
                }
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
