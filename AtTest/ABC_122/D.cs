using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_122
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
            int n = ReadInt();
            long mask = 1000000000 + 7;
            long[] all = new long[n];
            all[0] = 4;
            for(int i = 1; i < n; i++)
            {
                all[i] = all[i - 1] * 4;
                all[i] %= mask;
            }
            List<int> ng = new List<int>();
            for (int i = 0; i <= 4; i++)
            {
                ng.Add(i * 1000 + 132);
                ng.Add(i * 1000 + 123);
                ng.Add(i * 1000 + 312);
                if (i > 0)
                {
                    ng.Add(i * 100 + 1032);
                    ng.Add(i * 10 + 1302);
                }
            }
            var dict = new Dictionary<int, long>();
            dict.Add(1, 1);
            dict.Add(2, 1);
            dict.Add(3, 1);
            dict.Add(4, 1);
            for (int i = 1; i < n; i++)
            {
                var next = new Dictionary<int, long>();
                foreach (int key in dict.Keys)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        int val = (key % 1000)*10 + j;
                        bool isNg = false;
                        for (int k = 0; k < ng.Count; k++)
                        {
                            if (val == ng[k])
                            {
                                isNg = true;
                                break;
                            }
                        }
                        if (!isNg)
                        {
                            if (!next.ContainsKey(val))
                            {
                                next.Add(val, 0);
                            }
                            next[val] += dict[key];
                            next[val] %= mask;
                        }
                    }
                }
                dict = next;
            }
            long res = 0;
            foreach(int key in dict.Keys)
            {
                res += dict[key];
                res %= mask;
            }
            WriteLine(res);
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
