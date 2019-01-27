using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.EducationalDP
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nw = ReadInts();
            int n = nw[0];
            int w = nw[1];
            int[][] wvs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                wvs[i] = ReadInts();
            }
            var vDict = new Dictionary<int, long>();
            vDict.Add(0, 0);
            for (int i = 0; i < n; i++)
            {
                var nextDict = new Dictionary<int, long>();
                foreach (int key in vDict.Keys)
                {
                    if (nextDict.ContainsKey(key))
                    {
                        nextDict[key] = Math.Min(vDict[key], nextDict[key]);
                    }
                    else nextDict.Add(key, vDict[key]);
                    int next = key + wvs[i][1];
                    if (nextDict.ContainsKey(next))
                    {
                        nextDict[next] = Math.Min(
                                nextDict[next], vDict[key] + wvs[i][0]);
                    }
                    else nextDict.Add(next, vDict[key] + wvs[i][0]);
                }
                vDict = nextDict;
            }
            int max = 0;
            foreach(int key in vDict.Keys)
            {
                if (vDict[key] <= w) max = Math.Max(max, key);
            }
            Console.WriteLine(max);
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
