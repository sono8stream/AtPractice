using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.SpeedRun002
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var dict = new Dictionary<long, HashSet<long>>();
            for(int i = 0; i < n; i++)
            {
                long[] ab = ReadLongs();
                long a = Min(ab[0], ab[1]);
                long b = Max(ab[0], ab[1]);
                if (!dict.ContainsKey(a))
                {
                    dict.Add(a, new HashSet<long>());
                }
                dict[a].Add(b);
            }

            long res = 0;
            foreach(long key in dict.Keys)
            {
                res += dict[key].Count;
            }
            WriteLine(res);
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
