using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.DP
{
    class CodeThanksFestival2017_F
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[] array = new int[n];
            for (int i = 0; i < n; i++) array[i] = ReadInt();
            var dict = new Dictionary<int,long>();
            dict.Add(0, 1);
            long mask = 1000000000 + 7;
            for(int i = 0; i < n; i++)
            {
                var next = new Dictionary<int, long>();
                foreach(int key in dict.Keys)
                {
                    if (!next.ContainsKey(key))
                    {
                        next.Add(key, 0);
                    }
                    next[key] += dict[key];
                    next[key] %= mask;

                    int val = key ^ array[i];
                    if (!next.ContainsKey(val))
                    {
                        next.Add(val, 0);
                    }
                    next[val] += dict[key];
                    next[val] %= mask;
                }
                dict = next;
            }
            if (dict.ContainsKey(k))
            {
                WriteLine(dict[k]);
            }
            else
            {
                WriteLine(0);
            }
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
