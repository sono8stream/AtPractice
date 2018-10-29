using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_060
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] nw = ReadLongs();
            var wv = new long[nw[0]][];
            for (int i = 0; i < nw[0]; i++)
            {
                wv[i] = ReadLongs();
            }

            var dict = new Dictionary<long, long>();
            dict.Add(0, 0);
            for(int i = 0; i < nw[0]; i++)
            {
                var tempDict = new Dictionary<long, long>();
                foreach(long key in dict.Keys)
                {
                    long w = key + wv[i][0];
                    long v = dict[key] + wv[i][1];
                    if (w <= nw[1])
                    {
                        tempDict.Add(w, v);
                    }
                }
                foreach(long key in tempDict.Keys)
                {
                    if (dict.ContainsKey(key))
                    {
                        if (dict[key] < tempDict[key])
                        {
                            dict[key] = tempDict[key];
                        }
                    }
                    else
                    {
                        dict.Add(key, tempDict[key]);
                    }
                }
            }

            long res = 0;
            foreach(long key in dict.Keys)
            {
                res = Math.Max(res, dict[key]);
            }
            Console.WriteLine(res);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
