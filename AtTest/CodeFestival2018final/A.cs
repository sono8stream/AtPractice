using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeFestival2018final
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            var distDict = new Dictionary<int, List<int>>[n];
            for(int i = 0; i < n; i++)
            {
                distDict[i] = new Dictionary<int, List<int>>();
            }
            for (int i = 0; i < m; i++)
            {
                int[] abl = ReadInts();
                int a = abl[0] - 1;
                int b = abl[1] - 1;
                int l = abl[2];
                if (!distDict[a].ContainsKey(l))
                {
                    distDict[a].Add(l, new List<int>());
                }
                distDict[a][l].Add(b);
                if (!distDict[b].ContainsKey(l))
                {
                    distDict[b].Add(l, new List<int>());
                }
                distDict[b][l].Add(a);
            }
            long cnt = 0;
            for(int i = 0; i < n; i++)
            {
                foreach(int length in distDict[i].Keys)
                {
                    for(int j = 0; j < distDict[i][length].Count; j++)
                    {
                        int to = distDict[i][length][j];
                        if (distDict[to].ContainsKey(2540 - length))
                        {
                            if (length == 1270)
                            {
                                cnt += distDict[to][2540 - length].Count - 1;
                            }
                            else
                            {
                                cnt += distDict[to][2540 - length].Count;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(cnt/2);
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
